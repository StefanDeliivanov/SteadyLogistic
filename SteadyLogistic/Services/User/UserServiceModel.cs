namespace SteadyLogistic.Services.User
{
    using System;

    public class UserServiceModel
    {
        public string Id { get; set; }

        public int CompanyId { get; set; }

        public string UserName { get; set; }

        public string CompanyName { get; set; }

        public DateTime RegisteredOn { get; set; }
    }
}