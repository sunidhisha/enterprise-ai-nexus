using EnterpriseAI.Nexus.Api.DTOs;
using EnterpriseAI.Nexus.Api.Entities;
using EnterpriseAI.Nexus.Api.Interfaces;

namespace EnterpriseAI.Nexus.Api.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductResponse> CreateAsync(
        CreateProductRequest request,
        CancellationToken cancellationToken = default)
    {
        // Business Rule:
        // Product Code must be unique

        var existingProduct =
            await _repository.GetByCodeAsync(
                request.ProductCode,
                cancellationToken);

        if (existingProduct is not null)
        {
            throw new InvalidOperationException(
                $"Product code '{request.ProductCode}' already exists.");
        }

        var product = new Product
        {
            ProductCode = request.ProductCode,
            ProductName = request.ProductName,
            Description = request.Description,
            Category = request.Category,
            UnitOfMeasure = request.UnitOfMeasure,
            StandardUnitPrice = request.StandardUnitPrice,
            ReorderLevel = request.ReorderLevel
        };

        await _repository.AddAsync(product, cancellationToken);

        await _repository.SaveChangesAsync(cancellationToken);

        return new ProductResponse
        {
            ProductId = product.ProductId,
            ProductCode = product.ProductCode,
            ProductName = product.ProductName,
            Description = product.Description,
            Category = product.Category,
            UnitOfMeasure = product.UnitOfMeasure,
            StandardUnitPrice = product.StandardUnitPrice,
            ReorderLevel = product.ReorderLevel,
            IsActive = product.IsActive,
            CreatedAtUtc = product.CreatedAtUtc
        };
    }

    public async Task<IReadOnlyList<ProductResponse>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var products = await _repository.GetAllAsync(cancellationToken);

        return products
            .Select(product => new ProductResponse
            {
                ProductId = product.ProductId,
                ProductCode = product.ProductCode,
                ProductName = product.ProductName,
                Description = product.Description,
                Category = product.Category,
                UnitOfMeasure = product.UnitOfMeasure,
                StandardUnitPrice = product.StandardUnitPrice,
                ReorderLevel = product.ReorderLevel,
                IsActive = product.IsActive,
                CreatedAtUtc = product.CreatedAtUtc
            })
            .ToList();
    }

    public async Task<ProductResponse?> GetByIdAsync(
        int productId,
        CancellationToken cancellationToken = default)
    {
        var product =
            await _repository.GetByIdAsync(
                productId,
                cancellationToken);

        if (product is null)
            return null;

        return new ProductResponse
        {
            ProductId = product.ProductId,
            ProductCode = product.ProductCode,
            ProductName = product.ProductName,
            Description = product.Description,
            Category = product.Category,
            UnitOfMeasure = product.UnitOfMeasure,
            StandardUnitPrice = product.StandardUnitPrice,
            ReorderLevel = product.ReorderLevel,
            IsActive = product.IsActive,
            CreatedAtUtc = product.CreatedAtUtc
        };
    }

    public async Task<ProductResponse?> UpdateAsync(
    int productId,
    UpdateProductRequest request,
    CancellationToken cancellationToken = default)
    {
        var product = await _repository.GetTrackedByIdAsync(
            productId,
            cancellationToken);

        if (product is null)
        {
            return null;
        }

        product.ProductName = request.ProductName;
        product.Description = request.Description;
        product.Category = request.Category;
        product.UnitOfMeasure = request.UnitOfMeasure;
        product.StandardUnitPrice = request.StandardUnitPrice;
        product.ReorderLevel = request.ReorderLevel;
        product.IsActive = request.IsActive;
        product.UpdatedAtUtc = DateTime.UtcNow;

        await _repository.SaveChangesAsync(cancellationToken);

        return new ProductResponse
        {
            ProductId = product.ProductId,
            ProductCode = product.ProductCode,
            ProductName = product.ProductName,
            Description = product.Description,
            Category = product.Category,
            UnitOfMeasure = product.UnitOfMeasure,
            StandardUnitPrice = product.StandardUnitPrice,
            ReorderLevel = product.ReorderLevel,
            IsActive = product.IsActive,
            CreatedAtUtc = product.CreatedAtUtc
        };
    }
    public async Task<bool> DeactivateAsync(
    int productId,
    CancellationToken cancellationToken = default)
    {
        var product = await _repository.GetTrackedByIdAsync(
            productId,
            cancellationToken);

        if (product is null)
        {
            return false;
        }

        if (!product.IsActive)
        {
            return true;
        }

        product.IsActive = false;
        product.UpdatedAtUtc = DateTime.UtcNow;

        await _repository.SaveChangesAsync(cancellationToken);

        return true;
    }
}