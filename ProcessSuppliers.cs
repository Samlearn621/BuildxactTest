using buildxact_supplies.Factory;
using buildxact_supplies.Mappers;
using buildxact_supplies.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace buildxact_supplies
{
    public class ProcessSuppliers : IProcessSuppliers
    {
        private readonly IOptions<AppSettings> _options;
        private readonly IReaderFactory _readerFactory;

        public ProcessSuppliers(IOptions<AppSettings> options, IReaderFactory readerFactory)
        {
            _options = options;
            _readerFactory = readerFactory;
        }
       
        public void Process()
        {
            var items = new List<Item>();

            // reading json data
            foreach(var supplierSetting in _options.Value.SupplierSettingModel.Where(t=> t.Enable && t.File.Contains(".json")))
            {
                var reader = _readerFactory.GetReader(supplierSetting);
                var data  = reader.ReadSupplierData<JsonSupplierModel>(supplierSetting.File);
                items.AddRange(data.MapToItems(_options.Value.AudUsdExchangeRate, supplierSetting.Cents));
            }

            // reading csv data
            foreach (var supplierSetting in _options.Value.SupplierSettingModel.Where(t => t.Enable && t.File.Contains(".csv")))
            {
                var reader = _readerFactory.GetReader(supplierSetting);
                var data = reader.ReadSupplierData<CsvSupplierModel>(supplierSetting.File);
                //TODO: mapping csv data
               // items.AddRange(data.MapToItems(_options.Value.AudUsdExchangeRate, supplierSetting.Cents));
            }

            foreach (var item in items.OrderByDescending(t=> t.Price))
            {
                Console.WriteLine($"{item.Id}, {item.Description}, ${item.Price.ToString("#.##")}");
            }
        }
    }
}
