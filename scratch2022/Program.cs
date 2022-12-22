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
        /// <summary>
        /// AOC 2022 Day 7
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            var device = new Device();

            List<List<string>> inputLines = new List<List<string>>();
            foreach (string line in System.IO.File.ReadLines(@"C:\Repos\scratch2022\scratch2022\input.txt"))
            {
                var splitLine = line.Split(' ').ToList();
                inputLines.Add(splitLine);
            }

            device.BuildFileStructure(inputLines);
            device.PopulateDirectorySizes();
            var smallDirectories = device.DirectoryList.Where(d => d.TotalSize <= 100000).ToList();
            var bigDirectories = device.DirectoryList.Where(d => d.TotalSize >= 30000000).ToList();
            var smallDirectorySum = smallDirectories.Sum(d => d.TotalSize);
            var rootSum = device.Root.GetSumOfCurrentDirectory();
            var rootAndSubsSum = device.Root.GetSumOfCurrentAndSubDirectories();
            var freeSpace = 70000000 - rootAndSubsSum;
            var neededSpace = 30000000 - freeSpace;
            var potentialDirectories = device.DirectoryList.Where(d => d.TotalSize >= neededSpace).ToList();
            var sortedPotentials = potentialDirectories.OrderBy(d => d.TotalSize);
            var smallestPotentialDirectory = potentialDirectories.First();
        }
    }
}
