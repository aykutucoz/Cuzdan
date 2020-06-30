using Cuzdan.Entity.ComplexTypes;
using Cuzdan.Entity.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cuzdan.MvcWebUI.Models
{
    public class IslemViewModel
    {
        public List<IslemComplexData> Islemler { get; set; }
        public IslemComplexData IslemComplexData { get; set; }
        public Islem islem { get; set; }
        public Kisi kisi { get; set; }
        public Kurum kurum { get; set; }
        public Hisse hisse { get; set; }
        public Portfoy portfoy { get; set; }
        public List<SelectListItem> selectListKisiler { get; set; }
        public List<SelectListItem> selectListKurumlar { get; set; }
        public List<SelectListItem> selectListHisseler { get; set; }
    }
}
