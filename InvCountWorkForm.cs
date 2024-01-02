using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.IO;

namespace RBOS
{
    public partial class InvCountWorkForm : Form
    {
        #region Private variables

        private int BHHTCountID;
        private DateTime BHHTCountDate = DateTime.MinValue;
        private double TotalStockValue = 0;
        private double TotalDiffValue = 0;
        private int WorksheetID = -1;

        #endregion

        #region Constructor
        public InvCountWorkForm(int BHHTCountID)
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;

            // keep BHHT count id
            this.BHHTCountID = BHHTCountID;

            // lookup and keep some addition BHHT values
            OleDbDataAdapter bhhtAdapter = new OleDbDataAdapter("", db.Connection);
            DataTable bhhtTable = new DataTable();
            bhhtAdapter.SelectCommand.CommandText = string.Format(
                " select * from BHHTInvCountHeader " +
                " where CountID = {0}",
                BHHTCountID);
            bhhtAdapter.Fill(bhhtTable);
            if (bhhtTable.Rows.Count > 0)
            {
                DataRow bhhtRow = bhhtTable.Rows[0];

                // get and display BHHTCountDate
                BHHTCountDate = tools.object2datetime(bhhtRow["CountDate"]).Date;
                txtCountDate.Text = BHHTCountDate.ToString("dd-MM-yyyy");

                // get worksheet id
                WorksheetID = tools.object2int(bhhtRow["WorkSheetID"]);
            }

            // load any existing InvCountWork data
            adapterInvCountWork.Connection = db.Connection;
            adapterInvCountWork.Fill(dsItem.InvCountWork);

            // load LookupItem data
            adapterLookupItem.Connection = db.Connection;
            adapterLookupItem.Fill(dsItem.LookupItem);

            // if no existing InvCountWork data exists,
            // build new InvCountWork data based on the
            // provided BHHTCountID
            if (dsItem.InvCountWork.Rows.Count <= 0)
                BuildNewInvCountWorkData();

            // build the subcategory dropdown
            BuildSubCategoryDropdown();

            // position grid columns
            colItemName.DisplayIndex = 0;
            colStartOnHand.DisplayIndex = 1;
            colSalesPEJ.DisplayIndex = 2;
            colOnHandCalc.DisplayIndex = 3;
            colCountTime.DisplayIndex = 4;
            colCountBHHT.DisplayIndex = 5;
            colManCorrect.DisplayIndex = 6;
            colCountDifference.DisplayIndex = 7;
            colCostPrice.DisplayIndex = 8;
            colStockValue.DisplayIndex = 9;
            colDiffValue.DisplayIndex = 10;
        }
        #endregion

        #region METHOD: SaveData
        private void SaveData()
        {
            bindingInvCountWork.EndEdit();
            adapterInvCountWork.Update(dsItem.InvCountWork);
        }
        #endregion

        #region METHOD: BuildSubCategoryDropdown
        /// <summary>
        /// Builds the dropdown list with SubCategories.
        /// </summary>
        private void BuildSubCategoryDropdown()
        {
            // get all used subcategories
            comboSubCategory.Items.Clear();
            foreach (DataRow row in dsItem.InvCountWork.Rows)
            {
                string subcat = row["SubCategory"].ToString();
                if(comboSubCategory.Items.IndexOf(subcat) < 0)
                    comboSubCategory.Items.Add(subcat);
            }
            // select the first subcategory in the dropdown
            if (comboSubCategory.Items.Count > 0)
                comboSubCategory.SelectedIndex = 0;
        }
        #endregion

        #region METHOD: BuildNewInvCountWorkData
        /// <summary>
        /// Builds data for table InvCountWork based on
        /// BHHTCountID provided in class' constructor.
        /// </summary>
        private void BuildNewInvCountWorkData()
        {
            ProgressForm progress = new ProgressForm(db.GetLangString("InvCountWorkForm.PrepareData"));
            progress.Show();

            // variables needed more than once
            OleDbCommand cmd = new OleDbCommand("", db.Connection);

            #region Load BHHTInvCountDetails data

            // load BHHTInvCountDetails data
            OleDbDataAdapter adapterBHHT = new OleDbDataAdapter("", db.Connection);
            adapterBHHT.SelectCommand.CommandText = string.Format(
                " select * from BHHTInvCountDetails where CountID = {0} ",
                BHHTCountID);
            DataTable tableBHHT = new DataTable();
            adapterBHHT.Fill(tableBHHT);

            progress.ProgressMax = tableBHHT.Rows.Count;                                                         
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
                    string SubCategory = itemRow["SubCategory"].ToString();
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

                progress.StatusText = db.GetLangString("InvCountWorkForm.CollectingCountData");
            }

