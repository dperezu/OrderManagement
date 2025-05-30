using Prueba.Domain;

namespace MyApp.Infrastructure;

public class Repository : IRepository
{
    public string Get() => "Data from DB";

    public void Save(string data)
    {
        Console.WriteLine($"[DB] Saved: {data}");
    }
}

