using System.Collections.Generic;
using TellStick.Models;
using TellStick.Protocols;
using System;
using System.Reflection;

namespace TellStick
{
    public static class Base
    {
        private static TellStickMethods? _supportedMethods = null;
        public static TellStickMethods? SupportedMethods
        {
            get { return _supportedMethods; }
            set { _supportedMethods = value; }
        }

        public static int SendRawCommand(string command)
        {
            try
            {
                return External.tdSendRawCommand(command, 0);
            }
            catch (System.DllNotFoundException ex)
            {
                throw new TellStickException("Could not find TellStick software. Please make sure it's installed before you run this application!", ex);
            }
            catch
            {
                throw;
            }
        }

        public static int GetNumberOfDevices()
        {
            try
            {
                return External.tdGetNumberOfDevices();
            }
            catch (System.DllNotFoundException ex)
            {
                throw new TellStickException("Could not find TellStick software. Please make sure it's installed before you run this application!", ex);
            }
            catch
            {
                throw;
            }
        }

        public static int GetMethods(int deviceId, TellStickMethods methodsSupported)
        {
            try
            {
                int i = External.tdMethods(deviceId, (int)methodsSupported);
                return i;
            }
            catch (System.DllNotFoundException ex)
            {
                throw new TellStickException("Could not find TellStick software. Please make sure it's installed before you run this application!", ex);
            }
            catch
            {
                throw;
            }
        }

        public static TellStickDeviceType GetDeviceType(int deviceId)
        {
            try
            {
                return (TellStickDeviceType)External.tdGetDeviceType(deviceId);
            }
            catch (System.DllNotFoundException ex)
            {
                throw new TellStickException("Could not find TellStick software. Please make sure it's installed before you run this application!", ex);
            }
            catch
            {
                throw;
            }
        }

        public static int AddDevice()
        {
            try
            {
                return External.tdAddDevice();
            }
            catch (System.DllNotFoundException ex)
            {
                throw new TellStickException("Could not find TellStick software. Please make sure it's installed before you run this application!", ex);
            }
            catch
            {
                throw;
            }
        }

        public static bool RemoveDevice(int deviceId)
        {
            try
            {
                return External.tdRemoveDevice(deviceId);
            }
            catch (System.DllNotFoundException ex)
            {
                throw new TellStickException("Could not find TellStick software. Please make sure it's installed before you run this application!", ex);
            }
            catch
            {
                throw;
            }
        }

        public static int GetDeviceId(int deviceIndex)
        {
            try
            {
                return External.tdGetDeviceId(deviceIndex);
            }
            catch (System.DllNotFoundException ex)
            {
                throw new TellStickException("Could not find TellStick software. Please make sure it's installed before you run this application!", ex);
            }
            catch
            {
                throw;
            }

        }

        public static string GetName(int deviceId)
        {
            try
            {
                return External.tdGetName(deviceId);
            }
            catch (System.DllNotFoundException ex)
            {
                throw new TellStickException("Could not find TellStick software. Please make sure it's installed before you run this application!", ex);
            }
            catch
            {
                throw;
            }
        }

        public static bool SetName(int deviceId, string newName)
        {
            try
            {
                return External.tdSetName(deviceId, newName);
            }
            catch (System.DllNotFoundException ex)
            {
                throw new TellStickException("Could not find TellStick software. Please make sure it's installed before you run this application!", ex);
            }
            catch
            {
                throw;
            }
        }

        public static string GetModel(int deviceId)
        {
            try
            {
                return External.tdGetModel(deviceId);
            }
            catch (System.DllNotFoundException ex)
            {
                throw new TellStickException("Could not find TellStick software. Please make sure it's installed before you run this application!", ex);
            }
            catch
            {
                throw;
            }
        }

        public static bool SetModel(int deviceId, string newModel)
        {
            try
            {
                return External.tdSetModel(deviceId, newModel);
            }
            catch (System.DllNotFoundException ex)
            {
                throw new TellStickException("Could not find TellStick software. Please make sure it's installed before you run this application!", ex);
            }
            catch
            {
                throw;
            }
        }

