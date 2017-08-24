using System.Collections.Generic;

namespace Kowalsky.Models
{
    public class HomeOverviewViewModel
    {
        public HomeOverviewViewModel(int mainPrice, IReadOnlyCollection<Schedule> schedules,
            IReadOnlyList<Price> prices, IReadOnlyCollection<Comment> comments)
        {
            MainPrice = mainPrice;
            Schedules = schedules;
            Prices = prices;
            Comments = comments;
        }

        public int MainPrice { get; }

        public IReadOnlyCollection<Schedule> Schedules { get; }

        public IReadOnlyList<Price> Prices { get; }

        public IReadOnlyCollection<Comment> Comments { get; }
    }
}
