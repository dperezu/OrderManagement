using OrderManagement.Domain;

namespace OrderManagement.Infrastructure;

public class Repository : IRepository
{
    public string Get() => "Data from DB";

    public void Save(string data)
    {
        Console.WriteLine($"[DB] Saved: {data}");
    }
}