        public static TellStickErrors Bell(int deviceId)
        {
            try
            {
                return (TellStickErrors)External.tdBell(deviceId);
            }
            catch (System.DllNotFoundException ex)
            {
                throw new TellStickException("Could not find TellStick software. Please make sure it's installed before you run this application!", ex);
            }
            catch
            {
                throw;
            }
        }

        public static TellStickErrors Dim(int deviceId, byte level)
        {
            try
            {
                return (TellStickErrors)External.tdDim(deviceId, level);
            }
            catch (System.DllNotFoundException ex)
            {
                throw new TellStickException("Could not find TellStick software. Please make sure it's installed before you run this application!", ex);
            }
            catch
            {
                throw;
            }
        }

        public static TellStickErrors TurnOn(int deviceId)
        {
            try
            {
                return (TellStickErrors)External.tdTurnOn(deviceId);
            }
            catch (System.DllNotFoundException ex)
            {
                throw new TellStickException("Could not find TellStick software. Please make sure it's installed before you run this application!", ex);
            }
            catch
            {
                throw;
            }
        }

        public static TellStickErrors TurnOff(int deviceId)
        {
            try
            {
                return (TellStickErrors)External.tdTurnOff(deviceId);
            }
            catch (System.DllNotFoundException ex)
            {
                throw new TellStickException("Could not find TellStick software. Please make sure it's installed before you run this application!", ex);
            }
            catch
            {
                throw;
            }
        }

        public static TellStickErrors Learn(int deviceId)
        {
            try
            {
                return (TellStickErrors)External.tdLearn(deviceId);
            }
            catch (System.DllNotFoundException ex)
            {
                throw new TellStickException("Could not find TellStick software. Please make sure it's installed before you run this application!", ex);
            }
            catch
            {
                throw;
            }
        }

        public static bool SetParameter(int deviceId, TellStickParameterTypes type, string value)
        {
            try
            {
                return External.tdSetDeviceParameter(deviceId, type.ToString().ToLower(), value);
            }
            catch (System.DllNotFoundException ex)
            {
                throw new TellStickException("Could not find TellStick software. Please make sure it's installed before you run this application!", ex);
            }
            catch
            {
                throw;
            }
        }

        public static string GetParameter(int deviceId, TellStickParameterTypes type)
        {
            try
            {
                return External.tdGetDeviceParameter(deviceId, type.ToString().ToLower(), "");
            }
            catch (System.DllNotFoundException ex)
            {
                throw new TellStickException("Could not find TellStick software. Please make sure it's installed before you run this application!", ex);
            }
            catch
            {
                throw;
            }
        }

        public static string GetProtocol(int deviceId)
        {
            try
            {
                return External.tdGetProtocol(deviceId);
            }
            catch (System.DllNotFoundException ex)
            {
                throw new TellStickException("Could not find TellStick software. Please make sure it's installed before you run this application!", ex);
            }
            catch
            {
                throw;
            }
        }

        public static bool SetProtocol(int deviceId, string newProtocol)
        {
            try
            {
                if (newProtocol.Equals("nexa", System.StringComparison.InvariantCultureIgnoreCase))
                    return External.tdSetProtocol(deviceId, "arctech");
                else
                    return External.tdSetProtocol(deviceId, newProtocol);
            }
            catch (System.DllNotFoundException ex)
            {
                throw new TellStickException("Could not find TellStick software. Please make sure it's installed before you run this application!", ex);
            }
            catch
            {
                throw;
            }
        }

        public static string GetLastSentValue(int deviceId)
        {
            try
            {
                return External.tdLastSentValue(deviceId);
            }
            catch (System.DllNotFoundException ex)
            {
                throw new TellStickException("Could not find TellStick software. Please make sure it's installed before you run this application!", ex);
            }
            catch
            {
                throw;
            }
        }
        
        public static TellStickMethods GetLastSentCommand(int deviceId, TellStickMethods supportedMethods)
        {
            try
            {
                return (TellStickMethods)External.tdLastSentCommand(deviceId, (int)supportedMethods);
            }
            catch (System.DllNotFoundException ex)
            {
                throw new TellStickException("Could not find TellStick software. Please make sure it's installed before you run this application!", ex);
            }
            catch
            {
                throw;
            }
        }

