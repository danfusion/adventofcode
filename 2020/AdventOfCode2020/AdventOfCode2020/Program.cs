using System;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Advent of Code";
            Console.ForegroundColor = ConsoleColor.Green;

            bool allDone = false;

            while (!allDone)
            {
                PrintMenu();

                int choice;
                while(!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 25)
                {
                    Console.WriteLine("Invalid input.");
                }

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Exiting...");
                        allDone = true;
                        break;
                    case 1:
                        Day1.runDay();
                        
                        Console.Clear();
                        break;
                    case 2:
                        Day2.runDay();

                        Console.Clear();
                        break;
                    case 3:
                        Day3.runDay();

                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Exiting...");
                        allDone = true;
                        break;
                }
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\n Welcome to Advent of Code 2020!");
            Console.WriteLine("\t Enter the Day [1]-[25]");
            Console.WriteLine("\t Enter [0] to exit");
        }
    }
}
