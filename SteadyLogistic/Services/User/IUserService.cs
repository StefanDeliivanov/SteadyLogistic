namespace SteadyLogistic.Services.User
{
    using System;
    using SteadyLogistic.Data.Models;
    using SteadyLogistic.Models.Catalogue;

    public interface IUserService
    {

        public bool PhoneNumberTaken(string UserId);

        public bool CreateUser(string email, string password);

        public PremiumUser CreatePremium(string Id, string firstName, string lastName, string email, string phoneNumber, int companyId, DateTime registeredOn);

        public void AddAsManager(PremiumUser user);

        public void AddAsEmployee(PremiumUser premiumUser);

        public bool EmailTaken(string email);

        public User GetUserByEmail(string email);

        public int GetCompanyIdByPremiumUserId(string id);

        public string GetUserNamesById(string id);

        public UserQueryServiceModel All(
            string searchTerm = null,
            UserSearchType searchType = UserSearchType.Name,
            UserSorting sorting = UserSorting.UserNameAscending,
            int currentPage = 1,
            int usersPerPage = int.MaxValue);
    }
}