namespace CDWarehouse
{
    public class WareHouse
    {
        public bool IsTitleInStock(string title)
        {
            return true;
        }

        public void BuyCd(CD cD)
        {
            if (cD.Quantity > 0)
            {
                cD.Quantity--;
            }
        }
    }
}