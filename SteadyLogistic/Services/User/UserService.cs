namespace SteadyLogistic.Services.User
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using SteadyLogistic.Data;
    using SteadyLogistic.Data.Models;

    using static Areas.AreaGlobalConstants.Roles;

    public class UserService : IUserService
    {
        private readonly SteadyLogisticDbContext data;
        private readonly UserManager<User> userManager;

        public UserService(
            SteadyLogisticDbContext data, 
            UserManager<User> userManager)
        {
            this.data = data;
            this.userManager = userManager;
        }

        public void AddAsManager(PremiumUser premiumUser)
        {
            var user = data.Users
                        .Where(a => a.Id == premiumUser.Id)
                        .FirstOrDefault();

            Task
                .Run(async () =>
                {
                    await userManager.RemoveFromRoleAsync(user, MemberRoleName);
                    await userManager.AddToRoleAsync(user, ManagerRoleName);
                })
                .GetAwaiter()
                .GetResult();
        }

        public PremiumUser CreatePremium(string id, string firstName, string lastName, string email, string phoneNumber, int companyId)
        {
            var premiumUser = new PremiumUser()
            {
                Id = id,
                UserId = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                CompanyId = companyId,
            };

            data.PremiumUsers.Add(premiumUser);

            data.SaveChanges();

            return premiumUser;
        }

        public bool PhoneNumberTaken(string phoneNumber)
        {
            return this.data.PremiumUsers
                        .Any(a => a.PhoneNumber == phoneNumber);           
        }
    }
}
