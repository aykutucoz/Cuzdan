using Cuzdan.Core.DataAccess.EntityFrameworkCore;
using Cuzdan.DataAccess.Abstract;
using Cuzdan.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cuzdan.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfHisseDal:EfEntityReporsitoryBase<Hisse,CuzdanDbContext> , IHisseDal
    {
    }
}
