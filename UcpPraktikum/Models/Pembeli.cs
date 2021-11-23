using System;
using System.Collections.Generic;

namespace UcpPraktikum.Models
{
    public partial class Pembeli
    {
        public Pembeli()
        {
            Pemesanan = new HashSet<Pemesanan>();
        }

        public int IdPembeli { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public DateTime? TglLahir { get; set; }
        public string NoHp { get; set; }

        public virtual ICollection<Pemesanan> Pemesanan { get; set; }
    }
}
