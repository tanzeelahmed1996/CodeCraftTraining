using Moq;
using NUnit.Framework;

namespace CDWarehouse
{
    [TestFixture]
    public class SearchCDTests
    {

        public Mock<IChartNotifier> _notifyChart;

        [SetUp]
        public void Setup()
        {
            _notifyChart = new Mock<IChartNotifier>();
        }

        [Test]
        public void SearchByTitleForInStockCD()
        {
            var isInStock = false;
            var title = "Tanzeel's Greatest Hits";
            var wareHouse = new WareHouse(_notifyChart.Object);
            isInStock = wareHouse.IsTitleInStock(title);
            NUnit.Framework.Assert.That(isInStock, Is.EqualTo(true));
        }
    }
}