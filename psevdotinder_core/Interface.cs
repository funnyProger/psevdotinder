namespace psevdotinder.Core;

public record Id(Guid Value);

public interface IEntity
{
    Id Id { get; }
}

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    Task Add(TEntity entity, CancellationToken cancellationToken);
    Task Update(TEntity entity, CancellationToken cancellationToken);
    Task Remove(TEntity entity, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> Get(Func<TEntity, bool> predicate, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetPaged(Func<TEntity, bool> predicate, int page, int pageSize, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetWithoutTracking(Func<TEntity, bool> predicate, CancellationToken cancellationToken);
}
