using Cuzdan.Business.Abstract;
using Cuzdan.DataAccess.Abstract;
using Cuzdan.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cuzdan.Business.Concrete.Managers
{
    public class KurumManager : IKurumService
    {
        IKurumDal _kurumDal;
        public KurumManager(IKurumDal kurumDal)
        {
            _kurumDal = kurumDal;
        }
        public Kurum Add(Kurum kurum)
        {
            return _kurumDal.Add(kurum);
        }

        public async Task<Kurum> AddAsync(Kurum kurum)
        {
            return await _kurumDal.AddAsync(kurum);
        }

        public void Delete(Kurum kurum)
        {
            _kurumDal.Delete(kurum);
        }

        public Kurum GetById(int id)
        {
            return _kurumDal.Get(p => p.Id == id);
        }

        public List<Kurum> GetList()
        {
            return _kurumDal.GetAll();
        }

        public Kurum Update(Kurum kurum)
        {
            return _kurumDal.Update(kurum);
        }

        public async Task<Kurum> UpdateAsync(Kurum kurum)
        {
            return await _kurumDal.UpdateAsync(kurum);
        }
    }
}
