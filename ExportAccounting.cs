using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace RBOS
{
    class ExportAccounting
    {
        #region GenerateEODFile
#if !RBA
        /// <summary>
        /// Generates the EOD file.
        /// In case of any errors and file was not generated, user is informed and false is returned.
        /// False is also returned if no regnskab is selected for the station and file is not generated.
        /// True is returned if no errors occured and file was generated.
        /// </summary>
        /// <param name="BookDate">The BookDate of the EODReconcile record.</param>
        public static bool GenerateEODFile(DateTime BookDate)
        {
            // get output dir
            string dir = GetOutputDir();
            if (dir == "") return false; // no regnskab

            // lookup EODReconcile record
            DataRow rowEODReconcile = db.GetDataRow(string.Format(
                " select * from EODReconcile " +
                " where BookDate = '{0}' ",
                BookDate.Date));
            
            // check for data error
            if (rowEODReconcile == null)
                return false;

            // build path
            string path = dir + "\\" + GetSiteCodeFormatted() + "_" + FormatDate(BookDate) + ".EOD";

            // check if file already exists
            if (File.Exists(path))
            {
                // check if user wants to overwritefile or abort EOD file generation
                string msg = db.GetLangString("EODFile.OverwriteAlreadyExistingEODFile");
                if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return false; // abort file generation
            }

            // open file
            StreamWriter eodfile = new StreamWriter(path, false, Encoding.GetEncoding("iso-8859-1"));

            // write file header
            int lineno = 1;
            string header = 
                "1000" +
                GetSiteCodeFormatted() +
                FormatDate(BookDate) +
                FormatDate(DateTime.Now) +
                FormatString(Version.ExeVersion, 12, Padding.PrependedZeros) +
                (tools.object2bool(db.GetConfigString("EODFileEncrypted")) ? "E" : "N");
            eodfile.WriteLine(header);

            // write header values 1010 - 1069
            eodfile.WriteLine("1010" + Encrypt(FormatAmount(rowEODReconcile["BankDepAmount"]), ++lineno, header));
            eodfile.WriteLine("1012" + Encrypt(FormatAmount(rowEODReconcile["BankCardAmount"]), ++lineno, header));
            eodfile.WriteLine("1014" + Encrypt(FormatAmount(rowEODReconcile["ShellCardAmount"]), ++lineno, header));
            eodfile.WriteLine("1015" + Encrypt(FormatAmount(rowEODReconcile["DiscountAmount"]), ++lineno, header));
            eodfile.WriteLine("1016" + Encrypt(FormatAmount(rowEODReconcile["MiscCards"]), ++lineno, header));
            //eodfile.WriteLine("1018" + Encrypt(FormatAmount(rowEODReconcile["ManDankortSumB"]), ++lineno, header)); 20240404
            eodfile.WriteLine("1018" + Encrypt(FormatAmount(rowEODReconcile["WoltAmount"]), ++lineno, header));
            eodfile.WriteLine("1020" + Encrypt(FormatAmount(rowEODReconcile["CashDiscount"]), ++lineno, header));
            eodfile.WriteLine("1022" + Encrypt(FormatAmount(rowEODReconcile["DriveOffTotal"]), ++lineno, header));
            eodfile.WriteLine("1024" + Encrypt(FormatAmount(rowEODReconcile["LocalCredit"]), ++lineno, header));
            eodfile.WriteLine("1026" + Encrypt(FormatAmount(rowEODReconcile["LocalCreditPayin"]), ++lineno, header));
            eodfile.WriteLine("1028" + Encrypt(FormatAmount(rowEODReconcile["ForeignCurrency"]), ++lineno, header));
            eodfile.WriteLine("1030" + Encrypt(FormatAmount(rowEODReconcile["ForeignCurrency"]), ++lineno, header));
            eodfile.WriteLine("1032" + Encrypt(FormatAmount(rowEODReconcile["POSSales"]), ++lineno, header));
            eodfile.WriteLine("1034" + Encrypt(FormatAmount(rowEODReconcile["ManualSales"]), ++lineno, header));
            eodfile.WriteLine("1036" + Encrypt(FormatAmount(rowEODReconcile["Payin"]), ++lineno, header));
            eodfile.WriteLine("1038" + Encrypt(FormatAmount(rowEODReconcile["Payout"]), ++lineno, header));
            eodfile.WriteLine("1040" + Encrypt(FormatAmount(rowEODReconcile["CashOverUnder"]), ++lineno, header));
            eodfile.WriteLine("1042" + Encrypt(FormatAmount(rowEODReconcile["TotalBank"]), ++lineno, header));
            eodfile.WriteLine("1044" + Encrypt(FormatAmount(rowEODReconcile["TotalShell"]), ++lineno, header));
            eodfile.WriteLine("1046" + Encrypt(FormatAmount(rowEODReconcile["TotalMisc"]), ++lineno, header));
            eodfile.WriteLine("1048" + Encrypt(FormatAmount(rowEODReconcile["TotalSales"]), ++lineno, header));
            eodfile.WriteLine("1050" + Encrypt(FormatAmount(rowEODReconcile["TotalABC"]), ++lineno, header));
            eodfile.WriteLine("1052" + Encrypt(FormatAmount(rowEODReconcile["TotalD"]), ++lineno, header));
            eodfile.WriteLine("1054" + Encrypt(FormatAmount(rowEODReconcile["MoentDaglig"]), ++lineno, header));
            eodfile.WriteLine("1056" + Encrypt(FormatAmount(rowEODReconcile["MoentBank"]), ++lineno, header));

            eodfile.WriteLine("1061" + Encrypt(FormatAmount(rowEODReconcile["SafePayAmount"]), ++lineno, header));
            eodfile.WriteLine("1062" + Encrypt(FormatAmount(rowEODReconcile["SafePayAmountCurr"]), ++lineno, header));
            eodfile.WriteLine("1063" + Encrypt(FormatAmount(rowEODReconcile["ManBankDep"]), ++lineno, header));
            eodfile.WriteLine("1064" + Encrypt(FormatAmount(rowEODReconcile["OPTPrepayAmount"]), ++lineno, header));
            eodfile.WriteLine("1065" + Encrypt(FormatAmount(rowEODReconcile["TotalSafePay"]), ++lineno, header));

            eodfile.WriteLine("1066" + Encrypt(FormatAmount(rowEODReconcile["TmpAmt1"]) + rowEODReconcile["TmpAmt1Descr"], ++lineno, header));
            eodfile.WriteLine("1067" + Encrypt(FormatAmount(rowEODReconcile["TmpAmt2"]) + rowEODReconcile["TmpAmt2Descr"], ++lineno, header));
            eodfile.WriteLine("1068" + Encrypt(FormatAmount(rowEODReconcile["TmpAmt3"]) + rowEODReconcile["TmpAmt3Descr"], ++lineno, header));
            eodfile.WriteLine("1069" + Encrypt(FormatAmount(rowEODReconcile["TmpAmt4"]) + rowEODReconcile["TmpAmt4Descr"], ++lineno, header));
            DataTable table = null;

            // write details for 1010
            table = db.GetDataTable(string.Format(
                " select Description, Amount from EOD_BankDep " +
                " where BookDate = '{0}'",
                BookDate.Date));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("2000");
                eodfile.WriteLine(Encrypt(
                    "1010" +
                    FormatString(row["Description"], 25, Padding.AppendedBlanks) +
                    FormatAmount(row["Amount"]), ++lineno, header));
            }

            // write details for 1012
            table = db.GetDataTable(string.Format(
                " select MopCode, Description, Amount from EOD_BankCards " +
                " where BookDate = '{0}' ",
                BookDate.Date));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("2000");
                eodfile.WriteLine(Encrypt(
                    "1012" +
                    FormatString(row["MopCode"], 10, Padding.AppendedBlanks) +
                    FormatString(row["Description"], 25, Padding.AppendedBlanks) +
                    FormatAmount(row["Amount"]), ++lineno, header));
            }

            // write details for 1014
            table = db.GetDataTable(string.Format(
                " select MopCode, Description, Amount from EOD_ShellCards " +
                " where BookDate = '{0}'",
                BookDate.Date));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("2000");
                eodfile.WriteLine(Encrypt(
                    "1014" +
                    FormatString(row["MopCode"], 10, Padding.AppendedBlanks) +
                    FormatString(row["Description"], 25, Padding.AppendedBlanks) +
                    FormatAmount(row["Amount"]), ++lineno, header));
            }

            // write details for 1015 (discounts)
            table = db.GetDataTable(string.Format(
                " select MopCode, Description, Amount from EOD_Discounts " +
                " where BookDate = '{0}' ",
                BookDate.Date));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("2000");
                eodfile.WriteLine(Encrypt(
                    "1015" +
                    FormatString(row["MopCode"], 30, Padding.AppendedBlanks) +
                    FormatString(row["Description"], 25, Padding.AppendedBlanks) +
                    FormatAmount(row["Amount"]), ++lineno, header));
            }

            // write details for 1024
            table = db.GetDataTable(string.Format(
                " select cred.CustomerNo, deb.Name1, cred.Remark, cred.Amount, deb.RRNumber, deb.Employee " +
                " from EOD_LocalCred cred " +
                " inner join EOD_Debtor deb " +
                " on cred.CustomerNo = deb.DebtorNo " +
                " where (BookDate = '{0}') and TransType = {1} ",
                BookDate.Date, (int)TransTypeLocalCred.LocalCredit));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("2000");
                eodfile.WriteLine(Encrypt(
                    "1024" +
                    FormatCustNo(row["CustomerNo"]) +
                    FormatString(row["Name1"], 25, Padding.AppendedBlanks) +
                    FormatString(row["Remark"], 25, Padding.AppendedBlanks) +
                    FormatAmount(row["Amount"]) +
                    FormatString(row["RRNumber"], 20, Padding.AppendedBlanks) +
                    FormatBoolean(row["Employee"]), ++lineno, header));
            }

            // write details for 1026
            table = db.GetDataTable(string.Format(
                " select cred.CustomerNo, deb.Name1, cred.Remark, cred.Amount, deb.RRNumber, deb.Employee " +
                " from EOD_LocalCred cred " +
                " inner join EOD_Debtor deb " +
                " on cred.CustomerNo = deb.DebtorNo " +
                " where (BookDate = '{0}') and TransType = {1} ",
                BookDate.Date, (int)TransTypeLocalCred.LocalCreditPayin));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("2000");
                eodfile.WriteLine(Encrypt(
                    "1026" +
                    FormatCustNo(row["CustomerNo"]) +
                    FormatString(row["Name1"], 25, Padding.AppendedBlanks) +
                    FormatString(row["Remark"], 25, Padding.AppendedBlanks) +
                    FormatAmount(row["Amount"]) +
                    FormatString(row["RRNumber"], 20, Padding.AppendedBlanks) +
                    FormatBoolean(row["Employee"]), ++lineno, header));
            }

