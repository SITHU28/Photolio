using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PHOTOLIO.ViewModel
{
    public class ProductVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public long Version { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedUserId { get; set; }
        public long CreatedDate { get; set; }
        public int UpdatedUserId { get; set; }
        public long UpdatedDate { get; set; }
        public HttpPostedFileWrapper ImageFile { get; set; }
        public List<CategoryVM> CategoryVMs { get; set; }
        
    }
}