        public static IEnumerable<TellStickDevice> GetDevices()
        {
            for (int i = 0; i < Base.GetNumberOfDevices(); i++)
            {
                TellStickDevice d = new TellStickDevice(Base.GetDeviceId(i));
                yield return d;
            }
        }

        public static ModelBase GetModel(string modelName, string protocolName)
        {
            ModelBase _modelType = null;

            string[] s = modelName.Split(new char[] { ':' });
            if (s.Length > 1)
                modelName = s[1];
            else
                modelName = s[0];


            foreach (Type t in Assembly.GetAssembly(typeof(TellStick.TellStickDevice)).GetTypes())
            {
                if (t.Namespace.Equals("TellStick.Models") && t.BaseType == typeof(ModelBase))
                {
                    foreach (ModelNameAttribute attribute in t.GetCustomAttributes(typeof(ModelNameAttribute), true))
                        if (attribute != null && attribute.Name.Equals(modelName, StringComparison.InvariantCultureIgnoreCase))
                            _modelType = (ModelBase)Activator.CreateInstance(t);
                }
            }

            if (_modelType == null)
                _modelType = new ModelUndefined(modelName);

            //If we dont have a protocol we should at least try to find that.
            if (_modelType.Protocol == null)
            {
                foreach (Type t in Assembly.GetAssembly(typeof(TellStick.TellStickDevice)).GetTypes())
                {
                    if (t.Namespace.Equals("TellStick.Protocols") && t.BaseType == typeof(ProtocolBase))
                    {
                        foreach (ProtocolNameAttribute attribute in t.GetCustomAttributes(typeof(ProtocolNameAttribute), true))
                            if (attribute != null && attribute.Name.Equals(protocolName, StringComparison.InvariantCultureIgnoreCase))
                                _modelType.Protocol = (ProtocolBase)Activator.CreateInstance(t);
                    }
                }

                if (_modelType.Protocol == null)
                    _modelType.Protocol = new ProtocolUndefined(protocolName);
            }


            return _modelType;
        }


        #region eventHandler
        private static int _deviceHandlerId = -1;
        private static event DeviceEventHandler _deviceEvent;
        public static event DeviceEventHandler DeviceEvent
        {
            add
            {
                _deviceEvent = (DeviceEventHandler)Delegate.Combine(_deviceEvent, value);
                if (_deviceEvent !=  null && _deviceHandlerId < 0)
                {
                    _deviceHandlerId = External.tdRegisterDeviceEvent(tdDeviceEvent, new IntPtr(1));
                }
            }
            remove
            {
                _deviceEvent = (DeviceEventHandler)Delegate.Remove(_deviceEvent, value);
                if (_deviceEvent == null)
                {

                }
            }
        }

        private static void tdDeviceEvent(DeviceEvent ev)
        {
            OnDeviceEvent(new EventArgs());
        }

        internal static void OnDeviceEvent(EventArgs e)
        {
            if (_deviceEvent != null)
                _deviceEvent(e);
        }

        private static int _rawHandlerId = -1;
        private static event RawEventHandler _rawEvent;
        public static event RawEventHandler RawEvent
        {
            add
            {
                _rawEvent = (RawEventHandler)Delegate.Combine(_rawEvent, value);
                if (_rawEvent != null && _rawHandlerId < 0)
                {
                    _rawHandlerId = External.tdRegisterRawDeviceEvent(tdRawDeviceEvent, new IntPtr(1));
                }
            }
            remove
            {
                _rawEvent = (RawEventHandler)Delegate.Remove(_rawEvent, value);
                if (_rawEvent == null)
                {

                }
            }
        }
        
        private static void tdRawDeviceEvent(RawEvent ev)
        {
            OnRawEvent(new EventArgs());
        }

        internal static void OnRawEvent(EventArgs e)
        {
            if (_rawEvent != null)
                _rawEvent(e);
        }

        #endregion
    }

    #region eventDelegates
    public delegate void DeviceEventHandler(EventArgs e);
    public delegate void RawEventHandler(EventArgs e);
    #endregion
}