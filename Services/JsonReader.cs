using buildxact_supplies.Extensions;
using buildxact_supplies.Models;
using Microsoft.Extensions.Options;
using System.IO;

namespace buildxact_supplies.Services
{
    public class JsonReader : IReader
    {
        
        public string Name => "Json";      

        public T ReadSupplierData<T>(string filePath)
        {
            try
            {
                var content = File.ReadAllText(filePath);
                return content.Deserialize<T>();
            }
            catch
            {
                throw;
            }
          
        }
    }
}
