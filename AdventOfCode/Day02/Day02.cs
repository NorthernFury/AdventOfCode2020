using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day02
{
    public static class Day02
    {
        private static Day02Solution _instance;

        public static string Solve()
        {
            if (_instance == null)
                _instance = new Day02Solution();

            return _instance.Solve();
        }
    }

    internal class Day02Solution
    {
        private class Policy
        {
            public char Letter { get; set; }
            public int LowerBound { get; set; }
            public int UpperBound { get; set; }
            public string Password { get; set; }

            public bool Validate()
            {
                var charCount = Password.ToCharArray().Count(x => x == Letter);

                return charCount >= LowerBound && charCount <= UpperBound;
            }

            public bool ValidatePart2()
            {
                var passwordChars = Password.ToCharArray();

                return passwordChars[LowerBound - 1] == Letter ^ passwordChars[UpperBound - 1] == Letter;
            }
        }

        public string Solve()
        {
            string[] inputs = FileUtil.LoadInput(nameof(Day02));

            int validCount = 0;

            foreach(var input in inputs)
            {
                if (GetPolicy(input).ValidatePart2())
                    validCount++;
            }

            return $"There are { validCount } valid passwords";
        }

        private Policy GetPolicy(string input)
        {
            string[] policyInput = input.Split(':');
            string[] bounds = policyInput[0].Split(' ')[0].Split('-');

            Policy policy = new Policy
            {
                Letter = Convert.ToChar(policyInput[0].Substring(policyInput[0].Length - 1, 1)),
                LowerBound = Convert.ToInt32(bounds[0].Trim()),
                UpperBound = Convert.ToInt32(bounds[1].Trim()),
                Password = policyInput[1].Trim()
            };

            return policy;
        }
    }
}
