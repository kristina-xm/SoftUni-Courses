using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace Exam.Discord
{
    public class Discord : IDiscord
    {
        Dictionary<string,Message> messagesById = new Dictionary<string, Message>();
        Dictionary<string, HashSet<Message>> messagesByChannel = new Dictionary<string, HashSet<Message>>();
        public int Count => messagesById.Count;

        public bool Contains(Message message)
        {
            return messagesById.ContainsKey(message.Id);
        }

        public void DeleteMessage(string messageId)
        {
            if (!messagesById.ContainsKey(messageId))
            {
                throw new ArgumentException();
            }

            var message = messagesById[messageId];

            if (messagesByChannel[message.Channel].Contains(message))
            {
                messagesByChannel[message.Channel].Remove(message);
            }

            messagesById.Remove(messageId);
        }

        public IEnumerable<Message> GetAllMessagesOrderedByCountOfReactionsThenByTimestampThenByLengthOfContent()
        {
            return messagesById.Values
            .OrderByDescending(m => m.Reactions.Count)
            .ThenBy(m => m.Timestamp)
            .ThenBy(m => m.Content.Length)
            .ToArray();
        }

        public IEnumerable<Message> GetChannelMessages(string channel)
        {
            if (messagesByChannel[channel].Count() == 0)
            {
                throw new ArgumentException();
            }

            return messagesByChannel[channel].ToArray();
        }

        public Message GetMessage(string messageId)
        {
            if (!messagesById.ContainsKey(messageId))
            {
                throw new ArgumentException();
            }

            return messagesById.GetValueOrDefault(messageId);
        }

        public IEnumerable<Message> GetMessageInTimeRange(int lowerBound, int upperBound)
        {
            var messagesInRange = messagesByChannel.Values
            .SelectMany(channelMessages => channelMessages.Where(m => m.Timestamp >= lowerBound && m.Timestamp <= upperBound))
            .OrderByDescending(m => messagesByChannel[m.Channel].Count);

            return messagesInRange;
        }

        public IEnumerable<Message> GetMessagesByReactions(List<string> reactions)
        {
             var matchingMessages = messagesById.Values
                .Where(message => reactions.All(reaction => message.Reactions.Contains(reaction)))
                .OrderByDescending(message => message.Reactions.Count)
                .ThenBy(message => message.Timestamp);

            return matchingMessages;
        }

        public IEnumerable<Message> GetTop3MostReactedMessages()
        {
            var topMessages = messagesById.Values.OrderByDescending(m => m.Reactions.Count)
            .Take(3)
            .ToArray();

            return topMessages;
        }

        public void ReactToMessage(string messageId, string reaction)
        {
            if (!messagesById.ContainsKey(messageId))
            {
                throw new ArgumentException();
            }

            messagesById[messageId].Reactions.Add(reaction);
        }

        public void SendMessage(Message message)
        {
            messagesById.Add(message.Id, message);

            if (messagesByChannel.ContainsKey(message.Channel))
            {
                messagesByChannel[message.Channel].Add(message);
            }
            else
            {
                messagesByChannel.Add(message.Channel, new HashSet<Message>());
                messagesByChannel[message.Channel].Add(message);
            }
           
            
        }

    }
}
