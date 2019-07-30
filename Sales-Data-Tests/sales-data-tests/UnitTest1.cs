using NUnit.Framework;
using Sales_Data;
using Sales_Data.Pharmacy;

namespace Tests
{
  [TestFixture]
  public class Tests
  {

    [Test]
    public void AddItem_MakeSureItemIsAdded_IncreaseItemsSizeBy1()
    {
      var shop = new Shop("pharmacy");
      Assert.That(shop.Items.Count, Is.EqualTo(0));

      shop.AddItem("111", "1", "222");

      Assert.That(shop.Items.Count, Is.EqualTo(1));

      shop.AddItem("111", "2", "222");

      Assert.That(shop.Items.Count, Is.EqualTo(1));

    }

    [Test]
    public void FormatCurrencyString_DollarsAndCentsAreRemoved_ReturnStringNumber()
    {
      var shop = new Shop("pharmacy");
      
      var result = shop.FormatCurrencyString("$1,895.00");

      Assert.That(result, Is.EqualTo("1895.00"));
    }
  }
}