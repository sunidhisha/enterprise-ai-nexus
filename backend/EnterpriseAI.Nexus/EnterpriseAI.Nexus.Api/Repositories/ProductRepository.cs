using EnterpriseAI.Nexus.Api.Data;
using EnterpriseAI.Nexus.Api.Entities;
using EnterpriseAI.Nexus.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseAI.Nexus.Api.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Product>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Products
            .AsNoTracking()
            .OrderBy(product => product.ProductName)
            .ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetByIdAsync(
        int productId,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(
                product => product.ProductId == productId,
                cancellationToken);
    }

    public async Task<Product?> GetByCodeAsync(
        string productCode,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(
                product => product.ProductCode == productCode,
                cancellationToken);
    }

    public async Task AddAsync(
        Product product,
        CancellationToken cancellationToken = default)
    {
        await _dbContext.Products.AddAsync(product, cancellationToken);
    }

    public async Task SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
    public async Task<Product?> GetTrackedByIdAsync(
    int productId,
    CancellationToken cancellationToken = default)
    {
        return await _dbContext.Products
            .FirstOrDefaultAsync(
                product => product.ProductId == productId,
                cancellationToken);
    }
}