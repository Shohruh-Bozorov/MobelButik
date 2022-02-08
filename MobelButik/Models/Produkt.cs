using System;
using System.Collections.Generic;

#nullable disable

namespace MobelButik.Models
{
    public partial class Produkt
    {
        public Produkt()
        {
            OrderHistoriks = new HashSet<OrderHistorik>();
        }

        public int Id { get; set; }
        public string ProduktNamn { get; set; }
        public int? TillverkareId { get; set; }
        public int? KategoriId { get; set; }
        public int? Färg { get; set; }
        public int? Material { get; set; }
        public double? Pris { get; set; }

        public virtual Färg FärgNavigation { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual Material MaterialNavigation { get; set; }
        public virtual Tillverkare Tillverkare { get; set; }
        public virtual ICollection<OrderHistorik> OrderHistoriks { get; set; }
    }
}
