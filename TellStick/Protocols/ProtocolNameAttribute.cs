using System;
using System.Collections.Generic;
using System.Text;

namespace TellStick.Protocols
{
    public class ProtocolNameAttribute : Attribute
    {
        string _name;
        public string Name { get { return _name; } }

        public ProtocolNameAttribute(string name)
        {
            _name = name;
        }
    }
}
