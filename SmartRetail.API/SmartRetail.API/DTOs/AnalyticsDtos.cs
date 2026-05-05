namespace SmartRetail.API.DTOs;

public record DailySalesTrendResponse(
    List<string> Labels,
    List<double> Values,
    string Title
);

public record LowStockItemResponse(
    string ProductName,
    int CurrentStock,
    int Threshold
);

public record LowStockResponse(
    List<LowStockItemResponse> Data,
    int Count,
    string Title
);

public record TopProductsResponse(
    List<string> Labels,
    List<int> Values,
    string Title
);

public record KpiSummaryResponse(
    double TotalSales,
    int TotalQuantity,
    double AvgOrderValue,
    int TransactionCount
);