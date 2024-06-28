namespace Application.Interfaces;

public interface IEmailService
{
    Task SendEmail(string email);
}
