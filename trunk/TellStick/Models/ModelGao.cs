using System;
using System.Collections.Generic;
using System.Text;
using TellStick.Protocols;

namespace TellStick.Models
{
    [ModelName("gao")]
    public class ModelGao : ModelBase
    {
        private ProtocolBase _protocol;

        public override string DisplayName
        {
            get { return "GAO"; }
        }

        public override ProtocolBase Protocol
        {
            get
            {
                if (_protocol == null)
                    _protocol = new ProtocolRisingSun();
                return _protocol;
            }

            set { _protocol = value; }
        }
    }
}
