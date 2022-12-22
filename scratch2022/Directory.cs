using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scratch2022
{
    class Directory
    {
        public string Name { get; set; }
        public Directory Parent { get; set; }
        public List<Directory> Directories { get; set; }
        public List<File> Files;

        public Directory()
        {
            Name = "";
            Directories = new List<Directory>();
            Files = new List<File>();
        }

        public Directory(string name, List<Directory> directories, List<File> files)
        {
            Name = name;
            Directories = directories;
            Files = files;
        }

        public Directory(string name)
        {
            Name = name;
            Directories = new List<Directory>();
            Files = new List<File>();
        }

        public void AddDirectory(Directory directory)
        {
            directory.Parent = this;
            Directories.Add(directory);
        }

        public bool ContainsDirectory(string name)
        {
            var matchingDirectories = Directories.Where(d => d.Name == name);
            return matchingDirectories.Count() > 0;
        }

        public Directory GetDirectoryByName(string name)
        {
            return Directories.FirstOrDefault(d => d.Name == name);
        }

        public bool ContainsFile(string name)
        {
            var matchingFile = Files.Where(f => f.Name == name);
            return matchingFile.Count() > 0;
        }

        public void AddFile(File file)
        {
            Files.Add(file);
        }

        public int GetSumOfCurrentDirectory()
        {
            return Files.Sum(f => f.Size);
        }

        public int GetSumOfCurrentAndSubDirectories()
        {
            return this.GetSumOfCurrentDirectory() + _getSumOfSubDirectories(Directories);
        }

        public int _getSumOfSubDirectories(List<Directory> directories)
        {
            int subDirectorySizes = 0;
            foreach (var directory in directories)
            {
                subDirectorySizes += directory.GetSumOfCurrentDirectory();
                subDirectorySizes += _getSumOfSubDirectories(directory.Directories);
            }
            return subDirectorySizes;
        }
    }
}
