using System;
using System.Collections.Generic;

namespace UcpPraktikum.Models
{
    public partial class Pembelian
    {
        public int IdPembelian { get; set; }
        public int? IdBarang { get; set; }
        public int? IdSuplier { get; set; }
        public int? Jumlah { get; set; }
        public DateTime? TglPembelian { get; set; }

        public virtual Barang IdBarangNavigation { get; set; }
        public virtual Suplier IdSuplierNavigation { get; set; }
    }
}
