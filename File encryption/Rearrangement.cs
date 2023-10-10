using System;
using System.Linq;

namespace _2lb_3k_1s
{
    internal class Rearrangement
    {
        private byte[] encryptionKey;
        static public byte[] decryptionKey;

        public Rearrangement(byte[] key = null)
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

        private void GenerateKeys()
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

                // Создаем ключ для шифрования и сохраняем его
                encryptionKey = values.ToArray();

                // Создаем ключ для дешифрования
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
            int dataLength = data.Length;

            // Создание нового массива для зашифрованных данных
            byte[] encryptedData = new byte[dataLength];

            for (int i = 0; i < dataLength; i++)
            {
                // Перестановка байтов согласно ключу
                encryptedData[i] = encryptionKey[data[i]];
            }

            return encryptedData;
        }

        public byte[] Decrypt(byte[] encryptedData)
        {
            int dataLength = encryptedData.Length;

            // Создание нового массива для дешифрованных данных
            byte[] decryptedData = new byte[dataLength];

            for (int i = 0; i < dataLength; i++)
            {
                // Восстановление оригинального байта с использованием ключа для дешифрования
                decryptedData[i] = decryptionKey[encryptedData[i]];
            }

            return decryptedData;
        }
    }
}
