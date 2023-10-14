using DependencyInversion.Implementation;

namespace DependencyInversion;

public class RepositoryCreator
{
    public static IRepository CreateRepository(bool usePg) =>
        usePg ? new PgRepository() : new OraRepository();
}