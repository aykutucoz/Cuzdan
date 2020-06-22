using Cuzdan.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cuzdan.Business.Abstract
{
    public interface IHisseService
    {
        Hisse Add(Hisse hisse);
        Task<Hisse> AddAsync(Hisse hisse);
        Hisse Update(Hisse hisse);
        Task<Hisse> UpdateAsync(Hisse hisse);
        void Delete(Hisse hisse);
        Hisse GetById(int id);
        List<Hisse> GetList();      

    }
}
