using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PHOTOLIO.Service;
using PHOTOLIO.ViewModel;


namespace PHOTOLIO.Web.Controllers
{
    public class CategoryController : Controller
    {
        // GET: City
        public ActionResult Entry()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Entry(CategoryVM inputVM)
        {
            CategoryService service = new CategoryService();
            int result = service.Save(inputVM);

            if(result > 0)
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
            CategoryService service = new CategoryService();
            List<CategoryVM> list = service.SelectList();

            return View(list);
        }

        public ActionResult Edit(int id)
        {
            CategoryService service = new CategoryService();
            CategoryVM selectVM = service.SelectById(id);

            return View(selectVM);
        }

        [HttpPost]
        public JsonResult Edit(CategoryVM inputVM)
        {
            CategoryService service = new CategoryService();
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

        public JsonResult Delete(CategoryVM inputVM)
        {
            CategoryService service = new CategoryService();
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