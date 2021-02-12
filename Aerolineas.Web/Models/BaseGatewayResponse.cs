using System.Collections.Generic;

namespace Aerolineas.Models
{
    public abstract class BaseGatewayResponse
    {
        public bool Success { get; }
        public IEnumerable<Message> Messages { get; }

        protected BaseGatewayResponse(bool success = false, IEnumerable<Message> messages = null)
        {
            Success = success;
            Messages = messages;
        }
    }

    public sealed class Message
    {
        public Codes Code { get; }
        public string Description { get; }

        public Message(Codes code, string description)
        {
            Code = code;
            Description = description;
        }
    }

    public enum Codes
    {
        Ok = 0,
        Exception = 1,
        Mandatory = 2
    }
}
