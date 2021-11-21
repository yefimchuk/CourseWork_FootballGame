using System;

namespace PL
{
    public class MenuArgsException : Exception
    {
        public MenuArgsException(string message) 
            : base(message)
        {
        }
    }
}
