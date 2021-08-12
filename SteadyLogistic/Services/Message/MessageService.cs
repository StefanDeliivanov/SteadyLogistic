namespace SteadyLogistic.Services.Message
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        public MessageQueryServiceModel All(int currentPage = 1, int messagesPerPage = int.MaxValue)
        {
            var messagesQuery = this.data.Messages
                .OrderByDescending(a => a.SendOn);

            var totalMessages = messagesQuery.Count();

            var messages = GetMessages(messagesQuery
                .Skip((currentPage - 1) * messagesPerPage)
                .Take(messagesPerPage)).ToList();

            return new MessageQueryServiceModel
            {
                TotalMessages = totalMessages,
                CurrentPage = currentPage,
                MessagesPerPage = messagesPerPage,
                AllMessages = messages
            };
        }
        private static IEnumerable<MessageServiceModel> GetMessages(IQueryable<Message> query)
        {
            var messages = query
                .Select(a => new MessageServiceModel
                {
                    Id = a.Id,
                    FullName = a.FirstName + " " + a.LastName,
                    Title = a.Title,
                    SendOn = a.SendOn
                })
                .ToList();

            return messages;
        }

        public MessageDetailsServiceModel Details(int id)
        {
            var message = this.data.Messages
                .Where(a => a.Id == id)
                .Select(b => new MessageDetailsServiceModel
                {
                    Id = b.Id,
                    FullName = b.FirstName + " " + b.LastName,
                    Email = b.Email,
                    Body = b.Body,
                    Title = b.Title,
                    SendOn = b.SendOn
                })
                .FirstOrDefault();

            return message;
        }

        public bool Delete(int id)
        {
            var message = this.data
               .Messages
               .Where(a => a.Id == id)
               .FirstOrDefault();

            try
            {
                this.data.Messages.Remove(message);
                this.data.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool MessageExists(int id)
        {
            var message = this.data
                .Messages
                .Where(a => a.Id == id)
                .FirstOrDefault();

            if (message == null)
            {
                return false;
            }

            return true;
        }
    }
}