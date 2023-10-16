using DependencyInversion.Implementation;

namespace DependencyInversion;

public static class RepositoryCreator
{
    public static IRepository CreateRepository(bool usePg) =>
        usePg ? new PgRepository() : new OraRepository();
}