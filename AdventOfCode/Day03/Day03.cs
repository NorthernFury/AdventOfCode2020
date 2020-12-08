using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day03
{
    public class Day03
    {
        private class Map
        {
            public string[] Input { get; set; }

            public int Height => Input?.Length ?? 0;
            public int Width => Input[0]?.ToCharArray().Length ?? 0;

            readonly char TREE = '#';

            public bool IsTreeNext(int x, int y)
            {
                if (x >= Height)
                    return false;

                int yWrapPos = y;

                if (y >= Width)
                {
                    int loop = y / Width;
                    yWrapPos = y - (Width * loop);
                }

                //char found = Input[x].ToCharArray()[yWrapPos];
                //Console.WriteLine($"Found [{found}] at ({x},{yWrapPos})");

                return Input[x].ToCharArray()[yWrapPos] == TREE;
            }
        }

        private class Slope
        {
            public int Right { get; }
            public int Down { get; }

            public Slope(int right, int down)
            {
                Right = right;
                Down = down;
            }
        }

        private Map TreeMap { get; set; } = new Map
        {
            Input = FileUtil.LoadInput(nameof(Day03))
        };

        public string SolvePart1()
        {
            var slope = new Slope(3, 1);
            int treeCount = 0;

            for(int x = 0; x < TreeMap.Height; x++)
            {
                if (TreeMap.IsTreeNext((x + 1) * slope.Down, (x + 1) * slope.Right))
                    treeCount++;
            }

            return $"Trees counted: { treeCount }";
        }

        public string SolvePart2()
        {
            Dictionary<Slope, int> Slopes = new Dictionary<Slope, int>
            {
                { new Slope(1, 1), 0 },
                { new Slope(3, 1), 0 },
                { new Slope(5, 1), 0 },
                { new Slope(7, 1), 0 },
                { new Slope(1, 2), 0 }
            };

            for(int x = 0; x < TreeMap.Height; x++)
            {
                foreach (var slope in Slopes.Keys.ToList())
                {
                    int xPos = (x + 1) * slope.Down;
                    int yPos = (x + 1) * slope.Right;

                    if (TreeMap.IsTreeNext(xPos, yPos))
                        Slopes[slope] += 1;
                }
            }

            var result = Slopes.Values
                .Select(x => Convert.ToInt64(x))
                .Aggregate((mult, item) => mult * item);

            return $"Found { result } trees across all slopes";
        }
    }
}
