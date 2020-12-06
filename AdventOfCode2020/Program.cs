using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2020
{
    class Program
    {
        public static void FixTheRiport()
        {
            SolutionForFixTheReport();
        }

        private static void SolutionForFixTheReport()
        {
            List<int> expenseReport = ReadTheReportInput();
            SearchTheResult(expenseReport);
        }

        private static List<int> ReadTheReportInput()
        {
            List<int> expenseReport = new List<int>();
            const string Path = @"C:\source\Csharp_projects\dev\AdventOfCode2020\AdventOfCode2020\Day1Input.txt";
            Stream input = File.Open(Path, FileMode.Open);
            TextReader textReader = new StreamReader(input, Encoding.UTF8);
            string line;
            while ((line = textReader.ReadLine()) != null)
            {
                string[] inputText = line.Trim().Split(',');
                foreach (var item in inputText)
                {
                    expenseReport.Add(Convert.ToInt32(item));
                }
            }

            return expenseReport;
        }

        private static void SearchTheResult(List<int> expenseReport)
        {
            int numberresult;
            int numberresulttwo;
            bool resultfound;
            FindTheResult(expenseReport, out numberresult, out numberresulttwo, out resultfound);
            WriteTheResult(numberresult, numberresulttwo, resultfound);
        }

        private static void FindTheResult(List<int> expenseReport, out int numberresult, out int numberresulttwo, out bool resultfound)
        {
            BaseSearchPartOne(expenseReport, out numberresult, out resultfound);
            BaseSearchPartTwo(expenseReport, out numberresulttwo, out resultfound);

        }



        private static void BaseSearchPartOne(List<int> expenseReport, out int numberresult, out bool resultfound)
        {
            int[] expenseNumbers = expenseReport.ToArray();
            int numberfirst;
            int numbersecond;
            numberresult = 0;
            resultfound = false;
            for (int i = 0; i < expenseNumbers.Length; i++)
            {
                for (int j = 0; j < expenseNumbers.Length; j++)
                {
                    numberfirst = expenseNumbers[i];
                    numbersecond = expenseNumbers[j];
                    if (numberfirst + numbersecond == 2020)
                    {
                        resultfound = true;
                        numberresult = numberfirst * numbersecond;
                    }
                }
            }
        }

        private static void BaseSearchPartTwo(List<int> expenseReport, out int numberresulttwo, out bool resultfound)
        {
            int[] expenseNumbers = expenseReport.ToArray();
            int numberfirst;
            int numbersecond;
            int numberthird;
            numberresulttwo = 0;
            resultfound = false;
            for (int i = 0; i < expenseNumbers.Length; i++)
            {
                for (int j = 0; j < expenseNumbers.Length; j++)
                {
                    for (int k = 0; k < expenseNumbers.Length; k++)
                    {
                        numberfirst = expenseNumbers[i];
                        numbersecond = expenseNumbers[j];
                        numberthird = expenseNumbers[k];
                        if (numberfirst + numbersecond + numberthird == 2020)
                        {
                            resultfound = true;
                            numberresulttwo = (numberfirst * numbersecond) * numberthird;
                        }
                    }
                }
            }
        }

        private static void WriteTheResult(int numberresult, int numberresulttwo, bool resultfound)
        {
            Console.WriteLine("The result is found: " + resultfound.ToString(), "/n");
            Console.WriteLine("The number is: " + numberresult.ToString());
            Console.WriteLine("The part two number is: " + numberresulttwo.ToString());
        }

        static void Main(string[] args)
        {
            ChoosePuzzle();

        }

        private static void ChoosePuzzle()
        {
            int daynum = 0;
            Console.WriteLine("Choose a day from 1-25: ");
            daynum = Convert.ToInt32(Console.ReadLine());

            switch (daynum)
            {
                case 1:
                    FixTheRiport();
                    break;
                case 2:
                    PasswordCheck();
                    break;
                case 3:
                    CountTheTrees();
                    break;
                default:
                    break;
            }
        }

        private static void CountTheTrees()
        {
           //
        }

        private static void PasswordCheck()
        {
            List<(int pwmin, int pwmax, char mustinpw, string pwtocheck)> passwordlist = ReadPasswordslist();
            CheckPaswordValidation(passwordlist);
        }

        private static void CheckPaswordValidation(List<(int pwmin, int pwmax, char mustinpw, string pwtocheck)> passwordlist)
        {
            int validPWcount, validPWcountsecond;
            CheckFirstValidation(passwordlist, out validPWcount, out validPWcountsecond);
            validPWcountsecond = CheckSecondValidation(passwordlist, validPWcountsecond);
            WriteTheResult(validPWcount, validPWcountsecond);
        }

        private static void CheckFirstValidation(List<(int pwmin, int pwmax, char mustinpw, string pwtocheck)> passwordlist, out int validPWcount, out int validPWcountsecond)
        {
            Dictionary<int, int> occurance = new Dictionary<int, int>();
            validPWcount = 0;
            validPWcountsecond = 0;
            foreach (var item in passwordlist)
            {
                int characterOccurance = 0;
                int pwmustchar = item.pwtocheck.IndexOf(item.mustinpw);
                while (pwmustchar >= 0)
                {
                    ++characterOccurance;
                    pwmustchar = item.pwtocheck.IndexOf(item.mustinpw, pwmustchar + 1);
                }
                occurance.Add(occurance.Count, characterOccurance);
                if (characterOccurance >= item.pwmin && characterOccurance <= item.pwmax)
                {
                    ++validPWcount;
                }
            }
        }

        private static int CheckSecondValidation(List<(int pwmin, int pwmax, char mustinpw, string pwtocheck)> passwordlist, int validPWcountsecond)
        {
            bool mustcharpos1;
            bool mustcharpos2;
            foreach (var item in passwordlist)
            {
                mustcharpos1 = item.pwtocheck.Length >= item.pwmin && item.pwtocheck[item.pwmin - 1] == item.mustinpw;
                mustcharpos2 = item.pwtocheck.Length >= item.pwmax && item.pwtocheck[item.pwmax - 1] == item.mustinpw;
                if (mustcharpos1 != mustcharpos2)
                {
                    ++validPWcountsecond;
                }
            }

            return validPWcountsecond;
        }

        private static void WriteTheResult(int validPWcount, int validPWcountsecond)
        {
            Console.WriteLine("The First validation result: " + validPWcount.ToString());
            Console.WriteLine("The Second validation result: " + validPWcountsecond.ToString());
        }

        private static List<(int pwmin, int pwmax, char mustinpw, string pwtocheck)> ReadPasswordslist()
        {
            List<(int pwmin, int pwmax, char mustinpw, string pwtocheck)> passwordlist = new List<(int pwmin, int pwmax, char mustinpw, string pwtocheck)>();
            const string Path = @"C:\source\Csharp_projects\dev\AdventOfCode2020\AdventOfCode2020\Day2Input.txt";
            Stream input = File.Open(Path, FileMode.Open);
            TextReader textReader = new StreamReader(input, Encoding.UTF8);
            string line;
            while ((line = textReader.ReadLine()) != null)
            {
                string[] inputText = line.Trim().Split(',');
                foreach (var item in inputText)
                {
                    string[] lineparts = item.Split(' ');
                    string[] pwrule = lineparts[0].Split('-');
                    passwordlist.Add((int.Parse(pwrule[0]), int.Parse(pwrule[1]), lineparts[1][0], lineparts[2]));
                }
            }

            return passwordlist;
        }
    }
}
