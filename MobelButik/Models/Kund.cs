using System;
using System.Collections.Generic;

#nullable disable

namespace MobelButik.Models
{
    public partial class Kund
    {
        public Kund()
        {
            OrderHistoriks = new HashSet<OrderHistorik>();
        }

        public int Id { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Adress { get; set; }
        public string Ort { get; set; }
        public int? Postnummer { get; set; }

        public static int kundnr = 1;
        public virtual ICollection<OrderHistorik> OrderHistoriks { get; set; }
    }
}
