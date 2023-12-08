using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager("C:\\Temp", "LogFile.txt");

            while (true)
            {
                Console.WriteLine("Простой файловый менеджер");
                Console.WriteLine("1. Просмотр содержимого текущей директории");
                Console.WriteLine("2. Рекурсивный просмотр содержимого текущей директории");
                Console.WriteLine("3. Поиск файлов и директорий по имени");
                Console.WriteLine("4. Создание файла");
                Console.WriteLine("5. Создание директории");
                Console.WriteLine("6. Удаление файла");
                Console.WriteLine("7. Удаление директории");
                Console.WriteLine("8. Копирование файла");
                Console.WriteLine("9. Перемещение файла");
                Console.WriteLine("10. Чтение из файла");
                Console.WriteLine("11. Запись в файл");
                Console.WriteLine("0. Выход");

                Console.Write("Выберите действие (введите номер): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        fileManager.ShowCurrentDirectoryContents();
                        break;
                    case "2":
                        fileManager.ShowCurrentDirectoryContents(true);
                        break;
                    case "3":
                        Console.Write("Введите имя файла или директории для поиска: ");
                        string searchName = Console.ReadLine();
                        fileManager.Search(searchName);
                        break;
                    case "4":
                        Console.Write("Введите имя файла: ");
                        string fileName = Console.ReadLine();
                        fileManager.CreateFile(fileName);
                        break;
                    case "5":
                        Console.Write("Введите имя директории: ");
                        string directoryName = Console.ReadLine();
                        fileManager.CreateDirectory(directoryName);
                        break;
                    case "6":
                        Console.Write("Введите имя файла для удаления: ");
                        fileName = Console.ReadLine();
                        fileManager.DeleteFile(fileName);
                        break;
                    case "7":
                        Console.Write("Введите имя директории для удаления: ");
                        directoryName = Console.ReadLine();
                        fileManager.DeleteDirectory(directoryName);
                        break;
                    case "8":
                        Console.Write("Введите имя файла для копирования: ");
                        string sourceFileName = Console.ReadLine();
                        Console.Write("Введите имя файла для вставки: ");
                        string destinationFileName = Console.ReadLine();
                        fileManager.CopyFile(sourceFileName, destinationFileName);
                        break;
                    case "9":
                        Console.Write("Введите имя файла для перемещения: ");
                        sourceFileName = Console.ReadLine();
                        Console.Write("Введите имя файла для вставки: ");
                        destinationFileName = Console.ReadLine();
                        fileManager.MoveFile(sourceFileName, destinationFileName);
                        break;
                    case "10":
                        Console.Write("Введите имя файла для чтения: ");
                        fileName = Console.ReadLine();
                        fileManager.ReadFromFile(fileName);
                        break;
                    case "11":
                        Console.Write("Введите имя файла для записи: ");
                        fileName = Console.ReadLine();
                        Console.Write("Введите текст для записи в файл: ");
                        string content = Console.ReadLine();
                        fileManager.WriteToFile(fileName, content);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Некорректный ввод. Пожалуйста, повторите.");
                        break;
                }

                Console.WriteLine("\nНажмите Enter для продолжения...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
