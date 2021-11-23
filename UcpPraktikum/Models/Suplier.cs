using System;
using System.Collections.Generic;

namespace UcpPraktikum.Models
{
    public partial class Suplier
    {
        public Suplier()
        {
            Pembelian = new HashSet<Pembelian>();
        }

        public int IdSuplier { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }

        public virtual ICollection<Pembelian> Pembelian { get; set; }
    }
}
