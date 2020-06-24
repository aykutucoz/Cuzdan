using Cuzdan.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cuzdan.Entity.Concrete
{
    public class Portfoy : IEntity
    {
        public int Id { get; set; }
        public int KurumId { get; set; }
        public int KisiId { get; set; }
        public int HisseId { get; set; }
        public float Maliyet { get; set; }
        public int Adet { get; set; }
        public decimal Kar { get; set; }
        public int Tutar { get; set; }
    }
}
