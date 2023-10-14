using DependencyInjection.Implementation;

namespace DependencyInjection;

public class RepositoryCreator
{
    public static IRepository CreateRepository(bool usePg) =>
        usePg ? new PgRepository() : new OraRepository();
}