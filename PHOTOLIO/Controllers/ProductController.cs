using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PHOTOLIO.Service;
using PHOTOLIO.ViewModel;

namespace PHOTOLIO.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: City
        public ActionResult Entry()
        {
            CategoryService service = new CategoryService();
            List<CategoryVM> list = service.SelectList();
            return View(list);
        }

        [HttpPost]
        public JsonResult Entry(ProductVM inputVM)
        {
            ProductService service = new ProductService();
            int result = service.Save(inputVM);

            if(result == 100)
            {
                return Json("duplicate");
            }
            else if(result != 0)
            {
                return Json("success");
            }
            else
            {
                return Json("fail");
            }

            //if (result > 0)
            //{
            //    return Json("success");
            //}
            //else
            //{
            //    return Json("fail");
            //}
        }

        public ActionResult List()
        {
            ProductService service = new ProductService();
            List<ProductVM> list = service.SelectList();

            return View(list);
        }

        public ActionResult CartEmpty()
        {
            ProductService service = new ProductService();
            List<ProductVM> list = service.SelectList();

            return View(list);
        }

        public ActionResult GetListByCategoryId(int categoryId)
        {
            ProductService service = new ProductService();
            List<ProductVM> list = service.SelectListByCategoryId(categoryId);

            return View("List",list);
        }

        public ActionResult Edit(int id)
        {
            CategoryService categoryService = new CategoryService();
            ProductService service = new ProductService();
            ProductVM updateVM = service.SelectById(id);
            updateVM.CategoryVMs = categoryService.SelectList();

            return View(updateVM);
        }

        [HttpPost]
        public JsonResult Edit(ProductVM inputVM)
        {
            ProductService service = new ProductService();
            int result = service.Update(inputVM);

            //if (result == 100)
            //{
            //    return Json("duplicate");
            //}
            //else if (result != 0)
            //{
            //    return Json("success");
            //}
            //else
            //{
            //    return Json("fail");
            //}

            if (result > 0)
            {
                return Json("success");
            }
            else
            {
                return Json("fail");
            }
        }

        public JsonResult Delete(ProductVM inputVM)
        {
            ProductService service = new ProductService();
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