using System.Collections.Generic;

namespace buildxact_supplies.Models
{
    /// <summary>
    /// model to map csv data
    /// </summary>
    public class CsvSupplierModel
    {
        public List<Supplier> Supplier { get; set; }
    }
    public class Supplier
    {
        public int Identifier { get; set; }
        public string  Description { get; set; }
    }
}
