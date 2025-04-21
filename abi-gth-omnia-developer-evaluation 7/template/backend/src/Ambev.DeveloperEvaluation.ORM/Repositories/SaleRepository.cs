using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Infrastructure.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;

        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            // Adiciona a venda no contexto e salva no banco de dados
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync(cancellationToken);
            return sale;
        }

        public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            // Busca a venda pelo ID
            return await _context.Sales
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public async Task<Sale?> GetByIdItemAsync(Guid id, CancellationToken cancellationToken = default)
        {
            // Busca a venda pelo ID do item (assumindo que a venda tem um item relacionado)
            return await _context.Sales
                .Include(s => s.Items)  // Caso queira incluir os itens da venda
                .FirstOrDefaultAsync(s => s.Items.Any(i => i.ProductId == id), cancellationToken);
        }

        public async Task<Sale?> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            // Verifica se a venda existe
            var existingSale = await _context.Sales
                .FirstOrDefaultAsync(s => s.Id == sale.Id, cancellationToken);

            if (existingSale == null)
                return null;

            // Atualiza a venda existente
            _context.Entry(existingSale).CurrentValues.SetValues(sale);
            await _context.SaveChangesAsync(cancellationToken);

            return existingSale;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            // Busca a venda pelo ID
            var sale = await _context.Sales
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

            if (sale == null)
                return false;

            // Remove a venda
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
