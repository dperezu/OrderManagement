namespace Prueba.Domain;

public class Entity
{
    public string Data { get; set; } = string.Empty;

    public string GetData() => Data;
    public void SetData(string data) => Data = data;
}
