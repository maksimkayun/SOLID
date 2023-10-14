// See https://aka.ms/new-console-template for more information

using DependencyInversion.Services;
using DependencyInversion.Implementation;

namespace DependencyInversion;

public static class Program
{
    public static void Main(string[] args)
    {
        var service = new AutoService(new PgRepository(), new OraRepository());
    }
}