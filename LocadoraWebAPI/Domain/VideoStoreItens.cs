using System.ComponentModel.DataAnnotations;

namespace LocadoraWebAPI.Domain
{
    public class VideoStoreItens
    {
        [Key]
        public int VideoStoreID { get; set; }
        public int QuantityStock { get; set; }
        public int NumberRegister { get; set; }
        public virtual Category CategoryID { get; set; }
        public int CategoryId { get; set; }
    }
}