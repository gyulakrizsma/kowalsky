using System.Collections.Generic;

namespace Kowalsky.Models
{
    public class PriceModel
    {
        public PriceModel(int tariff, IReadOnlyList<Price> theoryPrices, IReadOnlyList<Price> prices)
        {
            Tariff = tariff;
            TheoryPrices = theoryPrices;
            Prices = prices;
        }

        public int Tariff { get; }

        public IReadOnlyList<Price> TheoryPrices { get; }

        public IReadOnlyList<Price> Prices { get; }

        public int MainPrice => 30 * Tariff;
    }
}
