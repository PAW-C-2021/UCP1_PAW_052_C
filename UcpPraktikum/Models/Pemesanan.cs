using System;
using System.Collections.Generic;

namespace UcpPraktikum.Models
{
    public partial class Pemesanan
    {
        public int IdPesanan { get; set; }
        public int? IdPelanggan { get; set; }
        public int? IdBarang { get; set; }
        public int? Jumlah { get; set; }
        public DateTime? TglPemesanan { get; set; }

        public virtual Barang IdBarangNavigation { get; set; }
        public virtual Pembeli IdPelangganNavigation { get; set; }
    }
}
