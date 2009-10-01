using System;
using System.Collections.Generic;
using System.Text;

namespace TellStick.Protocols
{
    public class MinMaxParameter : Parameter
    {
        private Type _pType;
        private object _min;
        private object _max;

        public Type ParameterType { get { return _pType; } set { _pType = value; } }
        public object Min { get { return _min; } set { _min = value; } }
        public object Max { get { return _max; } set { _max = value; } }
    }
}
