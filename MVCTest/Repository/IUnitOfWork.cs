
namespace MVCTest.Repository
{
    /// <summary>
    /// Basic UnitOfWork which derives all the UnitOfWork repositories
    /// </summary>
    public interface IUnitOfWork : IUnitOfWorkRepositories
    {
        void BeginTransaction();

        void Commit();

        void RollBack();

        void SaveChanges();
    }
}