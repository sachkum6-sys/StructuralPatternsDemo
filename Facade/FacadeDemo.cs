namespace StructuralPatternsDemo.Facade;

// Intent: Provide a simple interface to a complex subsystem.

public sealed class InventoryService
{
    public bool IsAvailable(string productCode)
    {
        Console.WriteLine($"Checking inventory for product: {productCode}");
        return true;
    }
}

public sealed class PaymentService
{
    public bool Charge(decimal amount)
    {
        Console.WriteLine($"Charging payment: ${amount}");
        return true;
    }
}

public sealed class ShippingService
{
    public void Ship(string productCode)
    {
        Console.WriteLine($"Shipping product: {productCode}");
    }
}

public sealed class OrderFacade
{
    private readonly InventoryService _inventoryService = new();
    private readonly PaymentService _paymentService = new();
    private readonly ShippingService _shippingService = new();

    public void PlaceOrder(string productCode, decimal amount)
    {
        if (!_inventoryService.IsAvailable(productCode))
        {
            Console.WriteLine("Product is not available.");
            return;
        }

        if (!_paymentService.Charge(amount))
        {
            Console.WriteLine("Payment failed.");
            return;
        }

        _shippingService.Ship(productCode);
        Console.WriteLine("Order placed successfully.");
    }
}

public static class FacadeDemo
{
    public static void Run()
    {
        var orderFacade = new OrderFacade();
        orderFacade.PlaceOrder("LAPTOP-001", 1200);
    }
}