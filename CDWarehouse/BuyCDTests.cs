using Moq;
using NUnit.Framework;

namespace CDWarehouse
{
    [TestFixture]
    public class BuyCDTests
    {

        private CreditCard _card;
        private Mock<IChartNotifier> _notifyChart;
        private Mock<ICompetitorPrices> _competitorPrices;
        private Mock<ITop100Chart> _top100Chart;
        private WareHouse _wareHouse;


        [SetUp]
        public void Setup()
        {
            _card = new CreditCard { IsValid = true };
            _notifyChart = new Mock<IChartNotifier>();
            _competitorPrices = new Mock<ICompetitorPrices>();
            _top100Chart = new Mock<ITop100Chart>();
            _wareHouse = new WareHouse(_notifyChart.Object, _top100Chart.Object, _competitorPrices.Object);
        }

        [Test]
        public void BuyCdInStockReducesQuantity()
        {

            CD cd = new CD { Title = "Tanzeel's Greatest Hits", Quantity = 1 };
            Customer customer = new Customer();
            _wareHouse.BuyCd(cd, customer, _card);

            NUnit.Framework.Assert.That(cd.Quantity, Is.EqualTo(0));
        }

        [Test]
        public void BuyCdOutOfStockDoesntReduceQuantity()
        {

            CD cd = new CD { Title = "Tanzeel's Greatest Hits", Quantity = 0 };
            Customer customer = new Customer();
            _wareHouse.BuyCd(cd, customer, _card);
            NUnit.Framework.Assert.That(cd.Quantity, Is.EqualTo(0));
        }

        [Test]
        public void BuyCdInStockAssignsUpdatesCustomerQuantity()
        {

            CD cd = new CD { Title = "Tanzeel's Greatest Hits", Quantity = 1 };
            Customer customer = new Customer();
            _wareHouse.BuyCd(cd, customer, _card);
            NUnit.Framework.Assert.That(customer.cdTitles.Count, Is.EqualTo(1));
        }

        [Test]
        public void BuyCDInStockCreditCardRejected()
        {

            CD cd = new CD { Title = "Tanzeel's Greatest Hits", Quantity = 1 };
            Customer customer = new Customer();
            _card.IsValid = false;
            _wareHouse.BuyCd(cd, customer, _card);
            NUnit.Framework.Assert.That(customer.cdTitles.Count, Is.EqualTo(0));
            NUnit.Framework.Assert.That(cd.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void BuyCDInStockCreditCardAccepted()
        {

            CD cd = new CD { Title = "Tanzeel's Greatest Hits", Quantity = 1 };
            Customer customer = new Customer();
            _wareHouse.BuyCd(cd, customer, _card);
            NUnit.Framework.Assert.That(customer.cdTitles.Count, Is.EqualTo(1));
            NUnit.Framework.Assert.That(cd.Quantity, Is.EqualTo(0));
        }

        [Test]
        public void BuyCdNotifyCharts()
        {

            CD cd = new CD { Title = "Tanzeel's Greatest Hits", Quantity = 1 };
            Customer customer = new Customer();
            _wareHouse.BuyCd(cd, customer, _card);
            _notifyChart.Verify(x => x.Notify("Tanzeel", "Greatest Hits", 1));
        }

        [Test]
        public void BuyCdInTop100()
        {

            Customer customer = new Customer();
            CD cd = new CD { Title = "Tanzeel's Greatest Hits", Quantity = 1, Price = 10.0 };

            _top100Chart.Setup(x => x.IsTop100(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            _competitorPrices.Setup(x => x.GetLowestPrice(It.IsAny<string>(), It.IsAny<string>())).Returns(9.0);

            _wareHouse.BuyCd(cd, customer, _card);

            NUnit.Framework.Assert.That(cd.Price, Is.EqualTo(8.0));
        }
    }
}
