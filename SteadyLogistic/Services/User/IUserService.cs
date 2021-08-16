namespace SteadyLogistic.Services.User
{
    using System;
    using SteadyLogistic.Data.Models;
    using SteadyLogistic.Models.Catalogue;

    public interface IUserService
    {
        public void AddAsEmployee(PremiumUser premiumUser);

        public void AddAsManager(PremiumUser user);

        public UserQueryServiceModel All(
            string searchTerm = null,
            UserSearchType searchType = UserSearchType.Name,
            UserSorting sorting = UserSorting.UserNameAscending,
            int currentPage = 1,
            int usersPerPage = int.MaxValue);

        public PremiumUser CreatePremium(
            string Id, 
            string firstName, 
            string lastName, 
            string email, 
            string phoneNumber, 
            int companyId, 
            DateTime registeredOn);

        public bool CreateUser(string email, string password);

        public UserDetailsServiceModel Details(string id);

        public bool EmailTaken(string email);

        public int GetCompanyIdByPremiumUserId(string id);

        public User GetUserByEmail(string email);

        public string GetUserNamesById(string id);

        public bool PhoneNumberTaken(string UserId);
    }
}