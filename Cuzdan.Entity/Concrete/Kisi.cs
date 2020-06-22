using Cuzdan.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cuzdan.Entity.Concrete
{
    public class Kisi:IEntity
    {
        public int Id { get; set; }
        public string User_Name { get; set; }
        public string User_Code { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
