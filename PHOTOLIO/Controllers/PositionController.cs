using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PHOTOLIO.Service;
using PHOTOLIO.ViewModel;

namespace PHOTOLIO.Web.Controllers
{
    public class PositionController : Controller
    {
        // GET: City
        public ActionResult Entry()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Entry(PositionVM inputVM)
        {
            PositionService service = new PositionService();
            int result = service.Save(inputVM);

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
            PositionService service = new PositionService();
            List<PositionVM> list = service.SelectList();

            return View(list);
        }

        public ActionResult Edit(int id)
        {
            PositionService service = new PositionService();
            PositionVM selectVM = service.SelectById(id);

            return View(selectVM);
        }

        [HttpPost]
        public JsonResult Edit(PositionVM inputVM)
        {
            PositionService service = new PositionService();
            int result = service.update(inputVM);

            if(result > 0)
            {
                return Json("success");
            }
            else
            {
                return Json("fail");
            }
        }

        public JsonResult Delete(PositionVM inputVM)
        {
            PositionService service = new PositionService();
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