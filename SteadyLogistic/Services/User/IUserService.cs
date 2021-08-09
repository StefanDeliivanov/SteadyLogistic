namespace SteadyLogistic.Services.User
{
    using SteadyLogistic.Data.Models;

    public interface IUserService
    {

        public bool PhoneNumberTaken(string UserId);

        public PremiumUser CreatePremium(string Id, string firstName, string lastName, string email, string phoneNumber, int companyId);

        public void AddAsManager(PremiumUser user);
    }
}