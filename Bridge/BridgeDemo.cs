namespace StructuralPatternsDemo.Bridge;

// Intent: Separate abstraction from implementation so both can vary independently.

public interface IMessageSender
{
    void Send(string message);
}

public sealed class EmailSender : IMessageSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Email sent: {message}");
    }
}

public sealed class SmsSender : IMessageSender
{
    public void Send(string message)
    {
        Console.WriteLine($"SMS sent: {message}");
    }
}

public abstract class Notification
{
    protected readonly IMessageSender Sender;

    protected Notification(IMessageSender sender)
    {
        Sender = sender;
    }

    public abstract void Notify(string message);
}

public sealed class OrderNotification : Notification
{
    public OrderNotification(IMessageSender sender) : base(sender)
    {
    }

    public override void Notify(string message)
    {
        Sender.Send($"Order Notification: {message}");
    }
}

public sealed class SecurityNotification : Notification
{
    public SecurityNotification(IMessageSender sender) : base(sender)
    {
    }

    public override void Notify(string message)
    {
        Sender.Send($"Security Notification: {message}");
    }
}

public static class BridgeDemo
{
    public static void Run()
    {
        Notification orderEmail = new OrderNotification(new EmailSender());
        orderEmail.Notify("Your order has shipped.");

        Notification securitySms = new SecurityNotification(new SmsSender());
        securitySms.Notify("New login detected.");
    }
}