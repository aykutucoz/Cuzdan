using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cuzdan.Business.Abstract;
using Cuzdan.Entity.Concrete;
using Cuzdan.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Org.BouncyCastle.Bcpg;

namespace Cuzdan.MvcWebUI.Controllers
{
    public class IslemController : Controller
    {
        IIslemService _islemService;
        IKisiService _kisiService;
        
        public IslemController(IIslemService islemService, IKisiService kisiService)
        {
            _islemService = islemService;
            _kisiService = kisiService;
        }
        public List<SelectListItem> selectListKisiler()
        {
            List<SelectListItem> kisiler = (from kisi in _kisiService.GetList()
                                             select new SelectListItem
                                             {
                                                 Value = kisi.Id.ToString(),
                                                 Text = kisi.User_Name.ToString()
                                             }).ToList();
            return kisiler;
        }        

        public IActionResult Islemler()
        {
            var islemviewmodel = new IslemViewModel
            {
                selectListKisiler = selectListKisiler()                
            };
            return View(islemviewmodel);
        }

        public ActionResult GetIslemler(int id)
        {            
            var islemler = _islemService.GetIslemComplexDatas(id);
            JsonResult result = new JsonResult(JsonConvert.SerializeObject(islemler));

            return result;
        }

        public JsonResult Edit(int id)
        {
            if (id == 0)
            {
                return Json(0);
            }
            var islem = _islemService.GetIslemComplexDataById(id);
            if (islem == null)
            {
                return Json(0);
            }
            return Json(islem);
        }

        [HttpPost]
        public IActionResult Add(IslemViewModel islemViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var islemComplexData = _islemService.GetIslemComplexDataById(islemViewModel.IslemComplexData.IslemId);
                    var islem = new Islem
                    {
                        IslemAdet = islemViewModel.IslemComplexData.IslemAdet,
                        AddedBy = "1",
                        IslemDate = DateTime.Now,
                        HisseId = islemComplexData.HisseId,
                        KurumId = islemComplexData.KurumId,
                        UserId = islemComplexData.KisiId,
                        IslemKodu = islemViewModel.IslemComplexData.IslemKodu,
                        IslemDurum = islemViewModel.IslemComplexData.IslemKodu == 0 ? 0 : 1,
                        Alis = islemViewModel.IslemComplexData.IslemKodu == 0 ? 0 : (float)islemViewModel.IslemComplexData.Alis,
                        Satis = islemViewModel.IslemComplexData.IslemKodu == 1 ? 0 : (float)islemViewModel.IslemComplexData.Alis
                    };
                   
                    _islemService.Add(islem);
                    TempData["message"] = "success";
                    return Json("success");
                }
                catch (Exception)
                {
                    return RedirectToAction("Islemler");
                }
            }
            return RedirectToAction("Islemler");
        }
    }
}
