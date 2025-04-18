namespace Ambev.DeveloperEvaluation.WebApi.Products.CreateProduct
{
    public class CreateProductRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}