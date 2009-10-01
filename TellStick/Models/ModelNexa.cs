using System;
using System.Collections.Generic;
using System.Text;
using TellStick.Protocols;

namespace TellStick.Models
{
    [ModelName("nexa")]
    public class ModelNexa : ModelBase
    {
        private ProtocolBase _protocol;

        public override string DisplayName
        {
            get { return "Nexa"; }
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
