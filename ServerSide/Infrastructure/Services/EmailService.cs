using Application.Models;
using MimeKit;
using MailKit.Net.Smtp;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.Helpers;
using System.Security.Cryptography;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;
    private readonly IUserRepository _userRepository;

    public EmailService(IConfiguration configuration, IUserRepository userRepository)
    {
        _config = configuration;
        _userRepository = userRepository;
    }

    public async Task SendEmail(string email)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        if (user is null)
        {
            //StatusCode = 404,
            //Message = "email Dosen't Exist"
        }
        var tokenBytes = RandomNumberGenerator.GetBytes(64);
        var emailToekn = Convert.ToBase64String(tokenBytes);
        user.ResetPasswordToken = emailToekn;
        user.ResetPasswordExpiry = DateTime.Now.AddMinutes(15);
        var emailModel = new EmailModel(email, "Reset Password!!", EmailBody.EmailStringBody(email, emailToekn));
        await _userRepository.UpdateAsync(user);

        await SendEmailMessage(emailModel);
    }
    private async Task SendEmailMessage(EmailModel emailModel)
    {
        string from = _config["EmailSettings:From"];
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("Oleksandr Verenchuk", from));
        emailMessage.To.Add(new MailboxAddress(emailModel.To, emailModel.To));
        emailMessage.Subject = emailModel.Subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = string.Format(emailModel.Content)
        };

        using (var client = new SmtpClient())
        {
            try
            {
                client.Connect(_config["EmailSettings:SmtpServer"], 465, true);
                client.Authenticate(_config["EmailSettings:From"], _config["EmailSettings:Password"]);
                client.Send(emailMessage);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
