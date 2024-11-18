using Microsoft.AspNetCore.Mvc;
using psevdotinder.application.User;
using psevdotinder.Core;
using psevdotinder.Core.Entities;
using psevdotinder_core.DTOs;

namespace CleanArch_recomend_sistem_api.Endpoints;

public static class UserEndpoint
{

    public static void MapProjectEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/get/user", GetUser);
        routes.MapPost("/addOrUpdate/user", AddOrUpdateUser);
    }

    private static async Task<IResult> GetUser([FromBody] Id userId, UserService service, CancellationToken cancellationToken)
    {
        try
        {
            return Results.Ok(await service.GetUserServiceAsync(userId, cancellationToken));
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }

    private static async Task<IResult> AddOrUpdateUser([FromBody] UserDTO userDTO, UserService service, CancellationToken cancellationToken)
    {
        try
        {
            await service.RegisterOrUpdateUsersAsync(userDTO, cancellationToken);
            return Results.Ok();

        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}