using Cuzdan.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cuzdan.Entity.Concrete
{
    public class Kurum : IEntity
    {
        public int Id { get; set; }
        public string Kurum_Kodu { get; set; }
        public string Kurum_Adi { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
