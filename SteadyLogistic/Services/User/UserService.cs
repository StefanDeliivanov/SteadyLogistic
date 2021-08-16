namespace SteadyLogistic.Services.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using SteadyLogistic.Data;
    using SteadyLogistic.Data.Models;
    using SteadyLogistic.Models.Catalogue;
    using SteadyLogistic.Services.Company;

    using static Areas.AreaGlobalConstants.Roles;

    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly SteadyLogisticDbContext data;   
        private readonly ICompanyService companies;

        public UserService(
            UserManager<User> userManager,
            SteadyLogisticDbContext data,
            ICompanyService companies)
        {
            this.userManager = userManager;
            this.data = data;        
            this.companies = companies;
        }

        public void AddAsEmployee(PremiumUser premiumUser)
        {
            var user = this.data.Users
                .Where(a => a.Id == premiumUser.Id)
                .FirstOrDefault();

            Task
                .Run(async () =>
                {
                    await this.userManager.AddToRoleAsync(user, PremiumRoleName);
                })
                .GetAwaiter()
                .GetResult();
        }

        public void AddAsManager(PremiumUser premiumUser)
        {
            var user = data.Users
                .Where(a => a.Id == premiumUser.Id)
                .FirstOrDefault();

            Task
                .Run(async () =>
                {
                    await this.userManager.RemoveFromRoleAsync(user, MemberRoleName);
                    await this.userManager.AddToRoleAsync(user, ManagerRoleName);
                })
                .GetAwaiter()
                .GetResult();
        }

        public UserQueryServiceModel All(
            string searchTerm = null,
            UserSearchType searchType = UserSearchType.Name,
            UserSorting sorting = UserSorting.UserNameAscending,
            int currentPage = 1,
            int usersPerPage = int.MaxValue)
        {
            var usersQuery = this.data.PremiumUsers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                usersQuery = searchType switch
                {
                    UserSearchType.CompanyName => usersQuery.Where(a => a.Company.Name.Contains(searchTerm)),
                    UserSearchType.PhoneNumber => usersQuery.Where(a => a.PhoneNumber.Contains(searchTerm)),
                    UserSearchType.Email => usersQuery.Where(a => a.Email.Contains(searchTerm)),
                    UserSearchType.Name or _ => usersQuery.Where(a => a.FirstName.Contains(searchTerm)
                                                                   || a.LastName.Contains(searchTerm))
                };
            }

            usersQuery = sorting switch
            {
                UserSorting.RegisteredOnDescending => usersQuery.OrderByDescending(a => a.RegisteredOn),
                UserSorting.RegisteredOnAscending => usersQuery.OrderBy(a => a.RegisteredOn),
                UserSorting.CompanyNameDescending => usersQuery.OrderByDescending(a => a.Company.Name),
                UserSorting.CompanyNameAscending => usersQuery.OrderBy(a => a.Company.Name),
                UserSorting.UserNameDescending => usersQuery.OrderByDescending(a => a.FirstName).ThenBy(a => a.LastName),
                UserSorting.UserNameAscending or _ => usersQuery.OrderBy(a => a.FirstName).ThenBy(a => a.LastName)
            };

            var totalUsers = usersQuery.Count();

            var users = GetUsers(usersQuery
                .Skip((currentPage - 1) * usersPerPage)
                .Take(usersPerPage)).ToList();

            return new UserQueryServiceModel
            {
                TotalUsers = totalUsers,
                CurrentPage = currentPage,
                UsersPerPage = usersPerPage,
                AllUsers = users
            };
        }

        public PremiumUser CreatePremium(
            string id, 
            string firstName, 
            string lastName, 
            string email, 
            string phoneNumber, 
            int companyId, 
            DateTime registeredOn)
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
                RegisteredOn = registeredOn
            };

            this.data.PremiumUsers.Add(premiumUser);
            this.data.SaveChanges();

            return premiumUser;
        }

        public bool CreateUser(string email, string password)
        {
            var user = new User
            {
                UserName = email,
                Email = email,
                RegisteredOn = DateTime.UtcNow
            };

            try
            {
                Task
                .Run(async () =>
                {
                    await this.userManager.CreateAsync(user, password);
                })
                .GetAwaiter()
                .GetResult();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public UserDetailsServiceModel Details(string id)
        {
            var user = this.data.PremiumUsers
                .Where(a => a.Id == id)
                .Select(b => new UserDetailsServiceModel
                {
                    Id = b.Id,
                    FullName = b.FirstName + " " + b.LastName,
                    PhoneNumber = b.PhoneNumber,
                    Email = b.Email,
                    RegisteredOn = b.RegisteredOn,
                    Company = companies.Details(b.CompanyId)
                })
                .FirstOrDefault();

            return user;
        }

        public bool EmailTaken(string email)
        {
            return this.data.Users
                .Any(a => a.Email == email);
        }

        public int GetCompanyIdByPremiumUserId(string id)
        {
            var user = this.data.PremiumUsers
                .Where(a => a.Id == id)
                .FirstOrDefault();

            return user.CompanyId;
        }

        public User GetUserByEmail(string email)
        {
            var user = this.data.Users
                .Where(a => a.Email == email)
                .FirstOrDefault(); ;

            return user;
        }

        public string GetUserNamesById(string id)
        {
            var user = this.data.PremiumUsers
                .Where(a => a.Id == id)
                .FirstOrDefault();

            return user.FirstName + " " + user.LastName;
        }

        public bool PhoneNumberTaken(string phoneNumber)
        {
            return this.data.PremiumUsers
                .Any(a => a.PhoneNumber == phoneNumber);
        }

        private static IEnumerable<UserServiceModel> GetUsers(IQueryable<PremiumUser> query)
        {
            var users = query
                .Select(a => new UserServiceModel
                {
                    Id = a.Id,
                    CompanyId = a.CompanyId,
                    UserName = a.FirstName + " " + a.LastName,
                    CompanyName = a.Company.Name,
                    RegisteredOn = a.RegisteredOn
                })
                .ToList();
                
            return users;
        }
    }
}