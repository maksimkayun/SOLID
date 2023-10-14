// See https://aka.ms/new-console-template for more information

using DependencyInjection.Implementation;
using DependencyInjection.Services;

namespace DependencyInjection;

public static class Program
{
    public static void Main(string[] args)
    {
        var service = new AutoService(RepositoryCreator.CreateRepository(usePg: bool.Parse(Environment.GetEnvironmentVariable("USE_PG") ?? "false")));
    }
}