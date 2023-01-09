using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022
{
    public static class Day1
    {

        public static void RunDay() {
            Console.WriteLine("Day 1");
            string? line;

            System.IO.StreamReader file = new(@"day_1\day_1_input.txt");

            int caloriesSum = 0;
            var elfCalorieData = new List<int>();

            using (file)
            {
                while (file.Peek() >= 0)
                {
                    line = file.ReadLine();

                    if(String.IsNullOrWhiteSpace(line)) {

                        elfCalorieData.Add(caloriesSum);

                        // reset the calories, we're onto the next elf
                        caloriesSum = 0;
                    } else {
                        if (Int32.TryParse(line, out int lineCalories))
                        {
                            caloriesSum += lineCalories;
                        }
                    }
                }
            }

            file.Close();

            elfCalorieData.Sort((a, b) => b.CompareTo(a));

            // pause at the end and wait for ESC
            Console.WriteLine("");
            Console.WriteLine($"Winning Elf Calories: {elfCalorieData[0]}");
            Console.WriteLine($"Second Place Elf Calories: {elfCalorieData[1]}");
            Console.WriteLine($"Third Place Elf Calories: {elfCalorieData[2]}");
            Console.WriteLine($"Sum of Elf Calories: {elfCalorieData.GetRange(0,3).Sum()}");
            Console.WriteLine("");
            Console.WriteLine("ESC to exit");
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                // do something
            }
        }
    }

}