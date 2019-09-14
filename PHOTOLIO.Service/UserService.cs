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
                }).ToList();

                //return context.UserDMs.GroupJoin(context.ProductDMs,
                //    o => o.ProductId,
                //    p => p.Id,
                //    (o, p) => new { o, p }).Where(w => w.o.IsDelete == false && w.o.ProductId == productId).Select(s => new UserVM
                //{
                //    Id = s.o.Id,
                //    Version = s.o.Version,
                //    Profile = s.o.Profile,
                //    Name = s.o.Name,
                //    Password = s.o.Password,
                //    UserBio = s.o.UserBio,
                //    FullAddress = s.o.FullAddress,
                //    PhoneNo = s.o.PhoneNo,
                //    Email = s.o.Email,
                //}).ToList();
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
                }).FirstOrDefault();
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


    }
}
