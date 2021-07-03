using buildxact_supplies.Models;
using buildxact_supplies.Services;
using System.Collections.Generic;
using System.Linq;

namespace buildxact_supplies.Factory
{
    public interface IReaderFactory
    {
        IReader GetReader(SupplierSetting supplierSetting);
    }
    public class ReaderFactory : IReaderFactory
    {
        private readonly IEnumerable<IReader> _readers;

        public ReaderFactory(IEnumerable<IReader> readers)
        {
            _readers = readers;
        }
        public IReader GetReader(SupplierSetting supplierSetting)
        {
            return _readers
                .Where(t => t.Name.ToLower() == supplierSetting.Type.ToLower()).FirstOrDefault();
        }
    }
}
