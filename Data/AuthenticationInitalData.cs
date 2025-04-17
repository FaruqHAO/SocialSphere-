using Microsoft.AspNetCore.Identity;

namespace DemoApplication.Server.Data
{
    public static class AuthenticationInitalData
    {
        public const string SuperAdminRole = "superadmin";
        public const string UserRole = "user";
        public const string MarketingRole = "marketing";
        public const string HrRole = "hr";
        public const string ManagerRole = "manager";
        public static readonly List<IdentityRole> AppRoles  = new List<IdentityRole>
                    {
                        new IdentityRole
                        {
                            Id = "1",
                            Name = SuperAdminRole,
                            NormalizedName = SuperAdminRole,
                        },
                        new IdentityRole
                        {
                            Id = "2",
                            Name = UserRole,
                            NormalizedName = UserRole,
                        },
                        new IdentityRole
                        {
                            Id = "3",
                            Name = MarketingRole,
                            NormalizedName = MarketingRole,
                        },
                        new IdentityRole
                        {
                            Id = "4",
                            Name = HrRole,
                            NormalizedName = HrRole,
                        },
                        new IdentityRole
                        {
                            Id = "5",
                            Name = ManagerRole,
                            NormalizedName = ManagerRole,
                        },
                    };
    }
}
