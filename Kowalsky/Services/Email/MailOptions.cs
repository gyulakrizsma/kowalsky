namespace Kowalsky.Services.Email
{
    public class MailOptions
    {
        public string From { get; set; }

        public string Password { get; set; }

        public bool Empty => string.IsNullOrWhiteSpace(From) || string.IsNullOrWhiteSpace(Password);
    }
}
