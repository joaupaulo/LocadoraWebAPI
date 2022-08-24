namespace LocadoraWebAPI.Domain
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public virtual VideoStoreItens VideoStoreItens { get; set; }
    }
}