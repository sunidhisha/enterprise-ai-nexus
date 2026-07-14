using EnterpriseAI.Nexus.Api.DTOs;

namespace EnterpriseAI.Nexus.Api.Interfaces;

public interface IProductService
{
    Task<ProductResponse> CreateAsync(
        CreateProductRequest request,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ProductResponse>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<ProductResponse?> GetByIdAsync(
        int productId,
        CancellationToken cancellationToken = default);
    Task<ProductResponse?> UpdateAsync(
    int productId,
    UpdateProductRequest request,
    CancellationToken cancellationToken = default);
    Task<bool> DeactivateAsync(
    int productId,
    CancellationToken cancellationToken = default);
}