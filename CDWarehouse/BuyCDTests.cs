using NUnit.Framework;

namespace CDWarehouse
{
    [TestClass]
    public class BuyCDTests
    {
        [TestMethod]
        public void BuyCdInStockReducesQuantity()
        {
            var wareHouse = new WareHouse();
            CD cd = new CD { Title = "Tanzeel's Greatest Hits", Quantity = 1 };
            wareHouse.BuyCd(cd);

            NUnit.Framework.Assert.That(cd.Quantity, Is.EqualTo(0));
        }

        [TestMethod]
        public void BuyCdOutOfStockDoesntReduceQuantity()
        {
            var wareHouse = new WareHouse();
            CD cd = new CD { Title = "Tanzeel's Greatest Hits", Quantity = 0 };
            wareHouse.BuyCd(cd);
            NUnit.Framework.Assert.That(cd.Quantity, Is.EqualTo(0));
        }
    }
}
