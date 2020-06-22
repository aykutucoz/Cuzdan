using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cuzdan.Business.Abstract;
using Cuzdan.Entity.Concrete;
using Cuzdan.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cuzdan.MvcWebUI.Extensions;

namespace Cuzdan.MvcWebUI.Controllers
{
    [Authorize]
    public class KurumController : Controller
    {
        IKurumService  _kurumService;
        public KurumController(IKurumService kurumService)
        {
            _kurumService = kurumService;
        }
        public IActionResult Kurumlar()
        {
            var kurumviewmodel = new KurumViewModel
            {
                Kurumlar = _kurumService.GetList()
            };
            return View(kurumviewmodel);
        }

        public IActionResult Add(KurumViewModel kurumViewModel)
        {
            if (ModelState.IsValid)
            {
                var kurumEkle = new Kurum
                {
                    AddedBy = "1",
                    Kurum_Adi = kurumViewModel.Kurum.Kurum_Adi,
                    Kurum_Kodu= kurumViewModel.Kurum.Kurum_Kodu,
                    AddedDate = DateTime.Now
                };
                try
                {
                    _kurumService.Add(kurumEkle);
                    return RedirectToAction("Kurumlar");
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return RedirectToAction("Kurumlar");
        }

        public JsonResult Edit(int id)
        {
            if (id == 0)
            {
                return Json(0);
            }
            var kurum = _kurumService.GetById(id);
            if (kurum == null)
            {
                return Json(0);
            }
            return Json(kurum);
        }

        [HttpPost]
        public IActionResult Edit(KurumViewModel kurumViewModel)
        {
            if (ModelState.IsValid)
            {
                var kurumIsValid = _kurumService.GetById(kurumViewModel.Kurum.Id);
                if (kurumIsValid == null)
                {
                    return RedirectToAction("Kurumlar");
                }
                try
                {
                    var kurumForEdit = new Kurum
                    {
                        AddedBy = "1",
                        AddedDate = DateTime.Now,
                        Id = kurumIsValid.Id,
                        Kurum_Adi = kurumViewModel.Kurum.Kurum_Adi,
                        Kurum_Kodu = kurumViewModel.Kurum.Kurum_Kodu
                    };

                    _kurumService.Update(kurumForEdit);
                    TempData["message"] = "success";
                    return RedirectToAction("Kurumlar");
                }
                catch (Exception)
                {
                    TempData["message"] = "error";
                    return RedirectToAction("Kurumlar");
                }
            }
            return RedirectToAction("Kurumlar");

        }

        public JsonResult Delete(int id)
        {
            if (id > 0)
            {
                var kurum = _kurumService.GetById(id);

                if (kurum == null)
                {
                    return Json(0);
                }                
                _kurumService.Delete(kurum);
                return Json(1);
            }            
            return Json(0);
        }
        
    }
}
