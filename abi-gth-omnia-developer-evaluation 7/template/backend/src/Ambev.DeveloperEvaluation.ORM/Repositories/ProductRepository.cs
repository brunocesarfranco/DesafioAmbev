using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of IProductRepository using Entity Framework Core
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly DefaultContext _context;

        public ProductRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
        {
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }

        public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            // Alterado para garantir que o tipo de retorno seja IEnumerable<Product>
            return await _context.Products.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(string category, CancellationToken cancellationToken = default)
        {
            return await _context.Products.Where(p => p.Category == category).ToListAsync(cancellationToken);
        }

        public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            var existingProduct = await GetByIdAsync(product.Id, cancellationToken);
            if (existingProduct == null)
                throw new InvalidOperationException("Product not found");

            // Atualizando os campos
            existingProduct.Title = product.Title;
            existingProduct.Category = product.Category;
            existingProduct.Quantity = product.Quantity;
            existingProduct.UnitPrice = product.UnitPrice;
            existingProduct.Discount = product.Discount;

            _context.Products.Update(existingProduct);
            await _context.SaveChangesAsync(cancellationToken);
            return existingProduct;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var product = await GetByIdAsync(id, cancellationToken);
            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Product?> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.Title == title, cancellationToken);
        }
    }
}
