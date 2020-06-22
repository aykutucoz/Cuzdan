using Cuzdan.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cuzdan.MvcWebUI.Models
{
    public class HisseViewModel
    {
        public Hisse Hisse { get; set; }
        public List<Hisse> Hisseler { get; set; }
    }
}
