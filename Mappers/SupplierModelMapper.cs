using buildxact_supplies.Models;
using System.Collections.Generic;

namespace buildxact_supplies.Mappers
{
    public static class SupplierModelMapper
    {   
        public static List<Item> MapToItems(this JsonSupplierModel jsonSupplierModel, double currencyRate, int cents, string currencyType = "AUD" )
        {
            var list = new List<Item>();
            foreach (var model in jsonSupplierModel.Partners)
            {
                foreach (var supply in model.Supplies)
                {
                    var item = new Item
                    {
                        Id = supply.Id.ToString(),
                        Description = supply.Description,
                        Price = GetPrice(supply.PriceInCents, currencyRate, cents),
                        CurrencyType = currencyType
                    };
                    list.Add(item);
                }               
            }
            return list;
        }

        public static List<Item> MapToItems(this CsvSupplierModel csvSupplierModel, double currencyRate, int cents, string currencyType = "AUD")
        {
            var list = new List<Item>();
            // logic to get data from supplier
            foreach (var model in csvSupplierModel.Supplier)
            {
            }
            return list;
        }

        private static double GetPrice(double price, double currencyRate, int cents)
        {
            return (price / cents * currencyRate);
        }
    }
}
