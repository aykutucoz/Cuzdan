using Cuzdan.Core.DataAccess;
using Cuzdan.Entity.ComplexTypes;
using Cuzdan.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cuzdan.DataAccess.Abstract
{
    public interface IIslemDal:IEntityReporsitory<Islem>
    {
        List<IslemComplexData> GetIslemComplexDatas(int id);
        IslemComplexData GetIslemComplexDataById(int id);
    }
}
