﻿using System;
using System.Runtime.Serialization;

namespace Examen2.Lexical
{
    [Serializable]
    internal class IllegalTokenException : Exception
    {
        public IllegalTokenException()
        {
        }

        public IllegalTokenException(string message) : base(message)
        {
        }

        public IllegalTokenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IllegalTokenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}