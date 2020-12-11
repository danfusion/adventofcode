using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    class Day4
    {
        public static void runDay()
        {
            // Test Input
            //System.IO.StreamReader file = new System.IO.StreamReader(@"input\Day4TestInput.txt");

            // Main Input
            System.IO.StreamReader file = new System.IO.StreamReader(@"input\Day4Input.txt");

            string contents = file.ReadToEnd();
            string[] entries = contents.Split(new String[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int validCount = 0;

            foreach (var entry in entries)
            {
                var entrySection = entry.Split(new string[] { " ", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                var passport = new Dictionary<string, string>();
                foreach (var item in entrySection)
                {
                    var temp = item.Split(':');

                    passport.Add(temp[0], temp[1]);
                }

                var validPassport = validatePassport(passport);
                if(validPassport)
                {
                    validCount++;
                }
                Console.WriteLine("Passport Id: {0} is {1}", passport.ContainsKey("pid") ? passport["pid"] : "no id" , validPassport ? "valid" : "not valid");
            }

            file.Close();

            Console.WriteLine("There are {0} valid passports.", validCount);

            // pause at the end
            System.Console.ReadLine();
        }

        private static bool validatePassport(Dictionary<string, string> passport)
        {
            bool debug = true;

            var requiredKeys = new List<string>() { "pid", "byr", "iyr", "eyr", "hgt", "hcl", "ecl" };

            foreach (var key in requiredKeys)
            {
                if (!passport.ContainsKey(key))
                {
                    if (debug)
                    {
                        Console.WriteLine("Missing Key: {0}", key);
                    }
                    return false;
                }

                string testValue;
                int testIntValue;

                switch (key)
                {
                    // byr (Birth Year) - four digits; at least 1920 and at most 2002.
                    case "byr":
                        if (passport.TryGetValue(key, out testValue)
                            && Int32.TryParse(testValue, out testIntValue) 
                            && (testIntValue < 1920
                            || testIntValue > 2020))
                        {
                            if (debug)
                            {
                                Console.WriteLine("byr error: {0}", testIntValue);
                            }
                            return false;
                        }
                        break;
                    // iyr (Issue Year) - four digits; at least 2010 and at most 2020.
                    case "iyr": 
                        if (passport.TryGetValue(key, out testValue) 
                            && Int32.TryParse(testValue, out testIntValue)
                            && (testIntValue < 2010 
                            || testIntValue > 2020))
                        {
                            if (debug)
                            {
                                Console.WriteLine("iyr error: {0}", testIntValue);
                            }
                            return false;
                        }
                        break;
                    // eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
                    case "eyr":
                        if (passport.TryGetValue(key, out testValue) 
                            && Int32.TryParse(testValue, out testIntValue)
                            && (testIntValue < 2020 
                            || testIntValue > 2030))
                        {
                            if (debug)
                            {
                                Console.WriteLine("eyr error: {0}", testIntValue);
                            }
                            return false;
                        }
                        break;
                    // hgt (Height) - a number followed by either cm or in.
                    case "hgt":
                        if (passport.TryGetValue(key, out testValue))
                        {
                            var hgtRegex = new Regex(@"([0-9]+)(cm|in)");
                            var hgtMatch = hgtRegex.Match(testValue);
                            if (!hgtMatch.Success)
                            {
                                if (debug)
                                {
                                    Console.WriteLine("hgt error: {0}", testValue);
                                }
                                return false;
                            }
                            if (Int32.TryParse(hgtMatch.Groups[1].Value, out testIntValue) || testIntValue ==0)
                            {
                                if(hgtMatch.Groups[2].Value == "cm"
                                    && testIntValue <= 150
                                    && testIntValue > 193)
                                {
                                    return false;
                                } else if (hgtMatch.Groups[2].Value == "in"
                                    && testIntValue <= 59
                                    && testIntValue > 76)
                                {
                                    if (debug)
                                    {
                                        Console.WriteLine("hgt error: {0}, {1}", testValue, testIntValue);
                                    }
                                    return false;
                                }
                            } else
                            {
                                if (debug)
                                {
                                    Console.WriteLine("hgt error: {0}, {1}", testValue, testIntValue);
                                }
                                return false;
                            }
                        }
                        break;
                    // hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
                    case "hcl":
                        var regex = new Regex(@"\#[0-9a-f]{6}");
                        if (passport.TryGetValue(key, out testValue)
                            && !regex.Match(testValue).Success)
                        {
                            if (debug)
                            {
                                Console.WriteLine("hcl error: {0}", testValue);
                            }
                            return false;
                        }
                        break;
                    // ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
                    case "ecl":
                        var eclRegex = new Regex(@"amb|blu|brn|gry|grn|hzl|oth");
                        if (passport.TryGetValue(key, out testValue)
                            && !eclRegex.Match(testValue).Success)
                        {
                            if (debug)
                            {
                                Console.WriteLine("ecl error: {0}", testValue);
                            }
                            return false;
                        }
                        break;
                    // pid (Passport ID) - a nine-digit number, including leading zeroes.
                    case "pid":
                        var pidRegex = new Regex(@"^[0-9]{9}");
                        if (passport.TryGetValue(key, out testValue)
                            && !pidRegex.Match(testValue).Success)
                        {
                            if (debug)
                            {
                                Console.WriteLine("pid error: {0}", testValue);
                            }
                            return false;
                        }
                        break;
                    default:
                        break;
                }

            }

            return true;
        }
    }
}
