using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sales_Data.Pharmacy;
using System.Linq;

namespace Sales_Data.CSVParser
{
  public class CsvParser
  {
    public CsvParser(string pharmacyName)
    {
      var pharmacy = new Shop(pharmacyName);
      ReadCSV(pharmacy);
    }
    public void ReadCSV(Shop pharmacy)
    {
      using (var reader = new StreamReader(@"/Users/benmuller/locumco/EnterFileHere/salitms1.csv"))
      {
        string itemNumber = "";
        string itemDescription = "";

        while (!reader.EndOfStream)
        {
          var line = reader.ReadLine();
          var values = line.Split(';');

          foreach (var item in values)
          {
            var entries = item.Split(",");

            if (!string.IsNullOrWhiteSpace(entries[1])) itemNumber = entries[1];
            if (!string.IsNullOrWhiteSpace(entries[2])) itemDescription = entries[2];

            foreach (var keyword in pharmacy.PharmacySearch)
            {
              if (!string.IsNullOrWhiteSpace(entries[3]) && entries[3].ToLower().Contains(keyword.Trim()))
              {
                var revenue = entries[5] + entries[6];
                pharmacy.AddItem(itemNumber,itemDescription, entries[4], revenue);
              }
            }
           
          }
        }
      }

      WriteToCsv(pharmacy);
    }

    public void WriteToCsv(Shop pharmacySearch)
    {
      //before your loop
      var csv = new StringBuilder();
      var heading = $"KeyWord Search: {string.Join(",", pharmacySearch.PharmacySearch)}";
      csv.AppendLine(heading);
      var firstLine = "Item Number,Locum Qty,Total Spend($)";
      csv.AppendLine(firstLine);


      foreach (var item in pharmacySearch.Items)
      {
          var line = $"{item.Id},{item.Description},{item.NumberOfLocums},{item.TotalSpend}";  
          csv.AppendLine(line);  
      }

      int totalLocums = pharmacySearch.Items.Aggregate(0, (total, next) => total += next.NumberOfLocums);
      decimal totalRevenue = pharmacySearch.Items.Aggregate((decimal)0, (total, next) => total += next.TotalSpend);

      var lastLine = $"TOTAL,,{totalLocums},{totalRevenue}";
      csv.AppendLine(lastLine);

      File.WriteAllText(@"/Users/benmuller/locumco/EnterFileHere/RESULTS.csv", csv.ToString());
    }
  }
}