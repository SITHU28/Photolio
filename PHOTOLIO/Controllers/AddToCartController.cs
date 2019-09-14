using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PHOTOLIO.Service;
using PHOTOLIO.ViewModel;
using PHOTOLIO.DataModel;

namespace PHOTOLIO.Web.Controllers
{
    public class AddToCartController : Controller
    {
        public List<int> li = new List<int>();
        public List<ProductVM> plist = new List<ProductVM>();       
        // GET: City
        public ActionResult Add(int Id)
        {
            if (Session["cart"] == null)
            {              
                li.Add(Id);
                Session["cart"] = li;
                ViewBag.cart = li.Count();

                Session["count"] = 1;
            }
            else
            {               
                li = (List<int>)Session["cart"];
                li.Add(Id);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
            }          

            return RedirectToAction("List", "Product");
        }



        public ActionResult Myorder()
        {
            li = (List<int>)Session["cart"];          
            
            if (li == null || li.Count() == 0)
            {               
                return RedirectToAction("CartEmpty", "Product");
            }
           
            else
            {
                ProductService service = new ProductService();
                List<ProductVM> list = new List<ProductVM>();                

                for (int i = 0; i < li.Count(); i++)
                {
                    var a = service.SelectById(li[i]);
                    list.Add(a);
                }
                return View(list);
            }         
            
        }
        
        public ActionResult Remove(int Id)// Try to still fix....
        {             
            List<int> cart = (List<int>)Session["cart"];           
            cart.Remove(Id);
            Session["cart"] = cart;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;            
            return RedirectToAction("Myorder", "AddToCart");
        }       

    }
}