using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBOS
{
    public partial class BHHTOrderHeaderForm : Form
    {
        // constructor
        public BHHTOrderHeaderForm()
        {
            InitializeComponent();
        }

        #region OpenDetails
        /// <summary>
        /// Open BHHTOrderDetails form.
        /// </summary>
        private void OpenDetails()
        {
            // if user clicks on the detail lines button,
            // open the detail lines form

            if (bindingOrderHeader.Current != null)
            {
                DataRowView row = (DataRowView)bindingOrderHeader.Current;
                if (row["OrderID"] != DBNull.Value)
                {
                    int id = int.Parse(row["OrderID"].ToString());
                    BHHTOrderDetailForm form = new BHHTOrderDetailForm(id);
                    form.ShowDialog(this);

                    // data might have changed, so refresh data
                    int index = bindingOrderHeader.Position;
                    adapterOrderHeader.Fill(dsImport.BHHTOrderHeader);
                    if ((index >= 0) && (index < bindingOrderHeader.Count))
                        bindingOrderHeader.Position = index;
                }
            }
        }
        #endregion

        // form load event
        private void BHHTOrderHeaderForm_Load(object sender, EventArgs e)
        {
            this.adapterLookupStatus.Connection = db.Connection;
            this.adapterLookupStatus.Fill(this.dsImport.LookupStatus);
            this.adapterLookupSupplier.Connection = db.Connection;
            this.adapterLookupSupplier.Fill(this.dsImport.LookupSupplier);
            this.adapterOrderHeader.Connection = db.Connection;
            this.adapterOrderHeader.Fill(this.dsImport.BHHTOrderHeader);
                     
            // Set display index for colums
            colBHHTOrderId.DisplayIndex = 0;
            colSupplierNo.DisplayIndex = 1;
            colSupplDescription.DisplayIndex = 2;
            colOrderDate.DisplayIndex = 3;
            colDeliveryDate.DisplayIndex = 4;
            colExcluted.DisplayIndex = 5;
            colStatus.DisplayIndex = 6;
            colStatusColor.DisplayIndex = 7;

            // Localization

            btnClose.Text = db.GetLangString("Application.Close");
            btnDetail.Text = db.GetLangString("BHHTOrderForm.DetailLabel");
            btnCreateOrder.Text = db.GetLangString("BHHTOrderForm.CreateOrderLabel");

            colBHHTOrderId.HeaderText = db.GetLangString("BHHTOrderForm.OrderIdLabel");
            colSupplierNo.HeaderText = db.GetLangString("BHHTOrderForm.SupplIdLabel");
            colSupplDescription.HeaderText = db.GetLangString("BHHTOrderForm.SupplNameLabel");
            colOrderDate.HeaderText = db.GetLangString("BHHTOrderForm.OrderDateLabel");
            colDeliveryDate.HeaderText = db.GetLangString("BHHTOrderForm.DeliveryDateLabel");
            colExcluted.HeaderText = db.GetLangString("BHHTOrderForm.ExcludeLabel");
            colStatus.HeaderText = db.GetLangString("BHHTOrderForm.StatusLabel");
            
        }

        // close button click event
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // detail button click event
        private void btnDetail_Click(object sender, EventArgs e)
        {
            OpenDetails();
        }

        // grid cell painting event
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // paint status color cell
            tools.PaintStatusCell(
                gridOrderHeader,
                e.ColumnIndex,
                e.RowIndex,
                colStatus.Index,
                colStatusColor.Index);
        }

        // create order button click event
        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (bindingOrderHeader.Current == null) return;
            DataRowView row = (DataRowView)bindingOrderHeader.Current;
            int BHHTOrderID = tools.object2int(row["OrderID"]);
            ImportBHHT importer = new ImportBHHT();
            importer.MoveBHHTOrderToRBOSOrderTables(BHHTOrderID, false);
            adapterOrderHeader.Fill(dsImport.BHHTOrderHeader);
        }

        // grid mouse double click event
        private void gridOrderHeader_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenDetails();
        }      
    }
}