using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    public static class FileUtil
    {
        public static string[] LoadInput(string day)
        {
            return File.ReadAllLines(@$"{day}\Input.txt");
        }
    }
}
