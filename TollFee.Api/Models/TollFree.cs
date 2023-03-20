using System;
using System.Collections.Generic;

#nullable disable

namespace TollFee.Api.Models
{
    public partial class TollFree
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public DateTime Date { get; set; }
    }
}
