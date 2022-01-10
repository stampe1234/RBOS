using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using GenericParsing;
using System.Data;

namespace RBOS
{
    class ImportKampagner
    {
        private static string LastMsg = "";

        public static void ShowDialog()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = db.GetLangString("ImportKampagner.DialogTitle");
            open.RestoreDirectory = true;
            if (open.ShowDialog() == DialogResult.OK)
            {
                ImportKampagneFile(open.FileName);
                MessageBox.Show(LastMsg);                
            }
        }

        public static bool ImportKampagneFile(string filename)
        {
            LastMsg = "";
            GenericParser parser = null;
            int CountUpdated = 0;
            try
            {
                db.StartTransaction();

                // hent items fra databasen, der har et kampagneid
                DataTable ItemsFromDBWithKampagneID = db.GetDataTable(@"
                    select Item.ItemID, Item.KampagneID
                    from (Item
                    inner join SalesPack
                    on SalesPack.ItemID = Item.ItemID)
                    where (Item.KampagneID is not null) and (Item.KampagneID <> 0)
                    ");
                // add a field to the db table, to use when marking a row for update in db
                ItemsFromDBWithKampagneID.Columns.Add("UpdateDB", typeof(bool));

                // opret en tabel til records fra filen
                DataTable ItemsFromFile = new DataTable();
                ItemsFromFile.Columns.Add("ItemID", typeof(int));
                ItemsFromFile.Columns.Add("KampagneID", typeof(int));

                // læs filen ind i denne tabel
                parser = tools.CreateCSVParser(filename, ';', false);
                parser.RowDelimiter = new char[] { '\n' };
                while (parser.Read())
                {
                    DataRow NewRow = ItemsFromFile.NewRow();
                    int ImportID = tools.object2int(parser[0].Trim());
                    int ItemID = ItemDataSet.ItemDataTable.GetItemIDFromImportID(ImportID);
                    // hvis et gyldigt ItemID er fundet og det ikke allerede er lagt ind i tabellen, lægges det ind
                    if ((ItemID > 0) && (ItemsFromFile.Select("ItemID = " + ItemID.ToString()).Length <= 0))
                    {
                        NewRow["ItemID"] = ItemID;
                        NewRow["KampagneID"] = tools.object2int(parser[1].Trim());
                        ItemsFromFile.Rows.Add(NewRow);
                    }
                }

                // dette loop gennemgår varer fra db og sammenholder med varer i filen
                foreach (DataRow RowInDB in ItemsFromDBWithKampagneID.Rows)
                {
                    /// de varer fra db, som ikke findes i filen, skal have sat
                    /// KampagneID = null opdateres i db.
                    int ItemID = tools.object2int(RowInDB["ItemID"]);
                    DataRow[] RowsInFile = ItemsFromFile.Select("ItemID = " + ItemID.ToString());
                    if (RowsInFile.Length <= 0)
                    {
                        RowInDB["KampagneID"] = DBNull.Value;
                        RowInDB["UpdateDB"] = true;
                    }

                    /// varen i db blev fundet i filen.
                    /// de varer i db, som har kampagneid forskelligt fra kampagneid i filen,
                    /// skal have opdateret kampagneid og opdateres i db.
                    else
                    {
                        int KampagneID_file = tools.object2int(RowsInFile[0]["KampagneID"]);
                        int KampagneID_db = tools.object2int(RowInDB["KampagneID"]);
                        if (KampagneID_file != KampagneID_db)
                        {
                            if (KampagneID_file > 0)
                                RowInDB["KampagneID"] = KampagneID_file;
                            else
                                RowInDB["KampagneID"] = DBNull.Value;
                            RowInDB["UpdateDB"] = true;
                        }
                    }
                }

                // de varer i filen, som ikke findes i db, skal have oprettet en record i db
                foreach (DataRow row in ItemsFromFile.Rows)
                {
                    int ItemID = tools.object2int(row["ItemID"]);
                    if (ItemsFromDBWithKampagneID.Select("ItemID = " + ItemID.ToString()).Length <= 0)
                    {
                        int KampagneID = tools.object2int(row["KampagneID"]);
                        if (KampagneID > 0)
                        {
                            DataRow NewRow = ItemsFromDBWithKampagneID.NewRow();
                            NewRow["ItemID"] = ItemID;
                            NewRow["KampagneID"] = KampagneID;
                            NewRow["UpdateDB"] = true;
                            ItemsFromDBWithKampagneID.Rows.Add(NewRow);
                        }
                    }
                }

                // gennemgå varer fra db nu, og opdatér de records, som har UpdateDB sat = true
                foreach (DataRow RowInDB in ItemsFromDBWithKampagneID.Rows)
                {
                    if (tools.object2bool(RowInDB["UpdateDB"]))
                    {
                        ++CountUpdated;
                        int ItemID = tools.object2int(RowInDB["ItemID"]);
                        int KampagneID = tools.object2int(RowInDB["KampagneID"]);
                        ItemDataSet.ItemDataTable.UpdateKampagneIDIfChanged(ItemID, KampagneID); // sætter selv UpdateStations = true på salespacks
                    }
                }

                db.CommitTransaction();
                if (CountUpdated > 0)
                {
                    LastMsg = db.GetLangString("ImportKampagner.CountUpdated") + CountUpdated.ToString();
                    return true;
                }
                else
                {
                    LastMsg = db.GetLangString("ImportKampagner.NoChanges");
                    return false;
                }
            }
            catch (Exception ex)
            {
                LastMsg = log.WriteException("ImportKampagner.ImportKampagneFile", ex.Message, ex.StackTrace);
                return false;
            }
            finally
            {
                if (db.CurrentTransaction != null)
                    db.RollbackTransaction();
                if (parser != null)
                    parser.Close();
            }
        }
    }
}
