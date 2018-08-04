using CashmoreApp.Data;

namespace CashmoreApp.Models
{
    public class Signatures
    {
        public int SignaturesID { get; set; }
        public ContractTypes ContractType { get; set; }
        public User HospitalSignature { get; set; }
        public User VendorSignature { get; set; }
        public int ContractID { get; set; }
        public Contract BaseContract { get; set; }
    }
}