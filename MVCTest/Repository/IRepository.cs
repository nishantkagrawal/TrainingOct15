namespace MVCTest.Repository
{
    /// <summary>
    /// Read/Write Interface for repository which derives from IReadRepository and IWriteRepository
    /// </summary>
    /// <typeparam name="T"><see cref="IEntity"/> type</typeparam>
    public interface IRwRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : IEntity
    {
    }
}