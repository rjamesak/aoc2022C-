using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scratch2022
{
    class Device
    {
        public Directory Root { get; set; }
        public Directory CurrentDirectory { get; set; }
        public List<Directory> DirectoryList { get; set; }
        public Device()
        {
            Root = new Directory();
            Root.Name = "Root";
            Root.Parent = Root;
            CurrentDirectory = Root;
            DirectoryList = new List<Directory>();
        }


        // interpret array of commands
        public void BuildFileStructure(List<List<string>> commands)
        {
            foreach (var command in commands)
            {
                if (command[0] == "$" && command[1] == "cd")
                {
                    string dirName = command[2];
                    ChangeDirectory(dirName);
                }
                else if (command[0] == "$" && command[1] == "ls")
                    continue;
                else
                {
                    // is list
                    HandleListItem(command);
                }
            }
        }

        public void ChangeDirectory(string directoryName)
        {
            if (directoryName == "/")
            {
                CurrentDirectory = Root;
            }
            else if (directoryName == "..")
            {
                var parentDirectory = CurrentDirectory.Parent;
                CurrentDirectory = parentDirectory;
            }
            else if (CurrentDirectory.ContainsDirectory(directoryName))
            {
                var newDirectory = CurrentDirectory.GetDirectoryByName(directoryName);
                CurrentDirectory = newDirectory;
            }
            else
            {
                var newDirectory = new Directory(directoryName);
                CurrentDirectory.AddDirectory(newDirectory);
                CurrentDirectory = newDirectory;
            }
        }

        public void HandleListItem(List<string> item)
        {
            if (item[0] == "dir")
            {
                string dirName = item[1];
                if (CurrentDirectory.ContainsDirectory(dirName)) return;
                var newDirectory = new Directory(dirName);
                CurrentDirectory.AddDirectory(newDirectory);
            }
            else
            {
                string fileName = item[1];
                if (CurrentDirectory.ContainsFile(fileName)) return;
                int fileSize = int.Parse(item[0]);
                var newFile = new File(fileName, fileSize);
                CurrentDirectory.AddFile(newFile);
            }
        }

        public void PopulateDirectorySizes()
        {
            _populateDirectorySizes(Root);
        }

        private void _populateDirectorySizes(Directory directory)
        {
            var directories = directory.Directories;
            foreach (var dir in directories)
            {
                _populateDirectorySizes(dir);
            }
            directory.Size = directory.GetSumOfCurrentDirectory();
            directory.TotalSize = directory.GetSumOfCurrentAndSubDirectories();
            DirectoryList.Add(directory);
        }
    }
}
