using System;
using System.Collections.Generic;
using System.Text;
using TellStick.Protocols;

namespace TellStick.Models
{
    [ModelName("homeeasy")]
    public class ModelHomeEasy : ModelBase
    {
        private ProtocolBase _protocol;

        public override string DisplayName
        {
            get { return "HomeEasy"; }
        }

        public override ProtocolBase Protocol
        {
            get
            {
                if (_protocol == null)
                {
                    _protocol = new ProtocolArctech();
                    _protocol.SettingTypes = TellStickSettingTypes.CodeSwitch | TellStickSettingTypes.SelfLearningSwitch | TellStickSettingTypes.SelfLearningDimmer;
                }
                return _protocol;
            }

            set { _protocol = value; }
        }
    }
}
