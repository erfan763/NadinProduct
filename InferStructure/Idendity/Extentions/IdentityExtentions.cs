using System.Security.Claims;
using System.Security.Principal;

namespace InferStructure.Idendity.Extentions;

public static class IdentityExtentions
{
    public static string FindFirstValue(this ClaimsIdentity identity, string claimType)
    {
        return identity?.FindFirst(claimType)?.Value;
    }

    public static string FindFirstValue(this IIdentity identity, string claimType)
    {
        var claimsIdentity = identity as ClaimsIdentity;
        return claimsIdentity?.FindFirstValue(claimType);
    }

    public static string GetUserId(this IIdentity identity)
    {
        return identity?.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}