using System;
using System.Collections.Generic;
using System.Text;

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
            var requiredKeys = new List<string>() { "pid", "byr", "iyr", "eyr", "hgt", "hcl", "ecl" };

            foreach (var key in requiredKeys)
            {
                if (!passport.ContainsKey(key))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
