namespace SteadyLogistic.Services.Message
{
    using System;

    public interface IMessageService
    {

        public void Create(string userId, string email, string firstName, string lastName, string title, string body, DateTime sendOn);
    }
}