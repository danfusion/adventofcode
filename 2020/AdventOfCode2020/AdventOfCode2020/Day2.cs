using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    class Day2
    {
        public static void runDay()
        {
            int validCount = 0;
            int validPart2Count = 0;
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(@"input\Day2Input.txt");

            while((line = file.ReadLine()) != null)
            {
                string[] passInstruction = line.Split(' ');
                string[] requiredRange = passInstruction[0].Split('-');
                int startRange = int.Parse(requiredRange[0]);
                int endRange = int.Parse(requiredRange[1]);
                string requiredChar = passInstruction[1].Replace(":", "").ToLower();
                int requiredCount = countLetters(passInstruction[2], requiredChar);

                /* -=-=-= Part One =-=-=- */
                if (requiredCount >= startRange && requiredCount <= endRange)
                {
                    Console.WriteLine("{0} - {1} : Required Letter: {2} : Count: {4} : Password: {3}", requiredRange[0], requiredRange[1], requiredChar, passInstruction[2], requiredCount);
                    validCount++;
                } else
                {
                    Console.WriteLine("INVALID: {0} - {1} : Required Letter: {2} : Count: {4} : Password: {3}", requiredRange[0], requiredRange[1], requiredChar, passInstruction[2], requiredCount);
                }

                /* -=-=-= Part Two =-=-=- */
                if (passInstruction[2][startRange - 1].ToString().ToLower().Equals(requiredChar)
                    ^ passInstruction[2][endRange - 1].ToString().ToLower().Equals(requiredChar)) {
                    Console.WriteLine("Part 2: {0} - {1} : {2}", passInstruction[2][startRange - 1], passInstruction[2][endRange - 1], requiredChar);
                    validPart2Count++;
                } else
                {
                    Console.WriteLine("INVALID Part 2: {0} - {1} : {2}", passInstruction[2][startRange - 1], passInstruction[2][endRange - 1], requiredChar);
                }
            }

            file.Close();

            Console.WriteLine("Part One: {0} passwords are valid", validCount);
            Console.WriteLine("Part Twp: {0} passwords are valid", validPart2Count);

            // pause at the end
            System.Console.ReadLine();
        }

        private static int countLetters(string srcString, string searchChar)
        {
            int letterCount = 0;

            foreach (var ch in srcString)
            {
                if (ch.ToString().ToLower().Equals(searchChar))
                {
                    letterCount++;
                }
            }

            return letterCount;
        }
    }
}
