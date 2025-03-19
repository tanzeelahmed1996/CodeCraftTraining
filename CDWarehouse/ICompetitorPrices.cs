namespace CDWarehouse
{
    public interface ICompetitorPrices
    {
        public double GetLowestPrice(string artist, string title);
    }
}