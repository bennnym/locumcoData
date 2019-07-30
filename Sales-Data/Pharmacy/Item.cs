using System;

namespace Sales_Data.Pharmacy
{
    public class Item
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public decimal TotalSpend { get; set; }
        public int NumberOfLocums { get; set; }
    }
}