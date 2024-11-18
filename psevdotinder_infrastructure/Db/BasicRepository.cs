using Microsoft.EntityFrameworkCore;
using psevdotinder.Core;
using System.Linq.Expressions;

namespace psevdotinder.Infrastructure.Db;

public class BasicRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
{
    private static readonly ProjectContext _context = new();

    public Task Add(TEntity entity, CancellationToken cancellationToken) =>
        Task.Run(async () =>
        {
            _context.Add(entity);
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException?.Message;
                Console.WriteLine($"Ошибка при обновлении базы данных: {innerException}");
            }
        }, cancellationToken);

    public Task Remove(TEntity entity, CancellationToken cancellationToken) =>
        Task.Run(async () =>
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }, cancellationToken);

    public Task Update(TEntity entity, CancellationToken cancellationToken) =>
        Task.Run(async () =>
        {
            _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }, cancellationToken);

    public Task<IEnumerable<TEntity>> GetPaged(Func<TEntity, bool> predicate, int page, int pageSize, CancellationToken cancellationToken) =>
        Task.FromResult(_context.Set<TEntity>().Where(predicate).Skip((page - 1) * pageSize).Take(pageSize).ToArray().AsEnumerable());

    public Task<IEnumerable<TEntity>> Get(Func<TEntity, bool> predicate, CancellationToken cancellationToken) =>
        Task.FromResult(_context.Set<TEntity>().Where(predicate).ToArray().AsEnumerable());

    public Task<IEnumerable<TEntity>> GetWithoutTracking(CancellationToken cancellationToken) =>
        Task.FromResult(_context.Set<TEntity>().AsNoTracking().ToArray().AsEnumerable());

    public Task<IEnumerable<TEntity>> GetWithoutTracking(Func<TEntity, bool> predicate, CancellationToken cancellationToken) =>
        Task.FromResult(_context.Set<TEntity>().AsNoTracking().Where(predicate).ToArray().AsEnumerable());
}
