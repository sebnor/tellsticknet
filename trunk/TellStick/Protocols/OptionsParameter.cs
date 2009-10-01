using System;
using System.Collections.Generic;
using System.Text;

namespace TellStick.Protocols
{
    public class OptionsParameter : Parameter
    {
        private string[][] _values;
        
        /// <summary>
        /// { {"DisplayName", "Value"}, {"DisplayName", "Value"} }
        /// </summary>
        public string[][] Values { get { return _values; } set { _values = value; } }
    }
}
