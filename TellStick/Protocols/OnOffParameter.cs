using System;
using System.Collections.Generic;
using System.Text;

namespace TellStick.Protocols
{
    public class OnOffParameter : Parameter
    {
        private string[] _values;
        
        public string[] Values { get { return _values; } set { _values = value; } }
    }
}
