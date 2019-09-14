using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHOTOLIO.DataModel
{
    public class ContactUsDM
    { 
        public int Id { get; set; }    
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool IsDelete { get; set; }
        public  long Version { get; set; }
        public int CreatedUserId { get; set; }
        public long CreatedDate { get; set; }
        public int UpdatedUserId { get; set; }
        public long UpdatedDate { get; set; }
    }
}
