namespace StructuralPatternsDemo.Adapter;

// Intent: Convert the interface of an existing class into another interface clients expect.

public interface IPaymentProcessor
{
    void Pay(decimal amount);
}

public sealed class StripePaymentProcessor : IPaymentProcessor
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid ${amount} using Stripe.");
    }
}

// Existing third-party API with incompatible method name/signature.
public sealed class LegacyPayPalGateway
{
    public void MakePayment(double amount)
    {
        Console.WriteLine($"Paid ${amount} using legacy PayPal gateway.");
    }
}

public sealed class PayPalAdapter : IPaymentProcessor
{
    private readonly LegacyPayPalGateway _legacyGateway;

    public PayPalAdapter(LegacyPayPalGateway legacyGateway)
    {
        _legacyGateway = legacyGateway;
    }

    public void Pay(decimal amount)
    {
        _legacyGateway.MakePayment((double)amount);
    }
}

public static class AdapterDemo
{
    public static void Run()
    {
        IPaymentProcessor stripe = new StripePaymentProcessor();
        stripe.Pay(100);

        IPaymentProcessor paypal = new PayPalAdapter(new LegacyPayPalGateway());
        paypal.Pay(250);
    }
}