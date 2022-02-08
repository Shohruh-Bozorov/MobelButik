using System;
using System.Collections.Generic;

#nullable disable

namespace MobelButik.Models
{
    public partial class LeveransAlternativ
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public double? Pris { get; set; }
    }
}
