using PHOTOLIO.Service;
using PHOTOLIO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHOTOLIO.Web.Controllers
{
    public class ContactUsController : Controller
    {
        // GET: Position
        public ActionResult Entry()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Entry(ContactUsVM input)
        {
            ContactUsService service = new ContactUsService();
            int result = service.Save(input);
            if (result > 0)
            {
                return Json("success");
            }
            else
            {
                return Json("fail");
            }

        }

        public ActionResult List()
        {
            ContactUsService service = new ContactUsService();
            List<ContactUsVM> list = service.SelectList();
            return View(list);
        }



        public ActionResult Edit(int id)
        {
            ContactUsService service = new ContactUsService();
            ContactUsVM selectVM = service.selectById(id);

            return View(selectVM);
        }

        [HttpPost]
        public JsonResult Edit(ContactUsVM inputVM)
        {
            ContactUsService service = new ContactUsService();
            int result = service.update(inputVM);

            if (result > 0)
            {
                return Json("success");
            }
            else
            {
                return Json("fail");
            }
        }


        [HttpPost]
        public JsonResult Delete(ContactUsVM inputVM)
        {
            ContactUsService service = new ContactUsService();
            int result = service.Delete(inputVM);

            if (result > 0)
            {
                return Json("success");
            }
            else
            {
                return Json("fail");
            }
        }

    }
}