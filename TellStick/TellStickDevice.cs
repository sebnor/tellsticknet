using System;
using System.Collections.Generic;
using System.Text;
using TellStick.Models;
using System.Reflection;
using TellStick.Protocols;

namespace TellStick
{
    public class TellStickDevice
    {
        private int _id = -1;
        private string _name;
        private TellStickMethods _methods;
        private ModelBase _model;
        private TellStickDeviceType _type;
        private TellStickSettingTypes _controlType = 0;
        private Dictionary<TellStickParameterTypes, string> _parameters;

        private TellStickMethods methods
        {
            get
            {
                if (((int)_methods) < 1)
                    _methods = Model.Protocol.SupportedMethods(ControlType);

                if (((int)_methods) < 1)
                    _methods = (TellStickMethods)Base.GetMethods(DeviceId);

                return _methods;
            }
        }

        public int DeviceId { get { return _id; } }
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                    _name = Base.GetName(DeviceId);

                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public TellStickMethods LastSentCommand
        {
            get { return Base.GetLastSentCommand(this.DeviceId, methods); }
        }

        public string LastSetValue
        {
            get { return Base.GetLastSentValue(this.DeviceId); }
        }

        public TellStickSettingTypes ControlType
        {
            get
            {
                if (((int)_controlType) < 1)
                {
                    string[] s = Base.GetModel(DeviceId).Split(new char[] { ':' });
                    string controlName = s[0];

                    foreach (int i in Enum.GetValues(typeof(TellStickSettingTypes)))
                        if (EnumHelper.GetSettingsValueName((TellStickSettingTypes)i).Equals(controlName, StringComparison.InvariantCultureIgnoreCase))
                            _controlType = (TellStickSettingTypes)i;

                }

                return _controlType;
            }
            set
            {
                _parameters = null;//let's delete all parameters, new type = new parameters
                _controlType = value;
            }
        }

        public TellStickDeviceType Type
        {
            get
            {
                if (((int)_type) < 1)
                    _type = (TellStickDeviceType)Base.GetDeviceType(DeviceId);

                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public ModelBase Model
        {
            get
            {
                if (_model == null)
                    _model = Base.GetModel(Base.GetModel(DeviceId), Base.GetProtocol(DeviceId));

                return _model;
            }
            set
            {
                _parameters = null;//let's delete all parameters, new model = new parameters
                _model = value;
            }
        }

        public TellStickDevice() { }
        public TellStickDevice(int deviceId)
        {
            _id = deviceId;
        }
        public TellStickDevice(string name, ModelBase model, TellStickSettingTypes controlType)
        {
            _name = name;
            _model = model;
            _controlType = controlType;
        }

        /// <summary>
        /// Dim the device
        /// </summary>
        /// <param name="level">An integer between 0 to 255 where 0 is off an 255 is on</param>
        /// <returns></returns>
        public bool Dim(int level)
        {
            if (HasMethod(TellStickMethods.Dim))
                if (level >= 0 && level <= 255)
                    return (Base.Dim(this.DeviceId, (byte)level) == TellStickErrors.Success);
                else
                    throw new TellStickException("Level is out of range, it have to be between 0 and 255.");
            else
                throw new TellStickException("The method you are trying to execute is not supported!");
        }

        public bool Bell()
        {
            if (HasMethod(TellStickMethods.Bell))
                return (Base.Bell(this.DeviceId) == TellStickErrors.Success);
            else
                throw new TellStickException("The method you are trying to execute is not supported!");
        }

        public bool TurnOn()
        {
            if (HasMethod(TellStickMethods.TurnOn))
                return (Base.TurnOn(this.DeviceId) == TellStickErrors.Success);
            else
                throw new TellStickException("The method you are trying to execute is not supported!");
        }

        public bool TurnOff()
        {
            if (HasMethod(TellStickMethods.TurnOff))
                return (Base.TurnOff(this.DeviceId) == TellStickErrors.Success);
            else
                throw new TellStickException("The method you are trying to execute is not supported!");
        }

        public bool Learn()
        {
            if (HasMethod(TellStickMethods.Learn))
                return (Base.Learn(this.DeviceId) == TellStickErrors.Success);
            else
                throw new TellStickException("The method you are trying to execute is not supported!");
        }

        public bool Toggle()
        {
            try
            {
                if (LastSentCommand == TellStickMethods.TurnOff)
                    return TurnOn();
                else
                    return TurnOff();
            }
            catch { throw; }
        }

        public bool HasMethod(TellStickMethods method)
        {
            return ((methods & method) == method);
        }

        public string GetParameter(TellStickParameterTypes type)
        {
            if ((int)_controlType < 1)
                throw new TellStickException("You must set SettingType first.");

            try
            {
                if (_parameters == null)
                {
                    _parameters = new Dictionary<TellStickParameterTypes, string>();
                    foreach (Parameter p in Model.Protocol.GetParameters(_controlType))
                        _parameters.Add(p.Type, Base.GetParameter(DeviceId, p.Type));
                }

                if (!_parameters.ContainsKey(type))
                    throw new TellStickException("This device doesn't support this parameter type.");
                else
                    return _parameters[type];
            }
            catch
            { throw; }

        }

        public string SetParameter(TellStickParameterTypes type, string value)
        {
            if ((int)_controlType < 1)
                throw new TellStickException("You must set SettingType first.");

            try
            {
                if (_parameters == null)
                {
                    _parameters = new Dictionary<TellStickParameterTypes, string>();
                    foreach (Parameter p in Model.Protocol.GetParameters(_controlType))
                        _parameters.Add(p.Type, Base.GetParameter(DeviceId, p.Type));
                }

                if (!_parameters.ContainsKey(type))
                    throw new TellStickException("This device doesn't support this parameter type.");
                else
                    _parameters[type] = value;
            }
            catch
            { throw; }

            return "";
        }

        /// <summary>
        /// Saves the edited entry, it does not work like a transaction.
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            if ((int)_controlType < 1)
                throw new TellStickException("You must set SettingType first.");

            if (this.DeviceId < 0)//is it a new device?
            {
                _id = Base.AddDevice();
            }

            if (!Base.SetName(DeviceId, Name))
                return false;

            if (!Base.SetProtocol(DeviceId, Model.Protocol.ProtocolName))
                return false;

            if (!Base.SetModel(DeviceId, string.Format("{0}:{1}", EnumHelper.GetSettingsValueName(_controlType), Model.ModelName)))
                return false;

            if (_parameters != null)
            {
                foreach (KeyValuePair<TellStickParameterTypes, string> kp in _parameters)
                    if (!Base.SetParameter(DeviceId, kp.Key, kp.Value))
                        return false;
            }
            return true;
        }

        public bool Remove()
        {
            return Base.RemoveDevice(DeviceId);
        }
    }
}
