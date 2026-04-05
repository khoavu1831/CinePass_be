using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace CinePass_be.Authorization;

public class SelfHandler : AuthorizationHandler<SelfRequirement>
{
  protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SelfRequirement requirement)
  {
    var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    if (!int.TryParse(userIdClaim, out var currentUserId))
      return Task.CompletedTask;

    // Get ID from route
    var httpContext = (context.Resource as HttpContext);
    var routeId = httpContext?.GetRouteValue("id")?.ToString();

    if (int.TryParse(routeId, out var targetUserId) && currentUserId == targetUserId)
    {
      context.Succeed(requirement);
    }

    return Task.CompletedTask;
  }
}