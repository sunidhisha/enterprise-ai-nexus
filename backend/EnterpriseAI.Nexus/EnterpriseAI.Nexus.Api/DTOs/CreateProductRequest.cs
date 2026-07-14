using System.ComponentModel.DataAnnotations;

namespace EnterpriseAI.Nexus.Api.DTOs;

public class CreateProductRequest
{
    [Required]
    [MaxLength(50)]
    public string ProductCode { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string ProductName { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }

    [Required]
    [MaxLength(100)]
    public string Category { get; set; } = string.Empty;

    [Required]
    [MaxLength(30)]
    public string UnitOfMeasure { get; set; } = string.Empty;

    [Range(0, double.MaxValue)]
    public decimal StandardUnitPrice { get; set; }

    [Range(0, int.MaxValue)]
    public int ReorderLevel { get; set; }
}