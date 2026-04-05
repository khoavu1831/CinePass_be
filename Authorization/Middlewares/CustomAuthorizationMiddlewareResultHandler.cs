using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;

namespace CinePass_be.Authorization;

public class CustomAuthorizationMiddlewareResultHandler
    : IAuthorizationMiddlewareResultHandler
{
  private readonly AuthorizationMiddlewareResultHandler _defaultHandler = new();

  public async Task HandleAsync(
      RequestDelegate next,
      HttpContext context,
      AuthorizationPolicy policy,
      PolicyAuthorizationResult authorizeResult)
  {
    if (authorizeResult.Challenged)
    {
      context.Response.StatusCode = StatusCodes.Status401Unauthorized;
      context.Response.ContentType = "application/json";

      await context.Response.WriteAsync(JsonSerializer.Serialize(new
      {
        message = "Chua dang nhap"
      }));
      return;
    }

    if (authorizeResult.Forbidden)
    {
      context.Response.StatusCode = StatusCodes.Status403Forbidden;
      context.Response.ContentType = "application/json";

      await context.Response.WriteAsync(JsonSerializer.Serialize(new
      {
        message = "Khong du quyen"
      }));
      return;
    }

    await _defaultHandler.HandleAsync(next, context, policy, authorizeResult);
  }
}