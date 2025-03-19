using NUnit.Framework;

namespace CDWarehouse
{
    [TestFixture]
    public class BuyCDTests
    {

        public CreditCard _card;
        [SetUp]
        public void Setup()
        {
            _card = new CreditCard { IsValid = true };
        }

        [Test]
        public void BuyCdInStockReducesQuantity()
        {
            var wareHouse = new WareHouse();
            CD cd = new CD { Title = "Tanzeel's Greatest Hits", Quantity = 1 };
            Customer customer = new Customer();
            wareHouse.BuyCd(cd, customer, _card);

            NUnit.Framework.Assert.That(cd.Quantity, Is.EqualTo(0));
        }

        [Test]
        public void BuyCdOutOfStockDoesntReduceQuantity()
        {
            var wareHouse = new WareHouse();
            CD cd = new CD { Title = "Tanzeel's Greatest Hits", Quantity = 0 };
            Customer customer = new Customer();
            wareHouse.BuyCd(cd, customer, _card);
            NUnit.Framework.Assert.That(cd.Quantity, Is.EqualTo(0));
        }

        [Test]
        public void BuyCdInStockAssignsUpdatesCustomerQuantity()
        {
            var wareHouse = new WareHouse();
            CD cd = new CD { Title = "Tanzeel's Greatest Hits", Quantity = 1 };
            Customer customer = new Customer();
            wareHouse.BuyCd(cd, customer, _card);
            NUnit.Framework.Assert.That(customer.cdTitles.Count, Is.EqualTo(1));
        }

        [Test]
        public void BuyCDInStockCreditCardRejected()
        {
            var wareHouse = new WareHouse();
            CD cd = new CD { Title = "Tanzeel's Greatest Hits", Quantity = 1 };
            Customer customer = new Customer();
            _card.IsValid = false;
            wareHouse.BuyCd(cd, customer, _card);
            NUnit.Framework.Assert.That(customer.cdTitles.Count, Is.EqualTo(0));
            NUnit.Framework.Assert.That(cd.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void BuyCDInStockCreditCardAccepted()
        {
            var wareHouse = new WareHouse();
            CD cd = new CD { Title = "Tanzeel's Greatest Hits", Quantity = 1 };
            Customer customer = new Customer();
            wareHouse.BuyCd(cd, customer, _card);
            NUnit.Framework.Assert.That(customer.cdTitles.Count, Is.EqualTo(1));
            NUnit.Framework.Assert.That(cd.Quantity, Is.EqualTo(0));
        }
    }
}
