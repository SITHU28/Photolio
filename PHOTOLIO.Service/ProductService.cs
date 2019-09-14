using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using PHOTOLIO.DataModel;
using PHOTOLIO.ViewModel;
using System.IO;

namespace PHOTOLIO.Service
{
    public class ProductService
    {

        public int Save( ProductVM productVM)
        {
            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                int count = context.ProductDMs.Where(w => w.IsDelete == false && w.Name == productVM.Name).Count();
                if(count > 0)
                {
                    return 100;
                }
            }



            var file = productVM.ImageFile;
            //byte[] imageByte = null;
            //BinaryReader reader = new BinaryReader(file.InputStream);
            //imageByte = reader.ReadBytes(file.ContentLength);
            string filename = string.Empty;
            if (file != null && file.ContentLength > 0)
            {
                filename = Path.GetFileName(file.FileName);
                string imgpath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("/GALLERY/"), filename);
                file.SaveAs(imgpath);
            }

            long time = DateTime.Now.Ticks;

            ProductDM dmEntity = new ProductDM();

            dmEntity.UserId = productVM.UserId;
            dmEntity.Photo = filename;
            dmEntity.Name = productVM.Name;
            dmEntity.Description = productVM.Description;
            dmEntity.Price = productVM.Price;
            dmEntity.CategoryId = productVM.CategoryId;

            dmEntity.Version = time;
            dmEntity.CreatedUserId = productVM.CreatedUserId;
            dmEntity.UpdatedUserId = productVM.UpdatedUserId;
            dmEntity.CreatedDate = time;
            dmEntity.UpdatedDate = time;

            int result = 0;
            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                context.ProductDMs.Add(dmEntity);
                result = context.SaveChanges();
            }
            return result;
        }

        public List<ProductVM> SelectListByCategoryId(int id)
        {
            List<ProductVM> list = new List<ProductVM>();

            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                return list = context.ProductDMs
                    .Join(context.CategoryDMs,
                    p => p.CategoryId,
                    c => c.Id,
                    (p, c) => new { p, c })
                    .Where(w => w.p.CategoryId == id && w.p.IsDelete == false)
                    .Select(s => new ProductVM
                    {
                        Id = s.p.Id,
                        Version = s.p.Version,
                        Photo = s.p.Photo,
                        Name = s.p.Name,
                        Description = s.p.Description,
                        Price = s.p.Price,
                        CategoryId = s.p.CategoryId,
                        CategoryName = s.c.Name,
                    }).ToList();
            }
        }

        public List<ProductVM> SelectList()
        {
            List<ProductVM> list = new List<ProductVM>();

            using(PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                return list = context.ProductDMs
                    .Join(context.CategoryDMs,
                    p => p.CategoryId,
                    c => c.Id,
                    (p, c) => new { p,c})
                    .Where(w => w.p.IsDelete == false)
                    .Select(s => new ProductVM
                    {
                        Id = s.p.Id,
                        UserId=s.p.UserId,
                        Version = s.p.Version,
                        Photo = s.p.Photo,
                        Name = s.p.Name,
                        Description = s.p.Description,
                        Price = s.p.Price,
                        CategoryId = s.p.CategoryId,
                        CategoryName = s.c.Name,
                }).ToList();
            }
        }

        public ProductVM SelectById(int id)
        {
            using(PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                return context.ProductDMs
                    .Where(w => w.Id == id && w.IsDelete == false)
                    .Select(s => new ProductVM
                    {
                        Id = s.Id,
                        UserId=s.UserId,
                        Photo = s.Photo,
                        Name = s.Name,
                        Description = s.Description,
                        Price = s.Price,
                        CategoryId = s.CategoryId,
                        //CategoryName = s.CategoryName,
                        Version = s.Version,
                    }).FirstOrDefault();
            }
        }

        public int Update(ProductVM inputVM)
        {
         
            var file = inputVM.ImageFile;
            long time = DateTime.Now.Ticks;

            //byte[] imageByte = null;
            //BinaryReader reader = new BinaryReader(file.InputStream);
            //imageByte = reader.ReadBytes(file.ContentLength);

            string filename = string.Empty;
            if (file != null && file.ContentLength > 0)
            {
                filename = Path.GetFileName(file.FileName);
                string imgpath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("/GALLERY/"), filename);
                file.SaveAs(imgpath);
            }

            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                return context.ProductDMs
                    .Where(w => w.Id == inputVM.Id && w.Version == inputVM.Version)
                    .Update(s => new ProductDM
                    {
                        Photo = filename,
                        UserId = inputVM.UserId,
                        Name = inputVM.Name,
                        Description = inputVM.Description,
                        Price = inputVM.Price,
                        CategoryId = inputVM.CategoryId,
                        UpdatedUserId=inputVM.UpdatedUserId,
                        Version = time,
                        UpdatedDate = time,
                    });
            }
        }

        public int Delete(ProductVM inputVM)
        {
            long time = DateTime.Now.Ticks;

            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                return context.ProductDMs
                    .Where(w => w.Id == inputVM.Id && w.Version == inputVM.Version)
                    .Update(s => new ProductDM
                    {
                        IsDelete = true,
                        Version = time,
                        UpdatedDate = time,
                    });
            }
        }      

    }
}
