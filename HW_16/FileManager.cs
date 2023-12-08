using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_16
{
    public class FileManager
    {
        private string currentDirectory;
        private string logFilePath;

        public FileManager(string initialDirectory, string logFileName)
        {
            currentDirectory = initialDirectory;
            logFilePath = Path.Combine(initialDirectory, logFileName);

            // Создаем лог-файл
            if (!File.Exists(logFilePath))
            {
                File.Create(logFilePath).Close();
            }
        }

        /// <summary>
        /// Метод для записи действия в лог-файл
        /// </summary>
        /// <param name="action"></param>
        private void LogAction(string action)
        {
            string logEntry = $"{DateTime.Now} - {action}";
            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
        }

        /// <summary>
        /// Метод для отображения содержимого текущей директории
        /// </summary>

        public void ShowCurrentDirectoryContents()
        {
            try
            {
                string[] files = Directory.GetFiles(currentDirectory);
                string[] directories = Directory.GetDirectories(currentDirectory);

                Console.WriteLine("Файлы:");
                foreach (string file in files)
                {
                    Console.WriteLine(Path.GetFileName(file));
                }

                Console.WriteLine("\nДиректории:");
                foreach (string directory in directories)
                {
                    Console.WriteLine(Path.GetFileName(directory));
                }

                LogAction("Просмотр содержимого директории");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// Метод для создания нового файла
        /// </summary>
        /// <param name="fileName"></param>
        public void CreateFile(string fileName)
        {
            try
            {
                File.Create(Path.Combine(currentDirectory, fileName)).Close();
                Console.WriteLine($"Файл {fileName} создан успешно.");

                LogAction($"Создание файла: {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// Метод для создания новой директории
        /// </summary>
        /// <param name="directoryName"></param>
        public void CreateDirectory(string directoryName)
        {
            try
            {
                Directory.CreateDirectory(Path.Combine(currentDirectory, directoryName));
                Console.WriteLine($"Директория {directoryName} создана успешно.");

                LogAction($"Создание директории: {directoryName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// Метод для удаления файла
        /// </summary>
        /// <param name="fileName"></param>
        public void DeleteFile(string fileName)
        {
            try
            {
                string filePath = Path.Combine(currentDirectory, fileName);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine($"Файл {fileName} удален успешно.");

                    LogAction($"Удаление файла: {fileName}");
                }
                else
                {
                    Console.WriteLine("Файл не существует.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// Метод для удаления директории
        /// </summary>
        /// <param name="directoryName"></param>
        public void DeleteDirectory(string directoryName)
        {
            try
            {
                string directoryPath = Path.Combine(currentDirectory, directoryName);

                if (Directory.Exists(directoryPath))
                {
                    Directory.Delete(directoryPath, true);
                    Console.WriteLine($"Директория {directoryName} удалена успешно.");

                    LogAction($"Удаление директории: {directoryName}");
                }
                else
                {
                    Console.WriteLine("Директория не существует.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// Метод для копирования файла
        /// </summary>
        /// <param name="sourceFileName"></param>
        /// <param name="destinationFileName"></param>
        public void CopyFile(string sourceFileName, string destinationFileName)
        {
            try
            {
                string sourcePath = Path.Combine(currentDirectory, sourceFileName);
                string destinationPath = Path.Combine(currentDirectory, destinationFileName);

                File.Copy(sourcePath, destinationPath, true);
                Console.WriteLine($"Файл {sourceFileName} скопирован в {destinationFileName}.");

                LogAction($"Копирование файла: {sourceFileName} -> {destinationFileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// Метод для перемещения файла
        /// </summary>
        /// <param name="sourceFileName"></param>
        /// <param name="destinationFileName"></param>
        public void MoveFile(string sourceFileName, string destinationFileName)
        {
            try
            {
                string sourcePath = Path.Combine(currentDirectory, sourceFileName);
                string destinationPath = Path.Combine(currentDirectory, destinationFileName);

                File.Move(sourcePath, destinationPath);
                Console.WriteLine($"Файл {sourceFileName} перемещен в {destinationFileName}.");

                LogAction($"Перемещение файла: {sourceFileName} -> {destinationFileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// Метод для чтения из файла
        /// </summary>
        /// <param name="fileName"></param>
        public void ReadFromFile(string fileName)
        {
            try
            {
                string filePath = Path.Combine(currentDirectory, fileName);

                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    Console.WriteLine($"Содержимое файла {fileName}:\n{content}");

                    LogAction($"Чтение файла: {fileName}");
                }
                else
                {
                    Console.WriteLine("Файл не существует.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// Метод для записи в файл
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="content"></param>
        public void WriteToFile(string fileName, string content)
        {
            try
            {
                string filePath = Path.Combine(currentDirectory, fileName);

                File.WriteAllText(filePath, content);
                Console.WriteLine($"Текст успешно записан в файл {fileName}.");

                LogAction($"Запись в файл: {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
