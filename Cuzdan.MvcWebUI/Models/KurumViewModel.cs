using Cuzdan.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cuzdan.MvcWebUI.Models
{
    public class KurumViewModel
    {
        public List<Kurum> Kurumlar { get; set; }
        public Kurum Kurum { get; set; }
    }
}
