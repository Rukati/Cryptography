using _2lb_3k_1s;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace _2lb_3k_1s
{
    class Program
    {
        private enum Menu
        {
            Зашифровать = 1,
            Расшифровать = 2,
            Выйти = 3
        }
        public enum Crypto
        {
            Подстановка = 1,
            Перестановка = 2,
            Гаммирование = 3,
            ОдноразовыйБлокнот = 4,
            Назад = 5
        }
        static void MenuEncrypt()
        {
            while (true)
            {
                Console.Write("1.Подстановка\n2.Перестановка\n3.Гаммирование\n4.Одноразовый блокнот\n5.Назад\nВвод: ");
                string userInput = Console.ReadLine();
                if (Enum.TryParse(userInput, out Crypto selectCrypto))
                {
                    Cryptography cryptography = new Cryptography(folderPath, folderPathCrypto);
                    switch (selectCrypto)
                    {
                        case Crypto.Подстановка:
                            Console.Clear();
                            cryptography.SimpleEncrypt();
                            break;
                        case Crypto.Перестановка:
                            Console.Clear();
                            cryptography.RearrangementEncrypt();
                            break;
                        case Crypto.Гаммирование:
                            Console.Clear();
                            cryptography.VigenereEncrypt();
                            break;
                        case Crypto.ОдноразовыйБлокнот:
                            Console.Clear();
                            cryptography.VernamEncrypt();
                            break;
                        case Crypto.Назад:
                            Console.Clear();
                            return;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                            Console.ResetColor();
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    Console.ResetColor();
                }
            }

        }
        static void MenuDecrypt()
        {
            while (true)
            {
                Console.Write("1.Подстановка\n2.Перестановка\n3.Гаммирование\n4.Одноразовый блокнот\n5.Назад\nВвод: ");
                string userInput = Console.ReadLine();
                if (Enum.TryParse(userInput, out Crypto selectCrypto))
                {
                    Cryptography cryptography = new Cryptography(folderPath, folderPathCrypto);
                    switch (selectCrypto)
                    {
                        case Crypto.Подстановка:
                            Console.Clear();
                            cryptography.SimpleDecrypt();
                            break;
                        case Crypto.Перестановка:
                            Console.Clear();
                            cryptography.RearrangementDecrypt();
                            break;
                        case Crypto.Гаммирование:
                            Console.Clear();
                            cryptography.VigenereDecrypt();
                            break;
                        case Crypto.ОдноразовыйБлокнот:
                            Console.Clear();
                            cryptography.VernamDecrypt();
                            break;
                        case Crypto.Назад:
                            Console.Clear();
                            return;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                            Console.ResetColor();
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    Console.ResetColor();
                }
            }

        }
        static void MainMenu()
        {
            while (true)
            {
                Console.Write("1.Зашифровать\n2.Разшифровать\n3.Выйти.\nВвод: ");
                string userInput = Console.ReadLine();
                if (Enum.TryParse(userInput, out Menu selectMenu))
                {
                    Console.Clear();
                    switch (selectMenu)
                    {
                        case Menu.Зашифровать:
                            MenuEncrypt();
                            break;
                        case Menu.Расшифровать:
                            MenuDecrypt();
                            break;
                        case Menu.Выйти:
                            Console.WriteLine("Выход из программы.");
                            return;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                            Console.ResetColor();
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    Console.ResetColor();
                }

            }

        }
        static private string folderPath = "Path to the folder with files to be encrypted";
        static private string folderPathCrypto = "Path to the folder where decrypted files will be saved";
        static void Main(string[] args)
        {
            MainMenu();
        }

    }
}