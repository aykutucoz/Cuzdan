using Cuzdan.Business.Abstract;
using Cuzdan.DataAccess.Abstract;
using Cuzdan.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cuzdan.Business.Concrete.Managers
{
    public class KisiManager : IKisiService
    {
        IKisiDal _kisiDal;
        public KisiManager(IKisiDal userDal)
        {
            _kisiDal = userDal;
        }
        public Kisi Add(Kisi user)
        {
            return _kisiDal.Add(user);
        }

        public async Task<Kisi> AddAsync(Kisi user)
        {
            return await _kisiDal.AddAsync(user);
        }

        public void Delete(Kisi user)
        {
            _kisiDal.Delete(user);
        }

        public List<Kisi> GetList()
        {
            return _kisiDal.GetAll();
        }
        public Kisi GetById(int id)
        {
            return _kisiDal.Get(p => p.Id == id);
        }
        public Kisi Update(Kisi user)
        {
            return _kisiDal.Update(user);
        }

        public async Task<Kisi> UpdateAsync(Kisi user)
        {
            return await _kisiDal.UpdateAsync(user);
        }
    }
}
