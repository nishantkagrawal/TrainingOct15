namespace MVCTest.Repository
{
    /// <summary>
    ///     Basic UnitOfWork which derives all the UnitOfWork repositories
    /// </summary>
    public interface IUnitOfWork : IUnitOfWorkRepositories
    {
        /// <summary>
        /// The begin transaction.
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// The commit.
        /// </summary>
        void Commit();

        /// <summary>
        /// The roll back.
        /// </summary>
        void RollBack();

        /// <summary>
        /// The save changes.
        /// </summary>
        void SaveChanges();
    }
}