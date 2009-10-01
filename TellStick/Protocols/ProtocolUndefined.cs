using System;
using System.Collections.Generic;
using System.Text;

namespace TellStick.Protocols
{
    [ProtocolName("undefined")]
    public class ProtocolUndefined : ProtocolBase
    {
        private TellStickSettingTypes _settingTypes = 0;

        public override IEnumerable<Parameter> GetParameters(TellStickSettingTypes type)
        {
            return null;
        }

        public override TellStickSettingTypes SettingTypes
        {
            get { return _settingTypes; }
            set { _settingTypes = value; }
        }

        
        public ProtocolUndefined(string name)
        {
            base._protocolName = name;
        }
    }
}
