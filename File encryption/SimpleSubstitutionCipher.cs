using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;

namespace _2lb_3k_1s
{
    internal class SimpleSubstitutionCipher
    {
        static private byte[] encryptionKey; // Ключ для шифрования
        static public byte[] decryptionKey; // Ключ для дешифрования

        public SimpleSubstitutionCipher(byte[] key = null)
        {
            if (key == null || key.Length == 0)
            {
                GenerateKeys();
            }
            else
            {
                decryptionKey = key;
            }

        }
        private static void GenerateKeys()
        {
            try
            {
                // Создаем массив с числами от 0 до 255
                byte[] values = Enumerable.Range(0, 256).Select(i => (byte)i).ToArray();

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
                encryptionKey = values.ToArray();

                // Создаем ключ для дешифрования (обратная подстановка)
                decryptionKey = new byte[256];
                for (int i = 0; i < 256; i++)
                {
                    decryptionKey[encryptionKey[i]] = (byte)i;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при генерации ключей: " + ex.Message);
                throw;
            }
        }

        public byte[] Encrypt(byte[] data)
        {
            if (data == null || data.Length == 0)
            {
                throw new ArgumentException("Входные данные не могут быть пустыми.");
            }

            byte[] encryptedBytes = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                encryptedBytes[i] = encryptionKey[data[i]];
            }

            return encryptedBytes;
        }
        public byte[] Decrypt(byte[] encryptedData)
        {
            if (encryptedData == null || encryptedData.Length == 0)
            {
                throw new ArgumentException("Зашифрованные данные не могут быть пустыми.");
            }

            byte[] decryptedBytes = new byte[encryptedData.Length];

            for (int i = 0; i < encryptedData.Length; i++)
            {
                decryptedBytes[i] = decryptionKey[encryptedData[i]];
            }

            return decryptedBytes;
        }
    }

}