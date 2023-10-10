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
        private string folderPath;
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Указанной папки не существует.");
                    Console.ResetColor();
                }
            }
            catch (IOException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Произошла ошибка при доступе к папке: " + e.Message);
                Console.ResetColor();
            }
        }
        public byte[] ReadKeyFromFile(string keyFilePath)
        {
            try
            {
                if (System.IO.File.Exists(keyFilePath))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    // Считываем содержимое файла с ключом
                    byte[] keyBytes = System.IO.File.ReadAllBytes(keyFilePath);
                    Console.WriteLine("Ключ успешно считан из файла.");
                    Console.ResetColor();
                    return keyBytes;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Указанный файл ключа не существует.");
                    Console.ResetColor();
                }
            }
            catch (IOException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Произошла ошибка при чтении файла ключа: " + e.Message);
                Console.ResetColor();
            }

            return null;
        }
        public void SaveKeyToFile(byte[] key, string keyFilePath,string nameKey)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                // Записываем ключ в файл
                System.IO.File.WriteAllBytes(keyFilePath + $"\\{nameKey}.txt", key);
                Console.WriteLine("Ключ успешно сохранен в файле.");
                Console.ResetColor();
            }
            catch (IOException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Произошла ошибка при сохранении ключа в файле: " + e.Message);
                Console.ResetColor();
            }
        }
        public void SaveFile(byte[] Byte, string filePathSave, string fileName)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string FilePath = Path.Combine(filePathSave, fileName);
                Console.WriteLine($"Файл {fileName} сохранен в {FilePath}");
                System.IO.File.WriteAllBytes(FilePath, Byte);
                Console.ResetColor();
            }
            catch (IOException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Произошла ошибка при сохранении файла: " + e.Message);
                Console.ResetColor();
            }
        }

    }
}
