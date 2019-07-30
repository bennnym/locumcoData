using System;
using System.Collections.Generic;

namespace Sales_Data.Pharmacy
{
  public class Shop
  {
    public string[] PharmacySearch { get; }
    public List<Item> Items;
    public Shop(string pharmacySearch)
    {
      PharmacySearch = pharmacySearch.Split(",");
      Items = new List<Item>();
    }

    public void AddItem(string itemNumber, string itemDescription, string locumQty, string spend)
    {
      var item = Items.Find(i => i.Id == itemNumber);

      if (item != null)
      {
        item.NumberOfLocums += Int32.Parse(locumQty);
        item.TotalSpend += Convert.ToDecimal(FormatCurrencyString(spend));
      }
      else
      {
        var addItem = new Item();
        addItem.Id = itemNumber;
        addItem.Description = itemDescription;
        addItem.NumberOfLocums = Int32.Parse(locumQty);
        System.Console.WriteLine(spend);
        addItem.TotalSpend = Convert.ToDecimal(FormatCurrencyString(spend));

        Items.Add(addItem);
      }
    }

    public string FormatCurrencyString(string dollarAmount)
    {
      var dollarSign = dollarAmount.IndexOf("$");
      var format = dollarAmount.Substring(dollarSign + 1);
      var str = format.Replace("\"", "");

  
      var comma = str.IndexOf(",");

      if ( comma > 0 )
      {
        return str.Substring(0, comma) + str.Substring(comma+1);
      }

      return str;

    }
  }
}