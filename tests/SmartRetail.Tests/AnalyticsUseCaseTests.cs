using Xunit;
using SmartRetail.Domain.UseCases;
using SmartRetail.Infrastructure.Repositories;

namespace SmartRetail.Tests;

public class AnalyticsUseCaseTests
{
    [Fact]
    public async Task GetDailySalesTrend_ReturnsLast7DaysData()
    {
        // Arrange
        var salesRepo = new MockSalesRepository();
        var productRepo = new MockProductRepository();
        var inventoryRepo = new MockInventoryRepository();
        var useCase = new AnalyticsUseCase(salesRepo, productRepo, inventoryRepo);

        // Act
        var result = await useCase.GetDailySalesTrendAsync(7);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Labels);
        Assert.NotNull(result.Values);
        Assert.Equal(result.Labels.Count, result.Values.Count);
    }

    [Fact]
    public async Task GetLowStockAlerts_ReturnsItems()
    {
        // Arrange
        var salesRepo = new MockSalesRepository();
        var productRepo = new MockProductRepository();
        var inventoryRepo = new MockInventoryRepository();
        var useCase = new AnalyticsUseCase(salesRepo, productRepo, inventoryRepo);

        // Act
        var result = await useCase.GetLowStockAlertsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Data);
    }

    [Fact]
    public async Task GetTopProducts_ReturnsLimitedResults()
    {
        // Arrange
        var salesRepo = new MockSalesRepository();
        var productRepo = new MockProductRepository();
        var inventoryRepo = new MockInventoryRepository();
        var useCase = new AnalyticsUseCase(salesRepo, productRepo, inventoryRepo);

        // Act
        var result = await useCase.GetTopProductsAsync(3);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Labels.Count <= 3);
        Assert.True(result.Values.Count <= 3);
    }
}