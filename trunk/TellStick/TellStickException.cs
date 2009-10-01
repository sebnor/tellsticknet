using System;
using System.Collections.Generic;
using System.Text;

namespace TellStick
{
    public class TellStickException : System.Exception
    {
        public TellStickException()
            : base() { }

        public TellStickException(string message)
            : base(message) { }

        public TellStickException(string message, System.Exception innerException)
            : base(message, innerException) { }

    }
}
