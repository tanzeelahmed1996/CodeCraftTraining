namespace CDWarehouse
{
    public interface IChartNotifier
    {
        public void Notify(string artist, string title, int quantity);
    }
}