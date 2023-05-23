// Apply SOLID design principles on the following code samples for better design
//1.  
public class UserService
{
    private readonly EmailService _emailService;
    public UserService(EmailService emailService)
    {
        _emailService = emailService;
    }
    public bool Register(string email, string password)
    {
        if (_emailService.ValidateEmail(email)) {
            var user = CreateUser(email, password);

            WelcomeUser(user);

            return true;
        }

        return false;
    }

    public User CreateUser(string email, string password)
    {
        return new User(email, password);
    }

    public void WelcomeUser(User user)
    {
        _emailService.SendEmail(new MailMessage("mysite@nowhere.com", user.email) { Subject = "HEllo foo" });
    }
}

public class EmailService
{
    public virtual bool ValidateEmail(string email)
    {
        return email.Contains("@");
    }

    public bool SendEmail(MailMessage message)
    {
        _smtpClient.Send(message);
    }
}