﻿using System;
using System.Linq;
using System.Collections.Generic;
using Sales_Data.CSVParser;

namespace Sales_Data
{
  class Program
  {
    static void Main(string[] args)
    {
      var keyword = GetUserSelectionForPharmacySearch();

      var search = new CsvParser(keyword);
    }

    static string GetUserSelectionForPharmacySearch()
    {
      System.Console.WriteLine("***LOCUMCO REPORT GENERATOR***");
      System.Console.WriteLine("--------------------------------");
      System.Console.WriteLine("Enter a Key Word or Key Words to search the CSV for make sure the Key Words are separated by a comma (,)");
      System.Console.WriteLine("--------------------------------");
      return Console.ReadLine();
    }
  }
}
