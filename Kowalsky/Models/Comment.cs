namespace Kowalsky.Models
{
    public class Comment
    {
        public Comment(string message, string name, string description)
        {
            Message = message;
            Name = name;
            Description = description;
        }

        public string Message { get; }

        public string Name { get; }

        public string Description { get; }
    }
}
