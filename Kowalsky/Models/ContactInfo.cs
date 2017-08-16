namespace Kowalsky.Models
{
    public class ContactInfo
    {
        public ContactInfo(string name, string email, string phone, string comment)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Comment = comment;
        }

        public string Name { get; }

        public string Email { get; }

        public string Phone { get; }

        public string Comment { get; }
    }
}
