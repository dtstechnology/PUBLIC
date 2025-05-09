﻿using System;
using System.Runtime.Serialization;

namespace DTS.Ear.Library.Exceptions
{
    public class FailedApiRequestException : Exception
    {
        public FailedApiRequestException(string message) : base(message){}

        public FailedApiRequestException(string message, Exception innerException) 
            : base(message, innerException) { }
        protected FailedApiRequestException(SerializationInfo info, StreamingContext context) 
            : base(info, context) { }
    }
}
