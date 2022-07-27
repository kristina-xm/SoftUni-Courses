using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementMessage
{
    public class Message
    {
        public Message(string phrase, string @event, string author, string city)
        {
            this.Phrase = phrase;
            this.Event = @event;
            this.Author = author;
            this.City = city;
        }

        public string Phrase { get; set; }

        public string Event { get; set; }

        public string Author { get; set; }

        public string City { get; set; }
    }
}
