using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling
{
    public class GameoverException : Exception
    {
        public GameoverException()
        { }

        public GameoverException(string message)
            : base(message)
        { }

        public GameoverException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }

}
