namespace psevdotinder.application.User;
using psevdotinder.Core.Entities;

public class ProfileService(IRepository<Profile> repository) : IService
{
    private IRepository<Profile> Repository { get; init; } = repository;

    public Task<IEnumerable<Profile>> GetProfileServiceAsync(User user, int page, int pageSize, CancellationToken cancellationToken = default) =>
        Repository.GetPaged((profile =>profile.City == user.City && ((profile.Age - user.Age) >= -5 && (profile.Age - user.Age) <= 5) && profile.Gender == user.Gender), page, pageSize, cancellationToken);
}

