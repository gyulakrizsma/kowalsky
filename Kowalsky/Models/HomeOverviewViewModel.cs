using System.Collections.Generic;

namespace Kowalsky.Models
{
    public class HomeOverviewViewModel
    {
        public HomeOverviewViewModel(PriceModel priceModel, IReadOnlyCollection<Comment> comments)
        {
            PriceModel = priceModel;
            Comments = comments;
        }

        public PriceModel PriceModel { get; }

        public IReadOnlyCollection<Comment> Comments { get; }
    }
}
