namespace SteadyLogistic.Models.Catalogue
{
    using System.Collections.Generic;
    using SteadyLogistic.Services.User;

    public class AllUsersQueryModel
    {
        public const int UsersPerPage = 10;

        public string SearchTerm { get; set; }

        public UserSearchType SearchType { get; set; }

        public UserSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalUsers { get; set; }

        public IEnumerable<UserServiceModel> Users { get; set; }
    }
}