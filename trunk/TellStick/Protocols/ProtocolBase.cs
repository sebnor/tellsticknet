using System;
using System.Collections.Generic;
using System.Text;
using TellStick;
using TellStick.Models;

namespace TellStick.Protocols
{
    public abstract class ProtocolBase
    {
        public abstract TellStickSettingTypes SettingTypes { get; set; }
        public abstract IEnumerable<Parameter> GetParameters(TellStickSettingTypes type);

        public virtual TellStickMethods SupportedMethods(TellStickSettingTypes type) { return 0; }

        protected string _protocolName = "";

        public string ProtocolName
        {
            get
            {
                if (!string.IsNullOrEmpty(_protocolName))
                    return _protocolName;
                else
                    return ((ProtocolNameAttribute)this.GetType().GetCustomAttributes(typeof(ProtocolNameAttribute), false)[0]).Name;
            }
        }
    }
}
