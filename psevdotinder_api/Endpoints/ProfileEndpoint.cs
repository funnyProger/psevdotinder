using Microsoft.AspNetCore.Mvc;
using psevdotinder.application.User;
using psevdotinder.Core.Entities;

namespace CleanArch_recomend_sistem_api.Endpoints;

public static class ProfileEndpoint
{

    public static void MapProjectEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/get/profiles/", GetProfiles);
    }

    private static async Task<IResult> GetProfiles([FromBody] User user, [FromHeader] int page, [FromHeader] int pageSize, ProfileService service, CancellationToken cancellationToken)
    {
        try
        {
            return Results.Ok(await service.GetProfileServiceAsync(user, page, pageSize, cancellationToken));
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }
}