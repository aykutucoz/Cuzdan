using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cuzdan.Business.Abstract;
using Cuzdan.Entity.Concrete;
using Cuzdan.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cuzdan.MvcWebUI.Controllers
{
    [Authorize]
    public class HisseController : Controller
    {
        IHisseService _hisseService;
        public HisseController(IHisseService hisseService)
        {
            _hisseService = hisseService;
        }
        public IActionResult Hisseler()
        {
            var hisseviewModel = new HisseViewModel
            {
                Hisseler = _hisseService.GetList()
            };
            return View(hisseviewModel);
        }

        [HttpPost]
        public IActionResult Add(HisseViewModel hisseViewModel)
        {
            if (ModelState.IsValid)
            {
                var hisseEkle = new Hisse
                {
                    AddedBy = User.Identity.Name,
                    AddedDate = DateTime.Now,
                    Hisse_Adi = hisseViewModel.Hisse.Hisse_Adi,
                    Hisse_Kodu = hisseViewModel.Hisse.Hisse_Kodu
                };
                try
                {
                    _hisseService.Add(hisseEkle);
                    return RedirectToAction("Hisseler");
                }
                catch (Exception)
                {
                    throw;
                }
                
            }
            return RedirectToAction("Hisseler");
        }

        public JsonResult Edit(int id)
        {
            if (id == 0)
            {
                return Json(0);
            }
            var hisse = _hisseService.GetById(id);
            if (hisse == null)
            {
                return Json(0);
            }
            return Json(hisse);
        }
        [HttpPost]
        public IActionResult Edit(HisseViewModel hisseViewModel)
        {
            if (ModelState.IsValid)
            {
                var hisseIsValid = _hisseService.GetById(hisseViewModel.Hisse.Id);
                if (hisseIsValid == null)
                {
                    return RedirectToAction("Hisseler");
                }
                try
                {
                    var hisseForEdit = new Hisse
                    {
                        Id = hisseIsValid.Id,
                        AddedBy = User.Identity.Name,
                        AddedDate = DateTime.Now,
                        Hisse_Adi = hisseViewModel.Hisse.Hisse_Adi,
                        Hisse_Kodu = hisseViewModel.Hisse.Hisse_Kodu
                    };
                    _hisseService.Update(hisseForEdit);
                    return RedirectToAction("Hisseler");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return RedirectToAction("Hisseler");
        }
    }
}
