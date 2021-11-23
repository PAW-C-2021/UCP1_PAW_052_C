using System;
using System.Collections.Generic;

namespace UcpPraktikum.Models
{
    public partial class Barang
    {
        public Barang()
        {
            Pembelian = new HashSet<Pembelian>();
            Pemesanan = new HashSet<Pemesanan>();
        }

        public int IdBarang { get; set; }
        public string NamaBarang { get; set; }
        public string JenisBarang { get; set; }
        public int? HargaBeli { get; set; }
        public int? HargaJual { get; set; }

        public virtual ICollection<Pembelian> Pembelian { get; set; }
        public virtual ICollection<Pemesanan> Pemesanan { get; set; }
    }
}
