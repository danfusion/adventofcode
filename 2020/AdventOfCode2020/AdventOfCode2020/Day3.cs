using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AdventOfCode2020
{
    class Day3
    {
        public static void runDay()
        {
            string line;
            int inputRows = 0;
            int inputCols = 0;

            List<Point> treeCoords = new List<Point>();
            List<Point> slopesList = new List<Point>()
            {
                new Point(1,1),
                new Point(3,1), // part 1
                new Point(5,1),
                new Point(7,1),
                new Point(1,2)
            };

            Int64 multipliedTreeHits = 1;

            // Test Input
            //System.IO.StreamReader file = new System.IO.StreamReader(@"input\Day3TestInput.txt");

            // Main Input
            System.IO.StreamReader file = new System.IO.StreamReader(@"input\Day3Input.txt");

            while ((line = file.ReadLine()) != null)
            {
                /* -=-=-= Part One =-=-=- */
                if (inputCols == 0)
                {
                    inputCols = line.Length;
                }

                // setup the tree matrix
                for (var i = 0; i < line.Length; i++)
                {
                    if (line[i].Equals('#'))
                    {
                        Point newTree = new Point(i, inputRows);
                        treeCoords.Add(newTree);
                        //Console.WriteLine("New Tree added: {0}", newTree);
                    }
                }

                inputRows++;
            }

            // input file stats
            Console.WriteLine("The input file contains {0} rows.", inputRows);
            Console.WriteLine("The input file contains {0} columns.", inputCols);
            Console.WriteLine("The input file contains {0} trees.", treeCoords.Count);

            // actual answers
            foreach(var slope in slopesList)
            {
                var numberOfTreeHits = countTreeCollisions(inputRows, inputCols, treeCoords, slope.X, slope.Y);
                Console.WriteLine("The slope {0},{1} hits {2} trees.", slope.X, slope.Y, numberOfTreeHits);
                multipliedTreeHits *= (numberOfTreeHits > 0 ? numberOfTreeHits : 1);
            }
            Console.WriteLine("Total number of tree hits multipled by each other: {0}.", multipliedTreeHits);


            //Console.WriteLine("The slope {0},{1} hits {2} trees.", slopeX, slopeY, numberOfTreeHits);

            file.Close();

            // pause at the end
            System.Console.ReadLine();
        }

        private static int countTreeCollisions(int inputRows, int inputCols, List<Point> treeCoords, int slopeX, int slopeY)
        {
            int calculatedXPos = 0;
            int numberOfTreeHits = 0;

            // loop for slope and collisions, loop from the top of the input to the bottom
            for (var j = slopeY; j <= inputRows; j += slopeY)
            {
                calculatedXPos = calculatedXPos + slopeX;
                
                if (calculatedXPos >= inputCols)
                {
                    calculatedXPos = calculatedXPos - inputCols;
                }

                Point testPos = new Point(calculatedXPos, j);

                if (treeCoords.Contains(testPos))
                {
                    numberOfTreeHits++;
                }
            }

            return numberOfTreeHits;
        }
    }
}
