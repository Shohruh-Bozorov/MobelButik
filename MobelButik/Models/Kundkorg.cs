using System;
using System.Collections.Generic;

#nullable disable

namespace MobelButik.Models
{
    public partial class Kundkorg
    {
        public int? ProduktId { get; set; }

        public virtual Produkt Produkt { get; set; }
    }
}
