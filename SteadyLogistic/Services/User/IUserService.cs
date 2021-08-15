namespace SteadyLogistic.Services.User
{
    using Microsoft.AspNetCore.Identity;
    using SteadyLogistic.Data.Models;

    public interface IUserService
    {

        public bool PhoneNumberTaken(string UserId);

        public bool CreateUser(string email, string password);

        public PremiumUser CreatePremium(string Id, string firstName, string lastName, string email, string phoneNumber, int companyId);

        public void AddAsManager(PremiumUser user);

        public void AddAsEmployee(PremiumUser premiumUser);

        public bool EmailTaken(string email);

        public User GetUserByEmail(string email);

        public int GetCompanyIdByPremiumUserId(string id);

        public string GetUserNamesById(string id);
    }
}