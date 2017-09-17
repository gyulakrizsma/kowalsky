using System.Collections.Generic;

namespace Kowalsky.Models
{
    public class PriceModel
    {
        public PriceModel(int mainPrice, IReadOnlyList<Price> prices)
        {
            MainPrice = mainPrice;
            Prices = prices;
        }

        public int MainPrice { get; }

        public IReadOnlyList<Price> Prices { get; }
    }
}
