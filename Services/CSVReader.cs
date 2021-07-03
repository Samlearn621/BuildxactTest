namespace buildxact_supplies.Services
{
    public class CSVReader: IReader
    {   
        public string Name => "Csv";
        public T ReadSupplierData<T>(string filePath)
        {
            try
            {
                
            }
            catch
            {
                throw;
            }

            return default(T);
        }
    }
}