#if DETAIL
            // write details for 1030 (DETAIL version has detail data for valuta)
            table = db.GetDataTable(string.Format(@"
                select * from EOD_DETAIL_Valuta
                where BookDate = cdate('{0}')
                order by LineNo
                ", BookDate.Date));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("2000");
                eodfile.WriteLine(Encrypt(
                    "1030" +
                    FormatValutaISOkode(row["ValutaISOkode"]) +
                    FormatString(row["Valuta"], 3, Padding.AppendedBlanks) +
                    FormatAmount(row["Valutabeloeb"]) +
                    FormatAmount(row["BeloebDKK"]), ++lineno, header));
            }
#endif

            // write details for 1032
            table = db.GetDataTable(string.Format(
                " select SubCategory, NumberOf, Amount from EOD_Sales " +
                " where (BookDate = '{0}') and TransType = {1} ",
                BookDate.Date, (int)TransTypeSales.POSSales));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("2000");
                eodfile.WriteLine(Encrypt(
                    "1032" +
                    FormatString(row["SubCategory"], 20, Padding.PrependedZeros) +
                    FormatNumberOf2(row["NumberOf"]) +
                    FormatAmount(row["Amount"]), ++lineno, header));
            }

            // write details for 1034
            table = db.GetDataTable(string.Format(
                " select SubCategory,SubCatDesc, NumberOf, Amount from EOD_Sales " +
                " where (BookDate = '{0}') and TransType = {1} ",
                BookDate.Date, (int)TransTypeSales.ManualSales));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("2000");
                eodfile.WriteLine(Encrypt(
                    "1034" +
                    FormatString(row["SubCategory"], 20, Padding.PrependedZeros) +
                    FormatNumberOf(row["NumberOf"]) +
                    FormatAmount(row["Amount"]) + FormatString(row["SubCatDesc"], 50, Padding.AppendedBlanks), ++lineno, header));
            }

            // write details for 1036
            table = db.GetDataTable(string.Format(
                " select Description, Amount from EOD_PayinPayout " +
                " where (BookDate = '{0}') and TransType = {1} ",
                BookDate.Date, (int)TransTypePayinPayout.Payin));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("2000");
                eodfile.WriteLine(Encrypt(
                    "1036" +
                    FormatString(row["Description"], 25, Padding.AppendedBlanks) +
                    FormatAmount(row["Amount"]), ++lineno, header));
            }

            // write details for 1038
            table = db.GetDataTable(string.Format(
                " select Description, Amount from EOD_PayinPayout " +
                " where (BookDate = '{0}') and TransType = {1} ",
                BookDate.Date, (int)TransTypePayinPayout.Payout));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("2000");
                eodfile.WriteLine(Encrypt(
                    "1038" +
                    FormatString(row["Description"], 25, Padding.AppendedBlanks) +
                    FormatAmount(row["Amount"]), ++lineno, header));
            }

            // write 3000 (afskrivninger)
            table = db.GetDataTable(string.Format(
                " select " +
                "   ItemTransaction.TransactionNumber, " +
                "   Item.SubCategory, " +
                "   sum(ItemTransaction.NumberOf) as NumberOf, " +
                "   sum(ItemTransaction.Amount) as Amount" +
                " from ItemTransaction " +
                " inner join Item " +
                " on ItemTransaction.ItemID = Item.ItemID " +
                " where (ItemTransaction.PostingDate <= '{0}') " +
                " and (ItemTransaction.Exported <> 1) " +
                " and (ItemTransaction.TransactionType = {1}) " +
                " group by ItemTransaction.TransactionNumber, Item.SubCategory ",
                BookDate.Date, (int)db.TransactionTypes.Waste));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("3000");
                eodfile.WriteLine(Encrypt(
                    FormatString(row["SubCategory"], 20, Padding.PrependedZeros) +
                    FormatNumberOf(row["NumberOf"]) +
                    FormatAmount(row["Amount"]), ++lineno, header));

                // while we are looping the in-memory data,
                // set the Exported flag on disk
                db.ExecuteNonQuery(string.Format(
                    " update ItemTransaction " +
                    " set Exported = 1 " +
                    " where TransactionNumber = {0} ",
                    row["TransactionNumber"]));
            }

            // write 4000 (pejletal)
            table = db.GetDataTable(string.Format(
                " select TankID, FuelProductID, ReadingVolume " +
                " from Import_RPOS_TPM_Details " +
                " where BookDate = '{0}' ",
                BookDate.Date));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("4000");
                eodfile.WriteLine(Encrypt(
                    FormatNumberID(row["TankID"]) +
                    FormatNumberID(row["FuelProductID"]) +
                    FormatNumberOf(row["ReadingVolume"]), ++lineno, header));
            }

            // write 7400 1010 (safepay: overførsel af mønt til safepay)
            table = db.GetDataTable(string.Format(@"
                select * from EOD_SafePay_OverfoerselTilSP
                where BookDate = '{0}'
                ", BookDate.Date));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("7400");
                eodfile.Write("1010");
                eodfile.WriteLine(Encrypt(
                    FormatKassenr(row["Kassenr"]) +
                    FormatTime(row["Tid"]) +
                    FormatNumberOf(row["Antal"]) +
                    FormatAmount(row["Beloeb"]), ++lineno, header));
            }

            // write 7400 1020 (safepay: udbetalinger)
            table = db.GetDataTable(string.Format(@"
                select * from EOD_SafePay_Udbetalinger
                where BookDate = '{0}'
                ", BookDate.Date));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("7400");
                eodfile.Write("1020");
                eodfile.WriteLine(Encrypt(
                    FormatKassenr(row["Kassenr"]) +
                    FormatTime(row["Tid"]) +
                    FormatNumberOf(row["Antal"]) +
                    FormatAmount(row["Beloeb"]) +
                    FormatString(row["Beskrivelse"], 25, Padding.AppendedBlanks), ++lineno, header));
            }

            // write 7400 1030 (safepay: indbetalinger)
            table = db.GetDataTable(string.Format(@"
                select * from EOD_SafePay_Indbetalinger
                where BookDate = '{0}'
                ", BookDate.Date));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("7400");
                eodfile.Write("1030");
                eodfile.WriteLine(Encrypt(
                    FormatKassenr(row["Kassenr"]) +
                    FormatTime(row["Tid"]) +
                    FormatNumberOf(row["Antal"]) +
                    FormatAmount(row["Beloeb"]) +
                    FormatString(row["Beskrivelse"], 25, Padding.AppendedBlanks), ++lineno, header));
            }

            // write 7400 1040 (safepay: byttepenge optalt)
            eodfile.Write("7400");
            eodfile.Write("1040");
            eodfile.WriteLine(Encrypt(FormatAmount(rowEODReconcile["SafePay_ByttepengeOptalt"]), ++lineno, header));

            // write 7400 1050 (safepay: tilført byttepenge fra Lomis)
            eodfile.Write("7400");
            eodfile.Write("1050");
            eodfile.WriteLine(Encrypt(FormatAmount(rowEODReconcile["SafePay_TilfoertByttepengeFraLomis"]), ++lineno, header));

            // write 7400 1060 (safepay: beløb tilført SafePay dobbelt)
            eodfile.Write("7400");
            eodfile.Write("1060");
            eodfile.WriteLine(Encrypt(FormatAmount(rowEODReconcile["SafePay_BeloebTilfoertDobbelt"]), ++lineno, header));

            // write 7400 1070 (safepay: depotbeholdning)
            table = db.GetDataTable(string.Format(@"
                select * from EOD_SafePay_Depotbeholdning
                where BookDate = '{0}'
                ", BookDate.Date));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("7400");
                eodfile.Write("1070");
                eodfile.WriteLine(Encrypt(
                    FormatEnhedsnummer(row["Enhedsnummer"]) +
                    FormatAmount(row["ValutaBeloeb"]) +
                    FormatValutaISOkode(row["ValutaISOkode"]) +
                    FormatAmount(row["DKKBeloeb"]), ++lineno, header));
            }

            // write 7400 1080 (valutakurs EURO)
            eodfile.Write("7400");
            eodfile.Write("1080");
            eodfile.WriteLine(Encrypt(FormatValutaKurs(
                EODDataSet.EOD_SafePay_ValutakurserDataTable.GetValutakurs(
                EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.EURO)), ++lineno, header));

            // write 7400 1081 (valutakurs NOK)
            eodfile.Write("7400");
            eodfile.Write("1081");
            eodfile.WriteLine(Encrypt(FormatValutaKurs(
                EODDataSet.EOD_SafePay_ValutakurserDataTable.GetValutakurs(
                EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.NOK)), ++lineno, header));

            // write 7400 1082 (valutakurs SEK)
            eodfile.Write("7400");
            eodfile.Write("1082");
            eodfile.WriteLine(Encrypt(FormatValutaKurs(
                EODDataSet.EOD_SafePay_ValutakurserDataTable.GetValutakurs(
                EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.SEK)), ++lineno, header));

            // close file
            eodfile.Close();

            // file was generated
            return true;
        }
#endif
        #endregion

        #region GenerateOPTFile
        /// <summary>
        /// Generates OPT file from the data given in Table.
        /// </summary>
        public static bool GenerateOPTFile(ReportDataSet.OnHandReportDataTable Table, DateTime DateTimeFrom, DateTime DateTimeTo)
        {
            // get output dir
            string dir = GetOutputDir();
            if (dir == "") return false; // no regnskab

            // build path
            string path = dir + "\\" + GetSiteCodeFormatted() + "_" + FormatDate(DateTimeTo) + ".OPT";

            // check if file already exists
            if (File.Exists(path))
            {
                // check if user wants to overwrite file or abort OPT file generation
                string msg = db.GetLangString("OPTFile.OverwriteAlreadyExistingOPTFile");
                if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return false; // abort file generation
            }

            // open file
            StreamWriter optfile = new StreamWriter(path, false, tools.Encoding());

            // write file header
            int lineno = 1;
            string header =
                "1000" +
                GetSiteCodeFormatted() +
                FormatDate(DateTimeFrom) +
                FormatDate(DateTimeTo) +
                FormatString(Version.ExeVersion, 12, Padding.PrependedZeros) +
                (tools.object2bool(db.GetConfigString("EODFileEncrypted")) ? "E" : "N");
            optfile.WriteLine(header);

            // build list of subcategories in the incoming table (has item data)
            List<string> listSubCategoryID = new List<string>();
            foreach (DataRow row in Table.Rows)
            {
                string SubCategoryID = tools.object2string(row["SubCategory"]);
                if (!listSubCategoryID.Contains(SubCategoryID))
                    listSubCategoryID.Add(SubCategoryID);
            }

            // write data records
            foreach (string SubCategoryID in listSubCategoryID)
            {
                // select item records for this subcategory
                DataRow[] rows = Table.Select("SubCategory = " + SubCategoryID);
                if (rows.Length > 0)
                {
                    // sum the StockValueExVAT field for this subcategory
                    double StockValueExVAT = 0;
                    foreach(DataRow row in rows)
                        StockValueExVAT += tools.object2double(row["StockValueExVAT"]);

                    // output totals per subcategory
                    optfile.Write("1010");
                    optfile.WriteLine(Encrypt(
                        FormatDate(DateTimeTo) +
                        FormatString(SubCategoryID, 20, Padding.PrependedZeros) +
                        FormatAmount(StockValueExVAT), ++lineno, header));
                }
            }

            // close file
            optfile.Close();

            // file was generated
            return true;
        }
        #endregion
    

        #region GenerateOPTFileRBA
        /// <summary>
        /// Generates OPT file from the data given in Table.
        /// </summary>
        public static bool GenerateOPTFileRBA(DateTime UltimoDate)
        {
            UltimoDate = UltimoDate.Date;

            // get output dir
            string dir = GetOutputDir();
            if (dir == "") return false; // no regnskab

            // build path
            string path = dir + "\\" + GetSiteCodeFormatted() + "_" + FormatDate(UltimoDate) + ".OPT";

            // check if file already exists
            if (File.Exists(path))
            {
                // check if user wants to overwrite file or abort OPT file generation
                string msg = db.GetLangString("OPTFile.OverwriteAlreadyExistingOPTFile");
                if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return false; // abort file generation
            }

            // open file
            StreamWriter optfile = new StreamWriter(path, false, tools.Encoding());

            // get the primo date of the month that UltimoDate falls in
            DateTime PrimoDate = tools.GetFirstDateInMonth(UltimoDate);

            // write file header
            int lineno = 1;
            string header =
                "1000" +
                GetSiteCodeFormatted() +
                FormatDate(PrimoDate) +
                FormatDate(UltimoDate) +
                FormatString(Version.ExeVersion, 12, Padding.PrependedZeros) +
                (tools.object2bool(db.GetConfigString("EODFileEncrypted")) ? "E" : "N");
            optfile.WriteLine(header);

            // create datatable
            DataTable table = new DataTable();
            table.Columns.Add("Varegruppe", typeof(string));
            table.Columns.Add("Amount", typeof(double));

            // load data (totals per subcategory)
            using (OleDbConnection conn = new OleDbConnection(db.ConnectionString))
            {
                string sql = @"
                    select Varegruppe, sum(Amount) as Amount
                    from ItemTransactionStockCountRBA
                    where UltimoDate = ?
                    group by Varegruppe
                    ";
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.Parameters.Add("UltimoDate", OleDbType.Date).Value = UltimoDate;
                    conn.Open();
                    db.FillDataTable(cmd, table, true);
                }
            }

            // output data to file
            foreach (DataRow row in table.Rows)
            {
                string Varegruppe = tools.object2string(row["Varegruppe"]);
                double Amount = tools.object2double(row["Amount"]);

                optfile.Write("1010");
                optfile.WriteLine(Encrypt(
                    FormatDate(UltimoDate) +
                    FormatString(Varegruppe, 20, Padding.PrependedZeros) +
                    FormatAmount(Amount),
                    ++lineno, header));
            }

            // close file
            optfile.Close();

            // file was generated
            return true;
        }
        #endregion

        #region GenerateOPGFile
#if RBA
        /// <summary>
        /// Generates the OPG file for RBA stations.
        /// In case of any errors and file was not generated, user is informed and false is returned.
        /// True is returned if no errors occured and file was generated.
        /// </summary>
        /// <param name="BookDate">The BookDate of the EODReconcile record.</param>
        public static bool GenerateOPGFile(DateTime BookDate)
        {
            // make sure service is set
            if (db.GetConfigString("RegnskabIF_flag") != "service")
                db.SetConfigString("RegnskabIF_flag", "service");

            // get output dir
            string dir = GetOutputDir();
            if (dir == "") return false; // no regnskab

            // lookup EODReconcile record
            DataRow rowEODReconcile = db.GetDataRow(string.Format(
                " select * from EODReconcile " +
                " where BookDate = cdate('{0}') ",
                BookDate));

            // check for data error
            if (rowEODReconcile == null)
                return false;

            // build path
            string path = dir + "\\" + GetSiteCodeFormatted() + "_" + FormatDate(BookDate) + ".OPG";

            // check if file already exists
            if (File.Exists(path))
            {
                // check if user wants to overwritefile or abort OPG file generation
                string msg = db.GetLangString("EODFile.OverwriteAlreadyExistingOPGFile");
                if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return false; // abort file generation
            }

            // open file
            StreamWriter eodfile = new StreamWriter(path, false, Encoding.GetEncoding("iso-8859-1"));

            // write file header
            int lineno = 1;
            string header =
                "1000" +
                GetSiteCodeFormatted() +
                FormatDate(BookDate) +
                FormatDate(DateTime.Now) +
                FormatString(Version.ExeVersion, 12, Padding.PrependedZeros) +
                (tools.object2bool(db.GetConfigString("EODFileEncrypted")) ? "E" : "N");
            eodfile.WriteLine(header);

            // write header values 1010 - 1054
            eodfile.WriteLine("1010" + Encrypt(FormatAmount(rowEODReconcile["BankDepAmount"]), ++lineno, header));
            eodfile.WriteLine("1018" + Encrypt(FormatAmount(rowEODReconcile["ManDankortSumB"]), ++lineno, header));
            eodfile.WriteLine("1020" + Encrypt(FormatAmount(rowEODReconcile["CashDiscount"]), ++lineno, header));
            eodfile.WriteLine("1022" + Encrypt(FormatAmount(rowEODReconcile["ReserveTerminal"]), ++lineno, header));
            eodfile.WriteLine("1024" + Encrypt(FormatAmount(rowEODReconcile["LocalCredit"]), ++lineno, header));
            eodfile.WriteLine("1026" + Encrypt(FormatAmount(rowEODReconcile["LocalCreditPayin"]), ++lineno, header));
            eodfile.WriteLine("1028" + Encrypt(FormatAmount(rowEODReconcile["ForeignCurrency"]), ++lineno, header));
            eodfile.WriteLine("1036" + Encrypt(FormatAmount(rowEODReconcile["Payin"]), ++lineno, header));
            eodfile.WriteLine("1038" + Encrypt(FormatAmount(rowEODReconcile["Payout"]), ++lineno, header));
            eodfile.WriteLine("1054" + Encrypt(FormatNumberOf(rowEODReconcile["NumberOfWashSold"]), ++lineno, header));

            DataTable table = null;
            string sql = "";

            // write details for 1010
            table = db.GetDataTable(string.Format(
                " select Description, Amount from EOD_BankDep " +
                " where BookDate = cdate('{0}') ",
                BookDate));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("2000");
                eodfile.WriteLine(Encrypt(
                    "1010" +
                    FormatString(row["Description"], 25, Padding.AppendedBlanks) +
                    FormatAmount(row["Amount"]), ++lineno, header));
            }

            // write details for 1018
            table = db.GetDataTable(string.Format(
                " select Description, Amount from EOD_ManualCards " +
                " where BookDate = cdate('{0}') ",
                BookDate));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("2000");
                eodfile.WriteLine(Encrypt(
                    "1018" +
                    FormatString(row["Description"], 25, Padding.AppendedBlanks) +
                    FormatAmount(row["Amount"]), ++lineno, header));
            }

            // write details for 1022
            table = db.GetDataTable(string.Format(
                " select Description, Amount from EOD_ReserveTerminal " +
                " where BookDate = cdate('{0}') ",
                BookDate));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("2000");
                eodfile.WriteLine(Encrypt(
                    "1022" +
                    FormatString(row["Description"], 25, Padding.AppendedBlanks) +
                    FormatAmount(row["Amount"]), ++lineno, header));
            }

            // write details for 1024
            table = db.GetDataTable(string.Format(
                " select cred.CustomerNo, deb.Name1, cred.Remark, cred.Amount, deb.RRNumber, deb.Employee " +
                " from EOD_LocalCred cred " +
                " inner join EOD_Debtor deb " +
                " on cred.CustomerNo = deb.DebtorNo " +
                " where (BookDate = cdate('{0}')) and TransType = {1} ",
                BookDate, (int)TransTypeLocalCred.LocalCredit));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("2000");
                eodfile.WriteLine(Encrypt(
                    "1024" +
                    FormatCustNo(row["CustomerNo"]) +
                    FormatString(row["Name1"], 25, Padding.AppendedBlanks) +
                    FormatString(row["Remark"], 25, Padding.AppendedBlanks) +
                    FormatAmount(row["Amount"]) +
                    FormatString(row["RRNumber"], 20, Padding.AppendedBlanks) +
                    FormatBoolean(row["Employee"]), ++lineno, header));
            }

            // write details for 1026
            table = db.GetDataTable(string.Format(
                " select cred.CustomerNo, deb.Name1, cred.Remark, cred.Amount, deb.RRNumber, deb.Employee " +
                " from EOD_LocalCred cred " +
                " inner join EOD_Debtor deb " +
                " on cred.CustomerNo = deb.DebtorNo " +
                " where (BookDate = cdate('{0}')) and TransType = {1} ",
                BookDate, (int)TransTypeLocalCred.LocalCreditPayin));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("2000");
                eodfile.WriteLine(Encrypt(
                    "1026" +
                    FormatCustNo(row["CustomerNo"]) +
                    FormatString(row["Name1"], 25, Padding.AppendedBlanks) +
                    FormatString(row["Remark"], 25, Padding.AppendedBlanks) +
                    FormatAmount(row["Amount"]) +
                    FormatString(row["RRNumber"], 20, Padding.AppendedBlanks) +
                    FormatBoolean(row["Employee"]), ++lineno, header));
            }

            // write details for 1028
            table = db.GetDataTable(string.Format(
                " select Description, Amount from EOD_ForeignCurrency " +
                " where BookDate = cdate('{0}') ",
                BookDate));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("2000");
                eodfile.WriteLine(Encrypt(
                    "1028" +
                    FormatString(row["Description"], 25, Padding.AppendedBlanks) +
                    FormatAmount(row["Amount"]), ++lineno, header));
            }

            // write details for 1036
            table = db.GetDataTable(string.Format(
                " select Description, Amount from EOD_PayinPayout " +
                " where (BookDate = cdate('{0}')) and TransType = {1} ",
                BookDate, (int)TransTypePayinPayout.Payin));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("2000");
                eodfile.WriteLine(Encrypt(
                    "1036" +
                    FormatString(row["Description"], 25, Padding.AppendedBlanks) +
                    FormatAmount(row["Amount"]), ++lineno, header));
            }

            // write details for 1038
            table = db.GetDataTable(string.Format(
                " select Description, Amount from EOD_PayinPayout " +
                " where (BookDate = cdate('{0}')) and TransType = {1} ",
                BookDate, (int)TransTypePayinPayout.Payout));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("2000");
                eodfile.WriteLine(Encrypt(
                    "1038" +
                    FormatString(row["Description"], 25, Padding.AppendedBlanks) +
                    FormatAmount(row["Amount"]), ++lineno, header));
            }

            // write 3000 (afskrivninger)
            table = db.GetDataTable(string.Format(@"
                select
                  AfskrProd.Varegruppe,
                  sum(ItemTransactionRBA.NumberOf) as NumberOf,
                  sum(ItemTransactionRBA.Amount) as Amount
                from ItemTransactionRBA
                inner join AfskrProd
                  on ItemTransactionRBA.LevNr = AfskrProd.LevNr
                  and ItemTransactionRBA.Varenummer = AfskrProd.Varenummer
                where (ItemTransactionRBA.PostingDate = cdate('{0}'))
                group by AfskrProd.Varegruppe
            ",
                BookDate));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("3000");
                eodfile.WriteLine(Encrypt(
                    FormatString(row["Varegruppe"], 20, Padding.PrependedZeros) +
                    FormatNumberOf(row["NumberOf"]) +
                    FormatAmount(row["Amount"]), ++lineno, header));
            }

            // write 8000 (afskrivninger details)
            table = db.GetDataTable(string.Format(
                " select " +
                " ItemTransactionRBA.LevNr, " +
                " ItemTransactionRBA.Varenummer, " +
                " ItemTransactionRBA.Varenavn, " +
                " AfskrProd.Varegruppe, " +
                " ItemTransactionRBA.NumberOf, " +
                " ItemTransactionRBA.Amount " +
                " from ItemTransactionRBA " +
                " inner join AfskrProd " +
                " on ItemTransactionRBA.LevNr = AfskrProd.LevNr " +
                " and ItemTransactionRBA.Varenummer = AfskrProd.Varenummer " +
                " where ItemTransactionRBA.PostingDate = cdate('{0}') ",
                BookDate));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("8000");
                eodfile.WriteLine(Encrypt(
                    FormatItemNo(row["Varenummer"]) +
                    FormatNumberID(row["LevNr"]) +
                    FormatString(row["Varenavn"], 25, Padding.AppendedBlanks) +
                    FormatString(row["Varegruppe"], 20, Padding.PrependedZeros) +
                    FormatNumberOf(row["NumberOf"]) +
                    FormatAmount(row["Amount"]), ++lineno, header));
            }

            // write 3050 (forbrugsvarer)
            sql = @"
                select
                  Forbrugsvare.Varegruppe,
                  sum(ItemTransactionForbrugsvare.NumberOf) as NumberOf,
                  sum(ItemTransactionForbrugsvare.Amount) as Amount
                from ItemTransactionForbrugsvare
                inner join Forbrugsvare
                  on ItemTransactionForbrugsvare.LevNr = Forbrugsvare.LevNr
                  and ItemTransactionForbrugsvare.Varenummer = Forbrugsvare.Varenummer
                where (ItemTransactionForbrugsvare.PostingDate = ?)
                group by Forbrugsvare.Varegruppe
                ";
            using (OleDbCommand cmd = new OleDbCommand(sql, db.Connection, db.CurrentTransaction))
            {
                cmd.Parameters.Add("PostingDate", OleDbType.Date).Value = BookDate;
                table = db.GetDataTable(cmd);
            }                
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("3050");
                eodfile.WriteLine(Encrypt(
                    FormatString(row["Varegruppe"], 20, Padding.PrependedZeros) +
                    FormatNumberOf(row["NumberOf"]) +
                    FormatAmount(row["Amount"]), ++lineno, header));
            }

            // write 7400 1010 (safepay: overførsel af mønt til safepay)
            table = db.GetDataTable(string.Format(@"
                select * from EOD_SafePay_OverfoerselTilSP
                where BookDate = cdate('{0}')
                ", BookDate.Date));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("7400");
                eodfile.Write("1010");
                eodfile.WriteLine(Encrypt(
                    FormatKassenr(row["Kassenr"]) +
                    FormatTime(row["Tid"]) +
                    FormatNumberOf(row["Antal"]) +
                    FormatAmount(row["Beloeb"]), ++lineno, header));
            }

            // write 7400 1020 (safepay: udbetalinger)
            table = db.GetDataTable(string.Format(@"
                select * from EOD_SafePay_Udbetalinger
                where BookDate = cdate('{0}')
                ", BookDate.Date));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("7400");
                eodfile.Write("1020");
                eodfile.WriteLine(Encrypt(
                    FormatKassenr(row["Kassenr"]) +
                    FormatTime(row["Tid"]) +
                    FormatNumberOf(row["Antal"]) +
                    FormatAmount(row["Beloeb"]) +
                    FormatString(row["Beskrivelse"], 25, Padding.AppendedBlanks), ++lineno, header));
            }

            // write 7400 1030 (safepay: indbetalinger)
            table = db.GetDataTable(string.Format(@"
                select * from EOD_SafePay_Indbetalinger
                where BookDate = cdate('{0}')
                ", BookDate.Date));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("7400");
                eodfile.Write("1030");
                eodfile.WriteLine(Encrypt(
                    FormatKassenr(row["Kassenr"]) +
                    FormatTime(row["Tid"]) +
                    FormatNumberOf(row["Antal"]) +
                    FormatAmount(row["Beloeb"]) +
                    FormatString(row["Beskrivelse"], 25, Padding.AppendedBlanks), ++lineno, header));
            }

            // write 7400 1040 (safepay: byttepenge optalt)
            eodfile.Write("7400");
            eodfile.Write("1040");
            eodfile.WriteLine(Encrypt(FormatAmount(rowEODReconcile["SafePay_ByttepengeOptalt"]), ++lineno, header));

            // write 7400 1050 (safepay: tilført byttepenge fra Lomis)
            eodfile.Write("7400");
            eodfile.Write("1050");
            eodfile.WriteLine(Encrypt(FormatAmount(rowEODReconcile["SafePay_TilfoertByttepengeFraLomis"]), ++lineno, header));

            // write 7400 1060 (safepay: beløb tilført SafePay dobbelt)
            eodfile.Write("7400");
            eodfile.Write("1060");
            eodfile.WriteLine(Encrypt(FormatAmount(rowEODReconcile["SafePay_BeloebTilfoertDobbelt"]), ++lineno, header));

            // write 7400 1070 (safepay: depotbeholdning)
            table = db.GetDataTable(string.Format(@"
                select * from EOD_SafePay_Depotbeholdning
                where BookDate = cdate('{0}')
                ", BookDate.Date));
            foreach (DataRow row in table.Rows)
            {
                eodfile.Write("7400");
                eodfile.Write("1070");
                eodfile.WriteLine(Encrypt(
                    FormatEnhedsnummer(row["Enhedsnummer"]) +
                    FormatAmount(row["ValutaBeloeb"]) +
                    FormatValutaISOkode(row["ValutaISOkode"]) +
                    FormatAmount(row["DKKBeloeb"]), ++lineno, header));
            }

            // write 7400 1080 (valutakurs EURO)
            eodfile.Write("7400");
            eodfile.Write("1080");
            eodfile.WriteLine(Encrypt(FormatValutaKurs(
                EODDataSet.EOD_SafePay_ValutakurserDataTable.GetValutakurs(
                EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.EURO)), ++lineno, header));

            // write 7400 1081 (valutakurs NOK)
            eodfile.Write("7400");
            eodfile.Write("1081");
            eodfile.WriteLine(Encrypt(FormatValutaKurs(
                EODDataSet.EOD_SafePay_ValutakurserDataTable.GetValutakurs(
                EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.NOK)), ++lineno, header));

            // write 7400 1082 (valutakurs SEK)
            eodfile.Write("7400");
            eodfile.Write("1082");
            eodfile.WriteLine(Encrypt(FormatValutaKurs(
                EODDataSet.EOD_SafePay_ValutakurserDataTable.GetValutakurs(
                EODDataSet.EOD_SafePay_ValutakurserDataTable.ISOKode.SEK)), ++lineno, header));

            // close file
            eodfile.Close();

            // file was generated
            return true;
        }
#endif
        #endregion

        #region GetSiteCodeFormatted
        private static string GetSiteCodeFormatted()
        {
            return AdminDataSet.SiteInformationDataTable.GetSiteCode().PadLeft(4, '0');
        }
        #endregion

        #region GetOutputDir
        /// <summary>
        /// Either the output directory or "" is returned.
        /// If "" is returned, no file is to be created.
        /// </summary>
        public static string GetOutputDir()
        {
            // check the config string RegnskabIF_flag for where to place the EOD file.
            // "" = no export to Regnskab
            // "local" = use config value RegnskabIF_local_dir to export files to
            // "service" = use config value DRS_FTP_client_depart_dir to export files to
            string RegnskabIF_flag = db.GetConfigString("RegnskabIF_flag");
            if (RegnskabIF_flag == "local")
                return db.GetConfigString("RegnskabIF_local_dir");
            else if (RegnskabIF_flag == "service")
                return db.GetConfigString("DRS_FTP_client_depart_dir");
            else
                return ""; // no regnskab
        }
        #endregion

        #region FormatAmount
        private static string FormatAmount(object o)
        {
            double dAmount = tools.object2double(o);
            string sAmount = ((dAmount * 100)).ToString("00000000000");
            if (dAmount >= 0) sAmount = "+" + sAmount;
            return sAmount;
        }
        #endregion

        private static string FormatNumberOf2(object o)
        {
            double dNumberOf  = tools.object2double(o);
            string sNumberOf = ((dNumberOf * 100)).ToString("000000000");
            if (dNumberOf >= 0) sNumberOf = "+" + sNumberOf;
            return sNumberOf;
        }

        #region FormatNumberOf
        private static string FormatNumberOf(object o)
        {
            int iNumberOf = tools.object2int(o);
            string sNumberOf = iNumberOf.ToString("000000000");
            if (iNumberOf >= 0) sNumberOf = "+" + sNumberOf;
            return sNumberOf;
        }
        #endregion

        #region FormatString
        private enum Padding { PrependedZeros, AppendedBlanks }
        private static string FormatString(object o, int length, Padding padding)
        {
            string s = tools.object2string(o);
            if (s.Length > length)
                s = s.Remove(length);
            if (padding == Padding.PrependedZeros)
                return s.PadLeft(length, '0');
            else // padding == StringPadding.AppendedBlanks
                return s.PadRight(length, ' ');
        }
        #endregion

        #region FormatCustNo
        private static string FormatCustNo(object o)
        {
            return tools.object2int(o).ToString("0000000000");
        }
        #endregion

        #region FormatKassenr
        private static string FormatKassenr(object o)
        {
            return tools.object2int(o).ToString("00");
        }
        #endregion

        #region FormatEnhedsnummer
        private static string FormatEnhedsnummer(object o)
        {
            return tools.object2int(o).ToString("00");
        }
        #endregion

        #region FormatValutaISOkode
        private static string FormatValutaISOkode(object o)
        {
            return tools.object2int(o).ToString("000");
        }
        #endregion

        #region FormatValutaKurs
        private static string FormatValutaKurs(object o)
        {
            return (tools.object2double(o) * 100).ToString("0000");
        }
        #endregion

        #region FormatTime
        private static string FormatTime(object o)
        {
            if (tools.IsNullOrDBNull(o))
                return "00:00";
            TimeSpan time = tools.object2timespan(o);
            return time.Hours.ToString("00") + ":" + time.Minutes.ToString("00");
        }
        #endregion

        #region FormatNumberID
        private static string FormatNumberID(object o)
        {
            return tools.object2int(o).ToString("0000000000");
        }
        #endregion

        #region FormatItemNo
        private static string FormatItemNo(object o)
        {
            return tools.object2int(o).ToString("0000000000000");
        }
        #endregion

        #region FormatDate
        private static string FormatDate(DateTime datetime)
        {
            return datetime.ToString("yyyyMMdd");
        }
        #endregion

        #region FormatBoolean
        private static string FormatBoolean(object o)
        {
            return (tools.object2bool(o) ? "1" : "0");
        }
        #endregion

        #region Encrypt
        private static string Encrypt(string s, int lineno, string header)
        {
            if (tools.object2bool(db.GetConfigString("EODFileEncrypted")))
                return EncryptionAccounting.EncryptString(s, lineno, header);
            else
                return s;
        }
        #endregion
    }
}
