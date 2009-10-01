using System;
using System.Collections.Generic;
using System.Text;
using TellStick.Protocols;

namespace TellStick.Models
{
    [ModelName("chacon")]
    public class ModelChacon : ModelBase
    {
        private ProtocolBase _protocol;

        public override string DisplayName
        {
            get { return "Chacon"; }
        }

        public override ProtocolBase Protocol
        {
            get
            {
                if (_protocol == null)
                    _protocol = new ProtocolArctech();
                return _protocol;
            }

            set { _protocol = value; }
        }
    }
}
