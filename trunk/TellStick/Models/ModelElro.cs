using System;
using System.Collections.Generic;
using System.Text;
using TellStick.Protocols;

namespace TellStick.Models
{
    [ModelName("elro")]
    public class ModelElro : ModelBase
    {
        private ProtocolBase _protocol;

        public override string DisplayName
        {
            get { return "Elro"; }
        }

        public override ProtocolBase Protocol
        {
            get
            {
                if (_protocol == null)
                    _protocol = new ProtocolSartano();
                return _protocol;
            }

            set { _protocol = value; }
        }
    }
}
