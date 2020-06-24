using Cuzdan.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cuzdan.Business.Abstract
{
    public interface IPortfoyService
    {
        Portfoy Add(Portfoy portfoy);
        Task<Portfoy> AddAsync(Portfoy portfoy);
        Portfoy Update(Portfoy portfoy);
        Task<Portfoy> UpdateAsync(Portfoy portfoy);
        void Delete(Portfoy portfoy);
        List<Portfoy> GetList();
        List<Portfoy> GetList(int id);
        Portfoy GetById(int id);
    }
}
