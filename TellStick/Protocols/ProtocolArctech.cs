using System;
using System.Collections.Generic;
using System.Text;
using TellStick.Models;

namespace TellStick.Protocols
{
    [ProtocolName("arctech")]
    public class ProtocolArctech : ProtocolBase
    {
        private TellStickSettingTypes _settingTypes = TellStickSettingTypes.CodeSwitch | TellStickSettingTypes.SelfLearningSwitch | TellStickSettingTypes.SelfLearningDimmer | TellStickSettingTypes.Bell;

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
            else if (type == TellStickSettingTypes.SelfLearningSwitch)
            {
                yield return BuildSelfLearningHouseParameter();
                yield return BuildUnitParameter();
            }
            else if (type == TellStickSettingTypes.SelfLearningDimmer)
            {
                yield return BuildSelfLearningHouseParameter();
                yield return BuildUnitParameter();
            }
            else if (type == TellStickSettingTypes.Bell)
            {
                yield return BuildHouseParameter();
            }
            else
                throw new TellStickException("This device doesn't support this settings type.");
        }

        private Parameter BuildSelfLearningHouseParameter()
        {
            MinMaxParameter selfLearnHouseParameter = new MinMaxParameter();
            selfLearnHouseParameter.ParameterType = typeof(int);
            selfLearnHouseParameter.Min = 1;
            selfLearnHouseParameter.Max = 9999999;
            selfLearnHouseParameter.Type = TellStickParameterTypes.House;
            selfLearnHouseParameter.ValidationRegex = new System.Text.RegularExpressions.Regex("^[1-9]{1,7}$");

            return selfLearnHouseParameter;
        }

        private Parameter BuildUnitParameter()
        {
            MinMaxParameter unitParameter = new MinMaxParameter();
            unitParameter.ParameterType = typeof(int);
            unitParameter.Min = 1;
            unitParameter.Max = 16;
            unitParameter.Type = TellStickParameterTypes.Unit;
            unitParameter.ValidationRegex = new System.Text.RegularExpressions.Regex("^[1-9]{1}$|^[1]{1}[1-6]{1}$");
            
            return unitParameter;
        }

        private Parameter BuildHouseParameter()
        {
            MinMaxParameter houseParameter = new MinMaxParameter();
            houseParameter.ParameterType = typeof(char);
            houseParameter.Min = 'A';
            houseParameter.Max = 'P';
            houseParameter.Type = TellStickParameterTypes.House;
            houseParameter.ValidationRegex = new System.Text.RegularExpressions.Regex("^[a-pA-P]{1}$");

            return houseParameter;
        }

        /// <summary>
        /// Only exists because I experienced some problem with tdMethods(), for some reason the method didn't always return correct flags.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override TellStickMethods SupportedMethods(TellStickSettingTypes type)
        {
            if (type == TellStickSettingTypes.Bell)
                return TellStickMethods.Bell;
            else if (type == TellStickSettingTypes.CodeSwitch)
                return TellStickMethods.TurnOff | TellStickMethods.TurnOn;
            else if (type == TellStickSettingTypes.SelfLearningSwitch)
                return TellStickMethods.TurnOff | TellStickMethods.TurnOn | TellStickMethods.Learn;
            else if (type == TellStickSettingTypes.SelfLearningDimmer)
                return TellStickMethods.TurnOff | TellStickMethods.TurnOn | TellStickMethods.Learn | TellStickMethods.Dim;
            else
                return 0;
        }
    }
}
