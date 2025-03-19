namespace CDWarehouse
{
    public class WareHouse
    {
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
                cD.Quantity--;
                customer.cdTitles.Add(cD.Title);
            }
        }
    }
}