using System;
using System.Collections.Generic;

#nullable disable

namespace MobelButik.Models
{
    public partial class Tillverkare
    {
        public Tillverkare()
        {
            Produkts = new HashSet<Produkt>();
        }

        public int Id { get; set; }
        public string Namn { get; set; }
        public string Land { get; set; }

        public virtual ICollection<Produkt> Produkts { get; set; }
    }
}
