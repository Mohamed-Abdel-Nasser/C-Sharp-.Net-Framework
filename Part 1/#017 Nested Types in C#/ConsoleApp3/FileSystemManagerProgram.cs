using System;
using System.IO;
namespace FileSystemManager
{
    class FileSystemManagerProgram
    {
        static void Main()
        {
            // Usage of nested File class
            FileSystemManager.File file = new FileSystemManager.File("example.txt");
            file.Delete();

            // Usage of nested Directory class
            FileSystemManager.Directory directory = new FileSystemManager.Directory("C:\\MyFolder");
            directory.Create();
        }
    }

    public class FileSystemManager
    {
        // Nested class representing a File
        public class File
        {
            public string FileName { get; private set; }

            public File(string fileName)
            {
                FileName = fileName;
            }

            public void Delete()
            {
                if (System.IO.File.Exists(FileName))
                {
                    System.IO.File.Delete(FileName);
                    Console.WriteLine($"File '{FileName}' deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"File '{FileName}' not found.");
                }
            }
        }

        // Nested class representing a Directory
        public class Directory
        {
            public string DirectoryPath { get; private set; }

            public Directory(string directoryPath)
            {
                DirectoryPath = directoryPath;
            }

            public void Create()
            {
                if (!System.IO.Directory.Exists(DirectoryPath))
                {
                    System.IO.Directory.CreateDirectory(DirectoryPath);
                    Console.WriteLine($"Directory '{DirectoryPath}' created successfully.");
                }
                else
                {
                    Console.WriteLine($"Directory '{DirectoryPath}' already exists.");
                }
            }
        }
    }
  

}
