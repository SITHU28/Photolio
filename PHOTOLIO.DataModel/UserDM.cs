using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace PHOTOLIO.DataModel
{
    public class UserDM
    {
        public int Id { get; set; }
        public string Profile { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int PositionId { get; set; }
        public string UserBio { get; set; }
        public string FullAddress { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }       
        public int ProductId { get; set; }
        public long Version { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedUserId { get; set; }
        public long CreatedDate { get; set; }
        public int UpdatedUserId { get; set; }
        public long UpdatedDate { get; set; }
    }
}
