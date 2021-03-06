namespace SteadyLogistic.Services.Message
{
    using System;

    public interface IMessageService
    {
        public MessageQueryServiceModel All(int currentPage = 1, int messagesPerPage = int.MaxValue);

        public void Create(string userId, string email, string firstName, string lastName, string title, string body, DateTime sendOn);

        public bool Delete(int id);

        public MessageDetailsServiceModel Details(int id);

        public bool MessageExists(int id);
    }
}