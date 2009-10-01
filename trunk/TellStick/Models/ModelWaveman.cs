using System;
using System.Collections.Generic;
using System.Text;
using TellStick.Protocols;

namespace TellStick.Models
{
    [ModelName("waveman")]
    public class ModelWaveman : ModelBase
    {
        private ProtocolBase _protocol;

        public override string DisplayName
        {
            get { return "Waveman"; }
        }

        public override ProtocolBase Protocol
        {
            get
            {
                if (_protocol == null)
                    _protocol = new ProtocolWaveman();
                return _protocol;
            }

            set { _protocol = value; }
        }
    }
}
