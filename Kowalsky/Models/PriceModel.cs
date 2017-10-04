using System.Collections.Generic;

namespace Kowalsky.Models
{
    public class PriceModel
    {
        public PriceModel(int mainPrice, IReadOnlyList<Price> theoryPrices, IReadOnlyList<Price> prices)
        {
            MainPrice = mainPrice;
            TheoryPrices = theoryPrices;
            Prices = prices;
        }

        public int MainPrice { get; }

        public IReadOnlyList<Price> TheoryPrices { get; }

        public IReadOnlyList<Price> Prices { get; }
    }
}
