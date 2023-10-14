// See https://aka.ms/new-console-template for more information

using DependencyInversion.Services;
using DependencyInversion.Implementation;

namespace DependencyInversion;

public static class Program
{
    public static void Main(string[] args)
    {
        var service = new AutoService(RepositoryCreator.CreateRepository(usePg: bool.Parse(Environment.GetEnvironmentVariable("USE_PG") ?? "false")));
    }
}