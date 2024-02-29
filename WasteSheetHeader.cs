using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class WasteSheetHeader : Form
    {
        public WasteSheetHeader()
        {
            InitializeComponent();

            // localization
            colName.HeaderText = db.GetLangString("WasteSheetHeader.colName");
            colNumDetailRecords.HeaderText = db.GetLangString("WasteSheetHeader.colNumDetailRecords");
            btnClose.Text = db.GetLangString("Application.Close");
            //   btnEdit.Text = db.GetLangString("Application.Edit");

            btnReport.Text = db.GetLangString("Application.Report");
        }

        private void LoadData()
        {
            adapterWasteSheetLookups.Connection = db.Connection;
            adapterWasteSheetLookups.Fill(dsItem.WasteSheetHeaderLookups);
            adapterWasteSheetHeader.Connection = db.Connection;
            adapterWasteSheetHeader.Fill(dsItem.WasteSheetHeader);
        }

        #region OpenDetail
        /// <summary>
        /// Opens waste details form. Creates a new header record if requested.
        /// </summary>
        /// <param name="CreateNew"></param>
        private void OpenDetail(bool CreateNew)
        {
            int ID = 0;

            if (CreateNew)
            {
                // create a new waste sheet header and get the ID
                ID = ItemDataSet.WasteSheetHeaderDataTable.CreateNewRecord();

            }
            else
            {
                // get ID of currently selected waste sheet
                if (bindingWasteSheetHeader.Current == null) return;
                DataRowView row = (DataRowView)bindingWasteSheetHeader.Current;
                ID = tools.object2int(row["ID"]);
            }

            // open details form
            if (ID > 0)
            {

                WasteSheetDetails details = new WasteSheetDetails(ID);

                if (details.ShowDialog(this) == DialogResult.OK)
                {
                    // reload data from disk and reposition on current record
                    int Pos = bindingWasteSheetHeader.Position;
                    LoadData();
                    if ((Pos >= 0) && (Pos < bindingWasteSheetHeader.Count))
                        bindingWasteSheetHeader.Position = Pos;
                }
                else
                {
                    if (CreateNew)
                    {
                        // a new header record was created and user selected cancel,
                        // so we must delete the header record
                        ItemDataSet.WasteSheetHeaderDataTable.DeleteRecord(ID);
                    }
                }
            }
        }
        #endregion

        private void Delete()
        {
            if (bindingWasteSheetHeader.Current == null) return;
            string msg = db.GetLangString("WasteSheetHeader.DeleteWasteSheet");
            if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataRowView row = (DataRowView)bindingWasteSheetHeader.Current;
                int ID = tools.object2int(row["ID"]);
                ItemDataSet.WasteSheetHeaderDataTable.DeleteRecord(ID);
                bindingWasteSheetHeader.RemoveCurrent();
            }
        }

        private void OpenReportForm()
        {
            if (bindingWasteSheetHeader.Current == null) return;
            DataRowView row = (DataRowView)bindingWasteSheetHeader.Current;
            int ID = tools.object2int(row["ID"]);
            WasteSheetRptFrm frm = new WasteSheetRptFrm(ID);
            frm.ShowDialog(this);
        }

        private void WasteSheetHeader_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eODDataSet.EODReconcile' table. You can move, or remove it, as needed.

            LoadData();
        }

        private void grid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
                OpenDetail(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            OpenDetail(true);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            OpenReportForm();
        }

        private void grid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenDetail(false);
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            //check først at alle skemaer har samme type 
            DateTime BookDate = DateTime.MinValue;

            int AntalSc = ItemDataSet.WasteSheetHeaderDataTable.ReturnSC();
            int AntalWaste = ItemDataSet.WasteSheetHeaderDataTable.ReturnWaste();
            if ((AntalSc != 0) & (AntalWaste != 0))
            {
                MessageBox.Show("Kan ikke bogføre både optælling og afskrivning");
                return;

            }
            if (AntalSc != 0)
            {
                BookSC();

            }
            if (AntalWaste != 0)
            {

                // bogføring på åbent døgn i eod 
                //lav data set med alle afskrivnings linjer
                //indsæt i itemstransactions med trans type = 3
                //dan fil 
                //udskriv rapport


                // check that no day is open, if there is, give error
                string sql = "select BookDate from EODReconcile where Closed <> 1";
                if (db.GetDataTable(sql).Rows.Count != 1)
                {
                    MessageBox.Show("intet åbent døgn");
                    return;
                }               
                // attempt to get the latest BookDate (if any)
                object oLastDate = db.ExecuteScalar(" select max(BookDate) from EODReconcile ");
                BookDate = tools.object2datetime(oLastDate);
                BookData(1, BookDate);
                
            }
            ItemDataSet.WasteSheetHeaderDataTable.ClearWasteSheetHeader();

            bindingWasteSheetHeader.EndEdit();
            adapterWasteSheetHeader.Update(dsItem.WasteSheetHeader);
            this.grid.Update();
            LoadData();
            MessageBox.Show("Bogført");
        }


        private void BookData(int type, DateTime BookDate)
        {
            // variables needed more than once
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter("", db.Connection);
            byte TransactionType = 0;
            int AdjustFactor = 0;
            DateTime PostingDate;
            string CmdTekstSelect = "";
            string CmdTekstUpdate = "Update [dbo].[WasteSheetDetails] Set Antal = 0";
            string CmdTekstUpdate2 = "Update [WasteSheetHeader] Set SC=null ,Waste= null , Book=null";


            if (type == 1)  //afskrivning
            {
                TransactionType = (byte)db.TransactionTypes.Waste;
                AdjustFactor = -1;
                CmdTekstSelect =
                "select t1.Antal,t3.ItemID,t3.PackType, t4.SubCategory  from [dbo].[WasteSheetDetails] as t1 " +
                    "join [dbo].[WasteSheetHeader] as t2 on t1.HeaderID = t2.ID  join Barcode as t3 " +
                    "on t3.Barcode = t1.Barcode join Item as t4 on t4.ItemID = t3.ItemID "
                    + "Where t2.Waste = 1 And t1.Antal <> 0";


            }

            if (type == 2) //optælling
            {
                TransactionType = (byte)db.TransactionTypes.Adjustment;
                AdjustFactor = 1;
                CmdTekstSelect =
                    "select t1.Antal,t1.DatoTid,t3.ItemID,t3.PackType, t4.SubCategory  from [dbo].[WasteSheetDetails] as t1 " +
                    "join [dbo].[WasteSheetHeader] as t2 on t1.HeaderID = t2.ID  join Barcode as t3 " +
                    "on t3.Barcode = t1.Barcode join Item as t4 on t4.ItemID = t3.ItemID "
                    + "Where t2.SC = 1 And t1.Antal <> 0"; ;
            }
            // load detail data
            DataTable tableDetails = new DataTable();
            adapter.SelectCommand.CommandText = CmdTekstSelect;
            adapter.Fill(tableDetails);

            // move adjustment data to ItemTransaction
            foreach (DataRow detailRow in tableDetails.Rows)
            {
                // get all values for the new ItemTransaction row
                int ItemID = tools.object2int(detailRow["ItemID"]);
                if (type == 1)
                {
                    PostingDate = BookDate;
                }
                else
                {
                    PostingDate = tools.object2datetime(detailRow["DatoTid"]);
                }

                int NumberOf = tools.object2int(detailRow["Antal"]);
                byte SalesPackType = tools.object2byte(detailRow["PackType"]);
                NumberOf = NumberOf * AdjustFactor;
                int NoOfSellingUnits = ItemDataSet.LookupPackTypeAmount(SalesPackType) * NumberOf;
                double Amount = ItemDataSet.SupplierItemDataTable.GetSupplierItemPackageCost(ItemID, SalesPackType);
                Amount = Amount * NumberOf;

                // write item transaction record
                ItemDataSet.ItemTransactionDataTable.WriteTransactionRecord(
                    ItemID,
                    PostingDate,
                    TransactionType,
                    NumberOf,
                    Amount,
                    SalesPackType,
                    0,
                    NoOfSellingUnits,
                    0,
                    true);
            }
            //Nulstil antal i alle wastesheet details
            db.ExecuteNonQuery(CmdTekstUpdate);
            db.ExecuteNonQuery(CmdTekstUpdate2);
        }

        private void BookSC()
        {
            // variables needed more than once
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter("", db.Connection);            
            DateTime PostingDate;
            string CmdTekstSelect = "";
            string CmdTekstUpdate = "Update [dbo].[WasteSheetDetails] Set Antal = 0";
            string CmdTekstUpdate2 = "Update [WasteSheetHeader] Set SC=null ,Waste= null , Book=null";


            // load detail data


            DataTable Headertable = new DataTable();
            adapter.SelectCommand.CommandText =
                  "select Distinct(t4.SubCategory)  from[dbo].[WasteSheetDetails] as t1 " +
                    "join[dbo].[WasteSheetHeader] as t2 on t1.HeaderID = t2.ID  join Barcode as t3 " +
                    "on t3.Barcode = t1.Barcode join Item as t4 on t4.ItemID = t3.ItemID " +
                    "Where t2.SC = 1 ";
            adapter.Fill(Headertable);          
            foreach (DataRow headerRow in Headertable.Rows)
            {

                
                CmdTekstSelect =
                   string.Format("select t1.Antal,t1.DatoTid,t3.ItemID,t3.PackType, t4.SubCategory  from [dbo].[WasteSheetDetails] as t1 " +
                   "join [dbo].[WasteSheetHeader] as t2 on t1.HeaderID = t2.ID  join Barcode as t3 " +
                   "on t3.Barcode = t1.Barcode join Item as t4 on t4.ItemID = t3.ItemID "
                   + "Where t2.SC = 1 And t4.SubCategory ={0}", tools.object2string(headerRow["SubCategory"]));
                DataTable tableDetails = new DataTable();
                adapter.SelectCommand.CommandText = CmdTekstSelect;
                adapter.Fill(tableDetails);
                // move adjustment data to ItemTransaction
                DateTime CountDate = Convert.ToDateTime(tableDetails.Compute("max([DatoTid])", String.Empty));                              
                object oLastHeaderInt = db.ExecuteScalar(" Select MAX([CountID]) from [dbo].[BHHTInvCountHeader] ");
                int HeaderId = tools.object2int(oLastHeaderInt);
                int LineNo = 0;
                HeaderId++;
                db.ExecuteNonQuery(string.Format(@"
                                        INSERT INTO [dbo].[BHHTInvCountHeader] ([CountID],[CountDate])Values({0},'{1}')", HeaderId, CountDate));


                foreach (DataRow detailRow in tableDetails.Rows)
                {

                    //lav BHHTInvCountLinjer her 
                    //kald kode på invcountworkform BuildNewinvCountW
                    //import dataset

                    // get all values for the new ItemTransaction row
                    LineNo++;
                    int ItemID = tools.object2int(detailRow["ItemID"]);

                    PostingDate = tools.object2datetime(detailRow["DatoTid"]);


                    int NumberOf = tools.object2int(detailRow["Antal"]);
                    byte SalesPackType = tools.object2byte(detailRow["PackType"]);

                    db.ExecuteNonQuery(string.Format(@"
                                        INSERT INTO[dbo].[BHHTInvCountDetails]
                                        ([CountID],[LineNo],[ItemID],[PackType],[Quantity],[TimeStmp])  VALUES                                        
                                        ({0},{1},{2},{3},{4},'{5}')", HeaderId, LineNo, ItemID, 1, NumberOf, PostingDate));



                }              
                BuildNewInvCountWorkData(HeaderId, CountDate);                
            }
            //Nulstil antal i alle wastesheet details
            db.ExecuteNonQuery(CmdTekstUpdate);
            db.ExecuteNonQuery(CmdTekstUpdate2);
        }

        private void BuildNewInvCountWorkData(int BHHTCountID, DateTime BHHTCountDate)
        {
           // ProgressForm progress = new ProgressForm(db.GetLangString("InvCountWorkForm.PrepareData"));
          //  progress.Show();

            // variables needed more than once
            OleDbCommand cmd = new OleDbCommand("", db.Connection);
            string SubCategory ="";
            #region Load BHHTInvCountDetails data

            // load BHHTInvCountDetails data
            OleDbDataAdapter adapterBHHT = new OleDbDataAdapter("", db.Connection);
            adapterBHHT.SelectCommand.CommandText = string.Format(
                " select * from BHHTInvCountDetails where CountID = {0} ",
                BHHTCountID);
            DataTable tableBHHT = new DataTable();
            adapterBHHT.Fill(tableBHHT);          
            //  progress.ProgressMax = tableBHHT.Rows.Count;
            foreach (DataRow rowBHHT in tableBHHT.Rows)
            {
                // get ItemID
                int ItemID = tools.object2int(rowBHHT["ItemID"]);              
                // get PackType
                byte PackType = tools.object2byte(rowBHHT["PackType"]);

                // get CountDateTime
                DateTime CountTime = tools.object2datetime(rowBHHT["TimeStmp"]);

                // get CountBHHT as sellingunits
                int CountBHHT = tools.object2int(rowBHHT["Quantity"]);

                CountBHHT = CountBHHT * ItemDataSet.LookupPackTypeAmount(PackType);

                // calculate start on-hand (lagerbeholdning pr. døgn start, dvs dagen før)
                int StartOnHand =
                    ItemDataSet.ItemTransactionDataTable.CalculateStock(ItemID, BHHTCountDate.AddDays(-1));


                // calculate SalesPEJ
                int SalesPEJ = ImportDataSet.BHHT_RSM_PEJSalesDataTable.CalcSumSelllingUnitSold(
                    BHHTCountID,
                    ItemID,
                    PackType,
                    CountTime);


                /// if the current item has prevously been added to the
                /// InvCountWork table, extract various values from that record.
                /// add sum them to the current values.
                OleDbDataAdapter adapter = new OleDbDataAdapter("", db.Connection);
                adapter.SelectCommand.CommandText = string.Format(
                    " select SalesPEJ, CountBHHT from InvCountWork " +
                    " where ItemID = {0} ",
                    ItemID);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    SalesPEJ += tools.object2int(row["SalesPEJ"]);
                    CountBHHT += tools.object2int(row["CountBHHT"]);
                }

                // calculate OnHandCalc
                int OnHandCalc = StartOnHand - SalesPEJ;

                // set ManCorrect to 0
                string ManCorrect = "NULL";

                // calculate CountDifference (ManCorrect is always 0 here)
                int CountDifference = CountBHHT - OnHandCalc;

                // calculate CostPrice without VAT
                double CostPrice = ItemDataSet.SupplierItemDataTable.CalcCostPriceExVAT(ItemID);

                // calculate StockValue
                double StockValue = CountBHHT * CostPrice;

                // calculate DiffValue
                double DiffValue = CountDifference * CostPrice;

                // get SubCategory
                DataRow itemRow = ItemDataSet.ItemDataTable.GetItemRecord(ItemID);
                if (itemRow != null)
                {
                    SubCategory = itemRow["SubCategory"].ToString();
                    string ItemName = itemRow["ItemName"].ToString();

                    // delete any existing InvCountWork record with the current ItemID
                    cmd.CommandText = string.Format(
                        " delete from InvCountWork " +
                        " where ItemID = {0}", ItemID);
                    cmd.ExecuteNonQuery();

                    //Pn20210114
                    ItemName = ItemName.Replace("'", "''");

                    // insert a new InvCountWork record with the above collected data
                    ItemDataSet.InvCountWorkDataTable.InsertRecord(
                        BHHTCountID,
                        BHHTCountDate,
                        ItemID,
                        CountTime,
                        CountBHHT,
                        StartOnHand,
                        SalesPEJ,
                        OnHandCalc,
                        ManCorrect,
                        CountDifference,
                        CostPrice,
                        StockValue,
                        DiffValue,
                        SubCategory,
                        ItemName);
                    
                }
                //bindingWasteSheetHeader.EndEdit();
                //adapterWasteSheetHeader.Update(dsItem.WasteSheetHeader);
                
                

            }

            #endregion

            #region Load worksheet data (collecting items for zero count)

            LoadData();
            OleDbDataAdapter adapterWSDetail = new OleDbDataAdapter("", db.Connection);
            DataTable tableWSDetail = new DataTable();
            // find out whether to get worksheet detail data
            // from table BHHTWSCatList or table BHHTWSItemList
            adapterWSDetail.SelectCommand.CommandText = string.Format(
                    " select ItemID from InvCountWork " +
                    " where BHHTCountID = {0} ",
                   BHHTCountID);

            
            adapterWSDetail.Fill(tableWSDetail);          
            // now we have a list of items
            foreach (DataRow rowItem in tableWSDetail.Rows)
                {
                    int ItemID = tools.object2int(rowItem["ItemID"]);                
                // check that this item has not already been
                // inserted in the work table
                cmd.CommandText = string.Format(
                        " select ItemID from InvCountWork " +
                        " where ItemID = {0} ",
                        ItemID);
                    object o = cmd.ExecuteScalar();
                    if ((o == null) || (o == DBNull.Value))
                    {
                        //// item has not already been insert in the work table

                        //// calculate start on-hand (lagerbeholdning pr. døgn start, dvs. dagen før)
                        //int StartOnHand =
                        //   ItemDataSet.ItemTransactionDataTable.CalculateStock(ItemID, BHHTCountDate.AddDays(-1));

                        string sql = string.Format(" select  sum(NoOfSellingUnits)   from ItemTransaction  Where  ItemTransAction.ItemID =  {0}) ", ItemID);

                        OleDbCommand cmd2 = new OleDbCommand(sql, db.Connection);
                        object o2 = cmd.ExecuteScalar();
                        int StartOnHand = tools.object2int(o2);

                    sql = string.Format(" select  sum(CountBHHT)  from InvCountWork  where ItemID = {0} ", ItemID);

                    OleDbCommand cmd3 = new OleDbCommand(sql, db.Connection);
                    object o3 = cmd.ExecuteScalar();
                    int CountBHHT =  tools.object2int(o3);

                    // calculate SalesPEJ
                    DateTime tmpTime = new DateTime(
                             BHHTCountDate.Year,
                             BHHTCountDate.Month,
                             BHHTCountDate.Day,
                             23, 59, 59);
                        int SalesPEJ = ImportDataSet.BHHT_RSM_PEJSalesDataTable.CalcSumSelllingUnitSold(
                            BHHTCountID,
                            ItemID,
                            1,
                            tmpTime);

                        // calculate OnHandCalc
                        int OnHandCalc = StartOnHand - SalesPEJ;

                        
                        //pn20210113

                        // calculate CountDifference (ManCorrect is always 0 here)
                        int CountDifference = CountBHHT - OnHandCalc;

                        // calculate CostPrice without VAT
                        double CostPrice = ItemDataSet.SupplierItemDataTable.CalcCostPriceExVAT(ItemID);

                        // calculate StockValue
                        double StockValue = CountBHHT * CostPrice;

                        // calculate DiffValue
                        double DiffValue = CountDifference * CostPrice;

                        // get SubCategory
                        DataRow itemRow = ItemDataSet.ItemDataTable.GetItemRecord(ItemID);
                        SubCategory = itemRow["SubCategory"].ToString();
                        string ItemName = itemRow["ItemName"].ToString();

                        // if OnHandCalc is 0, don't insert this Item
                        if (OnHandCalc != 0)
                        {
                            ItemDataSet.InvCountWorkDataTable.InsertRecord(
                                BHHTCountID,
                                BHHTCountDate,
                                ItemID,
                                DateTime.MinValue,
                                CountBHHT,
                                StartOnHand,
                                SalesPEJ,
                                OnHandCalc,
                                "NULL",
                                CountDifference,
                                CostPrice,
                                StockValue,
                                DiffValue,
                                SubCategory,
                                ItemName);

                        }
                    }

                   // progress.StatusText = db.GetLangString("InvCountWorkForm.CollectionItemData");
                }


            #endregion



            // refresh the GUI representation of data

            adapterInvCountWork.Connection = db.Connection; 
            adapterInvCountWork.Fill(dsItem.InvCountWork);
           
            Approve(BHHTCountID, BHHTCountDate, SubCategory);

        }

        private void Approve(int BHHTCountID, DateTime BHHTCountDate, string SubCategory)
        {
            // save pending data
            SaveData();
            
            double TotalStockValue = 0;            
            double TotalDiffValue = 0;
            string filter;
            filter = string.Format("SubCategory = '{0}'", SubCategory);
            foreach (DataRow row in dsItem.InvCountWork.Select(filter))
            {
                TotalStockValue += tools.object2double(row["StockValue"]);
                TotalDiffValue += tools.object2double(row["DiffValue"]);
            }         
            // create historik header
            int HeaderID = ItemDataSet.BookedInvCountHeaderDataTable.InsertRecord(
                BHHTCountDate,
                SubCategory,
                TotalStockValue,
                TotalDiffValue);

            if (db.GetConfigStringAsBool("StocCountFiles.Enabled"))
            {
                DateTime Timestamp = DateTime.Now;
                string TimeStampStr = Timestamp.ToString("yyyyMMddhhmmss");
                string SiteCode = AdminDataSet.SiteInformationDataTable.GetSiteCode().PadLeft(4, '0');
                string path = string.Format("{0}\\{1}_{2}.SC",
                    db.GetConfigString("DRS_FTP_client_depart_dir"),
                    SiteCode,
                    TimeStampStr).Replace("\\\\", "\\");
                StreamWriter file = new StreamWriter(path, false, tools.Encoding());
                file.WriteLine(BHHTCountDate.ToString() + ";" + SubCategory + ";" + TotalStockValue.ToString());
                file.Close();
            }
            /// We traverse all the InvCountWork records
            /// within the selected SubCategory (filtered)
            /// PN20210114
            filter = string.Format("SubCategory = '{0}'", SubCategory);
            foreach (DataRow row in dsItem.InvCountWork.Select(filter))
            {
                //>>Pn20230615
                int t1 = tools.object2int(row["CountBHHT"]);
                int t2 = tools.object2int(row["SalesPEJ"]);
                int t3 = tools.object2int(row["ManCorrect"]);             

                //if ((row.RowState != DataRowState.Deleted) && (row.RowState != DataRowState.Detached))
                //<<PN20230615
                if ((row.RowState != DataRowState.Deleted) && (row.RowState != DataRowState.Detached) &&
                    ((t1 != 0) || (t2 != 0) || (t3 != 0)))
                {
                    // get InvCountWork values for all imports
                    int ItemID = tools.object2int(row["ItemID"]);
                    DateTime CountDate = tools.object2datetime(row["CountDate"]).Date;

                    #region Booking SalesPEJ

                    // get SalesPEJ values
                    int SalesPEJ = tools.object2int(row["SalesPEJ"]);
                    byte TransactionTypePEJ = (byte)db.TransactionTypes.SalesCount;

                    // if SalesPEJ is not 0 and a transaction does not already exist,
                    // create a SalesPEJ ItemTransaction booking
                    if ((SalesPEJ != 0) &&
                        (!ItemDataSet.ItemTransactionDataTable.TransactionExists(ItemID, CountDate, TransactionTypePEJ)))
                    {
                        // create ItemTransaction record
                        ItemDataSet.ItemTransactionDataTable.WriteTransactionRecord(
                            ItemID,
                            CountDate,
                            TransactionTypePEJ,
                            -SalesPEJ,
                            0,
                            1,
                            null,
                            -SalesPEJ,
                            0,
                            false);
                    }

                    #endregion

                    #region Booking CountDifference

                    // get CountDifference value
                    int CountDifference = tools.object2int(row["CountDifference"]);
                    double DiffValue = tools.object2double(row["DiffValue"]);

                    // create ItemTransactionRecord
                    ItemDataSet.ItemTransactionDataTable.WriteTransactionRecord(
                        ItemID,
                        CountDate,
                        (byte)db.TransactionTypes.CountAdjustment,
                        CountDifference,
                        DiffValue,
                        1,
                        null,
                        CountDifference,
                        0,
                        false);

                    #endregion

                    #region Booking CountBHHT

                    // get values for booking CountBHHT
                    int CountBHHT = tools.object2int(row["CountBHHT"]);
                    int ManCorrect = tools.object2int(row["ManCorrect"]);
                    int ValueToUse = CountBHHT;
                    if (ManCorrect != 0)
                        ValueToUse = ManCorrect;
                    double StockValue = tools.object2double(row["StockValue"]);

                    // create ItemTransactionRecord
                    ItemDataSet.ItemTransactionDataTable.WriteTransactionRecord(
                        ItemID,
                        CountDate,
                        (byte)db.TransactionTypes.Count,
                        ValueToUse,
                        StockValue,
                        1,
                        0,
                        ValueToUse,
                        0,
                        true);

                    #endregion

                    #region Create historik detail

                    // get further values to use when
                    // create historik detail record
                    int StartOnHand = tools.object2int(row["StartOnHand"]);
                    DateTime CountTime = tools.object2datetime(row["CountTime"]);
                    double CostPrice = tools.object2double(row["CostPrice"]);

                    // create historik detail
                    ItemDataSet.BookedInvCountDetailDataTable.InsertRecord(
                        HeaderID,
                        ItemID,
                        StartOnHand,
                        SalesPEJ,
                        CountTime,
                        CountBHHT,
                        ManCorrect,
                        ValueToUse,
                        CostPrice);

                    #endregion

                    // when done booking all data for the row,
                    // delete the record from InvCountWork
                    row.Delete();//Pn20230615
                }
                else row.Delete();//Pn20230615

            }

            // save booked and now deleted records to disk                 
            SaveData();

            // when no more work records, remove related data
            // from BHHTInvCountHeader/Details and close work window
            if (!ItemDataSet.InvCountWorkDataTable.HasRecords())
            {
                ImportDataSet.BHHTInvCountHeaderDataTable.DeleteAllRecords(BHHTCountID);
                ImportDataSet.BHHTInvCountDetailsDataTable.DeleteAllRecords(BHHTCountID);
                ImportDataSet.BHHT_RSM_PEJSalesDataTable.DeleteAllRecords(BHHTCountID);
                
            }
        }

        #region METHOD: SaveData
        private void SaveData()
        {
            
            adapterInvCountWork.Update(dsItem.InvCountWork);
        }
        #endregion
    }
}