using EntityFramework.Extensions;
using PHOTOLIO.DataModel;
using PHOTOLIO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHOTOLIO.Service
{
   public class ContactUsService
    {
        public int Save(ContactUsVM vmEntity)
        {
            long time = DateTime.Now.Ticks;
            int effectedRowCount = 0;

            ContactUsDM dmEntity = new ContactUsDM();
            //dmEntity.UserId = vmEntity.UserId;
            dmEntity.Name = vmEntity.Name;
            dmEntity.Email = vmEntity.Email;
            dmEntity.Message = vmEntity.Message;

            dmEntity.Version = time;
            dmEntity.CreatedUserId = vmEntity.CreatedUserId;
            dmEntity.CreatedDate = vmEntity.CreatedDate;
            dmEntity.UpdatedUserId = vmEntity.UpdatedUserId;
            dmEntity.UpdatedDate = vmEntity.UpdatedDate;

            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                context.ContactUsDMs.Add(dmEntity);
                effectedRowCount = context.SaveChanges();
            }

            return effectedRowCount;
        }

        public List<ContactUsVM> SelectList()
        {
            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                return context.ContactUsDMs.Where(w => w.IsDelete == false).Select(s => new ContactUsVM
                {
                    Id = s.Id,
                    Version = s.Version,
                    Name = s.Name,
                    Email = s.Email,
                    Message = s.Message,


                })
                        .ToList();
            }
        }

        public ContactUsVM selectById(int id)
        {
            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                return context.ContactUsDMs
                    .Where(w => w.Id == id && w.IsDelete == false)
                    .Select(s => new ContactUsVM
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Email = s.Email,
                        Message = s.Message,
                        Version = s.Version,
                    }).FirstOrDefault();
            }
        }

        public int update(ContactUsVM inputVM)
        {
            long time = DateTime.Now.Ticks;

            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                return context.ContactUsDMs
                    .Where(w => w.Id == inputVM.Id && w.Version == inputVM.Version)
                    .Update(s => new ContactUsDM
                    {
                        Name = inputVM.Name,
                        Email = inputVM.Email,
                        Message = inputVM.Message,
                        Version = time,
                        UpdatedDate = time,
                    });
            }
        }


        public int Delete(ContactUsVM inputVM)
        {
            long time = DateTime.Now.Ticks;

            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                return context.ContactUsDMs
                    .Where(w => w.Id == inputVM.Id && w.Version == inputVM.Version)
                    .Update(s => new ContactUsDM
                    {
                        IsDelete = true,

                        Version = time,
                        UpdatedDate = time,
                    });
            }
        }

    }
}
