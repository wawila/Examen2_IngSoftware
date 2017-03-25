using System;
using System.Runtime.Serialization;

namespace Examen2.Parse
{
    [Serializable]
    internal class InvalidToken : Exception
    {
        public InvalidToken()
        {
        }

        public InvalidToken(string message) : base(message)
        {
        }

        public InvalidToken(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidToken(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}