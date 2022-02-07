using System;
using System.Collections.Generic;
using System.Text;

namespace Swimming_Pool
{
    class Day
    {
        public int DayNum;
        public int Adults;
        public int Children;

        public Day(int dayNum, int adults, int children)
        {
            this.DayNum = dayNum;
            this.Adults = adults;
            this.Children = children;
        }
    }
}
