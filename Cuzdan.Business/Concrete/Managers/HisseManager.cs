using Cuzdan.Business.Abstract;
using Cuzdan.DataAccess.Abstract;
using Cuzdan.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cuzdan.Business.Concrete.Managers
{
    public class HisseManager : IHisseService
    {
        IHisseDal _hisseDal;
        public HisseManager(IHisseDal hisseDal)
        {
            _hisseDal = hisseDal;
        }

        public Hisse Add(Hisse hisse)
        {
            return _hisseDal.Add(hisse);
        }

        public async Task<Hisse> AddAsync(Hisse hisse)
        {
            return await _hisseDal.AddAsync(hisse);
        }

        public void Delete(Hisse hisse)
        {
            _hisseDal.Delete(hisse);
        }

        public Hisse GetById(int id)
        {
            return _hisseDal.Get(p => p.Id == id);
        }

        public List<Hisse> GetList()
        {
            return _hisseDal.GetAll();
        }

        public Hisse Update(Hisse hisse)
        {
            return _hisseDal.Update(hisse);
        }

        public async Task<Hisse> UpdateAsync(Hisse hisse)
        {
            return await _hisseDal.UpdateAsync(hisse);
        }
    }
}
