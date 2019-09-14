using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PHOTOLIO.Service;
using PHOTOLIO.ViewModel;

namespace PHOTOLIO.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: Staff
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LogIn(UserVM inputVM)
        {
            UserService service = new UserService();
            UserVM result = service.LogIn(inputVM.Email, inputVM.Password);
            if(result == null)
            {
                return Json("fail");
            }
            else
            {
                Session["CurrentUser"] = result;
                return Json("success");
            }
        }

        public ActionResult LogOut()
        {
            var currentUser = (PHOTOLIO.ViewModel.UserVM)Session["CurrentUser"];
            
            if(currentUser.PositionId.Equals(1))
            {
                Session.Clear();
                Session.Abandon();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Session.Clear();
                Session.Abandon();
                return RedirectToAction("Index", "Home");
                //return Redirect(Request.UrlReferrer.ToString());
            }
        }

        public ActionResult Entry()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Entry(UserVM input)
        {
            UserService service = new UserService();
            int result = service.Save(input);
            UserVM regitAcc = service.LogIn(input.Email, input.Password);

            if (result > 0 && regitAcc != null)
            {
                Session["CurrentUser"] = regitAcc;
                return Json("success");
            }
            else
            {
                return Json("fail");
            }
        }

        public ActionResult List()
        {
            UserService service = new UserService();
            List<UserVM> list = service.SelectList();

            return View(list);
        }
      

        public ActionResult Edit(int id)
        {
            UserService service = new UserService();
            UserVM updateVM = service.SelectById(id);
            return View(updateVM);
        }

        [HttpPost]
        public JsonResult Edit(UserVM input)
        {
            UserService service = new UserService();
            int result = service.Update(input);

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
        public JsonResult Delete(UserVM input)
        {
            UserService service = new UserService();
            int result = service.Delete(input);

            if (result > 0)
            {
                return Json("success");
            }
            else
            {
                return Json("fail");
            }
        }
        public ActionResult Photographers()
        {
            UserService service = new UserService();
            List<UserVM> list = service.SelectList();

            return View(list);
        }

        public ActionResult UserProfile(int id)
        {
            UserService service = new UserService();
            UserVM updateVM = service.SelectById(id);
           
            return View(updateVM);

        }
    }
}