using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

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
            Stream input = File.Open(@"C:\source\Csharp_projects\dev\AdventOfCode2020\AdventOfCode2020\Day1Input.txt", FileMode.Open);
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
                 //   PasswordCheck();
                    break;
                default:
                    break;
            }
        }
    }
}
