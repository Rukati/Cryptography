using _2lb_3k_1s;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _2lb_3k_1s
{
    internal class File
    {
        private string folderPath { get; set; }
        public File(string folderPath)
        {
            this.folderPath = folderPath;
        }
        public void ReadFiles(ref List<(byte[], string)> filesData)
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    var files = Directory.GetFiles(folderPath);

                    foreach (var filePath in files)
                    {
                        byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                        string fileName = Path.GetFileName(filePath);
                        filesData.Add((fileBytes, fileName));
                    }
                }
                else
                {
                    Console.WriteLine("Указанной папки не существует.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Произошла ошибка при доступе к папке: " + e.Message);
            }
        }
        public byte[] ReadKeyFromFile(string keyFilePath)
        {
            try
            {
                if (System.IO.File.Exists(keyFilePath))
                {
                    // Считываем содержимое файла с ключом
                    byte[] keyBytes = System.IO.File.ReadAllBytes(keyFilePath);
                    Console.WriteLine("Ключ успешно считан из файла.");
                    return keyBytes;
                }
                else
                {
                    Console.WriteLine("Указанный файл ключа не существует.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Произошла ошибка при чтении файла ключа: " + e.Message);
            }

            return null;
        }
        public void SaveKeyToFile(byte[] key, string keyFilePath)
        {
            try
            {
                // Записываем ключ в файл
                System.IO.File.WriteAllBytes(keyFilePath + "\\key.txt", key);
                Console.WriteLine("Ключ успешно сохранен в файле.");
            }
            catch (IOException e)
            {
                Console.WriteLine("Произошла ошибка при сохранении ключа в файле: " + e.Message);
            }
        }
        public void SaveFile(byte[] encryptedByte, string filePathSave, string fileName)
        {
            try
            {
                string encryptedFilePath = Path.Combine(filePathSave, fileName);
                Console.WriteLine($"Файл {fileName} успешно зашифрован и сохранен в {encryptedFilePath}");
                System.IO.File.WriteAllBytes(encryptedFilePath, encryptedByte);
            }
            catch (IOException e)
            {
                Console.WriteLine("Произошла ошибка при сохранении файла: " + e.Message);
            }
        }

    }
}
