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
        public string Photoshop { get; set; }
        public string Photography { get; set; }
        public string Illustrator { get; set; }
        public string Media { get; set; }
        public string PremierePro { get; set; }
        public string Lightroom { get; set; }
        public string Burmese { get; set; }
        public string English { get; set; }
        public string Chinese { get; set; }
        public string PackageTitle { get; set; }
        public string AboutPackage { get; set; }
        public string PackagePrice { get; set; }
        //public int UserId { get; set; }
        //public List<ProductDM> ProductDMs { get; set; }
    }
}
