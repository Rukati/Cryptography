using _2lb_3k_1s;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace _2lb_3k_1s
{
    class Program
    {
        const string folderPath = "your_input_folder_path";
        const string folderPathCrypto = "your_output_folder_path";
        static void Main(string[] args)
        {
            File file = new File(folderPathCrypto);

            List<(byte[], string)> filesList = new List<(byte[], string)>();

            file.ReadFiles( ref filesList);

            byte[] key = file.ReadKeyFromFile(folderPathCrypto + "\\key.txt");
            SimpleSubstitutionCipher cipher = new SimpleSubstitutionCipher(key);

            foreach ((byte[] fileBytes, string fileName) in filesList)
            {
                byte[] encryptedBytes = cipher.Decrypt(fileBytes);
                file.SaveFile(encryptedBytes, folderPathCrypto, "Decryp_" + fileName);
            }
        }

    }
}
