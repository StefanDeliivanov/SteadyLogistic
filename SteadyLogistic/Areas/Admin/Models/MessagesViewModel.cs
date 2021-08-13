namespace SteadyLogistic.Areas.Admin.Models
{
    using System.Collections.Generic;
    using SteadyLogistic.Services.Message;

    public class MessagesViewModel
    {
        public const int MessagesPerPage = 8;

        public int CurrentPage { get; init; } = 1;

        public int TotalMessages { get; set; }

        public IEnumerable<MessageServiceModel> Messages { get; set; }
    }
}