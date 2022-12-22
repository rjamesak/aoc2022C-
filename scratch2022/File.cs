using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scratch2022
{
    class File
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public File()
        {
            Name = "";
            Size = 0;
        }

        public File(string name, int size)
        {
            Name = name;
            Size = size;
        }
    }
}
