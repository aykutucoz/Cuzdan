using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cuzdan.Business.Abstract;
using Cuzdan.Entity.Concrete;
using Cuzdan.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cuzdan.MvcWebUI.Controllers
{
    public class KisiController : Controller
    {
        IKisiService _kisiService;
        public KisiController(IKisiService kisiService)
        {
            _kisiService = kisiService;
        }
        public IActionResult Kisiler()
        {
            var userModel = new KisiViewModel
            {
                Kisiler = _kisiService.GetList()
            };            
            return View(userModel);
        }

        [HttpPost]
        public IActionResult Add(KisiViewModel kisiViewModel)
        {
            if (ModelState.IsValid)
            {
                var userForAdd = new Kisi
                {
                    AddedBy = "1",
                    AddedDate = DateTime.Now,
                    User_Name = kisiViewModel.Kisi.User_Name,
                    User_Code = kisiViewModel.Kisi.User_Code,
                    Email = kisiViewModel.Kisi.Email
                };
                try
                {
                    _kisiService.Add(userForAdd);
                    return RedirectToAction("Kisiler");
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return RedirectToAction("Kisiler");
        }       

        public JsonResult Edit(int id)
        {
            if (id == 0)
            {
                return Json(0);
            }

            var user = _kisiService.GetById(id);
            if (user == null)
            {
                return Json(0);
            }
            return Json(user);
        }
        [HttpPost]
        public IActionResult Edit(KisiViewModel kisiViewModel)
        {
            if (ModelState.IsValid)
            {
                var userIsValid = _kisiService.GetById(kisiViewModel.Kisi.Id);
                if (userIsValid == null)
                {
                    return RedirectToAction("Kisiler");
                }

                var userForEdit = new Kisi
                {
                    Id = userIsValid.Id,
                    AddedBy = "1",
                    AddedDate = DateTime.Now,
                    User_Name = kisiViewModel.Kisi.User_Name,
                    User_Code = kisiViewModel.Kisi.User_Code,
                    Email = kisiViewModel.Kisi.Email
                };
                try
                {
                    _kisiService.Update(userForEdit);
                    return RedirectToAction("Kisiler");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return RedirectToAction("Kisiler");
        }
    }
}
