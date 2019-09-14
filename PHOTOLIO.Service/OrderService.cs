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
    public class OrderService
    {
        public int Save(OrderVM inputVM)
        {
            OrderDM inputDM = new OrderDM();

            inputDM.UserId = inputVM.UserId;
            inputDM.ProductId = inputVM.ProductId;
            inputDM.Date = inputVM.Date;
            inputDM.Quantity = inputVM.Quantity;
            inputDM.TotalPrice = inputVM.TotalPrice;
            inputDM.Address = inputVM.Address;
            inputDM.Township = inputVM.Township;
            inputDM.CreatedUserId = inputVM.CreatedUserId;
            inputDM.UpdatedUserId = inputVM.UpdatedUserId;

            long time = DateTime.Now.Ticks;

            inputDM.Version = time;
            inputDM.CreatedDate = time;
            inputDM.UpdatedDate = time;

            int result = 0;
            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                context.OrderDMs.Add(inputDM);
                result = context.SaveChanges();
            }

            return result;
        }

        public int Update(OrderVM inputVM)
        {
            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                long time = DateTime.Now.Ticks;

                return context.OrderDMs.Where(w => w.Id == inputVM.Id && w.Version == inputVM.Version)
                        .Update(u => new OrderDM
                        {
                            UserId = inputVM.UserId,
                            ProductId = inputVM.ProductId,
                            Date = inputVM.Date,
                            Quantity = inputVM.Quantity,
                            TotalPrice = inputVM.TotalPrice,
                            Address = inputVM.Address,
                            Township = inputVM.Township,
                            Version = time,
                            UpdatedUserId = inputVM.UpdatedUserId,
                            UpdatedDate = time
                        });
            }
        }

        public int Delete(OrderVM inputVM)
        {
            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                long time = DateTime.Now.Ticks;

                return context.OrderDMs.Where(w => w.Id == inputVM.Id && w.Version == inputVM.Version)
                        .Update(u => new OrderDM
                        {
                            IsDelete = true,
                            Version = time,
                            UpdatedUserId = inputVM.UpdatedUserId,
                            UpdatedDate = time,
                        });
            }
        }
        public List<OrderVM> SelectList(int productId)
        {
            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                return context.OrderDMs
                    .GroupJoin(context.ProductDMs,
                    o => o.ProductId,
                    p => p.Id,
                    (o, p) => new { o, p })

                    .Where(w => w.o.IsDelete == false && w.o.ProductId == productId).Select(s => new OrderVM
                    {
                        Id = s.o.Id,
                        Version = s.o.Version,                        
                        Date = s.o.Date,
                        Quantity = s.o.Quantity,
                        TotalPrice = s.o.TotalPrice,
                        Address = s.o.Address,
                        Township = s.o.Township,
                        ProductName = s.p.FirstOrDefault().Name,
                        Price = s.p.FirstOrDefault().Price,
                    })
                .ToList();
            }
        }

        public OrderVM SelectById(int id)
        {
            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                return context.OrderDMs.Where(w => w.IsDelete == false && w.Id == id).Select(s => new OrderVM
                {
                    Id = s.Id,
                    Version = s.Version,
                    ProductId = s.ProductId,
                    UserId = s.UserId,
                    Date = s.Date,
                    Quantity = s.Quantity,
                    TotalPrice = s.TotalPrice,
                    Address = s.Address,
                    Township = s.Township,
                })
                .FirstOrDefault();
            }
        }

        public List<OrderVM> SelectListByUserId(int userId)
        {
            using (PHOTOLIODBContext context = new PHOTOLIODBContext())
            {
                return context.OrderDMs
                    .GroupJoin(context.ProductDMs,
                    o => o.ProductId,
                    p => p.Id,
                    (o, p) => new { o, p })                   
                    .Where(w => w.o.IsDelete == false && w.o.UserId == userId).Select(s => new OrderVM
                    {
                        Id = s.o.Id,
                        Version = s.o.Version,                        
                        Date = s.o.Date,
                        Quantity = s.o.Quantity,
                        TotalPrice = s.o.TotalPrice,
                        Address = s.o.Address,
                        Township = s.o.Township,
                        ProductName = s.p.FirstOrDefault().Name,
                        Price = s.p.FirstOrDefault().Price,    
                    })
                .ToList();
            }
        }

    }
}
