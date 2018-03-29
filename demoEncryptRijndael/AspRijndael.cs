using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RijndaelNs
{
    public class AspRijndael
    {
        public string EncryptData(string message, string password)
        {
            byte[] result = Rijndael.EncryptData(
                Encoding.ASCII.GetBytes(message),
                Encoding.ASCII.GetBytes(password),
                new byte[] { },
                Rijndael.BlockSize.Block256,
                Rijndael.KeySize.Key256,
                Rijndael.EncryptionMode.ModeECB
            );

            StringBuilder hexResult = new StringBuilder(result.Length * 2);
            foreach (byte b in result)
                hexResult.AppendFormat("{0:x2}", b);


            return hexResult.ToString();
        }

        public string DecryptData(string encryptedMessage, string password)
        {
            if (encryptedMessage.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            byte[] byteArr = new byte[encryptedMessage.Length / 2];
            for (int index = 0; index < byteArr.Length; index++)
            {
                string byteValue = encryptedMessage.Substring(index * 2, 2);
                byteArr[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }


            byte[] result = Rijndael.DecryptData(
                byteArr,
                Encoding.ASCII.GetBytes(password),
                new byte[] { },
                Rijndael.BlockSize.Block256,
                Rijndael.KeySize.Key256,
                Rijndael.EncryptionMode.ModeECB
            );

            return ASCIIEncoding.ASCII.GetString(result);
        }
    }
}
