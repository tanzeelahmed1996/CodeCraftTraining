using Moq;
using NUnit.Framework;

namespace CDWarehouse
{
    [TestFixture]
    public class SearchCDTests
    {

        public Mock<IChartNotifier> _notifyChart;
        public Mock<ITop100Chart> _top100Chart;
        public Mock<ICompetitorPrices> _competitorPrices;

        [SetUp]
        public void Setup()
        {
            _notifyChart = new Mock<IChartNotifier>();
            _top100Chart = new Mock<ITop100Chart>();
            _competitorPrices = new Mock<ICompetitorPrices>();
        }

        [Test]
        public void SearchByTitleForInStockCD()
        {
            var isInStock = false;
            var title = "Tanzeel's Greatest Hits";
            var wareHouse = new WareHouse(_notifyChart.Object, _top100Chart.Object, _competitorPrices.Object);
            isInStock = wareHouse.IsTitleInStock(title);
            NUnit.Framework.Assert.That(isInStock, Is.EqualTo(true));
        }
    }
}