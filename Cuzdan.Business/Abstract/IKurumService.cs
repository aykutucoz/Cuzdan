using Cuzdan.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cuzdan.Business.Abstract
{
    public interface IKurumService 
    {
        Kurum Add(Kurum kurum);
        Task<Kurum> AddAsync(Kurum kurum);
        Kurum Update(Kurum kurum);
        Task<Kurum> UpdateAsync(Kurum kurum);
        void Delete(Kurum kurum);
        Kurum GetById(int id);
        List<Kurum> GetList();        
        
    }
}
