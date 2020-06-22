using Cuzdan.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cuzdan.MvcWebUI.Models
{
    public class KisiViewModel
    {
        public Kisi Kisi { get; set; }
        public List<Kisi> Kisiler { get; set; }
    }
}
