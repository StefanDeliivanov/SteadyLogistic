namespace SteadyLogistic.Services.Message
{
    using System.Collections.Generic;

    public class MessageQueryServiceModel
    {
        public int CurrentPage { get; init; }

        public int MessagesPerPage { get; init; }

        public int TotalMessages { get; init; }

        public IEnumerable<MessageServiceModel> AllMessages { get; init; }
    }
}
