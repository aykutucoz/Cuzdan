using Cuzdan.Core.DataAccess.EntityFrameworkCore;
using Cuzdan.DataAccess.Abstract;
using Cuzdan.Entity.ComplexTypes;
using Cuzdan.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cuzdan.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfIslemDal : EfEntityReporsitoryBase<Islem, CuzdanDbContext>, IIslemDal
    {
        public IslemComplexData GetIslemComplexDataById(int id)
        {
            using (var _context = new CuzdanDbContext())
            {
                var result = from i in _context.Islem
                             join k in _context.Kurum on i.KurumId equals k.Id
                             join kisi in _context.Kisi on i.UserId equals kisi.Id
                             join h in _context.Hisse on i.HisseId equals h.Id
                             where i.Id == id
                             select new IslemComplexData
                             {
                                 IslemId = i.Id,
                                 HisseAdi = h.Hisse_Adi,
                                 KurumAdi = k.Kurum_Adi,
                                 KisiAdi = kisi.User_Name,
                                 KisiId = kisi.Id,
                                 KurumId = k.Id,
                                 HisseId = h.Id,
                                 Maliyet = i.Maliyet,
                                 AddedBy = i.AddedBy,
                                 AddedDate = i.IslemDate,
                                 Alis = i.Alis,
                                 IslemAdet = i.IslemAdet,
                                 Hedef = i.Hedef,
                                 IslemKodu = i.IslemKodu
                             };
                return result.FirstOrDefault();
            }
        }

        public List<IslemComplexData> GetIslemComplexDatas(int id)
        {
            using (var _context = new CuzdanDbContext())
            {
                var result = from i in _context.Islem
                             join k in _context.Kurum on i.KurumId equals k.Id
                             join kisi in _context.Kisi on i.UserId equals kisi.Id
                             join h in _context.Hisse on i.HisseId equals h.Id
                             where i.UserId == id && i.IslemDurum == 1
                             select new IslemComplexData
                             {
                                 IslemId = i.Id,
                                 HisseAdi = h.Hisse_Adi,
                                 KurumAdi = k.Kurum_Adi,
                                 KisiAdi = kisi.User_Name,
                                 KisiId = kisi.Id,
                                 KurumId = k.Id,
                                 HisseId = h.Id,
                                 Maliyet = i.IslemAdet * i.Alis,
                                 AddedBy = i.AddedBy,
                                 AddedDate = i.IslemDate,
                                 Alis = i.Alis,
                                 IslemAdet = i.IslemAdet,
                                 Hedef = i.Hedef,
                                 IslemKodu = i.IslemKodu
                             };
                return result.ToList();
            }
        }
    }
}
