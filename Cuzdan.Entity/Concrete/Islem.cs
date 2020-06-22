using Cuzdan.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cuzdan.Entity.Concrete
{
    public class Islem:IEntity
    {
        public int Id { get; set; }
        public int IslemKodu { get; set; }
        public int UserId { get; set; }
        public int HisseId { get; set; }
        public int KurumId { get; set; }
        public float Alis { get; set; }
        public float Satis { get; set; }
        public float Kar { get; set; }
        public float Hedef { get; set; }
        public float Maliyet { get; set; }
        public float AnlikDeger { get; set; }
        public DateTime IslemDate { get; set; }
        public int IslemAdet { get; set; }
        public string AddedBy { get; set; }
        public int IslemDurum { get; set; }

    }
}
