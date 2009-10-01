using System;
using System.Collections.Generic;
using System.Text;
using TellStick.Protocols;

namespace TellStick.Models
{
    [ModelName("ikea")]
    public class ModelIkea : ModelBase
    {
        private ProtocolBase _protocol;

        public override string DisplayName
        {
            get { return "IKEA"; }
        }

        public override ProtocolBase Protocol
        {
            get
            {
                if (_protocol == null)
                    _protocol = new ProtocolIkea();
                return _protocol;
            }

            set { _protocol = value; }
        }
    }
}
