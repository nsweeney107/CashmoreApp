using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CashmoreApp.Models
{    
    public class Contract
    {
        public int ContractID { get; set; }
        [Required]
        [Display(Name = "Product Line")]
        public string ContractProductLine { get; set; }
        [Required]
        [Display(Name = "Purchase Order")]
        public string ContractPurchaseOrder { get; set; }
        [Display(Name = "Status")]
        public string ContractStatus { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public DateTime ContractStartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime ContractEndDate { get; set; }
        [Required]
        [Display(Name = "Contract Value")]
        public decimal ContractValue { get; set; }

        public ICollection<EntityToContract> ContractEntities { get; set; }
        public ICollection<Signatures> ContractSignatures { get; set; }
    }
}