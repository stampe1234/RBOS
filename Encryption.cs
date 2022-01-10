using System;
using System.Collections.Generic;
using System.Text;

namespace RBOS
{
    class Encryption
    {
        #region Private variables

        private static string key = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅabcdefghijklmnopqrstuvwxyzæøå";

        #endregion

        #region EncryptString
        public static string EncryptString(string s)
        {
            string encryptedString = "";
            for (int i = 0; i < s.Length; i++)
                encryptedString += EncryptChar(s[i], i + 1);
            return encryptedString;
        }
        #endregion

        #region EncryptChar
        private static char EncryptChar(char unencryptedChar, int charpos)
        {
            // walk the key forwards a distance to get the encrypted char
            int index = key.IndexOf(unencryptedChar);
            int distance = Distance(charpos);
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
        public static string DecryptString(string s)
        {
            string decryptedString = "";
            for (int i = 0; i < s.Length; i++)
                decryptedString += DecryptChar(s[i], i + 1);
            return decryptedString;
        }
        #endregion

        #region DecryptChar
        private static char DecryptChar(char encryptedChar, int charpos)
        {
            // walk the key backwards a distance to get the encrypted char
            int index = key.IndexOf(encryptedChar);
            int distance = Distance(charpos);
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

        #region Distance
        private static int Distance(int charpos)
        {
            return ((charpos + 387) * charpos);
        }
        #endregion
    }
}
