namespace SteadyLogistic.Services.User
{
    using System.Collections.Generic;

    public class UserQueryServiceModel
    {
        public int CurrentPage { get; set; }

        public int UsersPerPage { get; set; }

        public int TotalUsers { get; set; }

        public IEnumerable<UserServiceModel> AllUsers { get; set; }
    }
}