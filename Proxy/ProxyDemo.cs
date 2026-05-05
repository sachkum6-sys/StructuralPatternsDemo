namespace StructuralPatternsDemo.Proxy;

// Intent: Provide a placeholder or controlled access to another object.

public interface IReportService
{
    string GetReport(string userRole);
}

public sealed class ReportService : IReportService
{
    public string GetReport(string userRole)
    {
        return "Confidential financial report data.";
    }
}

public sealed class ReportServiceProxy : IReportService
{
    private readonly ReportService _realService = new();

    public string GetReport(string userRole)
    {
        if (userRole != "Admin")
        {
            return "Access denied. Only admins can view this report.";
        }

        Console.WriteLine("Access granted. Loading real report service...");
        return _realService.GetReport(userRole);
    }
}

public static class ProxyDemo
{
    public static void Run()
    {
        IReportService reportService = new ReportServiceProxy();

        Console.WriteLine(reportService.GetReport("User"));
        Console.WriteLine(reportService.GetReport("Admin"));
    }
}