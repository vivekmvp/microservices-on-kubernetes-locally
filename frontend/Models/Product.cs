namespace frontend.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProdName { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? StockCount { get; set; }
        public bool? HavingWarranty { get; set; }
    }
}
