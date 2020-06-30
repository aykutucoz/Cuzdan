using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cuzdan.Business.Abstract;
using Cuzdan.Entity.Concrete;
using Cuzdan.MvcWebUI.Identity;
using Cuzdan.MvcWebUI.Models;
using Microsoft.AspNetCore.Identity;
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
        IPortfoyService _portfoyService;
        IKurumService _kurumService;
        IHisseService _hisseService;
        SignInManager<AppIdentityUser> _signInManager;



        public IslemController(IIslemService islemService, IKisiService kisiService,
                               IPortfoyService portfoyService,IKurumService kurumService,
                               IHisseService hisseService, SignInManager<AppIdentityUser> signInManager)
        {
            _islemService = islemService;
            _kisiService = kisiService;
            _portfoyService = portfoyService;
            _kurumService = kurumService;
            _hisseService = hisseService;
            _signInManager = signInManager;
        }
        private List<SelectListItem> selectListKisiler()
        {
            List<SelectListItem> kisiler = (from kisi in _kisiService.GetList()
                                             select new SelectListItem
                                             {
                                                 Value = kisi.Id.ToString(),
                                                 Text = kisi.User_Name.ToString()
                                             }).ToList();
            return kisiler;
        }
        private List<SelectListItem> selectListKurumlar()
        {
            List<SelectListItem> kurumlar = (from kurum in _kurumService.GetList()
                                             select new SelectListItem
                                             {
                                                 Value = kurum.Id.ToString(),
                                                 Text = kurum.Kurum_Adi.ToString()
                                             }).ToList();
            return kurumlar;
        }
        private List<SelectListItem> selectListHisseler()
        {
            List<SelectListItem> hisseler = (from hisse in _hisseService.GetList()
                                             select new SelectListItem
                                             {
                                                 Value = hisse.Id.ToString(),
                                                 Text = hisse.Hisse_Adi.ToString()
                                             }).ToList();
            return hisseler;
        }

        public IActionResult Islemler()
        {
            var islemviewmodel = new IslemViewModel
            {
                selectListKisiler = selectListKisiler(),
                selectListKurumlar = selectListKurumlar(),
                selectListHisseler = selectListHisseler()
            };
            return View(islemviewmodel);
        }

        public ActionResult GetIslemler(int id)
        {            
            var islemler = _portfoyService.GetIslemComplexDatas(id);
            JsonResult result = new JsonResult(JsonConvert.SerializeObject(islemler));

            return result;
        }
       
        public JsonResult Edit(int id)
        {
            if (id == 0)
            {
                return Json(0);
            }
            var islem = _portfoyService.GetIslemComplexDataById(id);
            if (islem == null)
            {
                return Json(0);
            }
            return Json(islem);
        }

        [HttpPost]
        public JsonResult Edit(IslemViewModel islemViewModel)
        {
            string msj = "";
            if (ModelState.IsValid)
            {
                try
                {
                    //var islemComplexData = _islemService.GetIslemComplexDataById(islemViewModel.IslemComplexData.IslemId);

                    var portfoy = _portfoyService.GetById(islemViewModel.IslemComplexData.IslemId);

                    if(islemViewModel.IslemComplexData.IslemKodu == 1)
                    {
                        portfoy.Adet =  portfoy.Adet + islemViewModel.IslemComplexData.IslemAdet;
                        portfoy.Tutar = portfoy.Tutar + (islemViewModel.IslemComplexData.IslemAdet * islemViewModel.IslemComplexData.Alis);
                        portfoy.Maliyet = portfoy.Tutar / portfoy.Adet;                        
                    }
                    else
                    {
                        portfoy.Adet =  portfoy.Adet - islemViewModel.IslemComplexData.IslemAdet ;
                        portfoy.Tutar = portfoy.Tutar - (islemViewModel.IslemComplexData.IslemAdet * islemViewModel.IslemComplexData.Alis);
                        if(portfoy.Maliyet < islemViewModel.IslemComplexData.Alis)
                        {
                            portfoy.Kar += (islemViewModel.IslemComplexData.Alis - portfoy.Maliyet) * islemViewModel.IslemComplexData.IslemAdet;
                        }
                        else
                        {                             
                            portfoy.Kar += (islemViewModel.IslemComplexData.Alis - portfoy.Maliyet) * islemViewModel.IslemComplexData.IslemAdet;
                        }
                        portfoy.Durum = portfoy.Adet == 0 ? 0 : 1;
                    }                                      

                    _portfoyService.Update(portfoy);

                    var islem = new Islem
                    {
                        KurumId = portfoy.KurumId,
                        HisseId = portfoy.HisseId,
                        UserId = portfoy.KisiId,
                        Maliyet = islemViewModel.IslemComplexData.Maliyet,
                        IslemKodu = islemViewModel.IslemComplexData.IslemKodu,
                        Alis = islemViewModel.IslemComplexData.Alis,
                        IslemAdet = islemViewModel.IslemComplexData.IslemAdet
                    };
                    islemLog(islem);

                    return Json(1);
                                   
                }
                catch (Exception ex)
                {
                    return Json(ex +" -- " + msj);
                }
            }
            return Json(0);
        }
        
        [HttpPost]
        public IActionResult Add(IslemViewModel islemViewModel)
        {
            if (ModelState.IsValid)
            {
                var portfoy = new Portfoy
                {
                    KurumId = islemViewModel.portfoy.KurumId,
                    HisseId = islemViewModel.portfoy.HisseId,
                    KisiId = islemViewModel.portfoy.KisiId,
                    Adet = islemViewModel.portfoy.Adet,
                    Maliyet = islemViewModel.portfoy.Maliyet,
                    Tutar = islemViewModel.portfoy.Adet * islemViewModel.portfoy.Maliyet,
                    Kar = 0,
                    Durum = 1
                };
                var islem = new Islem
                {
                    KurumId = portfoy.KurumId,
                    HisseId = portfoy.HisseId,
                    UserId = portfoy.KisiId,
                    Maliyet = portfoy.Tutar,
                    IslemKodu = 1,
                    Alis = portfoy.Maliyet,
                    IslemAdet = portfoy.Adet
                };
                try
                {
                    _portfoyService.Add(portfoy);
                    islemLog(islem);
                    return RedirectToAction("Islemler");
                }
                catch (Exception ex)
                {
                    Json(ex);
                }
            }
            return RedirectToAction("Islemler");
        }
        private void islemLog(Islem islem)
        {
            if (ModelState.IsValid)
            {
                var _islem = new Islem
                {
                    UserId = islem.UserId,
                    HisseId = islem.HisseId,
                    KurumId = islem.KurumId,
                    Maliyet = islem.Maliyet,
                    IslemDate = DateTime.Now,
                    IslemAdet = islem.IslemAdet,
                    IslemKodu = islem.IslemKodu,
                    AddedBy = User.Identity.Name,
                    Alis = islem.IslemKodu == 1 ? islem.Alis : 0,
                    Satis = islem.IslemKodu == 0 ? islem.Alis : 0,
                    Hedef = islem.Hedef,
                    AnlikDeger = islem.AnlikDeger,
                    IslemDurum = islem.IslemKodu == 0 ? 0 : 1
                };
                try
                {
                    _islemService.Add(_islem);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Hata", ex.ToString());
                }
            }
        }
    }
}
