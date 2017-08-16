namespace Kowalsky.Models
{
    public class Price
    {
        public Price(int prices, string title, string description)
        {
            Prices = prices;
            Title = title;
            Description = description;
        }

        public int Prices { get; }

        public string Title { get; }

        public string Description { get; }
    }
}
