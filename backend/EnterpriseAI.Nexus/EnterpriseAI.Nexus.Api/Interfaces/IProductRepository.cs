using EnterpriseAI.Nexus.Api.Entities;

namespace EnterpriseAI.Nexus.Api.Interfaces;

public interface IProductRepository
{
    Task<IReadOnlyList<Product>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<Product?> GetByIdAsync(
        int productId,
        CancellationToken cancellationToken = default);

    Task<Product?> GetByCodeAsync(
        string productCode,
        CancellationToken cancellationToken = default);

    Task AddAsync(
        Product product,
        CancellationToken cancellationToken = default);

    Task SaveChangesAsync(
        CancellationToken cancellationToken = default);

    Task<Product?> GetTrackedByIdAsync(
    int productId,
    CancellationToken cancellationToken = default);
}