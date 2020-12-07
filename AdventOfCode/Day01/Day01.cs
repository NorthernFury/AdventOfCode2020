using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day01
{
    public static class Day01
    {
        public static string GetSolution()
        {
            string[] input = FileUtil.LoadInput(nameof(Day01));

            for(int a = 0; a < input.Length; a++)
            {
                for(int b = 0; b < input.Length; b++)
                {
                    for(int c = 0; c < input.Length; c++)
                    {
                        if (a == b && b == c)
                            break;

                        int value1 = Convert.ToInt32(input[a]);
                        int value2 = Convert.ToInt32(input[b]);
                        int value3 = Convert.ToInt32(input[c]);

                        if (value1 + value2 + value3 == 2020)
                            return (value1 * value2 * value3).ToString();
                    }
                }
            }

            return "No solution";
        }
    }
}
