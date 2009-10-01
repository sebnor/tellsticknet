using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TellStick.Protocols
{
    public class Parameter
    {
        private TellStickParameterTypes _type;
        private Regex _validation;

        public TellStickParameterTypes Type { get { return _type; } set { _type = value; } }
        public Regex ValidationRegex { get { return _validation; } set { _validation = value; } }

        public virtual bool Validate(string value)
        {
            return _validation.IsMatch(value);
        }
    }
}
