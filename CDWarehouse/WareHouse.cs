namespace CDWarehouse
{
    public class WareHouse
    {
        private readonly IChartNotifier _chartNotifier;
        private readonly ITop100Chart _top100Chart;
        private readonly ICompetitorPrices _competitorPrices;

        public WareHouse(IChartNotifier chartNotifier, ITop100Chart top100Chart, ICompetitorPrices competitorPrices)
        {
            _chartNotifier = chartNotifier;
            _top100Chart = top100Chart;
            _competitorPrices = competitorPrices;
        }

        public bool IsTitleInStock(string title)
        {
            return true;
        }

        public void BuyCd(CD cD, Customer customer, CreditCard card)
        {
            bool isCreditCardAccepted = card.IsValid;

            if (!isCreditCardAccepted)
            {
                return;
            }

            if (cD.Quantity > 0)
            {
                if (_top100Chart.IsTop100("Tanzeel", cD.Title))
                {
                    double competitorPrice = _competitorPrices.GetLowestPrice("Tanzeel", cD.Title);

                    if (competitorPrice < cD.Price)
                    {
                        cD.Price = competitorPrice - 1.0;
                    }
                }

                cD.Quantity--;
                customer.cdTitles.Add(cD.Title);
                _chartNotifier.Notify("Tanzeel", "Greatest Hits", 1);
            }
        }
    }
}