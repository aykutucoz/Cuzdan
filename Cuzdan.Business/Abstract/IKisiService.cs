using Cuzdan.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cuzdan.Business.Abstract
{
    public interface IKisiService
    {
        Kisi Add(Kisi user);
        Task<Kisi> AddAsync(Kisi user);
        Kisi Update(Kisi user);
        Task<Kisi> UpdateAsync(Kisi user);
        void Delete(Kisi user);
        List<Kisi> GetList();
        Kisi GetById(int id);
    }
}
