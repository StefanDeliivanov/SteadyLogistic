namespace SteadyLogistic.Infrastructure.Extensions
{
    using System.Security.Claims;

    using static Areas.AreaGlobalConstants.Roles;

    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public static string GetEmail(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Email).Value;
        }

        public static bool IsMember(this ClaimsPrincipal user)
        {
            return user.IsInRole(MemberRoleName);
        }           
    }
}