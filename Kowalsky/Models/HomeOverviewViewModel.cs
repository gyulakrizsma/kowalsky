using System.Collections.Generic;

namespace Kowalsky.Models
{
    public class HomeOverviewViewModel
    {
        public HomeOverviewViewModel(int mainPrice, PriceModel priceModel, IReadOnlyCollection<Comment> comments)
        {
            MainPrice = mainPrice;
            PriceModel = priceModel;
            Comments = comments;
        }

        public int MainPrice { get; }

        public PriceModel PriceModel { get; }

        public IReadOnlyCollection<Comment> Comments { get; }
    }
}
