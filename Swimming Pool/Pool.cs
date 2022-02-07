using System;
using System.Collections.Generic;
using System.Text;

namespace Swimming_Pool
// Pool holds 660430 gallons of water
// 1 gallon chlorine : 1000 gallons water
// 10000 gallons chlorine for £800 - bulk order
// 10 gallons chlorine for £1 - standard rate
{
    class Pool
    {
        public static int PoolCapacity = 660430;
        public static int ChlorineMax = (PoolCapacity / 1000) + 1;
        public static int ChlorineBulkAmount = 10000;
        public static int ChlorineBulkCost = 800;
        public static int AnnualDealAmount = 1000000;
        public static int AnnualDealCost = 70000;

        public static int NotBulkCalculator(int amount)
        {
            int cost = (amount / 10) + 1;
            return cost;
        }
        public static int BulkCalculator(int amount)
        {
            int cost = amount * ChlorineBulkCost;
            return cost;
        }
        public static int DealCalculator(int amount)
        {
            int cost = amount * AnnualDealCost;
            return cost;
        }
    }
}
