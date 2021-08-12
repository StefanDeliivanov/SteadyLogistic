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
        public void AddAsEmployee(PremiumUser premiumUser)
        {
            var user = data.Users
                        .Where(a => a.Id == premiumUser.Id)
                        .FirstOrDefault();

            Task
                .Run(async () =>
                {
                    await userManager.AddToRoleAsync(user, PremiumRoleName);
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

        public bool CreateUser(string email, string password)
        {
            var user = new User
            {
                UserName = email,
                Email = email
            };

            try
            {
                Task
                .Run(async () =>
                {
                    await userManager.CreateAsync(user, password);
                })
                .GetAwaiter()
                .GetResult();
            }

            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool PhoneNumberTaken(string phoneNumber)
        {
            return this.data.PremiumUsers
                        .Any(a => a.PhoneNumber == phoneNumber);
        }

        public bool EmailTaken(string email)
        {
            return this.data.Users
                        .Any(a => a.Email == email);
        }

        public User GetUserByEmail(string email)
        {
            var user = this.data.Users
                .Where(a => a.Email == email)
                .FirstOrDefault(); ;

            return user;
        }

        public int GetCompanyIdByPremiumUserId(string id)
        {
            var user = this.data.PremiumUsers
                .Where(a => a.Id == id)
                .FirstOrDefault();

            return user.CompanyId;
        }
    }
}