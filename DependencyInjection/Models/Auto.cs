namespace DependencyInjection.Models;

public abstract class Auto
{
    public string SerialNumber { get; set; }
}

public class PgAuto : Auto
{
    public string Name { get; set; }
    public string Model { get; set; }
    public DateTime ReleaseDate { get; set; }
}

public class OraAuto : Auto
{
    public string Name { get; set; }
    public string Model { get; set; }
    public DateTime ReleaseDate { get; set; }
}