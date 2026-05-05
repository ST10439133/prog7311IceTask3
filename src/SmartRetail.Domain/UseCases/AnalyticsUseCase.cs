using SmartRetail.Domain.Entities;
using SmartRetail.Domain.Interfaces;

namespace SmartRetail.Domain.UseCases;

public class AnalyticsUseCase
{
    private readonly ISalesRepository _salesRepository;
    private readonly IProductRepository _productRepository;
    private readonly IInventoryRepository _inventoryRepository;

    public AnalyticsUseCase(
        ISalesRepository salesRepository,
        IProductRepository productRepository,
        IInventoryRepository inventoryRepository)
    {
        _salesRepository = salesRepository;
        _productRepository = productRepository;
        _inventoryRepository = inventoryRepository;
    }

    public async Task<DailySalesTrendDto> GetDailySalesTrendAsync(int days = 7)
    {
        var endDate = DateTime.Now;
        var startDate = endDate.AddDays(-days);

        var sales = await _salesRepository.GetSalesByDateRangeAsync(startDate, endDate);

        var dailyTotals = sales
            .GroupBy(s => s.Timestamp.Date)
            .ToDictionary(g => g.Key.ToString("yyyy-MM-dd"), g => g.Sum(s => s.TotalAmount));

        return new DailySalesTrendDto
        {
            Labels = dailyTotals.Keys.ToList(),
            Values = dailyTotals.Values.Select(v => (double)v).ToList(),
            Title = "Daily Sales Trend (Last 7 Days)"
        };
    }

    public async Task<LowStockResponseDto> GetLowStockAlertsAsync(double thresholdMultiplier = 1.0)
    {
        var inventory = await _inventoryRepository.GetCurrentInventoryAsync();
        var products = (await _productRepository.GetAllProductsAsync())
            .ToDictionary(p => p.Id, p => p);

        var lowStockItems = new List<LowStockItemDto>();

        foreach (var item in inventory)
        {
            if (item.QuantityOnHand < item.ReorderThreshold * thresholdMultiplier)
            {
                if (products.TryGetValue(item.ProductId, out var product))
                {
                    lowStockItems.Add(new LowStockItemDto
                    {
                        ProductName = product.Name,
                        CurrentStock = item.QuantityOnHand,
                        Threshold = item.ReorderThreshold
                    });
                }
            }
        }

        return new LowStockResponseDto
        {
            Data = lowStockItems,
            Count = lowStockItems.Count,
            Title = "Low Stock Alerts"
        };
    }

    public async Task<TopProductsResponseDto> GetTopProductsAsync(int limit = 5)
    {
        var endDate = DateTime.Now;
        var startDate = endDate.AddDays(-30);

        var sales = await _salesRepository.GetSalesByDateRangeAsync(startDate, endDate);
        var products = (await _productRepository.GetAllProductsAsync())
            .ToDictionary(p => p.Id, p => p);

        var topProducts = sales
            .GroupBy(s => s.ProductId)
            .Select(g => new { ProductId = g.Key, TotalQuantity = g.Sum(s => s.Quantity) })
            .OrderByDescending(x => x.TotalQuantity)
            .Take(limit)
            .ToList();

        return new TopProductsResponseDto
        {
            Labels = topProducts.Select(x => products.TryGetValue(x.ProductId, out var p) ? p.Name : "Unknown").ToList(),
            Values = topProducts.Select(x => x.TotalQuantity).ToList(),
            Title = $"Top {limit} Selling Products"
        };
    }

    public async Task<KpiSummaryResponseDto> GetKpiSummaryAsync()
    {
        var endDate = DateTime.Now;
        var startDate = endDate.AddDays(-7);

        var sales = (await _salesRepository.GetSalesByDateRangeAsync(startDate, endDate)).ToList();

        var totalSales = sales.Sum(s => s.TotalAmount);
        var totalQuantity = sales.Sum(s => s.Quantity);
        var avgOrderValue = sales.Any() ? totalSales / sales.Count : 0;

        return new KpiSummaryResponseDto
        {
            TotalSales = (double)totalSales,
            TotalQuantity = totalQuantity,
            AvgOrderValue = (double)avgOrderValue,
            TransactionCount = sales.Count
        };
    }
}

// DTOs for return types
public class DailySalesTrendDto
{
    public List<string> Labels { get; set; } = new();
    public List<double> Values { get; set; } = new();
    public string Title { get; set; } = string.Empty;
}

public class LowStockItemDto
{
    public string ProductName { get; set; } = string.Empty;
    public int CurrentStock { get; set; }
    public int Threshold { get; set; }
}

public class LowStockResponseDto
{
    public List<LowStockItemDto> Data { get; set; } = new();
    public int Count { get; set; }
    public string Title { get; set; } = string.Empty;
}

public class TopProductsResponseDto
{
    public List<string> Labels { get; set; } = new();
    public List<int> Values { get; set; } = new();
    public string Title { get; set; } = string.Empty;
}

public class KpiSummaryResponseDto
{
    public double TotalSales { get; set; }
    public int TotalQuantity { get; set; }
    public double AvgOrderValue { get; set; }
    public int TransactionCount { get; set; }
}