using Cuzdan.Business.Abstract;
using Cuzdan.DataAccess.Abstract;
using Cuzdan.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cuzdan.Business.Concrete.Managers
{
    public class PortfoyManager : IPortfoyService
    {
        IPortfoyDal _portfoyDal;
        public PortfoyManager(IPortfoyDal portfoyDal)
        {
            _portfoyDal = portfoyDal;
        }
        public Portfoy Add(Portfoy portfoy)
        {
            return _portfoyDal.Add(portfoy);
        }

        public async Task<Portfoy> AddAsync(Portfoy portfoy)
        {
            return await _portfoyDal.AddAsync(portfoy);
        }

        public void Delete(Portfoy portfoy)
        {
            _portfoyDal.Delete(portfoy);
        }

        public Portfoy GetById(int id)
        {
            return _portfoyDal.Get(p => p.Id == id);
        }

        public List<Portfoy> GetList()
        {
            return _portfoyDal.GetAll();
        }

        public List<Portfoy> GetList(int id)
        {
            return _portfoyDal.GetAll(p => p.Id == id);
        }

        public Portfoy Update(Portfoy portfoy)
        {
            return _portfoyDal.Update(portfoy);
        }

        public async Task<Portfoy> UpdateAsync(Portfoy portfoy)
        {
            return await _portfoyDal.UpdateAsync(portfoy);
        }
    }
}
