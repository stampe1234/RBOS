using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GenericParsing;
using System.Windows.Forms;
using System.Data;

namespace RBOS
{
    /// <summary>
    /// This class is to be used in ManualUpdatesForm.cs.
    /// It is the first class to actually be implemented outside
    /// that form, as all the other importers in that form should
    /// have been from the start.
    /// 
    /// All the other imports in that form should be refactored to
    /// mimic this class, when this class has been completed.
    /// 
    /// *.WPF files are Wastage Products File.
    /// These are import files from Navision to RBOS
    /// and updates the waste products catalog for RBA stations.
    /// 
    /// As of version 2.01.050 and forward, this file also
    /// contains products for Forbrugsvare (consumable products)
    /// which is set by a flag Forbrugsvare.
    /// </summary>
    class ImportWPF
    {
        private List<string> FileList = null;

        #region FilesPresent
        /// <summary>
        /// Collects the .WPF files for import
        /// and returns back if any was found.
        /// </summary>
        public bool FilesPresent(string ArriveDir)
        {
            FileList = new List<string>(Directory.GetFiles(ArriveDir, "DRS*.WPF"));
            FileList.Sort();
            return FileList.Count > 0;
        }
        #endregion

        public bool ImportFiles()
        {
            if (FileList.Count <= 0)
                return false;

            db.StartTransaction();
            string CurrentFile = ""; // used if exception occurs

            try
            {
                // if we have import files, empty the table before importing
                int counter = 0;
                foreach (string file in FileList)
                {
                    if (File.Exists(file))
                        ++counter;
                }
                if (counter > 0)
                    ItemDataSet.AfskrProdDataTable.InactivateAllRecords();
                
                // import the files
                foreach (string file in FileList)
                {
                    CurrentFile = file;
                    if (File.Exists(file))
                    {
                        GenericParser parser = tools.CreateCSVParser(file, ';', true);
                        while (parser.Read())
                        {
                            int LevNr = tools.object2int(parser["Levnr"].Trim());
                            double Varenummer = tools.object2double(parser["Varenummer"].Trim());
                            string Beskrivelse = tools.object2string(parser["Beskrivelse"].Trim());
                            double Kostpris = tools.object2double(parser["Kostpris"].Trim());
                            double Salgspris = tools.object2double(parser["Salgspris"].Trim());
                            string Varegruppe = tools.object2int(parser["Varegruppe"].Trim()).ToString(); // convert to int first to strip leading 0
                            double Barcode = tools.object2double(parser["Barcode"].Trim());
                            bool GenerelVare = tools.object2bool(parser["GenerelVare"].Trim());
                            string LevKategori = tools.object2string(parser["Kategori"].Trim());
                            bool Forbrugsvare = false;
                            if (parser["Forbrugsvare"] != null)
                                Forbrugsvare = tools.object2bool(parser["Forbrugsvare"].Trim());

                            // Barcode is optional, and if it is
                            // empty or 0, we set it to Varenummer.
                            if (Barcode == 0)
                                Barcode = Varenummer;

                            if (!Forbrugsvare)
                            {
                                // AfskrProd product
                                ItemDataSet.AfskrProdDataTable.CreateOrUpdateRecord(
                                    LevNr,
                                    Varenummer,
                                    Beskrivelse,
                                    Kostpris,
                                    Salgspris,
                                    Varegruppe,
                                    Barcode,
                                    GenerelVare,
                                    LevKategori);
                            }
                            else
                            {
                                // Forbrugsvare product
                                ItemDataSet.ForbrugsvareDataTable.CreateOrUpdateRecord(
                                    LevNr,
                                    Varenummer,
                                    Beskrivelse,
                                    Kostpris,
                                    Salgspris,
                                    Varegruppe,
                                    Barcode,
                                    GenerelVare,
                                    LevKategori);
                            }
                        }

                        // file imported, delete it
                        parser.Close();
                        tools.RemoveFileWriteProtection(file);
                        File.Delete(file);
                    }
                }

                db.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                MessageBox.Show(log.WriteException(
                    "Error while importing WPF file:" + CurrentFile,
                    ex.Message, ex.StackTrace));
                return false;
            }
        }
    }
}
