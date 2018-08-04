using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashmoreApp.Models
{
    public enum Access
    {
        Admin, FullAccess, ReadOnly 
    }

    public class User
    {
        public int UserID { get; set; }
        
        [Required]
        [StringLength(50)]
        [Column("First Name")]
        public string UserFirstName { get; set; }
        
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string UserLastName { get; set; }
        
        [Required]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }
        
        [Required]
        public string UserPassword { get; set; }
        
        public Access UserAccessLevel { get; set; }   
        
        
        public int EntityID { get; set; }
        public Entity UserEntity { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return UserFirstName + " " + UserLastName;
            }
        } 
    }
}