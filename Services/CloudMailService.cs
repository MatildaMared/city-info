namespace CityInfo.Services;

public class CloudMailService : IMailService
{
    private string _mailto = "admin@company.com";
    private string _mailFrom = "noreply@company.com";

    public void Send(string subject, string message)
    {
        Console.WriteLine($"Mail from {_mailFrom} to {_mailto}", $"with {nameof(CloudMailService)}.");
        Console.WriteLine($"Subject: {subject}");
        Console.WriteLine($"Message: {message}");
    }
}