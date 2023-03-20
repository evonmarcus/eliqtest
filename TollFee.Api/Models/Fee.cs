using System;
using System.Collections.Generic;

#nullable disable

namespace TollFee.Api.Models
{
    public partial class Fee
    {
        public Fee(int year, TimeSpan fromMinute, TimeSpan toMinute, int price)
        {
            Year = year;
            FromMinute = fromMinute;
            ToMinute = toMinute;
            Price = price;
        }

        public int Id { get; set; }
        public int Year { get; set; }
        public TimeSpan FromMinute { get; set; }
        public TimeSpan ToMinute { get; set; }
        public int Price { get; set; }
    }
}
