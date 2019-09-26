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
    public class UserService
    {
        public UserVM LogIn(string email,string password)
        {
            using(PHOTOLIODBContext context = new PHOTOLIODBContext())
            {

                return context.UserDMs.Where(w => w.IsDelete == false &&
                                            w.Email == email &&
                                            w.Password == password)
                                            .Select(s => new UserVM
                                            {
                                                Id = s.Id,
                                                Profile=s.Profile,
                                                Name = s.Name,
                                                UserBio=s.UserBio,
                                                PhoneNo=s.PhoneNo,
                                                FullAddress=s.FullAddress,
                                                Email=s.Email,
                                                PositionId = s.PositionId
                                            })
                                            .FirstOrDefault();
            }
        }

        public int Save(UserVM vmEntity)
        {
            var file = vmEntity.ProfileImage;
            //byte[] imageByte = null;
            //BinaryReader reader = new BinaryReader(file.InputStream);
            //imageByte = reader.ReadBytes(file.ContentLength);

            string filename = string.Empty;
            if (file != null && file.ContentLength > 0)
            {
                filename = Path.GetFileName(file.FileName);
                string imgpath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("/UserProfiles/"), filename);
                file.SaveAs(imgpath);
            }


            UserDM dmEntity = new UserDM();

            dmEntity.PositionId = vmEntity.PositionId;
            dmEntity.Profile = filename;
            dmEntity.Name = vmEntity.Name;
            dmEntity.Password = vmEntity.Password;
            dmEntity.UserBio = vmEntity.UserBio;
            dmEntity.FullAddress = vmEntity.FullAddress;
            dmEntity.PhoneNo = vmEntity.PhoneNo;
            dmEntity.Email = vmEntity.Email;

            dmEntity.CreatedUserId = vmEntity.CreatedUserId;
            dmEntity.UpdatedUserId = vmEntity.UpdatedUserId;

            dmEntity.Photoshop = vmEntity.Photoshop;
            dmEntity.Photography = vmEntity.Photography;
            dmEntity.Illustrator = vmEntity.Illustrator;
            dmEntity.Media = vmEntity.Media;
            dmEntity.PremierePro = vmEntity.PremierePro;
            dmEntity.Lightroom = vmEntity.Lightroom;
            dmEntity.Burmese = vmEntity.Burmese;
            dmEntity.English = vmEntity.English;
            dmEntity.Chinese = vmEntity.Chinese;
            dmEntity.PackageTitle = vmEntity.PackageTitle;
            dmEntity.AboutPackage = vmEntity.AboutPackage;
            dmEntity.PackagePrice = vmEntity.PackagePrice;

            long time = DateTime.Now.Ticks;
            dmEntity.Version = time;
            dmEntity.CreatedDate = time;
            dmEntity.UpdatedDate = time;

            int result = 0;                 //to know success

            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                context.UserDMs.Add(dmEntity);
                result = context.SaveChanges();
            }

            return result;
        }

        public List<UserVM> SelectList()
        {
            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                return context.UserDMs.Where(w => w.IsDelete == false).Select(s => new UserVM
                {
                    Id = s.Id,
                    Version = s.Version,
                    Profile = s.Profile,
                    Name = s.Name,
                    Password = s.Password,
                    UserBio = s.UserBio,
                    FullAddress = s.FullAddress,
                    PhoneNo = s.PhoneNo,
                    Email = s.Email,

                    Photoshop=s.Photoshop,
                    Photography=s.Photography,
                    Illustrator=s.Illustrator,
                    Media=s.Media,
                    PremierePro=s.PremierePro,
                    Lightroom=s.Lightroom,
                    Burmese=s.Burmese,
                    English=s.English,
                    Chinese=s.Chinese,
                    PackageTitle=s.PackageTitle,
                    AboutPackage=s.AboutPackage,
                    PackagePrice=s.PackagePrice,
                }).ToList();
            }
        }
       
        public UserVM SelectById(int id)
        {
            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                return context.UserDMs.Where(w => w.IsDelete == false && w.Id == id).Select(s => new UserVM
                {
                    Id = s.Id,
                    Version = s.Version,
                    Profile=s.Profile,
                    Name = s.Name,
                    Password = s.Password,
                    UserBio = s.UserBio,
                    FullAddress = s.FullAddress,
                    PhoneNo = s.PhoneNo,
                    Email = s.Email,

                    Photoshop = s.Photoshop,
                    Photography = s.Photography,
                    Illustrator = s.Illustrator,
                    Media = s.Media,
                    PremierePro = s.PremierePro,
                    Lightroom = s.Lightroom,
                    Burmese = s.Burmese,
                    English = s.English,
                    Chinese = s.Chinese,
                    PackageTitle = s.PackageTitle,
                    AboutPackage = s.AboutPackage,
                    PackagePrice = s.PackagePrice,
                }).FirstOrDefault();
            }
        }

        public List<ProductVM> GetProductsByUser(int id)
        {
            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                var products = context.ProductDMs.Where(x => x.UserId == id).Select(x => new ProductVM
                {
                    Photo = x.Photo,
                     Description = x.Description
                }).ToList();

                return products;
            }
        }

        public int Update(UserVM inputVM)
        {

            var file = inputVM.ProfileImage;
            //byte[] imageByte = null;
            //BinaryReader reader = new BinaryReader(file.InputStream);
            //imageByte = reader.ReadBytes(file.ContentLength);
            string filename = string.Empty;
            if (file != null && file.ContentLength > 0)
            {
                filename = Path.GetFileName(file.FileName);
                string imgpath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("/UserProfiles/"), filename);
                file.SaveAs(imgpath);
            }

            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                long time = DateTime.Now.Ticks;

                return context.UserDMs
                    .Where(w => w.Id == inputVM.Id && w.Version == inputVM.Version)
                    .Update(u => new UserDM
                    {
                        Profile= filename,
                        Name = inputVM.Name,
                        Password = inputVM.Password,
                        UserBio = inputVM.UserBio,
                        FullAddress = inputVM.FullAddress,
                        PhoneNo = inputVM.PhoneNo,
                        Email = inputVM.Email,

                        Photoshop = inputVM.Photoshop,
                        Photography = inputVM.Photography,
                        Illustrator = inputVM.Illustrator,
                        Media = inputVM.Media,
                        PremierePro = inputVM.PremierePro,
                        Lightroom = inputVM.Lightroom,
                        Burmese = inputVM.Burmese,
                        English = inputVM.English,
                        Chinese = inputVM.Chinese,
                        PackageTitle = inputVM.PackageTitle,
                        AboutPackage = inputVM.AboutPackage,
                        PackagePrice = inputVM.PackagePrice,

                        Version = time,
                        UpdatedUserId = inputVM.UpdatedUserId,
                        UpdatedDate = time,
                    });
            }
        }
       
        public int Delete(UserVM inputVM)
        {
            long time = DateTime.Now.Ticks;
            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                return context.UserDMs
                    .Where(w => w.Id == inputVM.Id && w.Version == inputVM.Version)
                    .Update(u => new UserDM
                    {
                        IsDelete = true,
                        Version = time,
                        UpdatedUserId = inputVM.UpdatedUserId,
                        UpdatedDate = time,
                    });
            }
        }
        //public List<ProductVM> SelectListByUserId(int UserID)
        //{
        //    using (PHOTOLIODBContext context = new PHOTOLIODBContext())
        //    {
        //        return context.ProductDMs
        //            .GroupJoin(context.UserDMs,
        //            u => u.UserId,
        //            p => p.Id,
        //            (u, p) => new { u, p })
        //            .Where(w => w.u.IsDelete == false && w.u.Id == UserID).Select(s => new ProductVM
        //            {
        //                Id = s.u.Id,
        //                Photo = s.u.Photo,
        //                Name = s.u.Name,
        //            })
        //        .ToList();
        //    }
        //}

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
                        UpdatedUserId = inputVM.UpdatedUserId,
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
