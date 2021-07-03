namespace buildxact_supplies.Services
{
    public interface IReader
    {
        string Name { get; }
        T ReadSupplierData<T>(string filePath);
    }
}
