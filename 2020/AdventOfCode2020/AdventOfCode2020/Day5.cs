﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    class Day5
    {
        public static void runDay()
        {
            bool debug = false;
            string line;
            int maxSeatId = 0;
            //List<int> seatRows = new List<int>();
            //List<int> seatCols = new List<int>();
            List<Seat> seats = new List<Seat>();

            // Test Input
            // System.IO.StreamReader file = new System.IO.StreamReader(@"input\Day5TestInput.txt");

            // Main Input
            System.IO.StreamReader file = new System.IO.StreamReader(@"input\Day5Input.txt");

            while ((line = file.ReadLine()) != null)
            {
                Seat thisSeat = new Seat();
                thisSeat.parseInstructions(line, debug);
                //seatRows.Add(thisSeat.seatCoords.seatRow);
                //seatCols.Add(thisSeat.seatCoords.seatCol);
                seats.Add(thisSeat);
                if (thisSeat.SeatId > maxSeatId)
                {
                    maxSeatId = thisSeat.SeatId;
                }
            }

            HashSet <(int row, int col)> myRange = new HashSet<(int row, int col)>();
            for(var i = 0; i < 128; i++)
            {
                for(var j = 0; j < 8; i++)
                {
                    myRange.Add(new Tuple<int, int>(i, j));
                }
            }
            var excludedSeats = seats.Where(x => !myRange.Equals(x.seatCoords));
            
            //List<int> missingRows = myRange.Except(seatRows).ToList();

            //Console.WriteLine(string.Join(",", missingRows));
            Console.WriteLine("Max Seat id: {0}", maxSeatId);

            // pause at the end
            System.Console.ReadLine();

        }
    }

    class Seat
    {
        public (int seatRow, int seatCol) seatCoords = (0, 0);

        public int SeatId => seatCoords.seatRow * 8 + seatCoords.seatCol;
        
        public Seat()
        {
            // do nothing
        }
        public Seat(int row, int col)
        {
            this.seatCoords.seatRow = row;
            this.seatCoords.seatCol = col;
        }

        public void parseInstructions(string instructions, bool debug)
        {
            (int min, int max) rowRange = (0, 127);
            (int min, int max) colRange = (0, 7);

            for (var i = 0; i < instructions.Length; i++)
            {
                int rowRangeDiff = rowRange.max - rowRange.min;
                int colRangeDiff = colRange.max - colRange.min;

                switch (instructions[i])
                {
                    case 'F':
                        if (rowRangeDiff > 1)
                        {
                            rowRange.max = rowRange.max - rowRangeDiff / 2 - 1;
                        }
                        seatCoords.seatRow = rowRange.min;
                        break;
                    case 'B':
                        if (rowRangeDiff > 1)
                        {
                            rowRange.min = rowRangeDiff / 2 + rowRange.min + 1;
                        }
                        seatCoords.seatRow = rowRange.max;
                        break;
                    case 'L':
                        if (colRangeDiff > 1)
                        {
                            colRange.max = colRange.max - colRangeDiff / 2 - 1;
                        }
                        seatCoords.seatCol = colRange.min;
                        break;
                    case 'R':
                        if (colRangeDiff > 1)
                        {
                            colRange.min = colRangeDiff / 2 + colRange.min + 1;
                        }
                        seatCoords.seatCol = colRange.max;
                        break;
                    default:
                        break;
                }
                if (debug)
                {
                    Console.WriteLine("{6} -> Row Range: ({0},{1}) Col Range: ({3},{4}) Seat: ({2},{5}) Seat ID: {7}", rowRange.min, rowRange.max, seatCoords.seatRow, colRange.min, colRange.max, seatCoords.seatCol, instructions[i], this.SeatId);
                }
            }

            Console.WriteLine("{0} -> Seat Coords: {1} Seat Id: {2}", instructions, seatCoords, this.SeatId);
        }
    }
}