            #endregion

            #region Load worksheet data (collecting items for zero count)

            // Look in worksheet to see what items has not been
            // counted, and thus will be marked for zero count.
            // Generate records in IncCountWork for these items.

            // load worksheet header
            OleDbDataAdapter adapterWSHeader = new OleDbDataAdapter("", db.Connection);
            adapterWSHeader.SelectCommand.CommandText = string.Format(
                " select * from BHHTWorksheet " +
                " where ID = {0} ",
                WorksheetID);
            DataTable tableWSHeader = new DataTable();
            adapterWSHeader.Fill(tableWSHeader);

            // check we have found a corresponding worksheet
            if (tableWSHeader.Rows.Count > 0)
            {
                DataRow rowWSHeader = tableWSHeader.Rows[0];
                OleDbDataAdapter adapterWSDetail = new OleDbDataAdapter("", db.Connection);
                DataTable tableWSDetail = new DataTable();

                // find out whether to get worksheet detail data
                // from table BHHTWSCatList or table BHHTWSItemList
                char WorksheetInclude = tools.object2char(rowWSHeader["Include"]);
                if (char.ToLower(WorksheetInclude) == 'c')
                {
                    /// load detail data from BHHTWSCatList.
                    /// this is done by selecting all items within
                    /// the given subcategories

                    adapterWSDetail.SelectCommand.CommandText = string.Format(
                        " select ItemID from Item " +
                        " where SubCategory in " +
                        " (select SubCategoryID from BHHTWSCatList " +
                        "  where WSID = {0}) ",
                        WorksheetID);
                    adapterWSDetail.Fill(tableWSDetail);
                }
                else if (char.ToLower(WorksheetInclude) == 'i')
                {
                    // load detail data from BHHTWSItemList.
                    // this is done by selecting all items in the list
                    adapterWSDetail.SelectCommand.CommandText = string.Format(
                        " select ItemID from BHHTWSItemList " +
                        " where WSID = {0} ",
                        WorksheetID);
                    adapterWSDetail.Fill(tableWSDetail);
                }
                else if (char.ToLower(WorksheetInclude) == 'a')
                {
                    // here we assume that all items is counted,
                    // so we include all items so all items not counted is being zeroed
                    adapterWSDetail.SelectCommand.CommandText = " select ItemID from Item ";
                    adapterWSDetail.Fill(tableWSDetail);
                }

                progress.ProgressMax = tableWSDetail.Rows.Count;

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

                        int CountBHHT = 0;
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
                        string SubCategory = itemRow["SubCategory"].ToString();
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

                    progress.StatusText = db.GetLangString("InvCountWorkForm.CollectionItemData");
                }
            }

            #endregion

            progress.Close();

            // refresh the GUI representation of data
            adapterInvCountWork.Fill(dsItem.InvCountWork);
        }

        #endregion

        #region METHOD: CalculateTotals
        /// <summary>
        /// Calculates and displays the summed values for
        /// StockValue and DiffValue for all rows within
        /// the selected SubCategory.
        /// </summary>
        private void CalculateTotals()
        {
            bindingInvCountWork.EndEdit();
            TotalStockValue = 0;
            TotalDiffValue = 0;
            string filter = "SubCategory = '" + tools.object2string(comboSubCategory.SelectedItem) + "'";
            foreach (DataRow row in dsItem.InvCountWork.Select(filter))
            {
                TotalStockValue += tools.object2double(row["StockValue"]);
                TotalDiffValue += tools.object2double(row["DiffValue"]);
            }
            txtTotalStockValue.Text = TotalStockValue.ToString("n2");
            txtTotalDiffValue.Text = TotalDiffValue.ToString("n2");
        }
        #endregion

        #region GetSiteCodeFormatted
        private static string GetSiteCodeFormatted()
        {
            return AdminDataSet.SiteInformationDataTable.GetSiteCode().PadLeft(4, '0');
        }
        #endregion
        #region METHOD: Approve
        /// <summary>
        /// Approves the InvCountWork records
        /// within the currently SubCategory.
        /// ItemTransaction records are written.
        /// </summary>
        private void Approve()
        {
            // save pending data
            SaveData();

            // get SubCategoryID needed more than once
            string SubCategoryID = tools.object2string(comboSubCategory.SelectedItem);

            // create historik header
            int HeaderID = ItemDataSet.BookedInvCountHeaderDataTable.InsertRecord(
                BHHTCountDate,
                SubCategoryID,
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
                file.WriteLine(BHHTCountDate.ToString() + ";" + SubCategoryID + ";" + TotalStockValue.ToString());
                file.Close();                
            }        
            /// We traverse all the InvCountWork records
            /// within the selected SubCategory (filtered)
            /// PN20210114
            string filter = string.Format("SubCategory = '{0}'", SubCategoryID);
            foreach (DataRow row in dsItem.InvCountWork.Select(filter))
            {
                //>>Pn20230615
                int t1 = tools.object2int(row["CountBHHT"]);           
                int t2 = tools.object2int(row["SalesPEJ"]);            
                int t3 = tools.object2int(row["ManCorrect"]);



                //if ((row.RowState != DataRowState.Deleted) && (row.RowState != DataRowState.Detached))
                //<<PN20230615
                if ((row.RowState != DataRowState.Deleted) && (row.RowState != DataRowState.Detached)  &&
                    ((t1 != 0) || (t2 != 0) || (t3 != 0) ))
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
                else  row.Delete();//Pn20230615

            }

            // save booked and now deleted records to disk
            SaveData();

            // show print report based on historik
            BookedInvCountReportF report = new BookedInvCountReportF(HeaderID);
            report.ShowDialog();

            // remove the SubCategoryID from the combobox and select the first
            comboSubCategory.Items.Remove(SubCategoryID);
            if (comboSubCategory.Items.Count > 0)
                comboSubCategory.SelectedIndex = 0;

            // when no more work records, remove related data
            // from BHHTInvCountHeader/Details and close work window
            if (!ItemDataSet.InvCountWorkDataTable.HasRecords())
            {
                ImportDataSet.BHHTInvCountHeaderDataTable.DeleteAllRecords(BHHTCountID);
                ImportDataSet.BHHTInvCountDetailsDataTable.DeleteAllRecords(BHHTCountID);
                ImportDataSet.BHHT_RSM_PEJSalesDataTable.DeleteAllRecords(BHHTCountID);

                // inform user and close work window
                MessageBox.Show(db.GetLangString("InvCountWorkForm.BookingDone"));
                Close();
            }
        }
        #endregion

        // comboSubCategory selected index changed event
        private void comboSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SubCategoryID = tools.object2string(comboSubCategory.SelectedItem);
            if(comboSubCategory.SelectedIndex >= 0)
            {
                // lookup subcategory description
                txtSubCategoryDesc.Text =
                    ItemDataSet.SubCategoryDataTable.GetSubCategoryDescription(SubCategoryID);
            }

            // apply filter for view
            bindingInvCountWork.Filter = "";
            if (SubCategoryID != "")
                bindingInvCountWork.Filter = "SubCategory = '" + SubCategoryID + "'";

            // re-calculate totals
            CalculateTotals();
        }

        // grid cell end edit event
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // when value of ManCorrect has changed
            if (e.ColumnIndex == colManCorrect.Index)
            {
                // refresh grid to fetch data generated
                // on dataset-level (OnColumnChanged event)
                dataGridView1.Refresh();

                // re-calculate totals
                CalculateTotals();
            }
        }

        // grid cell validating event
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // when changing ManCorrect value
            if (e.ColumnIndex == colManCorrect.Index)
            {
                // check that a whole number or null has been entered
                if (!tools.RegExCheckValue_int(e.FormattedValue, true))
                {
                    MessageBox.Show(db.GetLangString("InvCountWorkForm.EnterWholeNumber"));
                    e.Cancel = true;
                    return;
                }

                // check that the entered value is null or a positive integer
                int ManCorrect = tools.object2int(e.FormattedValue);
                if (ManCorrect < 0)
                {
                    MessageBox.Show(db.GetLangString("InvCountWorkForm.ManCorrectGreaterThan0"));
                    e.Cancel = true;
                    return;
                }
            }
        }

        // save and close button click event
        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            // save data and close form
            SaveData();
            Close();
        }

        // cancel button click event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // approve button click event
        private void btnApprove_Click(object sender, EventArgs e)
        {
            Approve();
        }

        private void InvCountWorkForm_Load(object sender, EventArgs e)
        {
            lbCountDate.Text = db.GetLangString("InvCountWorkForm.CountDatelbl");
            lbSubCategory.Text = db.GetLangString("InvCountWorkForm.Categorylbl");
            lbTotal.Text = db.GetLangString("InvCountWorkForm.TotalCountValuelbl");
            lbTotalDiff.Text = db.GetLangString("InvCountWorkForm.TotalCountDiffLbl");
            btnCancel.Text = db.GetLangString("Application.Cancel");
            btnSaveClose.Text = db.GetLangString("Application.SaveClose");
            btnApprove.Text = db.GetLangString("InvCountWorkForm.ApproveLbl");
            this.Text = db.GetLangString("InvCountWorkForm.Title");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}