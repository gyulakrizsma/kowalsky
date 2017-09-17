namespace Kowalsky.Models
{
    public class Price
    {
        public Price(int amount, string title, string description)
        {
            Amount = amount;
            Title = title;
            Description = description;
        }

        public int Amount { get; }

        public string Title { get; }

        public string Description { get; }
    }
}
