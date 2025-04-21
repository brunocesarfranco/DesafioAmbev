namespace Ambev.DeveloperEvaluation.WebApi.Sales.CreateSale
{
    public class CreateSaleRequest
    {
        public List<CreateItemSaleRequest> Items { get; set; } = new();
    }

    public class CreateItemSaleRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
