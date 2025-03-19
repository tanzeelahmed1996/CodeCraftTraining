namespace CDWarehouse
{
    public class WareHouse
    {
        public bool IsTitleInStock(string title)
        {
            return true;
        }

        public void BuyCd(CD cD, Customer customer, CreditCard card, IChartNotifier chartNotifier, ITop100Chart top100Chart, ICompetitorPrices competitorPrices)
        {
            bool isCreditCardAccepted = card.IsValid;

            if (!isCreditCardAccepted)
            {
                return;
            }

            if (cD.Quantity > 0)
            {
                if (top100Chart.IsTop100("Tanzeel", cD.Title))
                {
                    double competitorPrice = competitorPrices.GetLowestPrice("Tanzeel", cD.Title);

                    if (competitorPrice < cD.Price)
                    {
                        cD.Price = competitorPrice - 1.0;
                    }
                }

                cD.Quantity--;
                customer.cdTitles.Add(cD.Title);
                chartNotifier.Notify("Tanzeel", "Greatest Hits", 1);
            }
        }
    }
}