using System;
using System.Collections.Generic;

// ReSharper disable All

namespace Composite
{
    public static class Program
    {
        public static void Main()
        {
            FileSystem directory0 = new Directory("root");

            FileSystem directory1 = new Directory("root/folder #1");

            FileSystem file1 = new File("root/folder #1/test #1.txt");
            FileSystem file2 = new File("root/folder #1/test #2.txt");

            directory1.AddFile(file1);
            directory1.AddFile(file2);

            FileSystem directory2 = new Directory("root/folder #2");

            FileSystem file3 = new File("root/folder #2/test #3.txt");
            FileSystem file4 = new File("root/folder #2/test #4.txt");

            directory2.AddFile(file3);
            directory2.AddFile(file4);

            FileSystem file0 = new File("root/test #0.txt");

            directory0.AddDirectory(directory1);
            directory0.AddDirectory(directory2);

            directory0.AddFile(file0);

            foreach (string path in directory0.GetFiles())
            {
                Console.WriteLine(path);
            }

            Console.WriteLine();

            foreach (string path in directory0.GetDirectories())
            {
                Console.WriteLine(path);
            }

            Console.ReadKey();
        }
    }

    public abstract class FileSystem
    {
        private readonly string _path;

        protected FileSystem(string path)
        {
            _path = path;
        }

        public string Path => _path;

        public abstract void AddFile(FileSystem file);

        public abstract void AddDirectory(FileSystem directory);

        public abstract string[] GetFiles();

        public abstract string[] GetDirectories();
    }

    public class File : FileSystem
    {
        public File(string path) : base(path) { }

        public override void AddFile(FileSystem file) { }

        public override void AddDirectory(FileSystem directory) { }

        public override string[] GetFiles()
        {
            return Array.Empty<string>();
        }

        public override string[] GetDirectories()
        {
            return Array.Empty<string>();
        }
    }

    public class Directory : FileSystem
    {
        private readonly List<FileSystem> _files;
        private readonly List<FileSystem> _directories;

        public Directory(string path) : base(path)
        {
            _files = new List<FileSystem>();
            _directories = new List<FileSystem>();
        }

        public override void AddFile(FileSystem file)
        {
            _files.Add(file);
        }

        public override void AddDirectory(FileSystem directory)
        {
            _directories.Add(directory);
        }

        public override string[] GetFiles()
        {
            List<string> buffer = new List<string>();

            foreach (FileSystem file in _files)
            {
                buffer.Add(file.Path);
            }

            foreach (FileSystem directory in _directories)
            {
                buffer.AddRange(directory.GetFiles());
            }

            return buffer.ToArray();
        }

        public override string[] GetDirectories()
        {
            List<string> buffer = new List<string>();

            foreach (FileSystem file in _directories)
            {
                buffer.Add(file.Path);
            }

            return buffer.ToArray();
        }
    }
}
