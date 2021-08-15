namespace SteadyLogistic.Services.Message
{
    using System.Collections.Generic;

    public class MessageQueryServiceModel
    {
        public int CurrentPage { get; set; }

        public int MessagesPerPage { get; set; }

        public int TotalMessages { get; set; }

        public IEnumerable<MessageServiceModel> AllMessages { get; set; }
    }
}
