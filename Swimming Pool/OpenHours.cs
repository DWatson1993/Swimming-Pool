using System;
using System.Collections.Generic;
using System.Text;

namespace Swimming_Pool 
{ 

    class OpenHours
    {
        public string DayName;
        public int HoursOpen;

        public OpenHours(string dayName, int startHour, int endHour, int endMin) 
        {
            this.DayName = dayName; 
            this.HoursOpen = HourCalculator(startHour, endHour, endMin);
        }

        public int HourCalculator(int startHour, int endHour, int endMin) 
        {
            int openHours;

            if (endMin == 00)
            {
                openHours = endHour - startHour;
            }
            else 
            {
                openHours = (endHour - startHour) + 1;
            }

            return openHours;
        }

        public static string NumToDay(int i) 
        {
            string dayName = "";

            if (i == 1) 
            {
                dayName = "Friday";
            }
            if (i == 2)
            {
                dayName = "Saturday";
            }
            if (i == 3)
            {
                dayName = "Sunday";
            }
            if (i == 4)
            {
                dayName = "Monday";
            }
            if (i == 5)
            {
                dayName = "Tuesday";
            }
            if (i == 6)
            {
                dayName = "Wednesday";
            }
            if (i == 7)
            {
                dayName = "Thursday";
            }
            return dayName;
        }
    }
}
