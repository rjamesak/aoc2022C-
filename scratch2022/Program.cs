using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scratch2022
{
    class Program
    {
        static void Main(string[] args)
        {
            var dirA = new Directory();
            var dirB = new Directory();
            var dirC = new Directory();
            var file1 = new File("file 1", 100);
            var file2 = new File("file 2", 50);
            var file3 = new File("file 3", 25);
            var file4 = new File("file 4", 25);
            dirB.AddFile(file3);
            dirA.AddFile(file1);
            dirA.AddFile(file2);
            dirC.AddFile(file4);
            dirC.Name = "C";
            dirA.Name = "A";
            dirB.Name = "B";
            dirA.AddDirectory(dirB);
            dirB.AddDirectory(dirC);
            var dirASum = dirA.GetSumOfCurrentDirectory();
            var dirBSum = dirB.GetSumOfCurrentDirectory();
            var allDirSum = dirA.GetSumOfCurrentAndSubDirectories();

            var device = new Device();

            List<List<string>> inputLines = new List<List<string>>();
            foreach (string line in System.IO.File.ReadLines(@"C:\Repos\scratch2022\scratch2022\TestInput.txt"))
            {
                var splitLine = line.Split(' ').ToList();
                inputLines.Add(splitLine);
            }

            device.BuildFileStructure(inputLines);
            device.ListDirectorySizes();
            var rootSum = device.Root.GetSumOfCurrentDirectory();
            var rootAndSubsSum = device.Root.GetSumOfCurrentAndSubDirectories();
            Console.Read();
        }
    }
}
