using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022
{
    public enum GameStatus
    {
        win = 6,
        loss = 0,
        draw = 3
    }

    public enum ShapeScore
    {
        rock = 1,
        paper = 2,
        scissors = 3
    }

    public static class Day2
    {

        public static void RunDay() {
            Console.WriteLine("Day 2");
            string? line;
            int totalScore = 0;

            System.IO.StreamReader file = new(@"day_2\input.txt");
            using (file)
            {
                while (file.Peek() >= 0)
                {
                    line = file.ReadLine();
                    string[] gameChoices;
                    if(!String.IsNullOrEmpty(line))
                    {
                        gameChoices = line.Split(' ');
                        // part II
                        var cheatShape = ProcessCheat(gameChoices.GetValue(0).ToString(),gameChoices.GetValue(1).ToString());
                        var gameScore = GetGameScore(gameChoices.GetValue(0).ToString(),cheatShape);
                        totalScore += gameScore;
                        Console.WriteLine($"Opponent: {gameChoices.GetValue(0)} You: {gameChoices.GetValue(1)} Score: {gameScore}");
                    }
                }
            }

            file.Close();

            // pause at the end and wait for ESC
            Console.WriteLine("");
            Console.WriteLine($"Total Score: {totalScore}");
            Console.WriteLine("");
            Console.WriteLine("ESC to exit");
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                // do something
            }
        }

/*
A - Rock = 1
B - Paper = 2
C - Scissors = 3

// part one
X - Rock
Y - Paper
Z - Scissors

Win = 6
Draw = 3
Loss = 0
*/
        private static int GetGameScore(string shape1, string shape2)
        {
            var score = 0;
            var gameStatus = GetGameStatus(shape1, shape2);

            // your shape score modifier
            switch(shape2) {
                case "X":
                    score += 1;
                    break;
                case "Y":
                    score += 2;
                    break;
                case "Z":
                    score += 3;
                    break;
            }

            // win / loss score addition
            switch(gameStatus) {
                case GameStatus.win:
                    score += (int) GameStatus.win;
                    break;
                case GameStatus.draw:
                    score += (int) GameStatus.draw;
                    break;
            }

            return score;
        }

        private static GameStatus GetGameStatus(string shape1, string shape2)
        {
            switch (shape1){
                case "A":
                    if(shape2.Equals("X"))
                    {
                        return GameStatus.draw;
                    }
                    else if (shape2.Equals("Y"))
                    {
                        return GameStatus.win;
                    }
                    else if (shape2.Equals("Z"))
                    {
                        return GameStatus.loss;
                    }
                    break;
                case "B":
                    if(shape2.Equals("X"))
                    {
                        return GameStatus.loss;
                    }
                    else if (shape2.Equals("Y"))
                    {
                        return GameStatus.draw;
                    }
                    else if (shape2.Equals("Z"))
                    {
                        return GameStatus.win;
                    }
                    break;
                case "C":
                    if(shape2.Equals("X"))
                    {
                        return GameStatus.win;
                    }
                    else if (shape2.Equals("Y"))
                    {
                        return GameStatus.loss;
                    }
                    else if (shape2.Equals("Z"))
                    {
                        return GameStatus.draw;
                    }
                    break;
                default:
                    return GameStatus.draw;
            }

            return GameStatus.draw;
        }

/*
Part II

X = loss
Y = draw
Z = win
*/
        private static string ProcessCheat(string shape1, string gameOutcome) {
            string playShape = "";

            switch(gameOutcome) {
                case "X": // outcome: loss
                    if (shape1.Equals("A"))
                    {
                        playShape = "Z"; // rock > scissors = loss
                    }
                    else if (shape1.Equals("B"))
                    {
                        playShape = "X"; // paper > rock = loss
                    }
                    else if (shape1.Equals("C"))
                    {
                        playShape = "Y"; // scissors > paper = loss
                    }
                    break;
                case "Y": // outcome: draw
                    if (shape1.Equals("A"))
                    {
                        playShape = "X"; // rock == rock = draw
                    }
                    else if (shape1.Equals("B"))
                    {
                        playShape = "Y"; // paper == paper = draw
                    }
                    else if (shape1.Equals("C"))
                    {
                        playShape = "Z"; // scissors == scissors = draw
                    }
                    break;
                case "Z": // outcome: win
                    if (shape1.Equals("A"))
                    {
                        playShape = "Y"; // rock < paper = win
                    }
                    else if (shape1.Equals("B"))
                    {
                        playShape = "Z"; // paper < scissors = win
                    }
                    else if (shape1.Equals("C"))
                    {
                        playShape = "X"; // scissors < rock = win
                    }
                    break;
            }

            return playShape;
        }

    }

}