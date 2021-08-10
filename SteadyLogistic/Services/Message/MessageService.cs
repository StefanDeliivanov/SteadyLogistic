namespace SteadyLogistic.Services.Message
{
    using System;
    using SteadyLogistic.Data;
    using SteadyLogistic.Data.Models;

    public class MessageService : IMessageService
    {
        private readonly SteadyLogisticDbContext data;

        public MessageService(SteadyLogisticDbContext data)
        {
            this.data = data;
        }

        public void Create(string userId, string email, string firstName, string lastName, string title, string body, DateTime sendOn)
        {
            var message = new Message
            {
                UserID = userId,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Title = title,
                Body = body,
                SendOn = sendOn
            };

            data.Messages.Add(message);

            data.SaveChanges();
        }
    }
}