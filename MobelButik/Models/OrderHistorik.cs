using System;
using System.Collections.Generic;

#nullable disable

namespace MobelButik.Models
{
    public partial class OrderHistorik
    {
        public int Id { get; set; }
        public int? KundId { get; set; }
        public int? ProduktId { get; set; }
        public static int kundnr = 1;
        public virtual Kund Kund { get; set; }
        public virtual Produkt Produkt { get; set; }
    }
}
