namespace CityInfo.Services;

public class LocalMailService
{
    private string _mailto = "admin@company.com";
    private string _mailFrom = "noreply@company.com";

    public void Send(string subject, string message)
    {
        Console.WriteLine($"Mail from {_mailFrom} to {_mailto}", $"with {nameof(LocalMailService)}.");
        Console.WriteLine($"Subject: {subject}");
        Console.WriteLine($"Message: {message}");
    }
}