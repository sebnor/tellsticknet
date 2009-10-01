using System;
using System.Collections.Generic;
using System.Text;
using TellStick.Models;

namespace TellStick.Protocols
{
    [ProtocolName("ikea")]
    public class ProtocolIkea : ProtocolBase
    {
        private TellStickSettingTypes _settingTypes = TellStickSettingTypes.SelfLearning;

        public override TellStickSettingTypes SettingTypes
        {
            get { return _settingTypes; }
            set { _settingTypes = value; }
        }

        public override IEnumerable<Parameter> GetParameters(TellStickSettingTypes type)
        {
            if (type == TellStickSettingTypes.SelfLearning)
            {
                yield return BuildUnitsParameter();
                yield return BuildSystemParameter();
                yield return BuildFadeParameter();
            }
            else
                throw new TellStickException("This device doesn't support this settings type.");
        }

        private Parameter BuildUnitsParameter()
        {
            OnOffParameter unitsParameter = new OnOffParameter();
            unitsParameter.Values = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            unitsParameter.Type = TellStickParameterTypes.Units;
            unitsParameter.ValidationRegex = new System.Text.RegularExpressions.Regex("^(([1-9]|10),?){0,9}(([1-9]|10))$");

            return unitsParameter;
        }

        private Parameter BuildSystemParameter()
        {
            MinMaxParameter unitParameter = new MinMaxParameter();
            unitParameter.ParameterType = typeof(int);
            unitParameter.Min = 1;
            unitParameter.Max = 16;
            unitParameter.Type = TellStickParameterTypes.System;
            unitParameter.ValidationRegex = new System.Text.RegularExpressions.Regex("^[1-9]{1}$|^[1]{1}[1-6]{1}$");

            return unitParameter;
        }

        private Parameter BuildFadeParameter()
        {
            OptionsParameter unitsParameter = new OptionsParameter();
            unitsParameter.Values = new string[][] { new string[] { "Soft", "true" }, new string[] { "Direct", "false" } };
            unitsParameter.Type = TellStickParameterTypes.Fade;
            unitsParameter.ValidationRegex = new System.Text.RegularExpressions.Regex("^true$|^false$");

            return unitsParameter;
        }


        /// <summary>
        /// Only exists because I experienced some problem with tdMethods(), for some reason the method didn't always return correct flags.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override TellStickMethods SupportedMethods(TellStickSettingTypes type)
        {
            if (type == TellStickSettingTypes.SelfLearning)
                return TellStickMethods.TurnOff | TellStickMethods.TurnOn | TellStickMethods.Dim;
            else
                return 0;
        }
    }
}
