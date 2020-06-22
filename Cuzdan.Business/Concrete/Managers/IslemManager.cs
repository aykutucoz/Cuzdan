using Cuzdan.Business.Abstract;
using Cuzdan.DataAccess.Abstract;
using Cuzdan.Entity.ComplexTypes;
using Cuzdan.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cuzdan.Business.Concrete.Managers
{
    public class IslemManager : IIslemService
    {
        IIslemDal _islemDal;
        public IslemManager(IIslemDal islemDal)
        {
            _islemDal = islemDal;
        }
        public Islem Add(Islem islem)
        {
            return _islemDal.Add(islem);
        }

        public async Task<Islem> AddAsync(Islem islem)
        {
            return await _islemDal.AddAsync(islem);
        }

        public void Delete(Islem islem)
        {
            _islemDal.Delete(islem);
        }

        public Islem GetById(int id)
        {
            return _islemDal.Get(p => p.Id == id);
        }

        public IslemComplexData GetIslemComplexDataById(int id)
        {
            return _islemDal.GetIslemComplexDataById(id);
        }

        public List<IslemComplexData> GetIslemComplexDatas(int id)
        {
            return _islemDal.GetIslemComplexDatas(id);
        }

        public List<Islem> GetList()
        {
            return _islemDal.GetAll();
        }

        public List<Islem> GetListByHisseId(int hisseId)
        {
            return _islemDal.GetAll(p => p.HisseId == hisseId);
        }

        public List<Islem> GetListByKurumId(int kurumId)
        {
            return _islemDal.GetAll(p => p.KurumId == kurumId);
        }

        public List<Islem> GetListByUserId(int userId)
        {
            return _islemDal.GetAll(p => p.UserId == userId);
        }

        public Islem Update(Islem islem)
        {
            return _islemDal.Update(islem);
        }

        public async Task<Islem> UpdateAsync(Islem islem)
        {
            return await _islemDal.UpdateAsync(islem);
        }
    }
}
