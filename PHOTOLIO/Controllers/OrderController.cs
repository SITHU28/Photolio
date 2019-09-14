using PHOTOLIO.DataModel;
using PHOTOLIO.Service;
using PHOTOLIO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHOTOLIO.Web.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Entry(int productId)
        {
            OrderVM orderVM = new OrderVM();
            UserVM currentUser = Session["CurrentUser"] as UserVM;

            if (currentUser != null)
            {
                ProductService productService = new ProductService();
                orderVM.Product = productService.SelectById(productId);

                UserService userService = new UserService();
                UserVM userVM = userService.SelectById(currentUser.Id);

                orderVM.UserId = currentUser.Id;

                if (Session["cart"] != null) { 
                List<int> cart = (List<int>)Session["cart"];
                cart.Remove(productId);
                Session["cart"] = cart;
                Session["count"] = Convert.ToInt32(Session["count"]) - 1;
                }
            }
            else
            {
                RedirectToAction("LogIn", "User");
            }           

            return View(orderVM);
        }
        

        [HttpPost]
        public JsonResult Entry(OrderVM inputVM)
        {
            OrderService service = new OrderService();
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

        public ActionResult Edit(int id)
        {
            OrderService orderService = new OrderService();
            OrderVM orderVM = orderService.SelectById(id);

            ProductService productService = new ProductService();
            orderVM.Product = productService.SelectById(orderVM.ProductId);
            return View(orderVM);
        }

        [HttpPost]
        public JsonResult Edit(OrderVM inputVM)
        {
            OrderService service = new OrderService();
            int result = service.Update(inputVM);

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
        public JsonResult Delete(OrderVM inputVM)
        {
            OrderService service = new OrderService();
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

        public ActionResult MyOrderList(int userId)
        {
            OrderService orderService = new OrderService();
            OrderVM orderList = new OrderVM();
            orderList.OrderVMs = orderService.SelectListByUserId(userId);            

            ProductService productService = new ProductService();
            orderList.Product = productService.SelectById(orderList.ProductId);            

            return View(orderList);            
        }

    }
}