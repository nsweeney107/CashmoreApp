using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CashmoreApp.Models
{
    public enum EntityTypes
    {
        Hospital, Vendor
    }
    public class Entity
    {
        public int EntityID { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string EntityName { get; set; }
        [Required]
        [Display(Name = "Address Line 1")]
        public string EntityAddress1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string EntityAddress2 { get; set; }
        [Required]
        [Display(Name = "City")]
        public string EntityCity { get; set; }
        [Required]
        [Display(Name = "State")]
        public string EntityState { get; set; }
        [Required]
        [Display(Name = "Zipcode")]
        public string EntityZipcode { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string EntityCountry { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string EntityPhoneNumber { get; set; }
        // The type is used to differentiate between Vendors and Hospitals
        [Display(Name = "Type")]
        public EntityTypes EntityType { get; set; }
        
        public ICollection<User> EntityUsers { get; set; }
        public ICollection<EntityToContract> EntityContracts { get; set; }
    }
}