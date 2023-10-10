using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lb_3k_1s
{
    internal class VernamCipher
    {
        static public byte[] key;
        public VernamCipher(byte[] key = null, byte[] len = null)
        {
            if (key == null || key.Length == 0)
            {
                GenerateKeys(len);
            }
            else
            {
                VernamCipher.key = key;
            }
        }
        private void GenerateKeys(byte[] len)
        {
            try
            {
                // Создаем массив с числами от 0 до len
                byte[] values = Enumerable.Range(0, len.Length).Select(i => (byte)i).ToArray();

                // Перемешиваем значения
                Random rng = new Random();
                int n = values.Length;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    byte temp = values[k];
                    values[k] = values[n];
                    values[n] = temp;
                }

                // Создаем ключ для шифрования
                key = values.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при генерации ключей: " + ex.Message);
                throw;
            }
        }
        public byte[] Encrypt(byte[] data)
        {
            byte[] encryptedData = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                encryptedData[i] = (byte)(data[i] ^ key[i % key.Length]);
            }
            return encryptedData;
        }

        public byte[] Decrypt(byte[] encryptedData)
        {
            byte[] decryptedData = new byte[encryptedData.Length];
            for (int i = 0; i < encryptedData.Length; i++)
            {
                decryptedData[i] = (byte)(encryptedData[i] ^ key[i % key.Length]);
            }
            return decryptedData;
        }
    }
}
