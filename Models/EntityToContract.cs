namespace CashmoreApp.Models
{
    public class EntityToContract
    {
        public int EntityID { get; set; }
        public Entity Entity { get; set; }
        public int ContractID { get; set; }
        public Contract Contract { get; set; }
    }
}