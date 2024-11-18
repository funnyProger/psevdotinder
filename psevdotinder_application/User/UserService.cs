namespace psevdotinder.application.User;
using psevdotinder.Core.Entities;
using psevdotinder_core.DTOs;

public class UserService(IRepository<User> repository) : IService
{
    private IRepository<User> Repository { get; init; } = repository;

    public Task<IEnumerable<User>> GetUserServiceAsync(Id userId, CancellationToken cancellationToken = default) =>
        Repository.Get(user => user.Id.Value == userId.Value, cancellationToken);

    public async Task RegisterOrUpdateUsersAsync(UserDTO user, CancellationToken cancellationToken = default)
    {
        User localProj;
        if (user.Id is not null)
        {
            localProj = (await Repository.Get(x => x.Id.Value == user.Id.Value, cancellationToken)).FirstOrDefault() ??
                throw new Core.Exceptions.UserNotFoundException(user.Id.Value);
            localProj.Name = user.Name;
            localProj.Phone = user.Phone;
            localProj.Password = user.Password;
        }
        else
            localProj = new()
            {
                Name = user.Name,
                Phone = user.Phone,
                Password = user.Password,
            };
        if (localProj.Id is null)
            await Repository.Add(localProj, cancellationToken);
        else
            await Repository.Update(localProj, cancellationToken);
    }
}

