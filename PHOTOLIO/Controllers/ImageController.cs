//using PHOTOLIO.Model;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace PHOTOLIO.Controllers
//{
//    public class ImageController : Controller
//    {
//        // GET: Image
//        [HttpGet]
//        public ActionResult Add()
//        {
//            return View();
//        }
//        [HttpPost]
//        public ActionResult Add(Image imageModel)
//        {
//            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
//            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
//            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
//            imageModel.ImagePath = "/GALLERY/" + fileName;
//            fileName = Path.Combine(Server.MapPath("/GALLERY/"), fileName);
//            imageModel.ImageFile.SaveAs(fileName);
//            using (DbModel db = new DbModel())
//            {
//                db.Images.Add(imageModel);
//                db.SaveChanges();
//            }
//            ModelState.Clear();
//            return View();
//        }
//        [HttpGet]
//        public ActionResult View(int id)
//        {
//            Image imageModel = new Image();
//            using (DbModel db = new DbModel())
//            {
//                imageModel = db.Images.Where(x => x.ImageId == id).FirstOrDefault();
//            }
//            return View(imageModel);

//        }
//    }
//}