using System;
using System.Collections.Generic;
using System.Text;

namespace RBOS
{
    class EncryptionAccounting
    {
        #region Private variables

        private static string key = " +-,.;:0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅabcdefghijklmnopqrstuvwxyzæøå";
        private static int rightpadlength = 100;

        #endregion

        #region EncryptString
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s">String to encrypt.</param>
        /// <param name="lineno">1 based line no.</param>
        /// <param name="header">Header string with numbers in first 24 positions.</param>
        /// <returns></returns>
        public static string EncryptString(string s, int lineno, string header)
        {
            // encrypt string
            string encryptedString = "";
            for (int i=0; i<s.Length; i++)
                encryptedString += EncryptChar(s[i], lineno, i+1, header);

            // right-pad with random data to a specific length
            Random rand = new Random(DateTime.Now.Millisecond + lineno);
            int index = encryptedString.Length;
            while (index < rightpadlength)
            {
                encryptedString += key[rand.Next(key.Length-1)].ToString();
                ++index;
            }

            return encryptedString;
        }
        #endregion

        #region EncryptChar
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unencryptedChar">The unencrypted character.</param>
        /// <param name="lineno">1 based line no.</param>
        /// <param name="charpos">1 based character position.</param>
        /// <param name="header">Header string with numbers in first 24 positions.</param>
        /// <returns></returns>
        private static char EncryptChar(char unencryptedChar, int lineno, int charpos, string header)
        {
            // walk the key forwards a distance to get the encrypted char
            int index = key.IndexOf(unencryptedChar);
            int distance = Distance(lineno, charpos, header);
            if (index >= 0)
            {
                for (int i = 0; i < distance; i++)
                {
                    ++index;
                    if (index >= key.Length)
                        index = 0;
                }
            }

            // return the encrypted character
            if ((index >= 0) && (index < key.Length))
                return key[index];
            else
                return '#';
        }
        #endregion

        #region DecryptString
        public static string DecryptString(string s, int lineno, string header)
        {
            string decryptedString = "";
            for (int i = 0; i < s.Length; i++)
                decryptedString += DecryptChar(s[i], lineno, i + 1, header);

            return decryptedString;
        }
        #endregion

        #region DecryptChar
        private static char DecryptChar(char encryptedChar, int lineno, int charpos, string header)
        {
            // walk the key backwards a distance to get the encrypted char
            int index = key.IndexOf(encryptedChar);
            int distance = Distance(lineno, charpos, header);
            if (index >= 0)
            {
                for (int i = 0; i < distance; i++)
                {
                    --index;
                    if (index < 0)
                        index = key.Length - 1;
                }
            }

            // return the decrypted character
            if ((index >= 0) && (index < key.Length))
                return key[index];
            else
                return '#';
        }
        #endregion

        #region TvaersumHeader
        /// <summary>
        /// Calculate tværsum of header's first 24 characters,
        /// which are the digits before version number and encryption flag.
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        private static int TvaersumHeader(string header)
        {
            int tvaersumHeader = 0;
            for (int i = 0; (i < header.Length) && (i < 24); i++)
                tvaersumHeader += tools.object2int(header[i]);
            return tvaersumHeader;
        }
        #endregion

        #region Distance
        private static int Distance(int lineno, int charpos, string header)
        {
            // calculate how far to walk in the key from the index
            int distance = ((lineno + charpos + TvaersumHeader(header)) * charpos);
            return distance;
        }
        #endregion
    }
}
