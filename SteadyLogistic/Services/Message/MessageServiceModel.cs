namespace SteadyLogistic.Services.Message
{
    using System;

    public class MessageServiceModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Title { get; set; }

        public DateTime SendOn { get; set; }
    }
}