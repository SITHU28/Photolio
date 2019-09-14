using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHOTOLIO.DataModel
{
    public class OrderDM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Date { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public string Address { get; set; }
        public string Township { get; set; }
        public bool IsDelete { get; set; }
        public long Version { get; set; }
        public int CreatedUserId { get; set; }
        public long CreatedDate { get; set; }
        public int UpdatedUserId { get; set; }
        public long UpdatedDate { get; set; }
    }
}
