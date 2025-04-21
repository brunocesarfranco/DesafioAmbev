using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class ItemSale : BaseEntity
{
    public Guid SaleId { get; set; }
    public Sale Sale { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsCancelled { get; set; }

    // Construtor sem parâmetros para o EF Core
    private ItemSale() { }

    // Construtor com parâmetros, usado na lógica de negócios
    public ItemSale(Guid productId, int quantity, decimal unitPrice, Product product, Sale sale)
    {
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Product = product;
        Sale = sale;
        SaleId = sale.Id;

        ApplyDiscount(); // Calcula automaticamente desconto e total
    }

    // Método para aplicar o desconto
    public void ApplyDiscount()
    {
        if (Quantity < 4)
        {
            Discount = 0;
        }
        else if (Quantity >= 4 && Quantity < 10)
        {
            Discount = 0.10m;
        }
        else if (Quantity <= 20)
        {
            Discount = 0.20m;
        }
        else
        {
            throw new InvalidOperationException("A quantidade máxima por item é 20.");
        }

        var discountedTotal = Quantity * UnitPrice * (1 - Discount);
        TotalAmount = Math.Round(discountedTotal, 2);
    }

    // Método para cancelar o item
    public void CancelItem()
    {
        IsCancelled = true;
    }
}
