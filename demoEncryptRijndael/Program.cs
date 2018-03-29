using RijndaelNs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoEncryptRijndael
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("__________ Begin __________");


            string encrypted = "51509911952AB679F736C53107E99EE57B5D299E99C1230BD2C8E38A397929B284F38837A18C181E4103E05B34F376126B467E44B6A26CD76597108C09447AE1";

            Console.WriteLine(DecryptData(encrypted, "P@ssw0rd")) ;



            Console.WriteLine("__________ End __________");
            Console.ReadLine();

        }

        public static  string DecryptData(string encryptedMessage, string password)
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
                new byte[] { }, // Initialization vector
                Rijndael.BlockSize.Block256, // Typically 128 in most implementations
                Rijndael.KeySize.Key256,
                Rijndael.EncryptionMode.ModeECB // Rijndael.EncryptionMode.ModeCBC
            );

            return ASCIIEncoding.ASCII.GetString(result);
        }
    }
}
