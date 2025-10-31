// SRP: each class has one reason to change.
// OrderService ONLY orchestrates; validation and email are separate.

using ConsoleAppAlgorithmsExamples.Interfaces;

record Order(decimal Amount);

interface IOrderValidator { bool IsValid(Order o); }
interface IEmailSender { void SendReceipt(Order o); }

class BasicOrderValidator : IOrderValidator
{
    public bool IsValid(Order o) => o.Amount > 0;
}

class ConsoleEmailSender : IEmailSender
{
    public void SendReceipt(Order o) => Console.WriteLine($"[Email] Receipt for {o.Amount:C}");
}

class OrderService
{
    private readonly IOrderValidator _validator;
    private readonly IEmailSender _email;

    public OrderService(IOrderValidator validator, IEmailSender email)
        => (_validator, _email) = (validator, email);

    public void Place(Order order)
    {
        if (!_validator.IsValid(order)) throw new ArgumentException("Invalid order");
        // …charge payment here…
        _email.SendReceipt(order);
    }
}

class DemoOrderService : ITest
{
    public void Execute()
    {
        var service = new OrderService(new BasicOrderValidator(), new ConsoleEmailSender());
        service.Place(new Order(99.0m));
    }
}
