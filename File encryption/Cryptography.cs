using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lb_3k_1s
{
    internal class Cryptography
    {
        private string folderPath;
        private string folderPathCrypto;
        List<(byte[], string)> filesList = new List<(byte[], string)>();
        File file;
        public Cryptography(string folderPath, string folderPathCrypto)
        {
            this.folderPath = folderPath;
            this.folderPathCrypto = folderPathCrypto;
        }

        public void SimpleEncrypt()
        {
            file = new File(folderPath);
            file.ReadFiles(ref filesList);

            SimpleSubstitutionCipher cipher = new SimpleSubstitutionCipher();

            foreach ((byte[] fileBytes, string fileName) in filesList)
            {
                if (fileName.Substring(0, 3).Equals("KEY", StringComparison.OrdinalIgnoreCase))
                    continue;
                byte[] encryptedBytes = cipher.Encrypt(fileBytes);
                file.SaveFile(encryptedBytes, folderPathCrypto, "Encrypt_" + fileName);
                file.SaveKeyToFile(SimpleSubstitutionCipher.decryptionKey, folderPathCrypto, "KEY_SimpleSubstitutionCipher");
            }
        }
        public void SimpleDecrypt()
        {
            file = new File(folderPathCrypto);
            file.ReadFiles(ref filesList);

            byte[] key = file.ReadKeyFromFile(folderPathCrypto + "\\KEY_SimpleSubstitutionCipher.txt");
            if (key != null && key.Length > 0)
            {
                SimpleSubstitutionCipher cipher = new SimpleSubstitutionCipher(key);

                foreach ((byte[] fileBytes, string fileName) in filesList)
                {
                    if (fileName.Substring(0, 3).Equals("KEY", StringComparison.OrdinalIgnoreCase))
                        continue;
                    byte[] decryptedBytes = cipher.Decrypt(fileBytes);
                    file.SaveFile(decryptedBytes, folderPathCrypto, "Decrypt_" + fileName);
                }
            }
        }
        public void VigenereEncrypt()
        {
            file = new File(folderPath);
            file.ReadFiles(ref filesList);

            VigenereCipher cipher = new VigenereCipher();

            foreach ((byte[] fileBytes, string fileName) in filesList)
            {
                if (fileName.Substring(0, 3).Equals("KEY", StringComparison.OrdinalIgnoreCase))
                    continue;
                byte[] encryptedBytes = cipher.Encrypt(fileBytes);
                file.SaveFile(encryptedBytes, folderPathCrypto, "Encrypt_" + fileName);
                file.SaveKeyToFile(VigenereCipher.key, folderPathCrypto, "KEY_VigenereCipher");
            }
        }
        public void VigenereDecrypt()
        {
            file = new File(folderPathCrypto);
            file.ReadFiles(ref filesList);

            byte[] key = file.ReadKeyFromFile(folderPathCrypto + "\\KEY_VigenereCipher.txt");
            if (key != null && key.Length > 0)
            {
                VigenereCipher cipher = new VigenereCipher(key);

                foreach ((byte[] fileBytes, string fileName) in filesList)
                {
                    if (fileName.Substring(0, 3).Equals("KEY", StringComparison.OrdinalIgnoreCase))
                        continue;
                    byte[] decryptedBytes = cipher.Decrypt(fileBytes);
                    file.SaveFile(decryptedBytes, folderPathCrypto, "Decrypt_" + fileName);
                }
            }
        }
        public void RearrangementEncrypt()
        {
            file = new File(folderPath);
            file.ReadFiles(ref filesList);

            Rearrangement cipher = new Rearrangement();

            foreach ((byte[] fileBytes, string fileName) in filesList)
            {
                if (fileName.Substring(0, 3).Equals("KEY", StringComparison.OrdinalIgnoreCase))
                    continue;
                byte[] encryptedBytes = cipher.Encrypt(fileBytes);
                file.SaveFile(encryptedBytes, folderPathCrypto, "Encrypt_" + fileName);
                file.SaveKeyToFile(Rearrangement.decryptionKey, folderPathCrypto, "KEY_RearrangementCipher");
            }

        }
        public void RearrangementDecrypt()
        {
            file = new File(folderPathCrypto);
            file.ReadFiles(ref filesList);

            byte[] key = file.ReadKeyFromFile(folderPathCrypto + "\\KEY_RearrangementCipher.txt");
            if (key != null && key.Length > 0)
            {
                Rearrangement cipher = new Rearrangement(key);

                foreach ((byte[] fileBytes, string fileName) in filesList)
                {
                    if (fileName.Substring(0, 3).Equals("KEY", StringComparison.OrdinalIgnoreCase))
                        continue;
                    byte[] decryptedBytes = cipher.Decrypt(fileBytes);
                    file.SaveFile(decryptedBytes, folderPathCrypto, "Decrypt_" + fileName);
                }
            }
        }
        public void VernamEncrypt()
        {
            file = new File(folderPath);
            file.ReadFiles(ref filesList);

            
            foreach ((byte[] fileBytes, string fileName) in filesList)
            {
                VernamCipher cipher = new VernamCipher(len:fileBytes);
                if (fileName.Substring(0, 3).Equals("KEY", StringComparison.OrdinalIgnoreCase))
                    continue;
                byte[] encryptedBytes = cipher.Encrypt(fileBytes);
                file.SaveFile(encryptedBytes, folderPathCrypto, "Encrypt_" + fileName);
                file.SaveKeyToFile(VernamCipher.key, folderPathCrypto, "KEY_VernamCipher");
            }

        }
        public void VernamDecrypt()
        {
            file = new File(folderPathCrypto);
            file.ReadFiles(ref filesList);

            byte[] key = file.ReadKeyFromFile(folderPathCrypto + "\\KEY_VernamCipher.txt");

            if (key != null && key.Length > 0)
            {
                VernamCipher cipher = new VernamCipher(key:key);
                foreach ((byte[] fileBytes, string fileName) in filesList)
                {
                    if (fileName.Substring(0, 3).Equals("KEY", StringComparison.OrdinalIgnoreCase))
                        continue;
                    byte[] decryptedBytes = cipher.Decrypt(fileBytes);
                    file.SaveFile(decryptedBytes, folderPathCrypto, "Decrypt_" + fileName);
                }
            }
        }


    }
}
