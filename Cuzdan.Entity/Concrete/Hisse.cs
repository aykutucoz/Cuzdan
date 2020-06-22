using Cuzdan.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cuzdan.Entity.Concrete
{
    public class Hisse :IEntity
    {
        public int Id { get; set; }
        public string Hisse_Kodu { get; set; }
        public string Hisse_Adi { get; set; }
        public string  AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
