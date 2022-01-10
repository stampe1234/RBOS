using System;

namespace RBOS
{
	/// <summary>
	/// Summary description for Barcode.
	/// </summary>
	public class Barcode
	{
		// holds the last error message
		private string errmsg = "";

        // supported barcode types
        public enum Types
        {
            CUSTOM = 1,
            EAN13,
            EAN8,
            UPC8BIT,
            UPC12BIT
        }

		/// <summary>
		/// 
		/// </summary>
		public string ErrorMsg
		{
			get { return errmsg; }
		}

		/// <summary>
		/// 
		/// </summary>
		public Barcode()
		{
		}

        /// <summary>
        /// Verifies if provided barcode has a correct checksum according to its type,
        /// or, if it has 7 or 12 digits, it is assumed that the last digit will be prepended.
        /// </summary>
        /// <param name="barcodeType">Barcode type, like EAN8, EAN13 etc.</param>
        /// <param name="code">The barcode.</param>
        /// <returns>True if correct format, false if not.</returns>
        public bool IsValidBarcode(short barcodeType, string code)
        {
            // we don't support barcodes with prepended zeros
            code = tools.object2double(code).ToString();

            // barcode may not be 0
            if (code == "0")
            {
                errmsg = db.GetLangString("Barcode.BarcodeCannotBe0");
                return false;
            }

            // no barcode may have anything else than numbers in them
            string p = "^([0-9]+)$";
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(p);
            if (!regex.IsMatch(code))
            {
                errmsg = db.GetLangString("Barcode.CanOnlyContainDigits");
                return false;
            }

            // if length is 7 or 12, calculate the checksum automatically for validating
            if ((code.Length == 7) || (code.Length == 12))
                code = TryCalculateChecksum(code, (byte)barcodeType);

            // check for valid types
            if (barcodeType == (int)Types.EAN8)
                return IsValidEAN8(code);
            else if (barcodeType == (int)Types.EAN13)
                return IsValidEAN13(code);
            else if (barcodeType == (int)Types.CUSTOM)
                return true; // custom always has correct format
            else
                return false;
        }

        /// <summary>
        /// Verifies if provided barcode has a correct checksum according to its type.
        /// </summary>
        /// <param name="barcodeType">Barcode type, like EAN8, EAN13 etc.</param>
        /// <param name="code">The barcode.</param>
        /// <returns>True if correct format, false if not.</returns>
        public bool IsValidBarcode(Barcode.Types barcodeType, string code)
        {
            return IsValidBarcode(short.Parse(barcodeType.ToString()), code);
        }

        /// <summary>
        /// Calculates the checksum for EAN8 and EAN13 barcodes
        /// if provided barcode is 7 or 12 characters long and
        /// bctype is EAN8 or EAN13. If a checksum was calculated
        /// the return value has that value appened, otherwise
        /// the barcode is returned as it was originally provided.
        /// </summary>
        public string TryCalculateChecksum(string code, int bctype)
        {
            if ((bctype == (short)Types.EAN13) && (code.Length == 12))
                return code + CalculateEAN13(code).ToString();
            else if ((bctype == (short)Types.EAN8) && (code.Length == 7))
                return code + CalculateEAN8(code).ToString();
            else
                return code;
        }

        public double TryCalculateChecksum(object code, int bctype)
        {
            return double.Parse(TryCalculateChecksum(code.ToString(), bctype));
        }

        public double TryCalculateChecksum(double code, int bctype)
        {
            return double.Parse(TryCalculateChecksum(code.ToString(), bctype));
        }

        /// <summary>
        /// Calculates EAN 8 and returns the checksum
        /// </summary>
        /// <param name="code">The EAN 8 barcode</param>
        /// <returns>The EAN 8 barcode checksum (the last digit)</returns>
        public int CalculateEAN8(string code)
        {
            // calculate weighted values
            int n1 = int.Parse(code[0].ToString()) * 3;
            int n2 = int.Parse(code[1].ToString()) * 1;
            int n3 = int.Parse(code[2].ToString()) * 3;
            int n4 = int.Parse(code[3].ToString()) * 1;
            int n5 = int.Parse(code[4].ToString()) * 3;
            int n6 = int.Parse(code[5].ToString()) * 1;
            int n7 = int.Parse(code[6].ToString()) * 3;
            int sum = n1 + n2 + n3 + n4 + n5 + n6 + n7;

            // checksum is whatever needs to be added to the sum
            // to make a number dividable by 10
            int checksum = (10 - (sum % 10));
            if (checksum == 10) checksum = 0;

            return checksum;
        }

        /// <summary>
        /// Calculates EAN 13 and returns the checksum
        /// </summary>
        /// <param name="code">The EAN 13 barcode</param>
        /// <returns>The EAN 13 barcode checksum (the last digit)</returns>
        public int CalculateEAN13(string code)
        {
            // calculate weighted values
            int n1 = int.Parse(code[0].ToString()) * 1;
            int n2 = int.Parse(code[1].ToString()) * 3;
            int n3 = int.Parse(code[2].ToString()) * 1;
            int n4 = int.Parse(code[3].ToString()) * 3;
            int n5 = int.Parse(code[4].ToString()) * 1;
            int n6 = int.Parse(code[5].ToString()) * 3;
            int n7 = int.Parse(code[6].ToString()) * 1;
            int n8 = int.Parse(code[7].ToString()) * 3;
            int n9 = int.Parse(code[8].ToString()) * 1;
            int n10 = int.Parse(code[9].ToString()) * 3;
            int n11 = int.Parse(code[10].ToString()) * 1;
            int n12 = int.Parse(code[11].ToString()) * 3;
            int sum = n1 + n2 + n3 + n4 + n5 + n6 + n7 + n8 + n9 + n10 + n11 + n12;

            // checksum is whatever needs to be added to the sum
            // to make a number dividable by 10
            int checksum = (10 - (sum % 10));
            if (checksum == 10) checksum = 0;

            return checksum;
        }

        // private helper method to check for valid EAN 8 barcode
        private bool IsValidEAN8(string code)
        {
            // check that we have the needed amount of digits
            if (code.Length != 8)
            {
                errmsg = db.GetLangString("Barcode.EAN8MustContain8Digits");
                return false;
            }

            // check that code is only integers
            try { long i = long.Parse(code); }
            catch
            {
                errmsg = db.GetLangString("Barcode.EAN8CanOnlyContainIntegers");
                return false;
            }

            int checksum = CalculateEAN8(code);

            // check if the checksum cipher in the barcode is correct
            bool result = (int.Parse(code[7].ToString()) == checksum);

            // report any checksum error
            if (!result) errmsg = db.GetLangString("Barcode.IncorrectEAN8Code");

            return result;
        }

        // private helper method to check for valid EAN 13 barcode
        private bool IsValidEAN13(string code)
		{
			// check that we have the needed amount of digits
			if(code.Length != 13)
			{
				errmsg = db.GetLangString("Barcode.EAN13MustContain13Digits");
				return false;
			}

			// check that code is only integers
			try { long i = long.Parse(code); }
			catch
			{
				errmsg = db.GetLangString("Barcode.EAN13CanOnlyContainIntegers");
				return false;
			}

            int checksum = CalculateEAN13(code);

			// check if the checksum cipher in the barcode is correct
			bool result = (int.Parse(code[12].ToString()) == checksum);

			// report any checksum error
			if(!result) errmsg = db.GetLangString("Barcode.IncorrectEAN13Code");

			return result;
		}

        private bool IsValid12BitUPC(string code)
		{
            return false;
		}

		private bool IsValid8BitUPC(string code)
		{
            return false;
		}
	}
}
