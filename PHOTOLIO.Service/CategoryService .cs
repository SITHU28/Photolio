using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using PHOTOLIO.DataModel;
using PHOTOLIO.ViewModel;

namespace PHOTOLIO.Service
{
    public class CategoryService
    {
        public int Save(CategoryVM inputVM)
        {
            long time = DateTime.Now.Ticks;

            CategoryDM dmEntity = new CategoryDM();

            dmEntity.Name = inputVM.Name;

            dmEntity.Version = time;
            dmEntity.CreatedUserId = inputVM.CreatedUserId;
            dmEntity.UpdatedUserId = inputVM.UpdatedUserId;
            dmEntity.CreatedDate = time;
            dmEntity.UpdatedDate = time;

            int result = 0;
            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                context.CategoryDMs.Add(dmEntity);
                result = context.SaveChanges();
            }
            return result;
        }

        public List<CategoryVM> SelectList()
        {
            List<CategoryVM> list = new List<CategoryVM>();

            using(PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
               return list = context.CategoryDMs.Where(w => w.IsDelete == false).Select(s => new CategoryVM
                {
                    Id = s.Id,
                    Name = s.Name,
                    Version = s.Version,
                }).ToList();
            }
        }

        public CategoryVM SelectById(int id)
        {
            using(PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                return context.CategoryDMs
                    .Where(w => w.Id == id && w.IsDelete == false)
                    .Select(s => new CategoryVM
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Version = s.Version,
                    }).FirstOrDefault();
            }
        }

        public int update(CategoryVM inputVM)
        {
            long time = DateTime.Now.Ticks;

            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                return context.CategoryDMs
                    .Where(w => w.Id == inputVM.Id && w.Version == inputVM.Version)
                    .Update(s => new CategoryDM
                    {
                        Name = inputVM.Name,
                        Version = time,
                        UpdatedDate = time,
                    });
            }
        }

        public int Delete(CategoryVM inputVM)
        {
            long time = DateTime.Now.Ticks;

            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                return context.CategoryDMs
                    .Where(w => w.Id == inputVM.Id && w.Version == inputVM.Version)
                    .Update(s => new CategoryDM
                    {
                        IsDelete = true,

                        Version = time,
                        UpdatedDate = time,
                    });
            }
        }
    }
}
