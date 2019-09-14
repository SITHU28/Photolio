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
    public class PositionService
    {
        public int Save(PositionVM inputVM)
        {
            long time = DateTime.Now.Ticks;

            PositionDM dmEntity = new PositionDM();

            dmEntity.Name = inputVM.Name;

            dmEntity.Version = time;
            dmEntity.CreatedUserId = inputVM.CreatedUserId;
            dmEntity.UpdatedUserId = inputVM.UpdatedUserId;
            dmEntity.CreatedDate = time;
            dmEntity.UpdatedDate = time;

            int result = 0;
            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                context.PositionDMs.Add(dmEntity);
                result = context.SaveChanges();
            }
            return result;
        }

        public List<PositionVM> SelectList()
        {
            List<PositionVM> list = new List<PositionVM>();

            using(PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
               return list = context.PositionDMs.Where(w => w.IsDelete == false).Select(s => new PositionVM
                {
                    Id = s.Id,
                    Name = s.Name,
                    Version = s.Version,
                }).ToList();
            }
        }

        public PositionVM SelectById(int id)
        {
            using(PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                return context.PositionDMs
                    .Where(w => w.Id == id && w.IsDelete == false)
                    .Select(s => new PositionVM
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Version = s.Version,
                    }).FirstOrDefault();
            }
        }

        public int update(PositionVM inputVM)
        {
            long time = DateTime.Now.Ticks;

            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                return context.PositionDMs
                    .Where(w => w.Id == inputVM.Id && w.Version == inputVM.Version)
                    .Update(s => new PositionDM
                    {
                        Name = inputVM.Name,
                        Version = time,
                        UpdatedDate = time,
                    });
            }
        }

        public int Delete(PositionVM inputVM)
        {
            long time = DateTime.Now.Ticks;

            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                return context.PositionDMs
                    .Where(w => w.Id == inputVM.Id && w.Version == inputVM.Version)
                    .Update(s => new PositionDM
                    {
                        IsDelete = true,

                        Version = time,
                        UpdatedDate = time,
                    });
            }
        }
    }
}
