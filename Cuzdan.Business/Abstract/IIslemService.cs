using Cuzdan.Entity.ComplexTypes;
using Cuzdan.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cuzdan.Business.Abstract
{
    public interface IIslemService
    {
        Islem Add(Islem islem);
        Task<Islem> AddAsync(Islem islem);
        Islem Update(Islem islem);
        Task<Islem> UpdateAsync(Islem islem);
        void Delete(Islem islem);
        List<Islem> GetList();
        Islem GetById(int id);
        List<Islem> GetListByUserId(int userId);
        List<Islem> GetListByHisseId(int hisseId);
        List<Islem> GetListByKurumId(int kurumId);
        List<IslemComplexData> GetIslemComplexDatas(int id);
        IslemComplexData GetIslemComplexDataById(int id);
    }
}
