using Cuzdan.Entity.Concrete;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cuzdan.Entity.ComplexTypes
{
    public class IslemComplexData
    {
        public int IslemId { get; set; }
        public int KurumId { get; set; }
        public int KisiId { get; set; }
        public int HisseId { get; set; }
        public string KurumAdi { get; set; }
        public string KisiAdi { get; set; }
        public string HisseAdi { get; set; }
        public int IslemAdet { get; set; }
        public int IslemKodu { get; set; }
        public float Alis { get; set; }
        public float Satis { get; set; }
        public float Maliyet { get; set; }        
        public decimal KarZarar { get; set;  }
        public float AnlikDeger { get; set; }
        public float Hedef { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }

    }
}
