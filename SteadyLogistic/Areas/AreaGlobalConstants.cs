namespace SteadyLogistic.Areas
{
    public class AreaGlobalConstants
    {
        public static class Admin
        {
            public const string defaultAdminEmail = "admin@steadylogistics.com";
            public const string defaultAdminPassword = "admin123";
        }

        public static class Roles
        {
            public const string AdministratorRoleName = "Administrator";
            public const string Bosses = "Administrator,Manager";
            public const string FreightBrokersRoleName = "Manager,Premium";
            public const string MemberRoleName = "Member";
            public const string ManagerRoleName = "Manager";
            public const string NotAMemberRoleName = "Administrator,Manager,Premium";
            public const string PremiumRoleName = "Premium";       
        }
    }
}