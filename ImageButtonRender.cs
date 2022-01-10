using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace RBOS
{
    class ImageButtonRender
    {
        // images loaded once
        private static Image imgSearch = Image.FromFile("img\\search_16.gif");
        private static Image imgBarcode = Image.FromFile("img\\barcode.gif");
        private static Image imgLookupForm = Image.FromFile("img\\lookupform.gif");
        private static Image imgExecute = Image.FromFile("img\\execute.gif");
        private static Image imgDetails = Image.FromFile("img\\details.bmp");
        private static Image imgInfo = Image.FromFile("img\\info.bmp");
        private static Image imgDetailForm = Image.FromFile("img\\detailform.gif");
        private static Image imgDetailFormGreyScale = Image.FromFile("img\\detailform_greyscale.gif");
        private static Image imgCheckmark = Image.FromFile("img\\green_checkmark.gif");
        private static Image imgTrash = Image.FromFile("img\\trash.gif");
        private static Image imgDateTime = Image.FromFile("img\\datetime.gif");
        private static Image imgDateTimeGreyscale = Image.FromFile("img\\datetime_greyscale.gif");

        // enum containing valid images to use
        public enum Images
        {
            Search,
            Barcode,
            LookupForm,
            Execute,
            Details,
            Info,
            DetailForm,
            DetailFormGreyScale,
            Checkmark,
            Trash,
            DateTime,
            DateTimeGreyScale
        }

        // method to be called from a DataGridView.CellPainting event
        public static void OnCellPainting(
            DataGridViewCellPaintingEventArgs e,
            int colIndexToUse,
            Images image)
        {
            if ((e.ColumnIndex == colIndexToUse) && (e.RowIndex >= 0))
            {
                // render the cell and it's contents
                e.PaintBackground(e.CellBounds, false);
                e.PaintContent(e.CellBounds);

                // get the selected image
                Image img = GetImage(image);

                // calculate x and y positions for centering image on grid button
                // and set the width of the image
                int imgWidth = 15;
                int xCorrection = -1;
                int yCorrection = -1;
                Rectangle rectImage = new Rectangle();
                rectImage.X = e.CellBounds.X + (e.CellBounds.Width / 2) - (imgWidth / 2) + xCorrection;
                rectImage.Y = e.CellBounds.Y + (e.CellBounds.Height / 2) - (imgWidth / 2) + yCorrection;
                rectImage.Width = imgWidth;
                rectImage.Height = imgWidth;

                // render the selected image
                e.Graphics.DrawImage(img, rectImage);

                // signal handled CellPainting event
                e.Handled = true;
            }
        }

        public static Image GetImage(Images image)
        {
            Image img = null;
            switch (image)
            {
                case Images.Search: img = imgSearch; break;
                case Images.Barcode: img = imgBarcode; break;
                case Images.LookupForm: img = imgLookupForm; break;
                case Images.Execute: img = imgExecute; break;
                case Images.Details: img = imgDetails; break;
                case Images.Info: img = imgInfo; break;
                case Images.DetailForm: img = imgDetailForm; break;
                case Images.DetailFormGreyScale: img = imgDetailFormGreyScale; break;
                case Images.Checkmark: img = imgCheckmark; break;
                case Images.Trash: img = imgTrash; break;
                case Images.DateTime: img = imgDateTime; break;
                case Images.DateTimeGreyScale: img = imgDateTimeGreyscale; break;
            }
            return img;
        }
    }
}
