using System;
using System.Collections.Generic;
using System.Text;
using TellStick.Protocols;

namespace TellStick.Models
{
    [ModelName("sartano")]
    public class ModelSartano : ModelBase
    {
        private ProtocolBase _protocol;

        public override string DisplayName
        {
            get { return "Sartano"; }
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
