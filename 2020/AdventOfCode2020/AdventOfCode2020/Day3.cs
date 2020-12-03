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

            int slopeX = 3;
            int slopeY = 1;
            int calculatedXPos = 0;

            List<Point> treeCoords = new List<Point>();
            int numberOfTreeHits = 0;

            System.IO.StreamReader file = new System.IO.StreamReader(@"input\Day3Input.txt");

            while ((line = file.ReadLine()) != null)
            {
                /* -=-=-= Part One =-=-=- */
                if (inputRows == 0)
                {
                    inputCols = line.Length;
                }

                // setup the tree matrix
                for (var i = 0; i < line.Length; i++)
                {
                    if (line[i].Equals('#'))
                    {
                        Point newTree = new Point(i,inputRows);
                        treeCoords.Add(newTree);
                        // Console.WriteLine("New Tree added: {0}", newTree);
                    }
                }

                inputRows++;
            }

            // loop for slope and collisions, loop from the top of the input to the bottom
            for (var j = 1; j < inputRows; j++)
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

            Console.WriteLine("The input file contains {0} rows.", inputRows);
            Console.WriteLine("The input file contains {0} columns.", inputCols);
            Console.WriteLine("The input file contains {0} trees.", treeCoords.Count);
            Console.WriteLine("The slope {0},{1} hits {2} trees.", slopeX, slopeY, numberOfTreeHits);

            file.Close();

            /* -=-=-= Part Two =-=-=- */

            // pause at the end
            System.Console.ReadLine();
        }
    }
}
