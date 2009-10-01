using System;
using System.Collections.Generic;
using System.Text;
using TellStick.Protocols;

namespace TellStick.Models
{
    [ModelName("undefined", false)]
    public class ModelUndefined : ModelBase
    {
        private ProtocolBase _protocol = null;

        public override string DisplayName
        {
            get { return "undefined"; }
        }

        public override ProtocolBase Protocol
        {
            get
            {
                return _protocol;
            }

            set { _protocol = value; }
        }

        public ModelUndefined(string name)
        {
            base._modelName = name;
        }
    }
}
