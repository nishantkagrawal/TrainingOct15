

namespace MVCTest.Repository
{
    /// <summary>
    /// Read/Write Interface for repository which derives from IReadRepository and IWriteRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRWRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : IEntity
    {
    }
}