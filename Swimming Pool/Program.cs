using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Swimming_Pool
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] hourInput = ReadHoursInput();
            string[] dayInput = ReadDaysInput();
            var openHours = ReadOpenHours(hourInput);
            var day = new List<Day>(ReadDays(dayInput));
            int part1 = Part1(openHours);
            int part2 = Part2(part1);
            int part3 = Part3(openHours);
            Part4(part3, day);
        }

        static string[] ReadHoursInput()
        {
            string[] input = File.ReadAllLines("input.txt");
            var hourInput = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                hourInput.Add(input[i]);
            }
            string[] hourInputSA = hourInput.ToArray();
            return hourInputSA;
        }
        static string[] ReadDaysInput()
        {
            string[] input = File.ReadAllLines("input.txt");
            var dayInput = new List<string>();
            for (int i = 8; i <= input.Length - 1; i++)
            {
                dayInput.Add(input[i]);
            }
            string[] dayInputSA = dayInput.ToArray();
            return dayInputSA;
        }
        static Dictionary<string, int> ReadOpenHours(string[] input)
        {
            var openHours = new Dictionary<string, int>();

            foreach (string line in input)
            {
                //DayName
                string[] split1 = line.Split(": ");
                string dayName = split1[0];

                //StartTime
                string[] split2 = split1[1].Split(" - ");
                string[] startTime = split2[0].Split(":");
                int startHour = Convert.ToInt32(startTime[0]);

                //FinishTime
                string[] endTime = split2[1].Split(":");
                int endHour = Convert.ToInt32(endTime[0]);
                int endMin = Convert.ToInt32(endTime[1]);

                var openHoursToAdd = new OpenHours(dayName, startHour, endHour, endMin);
                int hours = openHoursToAdd.HourCalculator(startHour, endHour, endMin);
                openHours.Add(dayName, hours);
            }
            return openHours;
        }
        static List<Day> ReadDays(string[] dayInput)
        {
            var day = new List<Day>();

            foreach (string line in dayInput)
            {
                //Day Number
                string[] split1 = line.Split(": ");
                string[] daySplit = split1[0].Split(" ");
                int dayNum = Convert.ToInt32(daySplit[1]);

                //Adults
                string[] split2 = split1[1].Split(", ");
                string[] adultSplit = split2[0].Split(" ");
                int adultNum = Convert.ToInt32(adultSplit[0]);

                //Children
                string[] childrenSplit = split2[1].Split(" ");
                int childrenNum = Convert.ToInt32(childrenSplit[0]);

                var dayToAdd = new Day(dayNum, adultNum, childrenNum);
                day.Add(dayToAdd);
            }
            return day;
        }
        static int Part1(Dictionary<string, int> openHours)
        {
            int total = 0;

            foreach (var day in openHours)
            {
                var hours = day.Value;
                int subTotal = hours * Pool.ChlorineMax;
                total += subTotal;
            }
            Console.WriteLine("Part 1 = " + total);
            return total;
        }
        static int Part2(int chlorinePerWeek)
        {
            int notBulkAmount = chlorinePerWeek % Pool.ChlorineBulkAmount;
            int bulkAmount = chlorinePerWeek / Pool.ChlorineBulkAmount;
            int notBulkCost = Pool.NotBulkCalculator(notBulkAmount);
            int bulkCost = Pool.BulkCalculator(bulkAmount);
            int totalCost = notBulkCost + bulkCost;
            Console.WriteLine("Part 2 = £" + totalCost);
            return totalCost;
        }
        static int Part3(Dictionary<string, int> openHours)
        {
            int annualAmount = 0;
            int i = 0;

            while (i < 365) 
            {
                for (int r = 1; r <= 7; r++)
                {
                    int subTotal = 0;
                    string dayName = OpenHours.NumToDay(r);
                    int hours = openHours[dayName];
                    subTotal = hours * Pool.ChlorineMax;
                    annualAmount += subTotal;
                    i++;
                }
            }


            int notDealAmount = annualAmount % Pool.AnnualDealAmount;
            int dealAmount = annualAmount / Pool.AnnualDealAmount;
            int notBulkAmount = notDealAmount % Pool.ChlorineBulkAmount;
            int bulkAmount = notDealAmount / Pool.ChlorineBulkAmount;

            int dealCost = Pool.DealCalculator(dealAmount);
            int bulkCost = Pool.BulkCalculator(bulkAmount);
            int standardCost = Pool.NotBulkCalculator(notBulkAmount);

            int totalCost = dealCost + bulkCost + standardCost;
            Console.WriteLine("Part 3 = £" + totalCost);
            return totalCost;
        }
        static void Part4(int annualCost, List<Day> days) 
        {
            int annualIncome = 0;

            foreach (var day in days) 
            {
                int adults = day.Adults;
                int children = day.Children;
                int subTotal = (adults * 10) + (children * 7);
                annualIncome += subTotal;
            }

            Console.WriteLine("Part 4 = £" + (annualIncome - annualCost));
        }
    }
}
