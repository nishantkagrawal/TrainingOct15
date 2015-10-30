namespace MVCTest.Repository
{
    /// <summary>
    ///     An interface that each entity should implement
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        int Id { get; set; }
    }
}