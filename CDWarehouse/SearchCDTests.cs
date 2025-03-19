using Moq;
using NUnit.Framework;

namespace CDWarehouse
{
    [TestFixture]
    public class SearchCDTests
    {

        public Mock<IChartNotifier> _notifyChart;
        public Mock<ITop100Chart> _top100Chart;

        [SetUp]
        public void Setup()
        {
            _notifyChart = new Mock<IChartNotifier>();
            _top100Chart = new Mock<ITop100Chart>();
        }

        [Test]
        public void SearchByTitleForInStockCD()
        {
            var isInStock = false;
            var title = "Tanzeel's Greatest Hits";
            var wareHouse = new WareHouse(_notifyChart.Object, _top100Chart.Object);
            isInStock = wareHouse.IsTitleInStock(title);
            NUnit.Framework.Assert.That(isInStock, Is.EqualTo(true));
        }
    }
}