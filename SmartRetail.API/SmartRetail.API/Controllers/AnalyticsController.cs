using Microsoft.AspNetCore.Mvc;
using SmartRetail.Domain.UseCases;
using SmartRetail.Infrastructure.Repositories;
using SmartRetail.API.DTOs;

namespace SmartRetail.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AnalyticsController : ControllerBase
{
    private readonly AnalyticsUseCase _analyticsUseCase;

    public AnalyticsController()
    {
        // Dependency Injection can be used here, but for simplicity:
        var salesRepo = new MockSalesRepository();
        var productRepo = new MockProductRepository();
        var inventoryRepo = new MockInventoryRepository();
        _analyticsUseCase = new AnalyticsUseCase(salesRepo, productRepo, inventoryRepo);
    }

    /// <summary>
    /// Get daily sales trend for line chart
    /// </summary>
    [HttpGet("sales/daily")]
    [ProducesResponseType(typeof(DailySalesTrendResponse), 200)]
    public async Task<IActionResult> GetDailySalesTrend([FromQuery] int days = 7)
    {
        var result = await _analyticsUseCase.GetDailySalesTrendAsync(days);
        return Ok(new DailySalesTrendResponse(result.Labels, result.Values, result.Title));
    }

    /// <summary>
    /// Get low stock alerts for inventory monitoring
    /// </summary>
    [HttpGet("inventory/low-stock")]
    [ProducesResponseType(typeof(LowStockResponse), 200)]
    public async Task<IActionResult> GetLowStock([FromQuery] double thresholdMultiplier = 1.0)
    {
        var result = await _analyticsUseCase.GetLowStockAlertsAsync(thresholdMultiplier);
        return Ok(new LowStockResponse(
            result.Data.Select(x => new LowStockItemResponse(x.ProductName, x.CurrentStock, x.Threshold)).ToList(),
            result.Count,
            result.Title
        ));
    }

    /// <summary>
    /// Get top selling products for pie chart
    /// </summary>
    [HttpGet("products/top")]
    [ProducesResponseType(typeof(TopProductsResponse), 200)]
    public async Task<IActionResult> GetTopProducts([FromQuery] int limit = 5)
    {
        var result = await _analyticsUseCase.GetTopProductsAsync(limit);
        return Ok(new TopProductsResponse(result.Labels, result.Values, result.Title));
    }

    /// <summary>
    /// Get KPI summary cards (total sales, avg order value, etc.)
    /// </summary>
    [HttpGet("kpi/summary")]
    [ProducesResponseType(typeof(KpiSummaryResponse), 200)]
    public async Task<IActionResult> GetKpiSummary()
    {
        var result = await _analyticsUseCase.GetKpiSummaryAsync();
        return Ok(new KpiSummaryResponse(
            result.TotalSales,
            result.TotalQuantity,
            result.AvgOrderValue,
            result.TransactionCount
        ));
    }
}