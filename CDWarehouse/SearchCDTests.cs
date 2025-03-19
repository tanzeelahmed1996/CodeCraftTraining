using NUnit.Framework;

namespace CDWarehouse
{
    [TestClass]
    public class SearchCDTests
    {
        [TestMethod]
        public void SearchByTitleForInStockCD()
        {
            var isInStock = false;
            var title = "Tanzeel's Greatest Hits";
            var wareHouse = new WareHouse();
            isInStock = wareHouse.IsTitleInStock(title);
            NUnit.Framework.Assert.That(isInStock, Is.EqualTo(true));
        }
    }
}