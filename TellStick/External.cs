using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace TellStick
{
    internal static class External
    {
        internal delegate void TDDeviceEventCallBack(DeviceEvent ev);
        internal delegate void TDRawEventCallBack(RawEvent ev);

        [DllImport("TelldusCore.dll")]
        internal static extern int tdRegisterDeviceEvent(TDDeviceEventCallBack eventFunction, IntPtr context);

        [DllImport("TelldusCore.dll")]
        internal static extern int tdRegisterRawDeviceEvent(TDRawEventCallBack eventFunction, IntPtr context);

        [DllImport("TelldusCore.dll")]
        internal static extern int tdSendRawCommand(string command, int reserved);

        [DllImport("TelldusCore.dll")]
        internal static extern int tdAddDevice();

        [DllImport("TelldusCore.dll")]
        internal static extern int tdTurnOn(int deviceId);

        [DllImport("TelldusCore.dll")]
        internal static extern int tdTurnOff(int deviceId);

        [DllImport("TelldusCore.dll")]
        internal static extern int tdBell(int deviceId);

        [DllImport("TelldusCore.dll")]
        internal static extern int tdLearn(int deviceId);

        [DllImport("TelldusCore.dll")]
        internal static extern int tdDim(int deviceId, byte level);

        [DllImport("TelldusCore.dll")]
        internal static extern int tdLastSentCommand(int deviceId, int methodsSupported);

        [DllImport("TelldusCore.dll")]
        internal static extern string tdLastSentValue(int deviceId);

        [DllImport("TelldusCore.dll")]
        internal static extern string tdGetErrorString(int intErrorNo);

        [DllImport("TelldusCore.dll")]
        internal static extern int tdGetDeviceType(int deviceId);

        [DllImport("TelldusCore.dll")]
        internal static extern int tdGetNumberOfDevices();

        [DllImport("TelldusCore.dll")]
        internal static extern string tdGetName(int deviceId);

        [DllImport("TelldusCore.dll")]
        internal static extern bool tdSetName(int deviceId, string newName);

        [DllImport("TelldusCore.dll")]
        internal static extern string tdGetProtocol(int deviceId);

        [DllImport("TelldusCore.dll")]
        internal static extern bool tdSetProtocol(int deviceId, string newName);

        [DllImport("TelldusCore.dll")]
        internal static extern string tdGetDeviceParameter(int deviceId, string name, string defaultValue);

        [DllImport("TelldusCore.dll")]
        internal static extern bool tdSetDeviceParameter(int deviceId, string name, string value);

        [DllImport("TelldusCore.dll")]
        internal static extern string tdGetModel(int deviceId);

        [DllImport("TelldusCore.dll")]
        internal static extern bool tdSetModel(int deviceId, string newName);

        [DllImport("TelldusCore.dll")]
        internal static extern int tdMethods(int deviceId);

        [DllImport("TelldusCore.dll")]
        internal static extern bool tdRemoveDevice(int deviceId);

        [DllImport("TelldusCore.dll")]
        internal static extern int tdGetDeviceId(int deviceIndex);

    }
}
