using System.Collections.Generic;

namespace Kowalsky.Models
{
    public class HomeOverviewViewModel
    {
        public HomeOverviewViewModel(int mainPrice, IReadOnlyCollection<Schedule> schedules,
            PriceModel priceModel, IReadOnlyCollection<Comment> comments)
        {
            MainPrice = mainPrice;
            Schedules = schedules;
            PriceModel = priceModel;
            Comments = comments;
        }

        public int MainPrice { get; }

        public IReadOnlyCollection<Schedule> Schedules { get; }

        public PriceModel PriceModel { get; }

        public IReadOnlyCollection<Comment> Comments { get; }
    }
}
