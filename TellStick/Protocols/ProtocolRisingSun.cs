using System;
using System.Collections.Generic;
using System.Text;
using TellStick.Models;

namespace TellStick.Protocols
{
    [ProtocolName("risingsun")]
    public class ProtocolRisingSun : ProtocolBase
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
                yield return BuildHouseParameter();
                yield return BuildUnitParameter();
            }
            else
                throw new TellStickException("This device doesn't support this settings type.");
        }

        private Parameter BuildUnitParameter()
        {
            MinMaxParameter unitParameter = new MinMaxParameter();
            unitParameter.ParameterType = typeof(int);
            unitParameter.Min = 1;
            unitParameter.Max = 4;
            unitParameter.Type = TellStickParameterTypes.Unit;
            unitParameter.ValidationRegex = new System.Text.RegularExpressions.Regex("^[1-4]{1}$");
            
            return unitParameter;
        }

        private Parameter BuildHouseParameter()
        {
            MinMaxParameter houseParameter = new MinMaxParameter();
            houseParameter.ParameterType = typeof(int);
            houseParameter.Min = 1;
            houseParameter.Max = 4;
            houseParameter.Type = TellStickParameterTypes.House;
            houseParameter.ValidationRegex = new System.Text.RegularExpressions.Regex("^[1-4]{1}$");

            return houseParameter;
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
