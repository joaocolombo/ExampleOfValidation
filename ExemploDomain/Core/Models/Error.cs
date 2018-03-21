using System;

namespace Core.Models
{
    public class Error
    {
        private Error()
        {
        }
        public string Title { get; private set; }
        public string Message { get; private set; }
        public ErroTypes Type { get; private set; }

        public static class ErrorFactory
        {
            public static Error NewError(string title, string message, ErroTypes type)
            {
                return new Error()
                {
                    Title = title,
                    Message = message,
                    Type = type
                };
            }
            public static Error NewError(string message, ErroTypes type)
            {
                return new Error()
                {
                    Message = message,
                    Type = type
                };
            }

        }


    }

    public enum ErroTypes
    {
        Error,
        Warning
    }
}