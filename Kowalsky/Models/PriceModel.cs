using System.Collections.Generic;

namespace Kowalsky.Models
{
    public class PriceModel
    {
        public PriceModel(int tariff, Price theoryPrice, IReadOnlyList<Price> prices)
        {
            Tariff = tariff;
            TheoryPrice = theoryPrice;
            Prices = prices;
        }

        public int Tariff { get; }

        public Price TheoryPrice { get; }

        public IReadOnlyList<Price> Prices { get; }

        public int MainPrice => 30 * Tariff + TheoryPrice.Amount;
    }
}
