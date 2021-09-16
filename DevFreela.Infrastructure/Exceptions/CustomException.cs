using DevFreela.Core.Enums;
using System;

namespace DevFreela.Infrastructure.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException()
        {
        }

        public CustomException(string message) : base(message)
        {
            ExceptionMessage = message;
        }

        public CustomException(string message, EExceptionType type) : base(message)
        {
            Type = type;
            ExceptionMessage = message;
        }

        public CustomException(string message, Exception ex) : base(message, ex)
        {
            ExceptionMessage = message;
        }

        public CustomException(string message, Exception ex, EExceptionType type) : base(message, ex)
        {
            Type = type;
            ExceptionMessage = message;
        }

        public virtual EExceptionType Type { get; set; }

        public virtual string ExceptionMessage { get; set; }

        public virtual string ExceptionReason { get; set; }

        public virtual string ExceptionFix { get; set; }
    }
}