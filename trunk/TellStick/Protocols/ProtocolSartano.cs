using System;
using System.Collections.Generic;
using System.Text;
using TellStick.Models;

namespace TellStick.Protocols
{
    [ProtocolName("sartano")]
    public class ProtocolSartano : ProtocolBase
    {
        private TellStickSettingTypes _settingTypes = TellStickSettingTypes.CodeSwitch;

        public override TellStickSettingTypes SettingTypes
        {
            get { return _settingTypes; }
            set { _settingTypes = value; }
        }

        public override IEnumerable<Parameter> GetParameters(TellStickSettingTypes type)
        {
            if (type == TellStickSettingTypes.CodeSwitch)
            {
                yield return BuildCodeParameter();
            }
            else
                throw new TellStickException("This device doesn't support this settings type.");
        }

        private Parameter BuildCodeParameter()
        {
            OnOffParameter codeParameter = new OnOffParameter();
            codeParameter.Values = new string[] { "1", "2", "3", "4", "5", "A", "B", "C", "D", "E" };
            codeParameter.Type = TellStickParameterTypes.Code;
            codeParameter.ValidationRegex = new System.Text.RegularExpressions.Regex("^[01]{10}$");

            return codeParameter;
        }

        /// <summary>
        /// Only exists because I experienced some problem with tdMethods(), for some reason the method didn't always return correct flags.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override TellStickMethods SupportedMethods(TellStickSettingTypes type)
        {
            if (type == TellStickSettingTypes.CodeSwitch)
                return TellStickMethods.TurnOff | TellStickMethods.TurnOn;
            else
                return 0;
        }
    }
}
