using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace TellStick
{
    //typedef void (WINAPI *TDDeviceEvent)(int deviceId, int method, const char *data, int callbackId, void *context);
    //typedef void (WINAPI *TDRawDeviceEvent)(const char *data, int callbackId, void *context);

    public struct DeviceEvent
    {
        public int deviceId;
        public TellStickMethods method;
        public string data;
        public int callbackId;
        public IntPtr context;
    }

    public struct RawEvent
    {
        public string data;
        public int callbackId;
        public IntPtr context;
    }

    [Flags]
    public enum TellStickMethods
    {
        TurnOn = 1,
        TurnOff = 2,
        Bell = 4,
        Toggle = 8,
        Dim = 16,
        Learn = 32
    }

    public enum TellStickErrors
    {
        Success = 0,
        NotFound = -1,
        PermissionDenied = -2,
        DeviceNotFound = -3,
        MethodNotSupported = -4,
        Unknown = -99
    }

    public enum TellStickDeviceType
    {
        Device = 1,
        Group = 2
    }

    [Flags]
    public enum TellStickParameterTypes
    {
        /// <summary>
        /// Archtech: A-P
        /// RisingSun: 1-4
        /// Brateck
        /// Display: 8 switches (1, -, 0)
        /// Value: 10 1 10   (1 for 1, [space] for -, 0 for 0)
        /// </summary>
        House = 1,
        /// <summary>
        /// Archtech: 1-16
        /// RisingSun: 1-4
        /// </summary>
        Unit = 2,
        /// <summary>
        /// Sartano
        /// Display: 12345ABCDE
        /// Value:   0101000100 (0 == off, 1 == on)
        /// </summary>
        Code = 4,
        /// <summary>
        /// Ikea
        /// Value: 1-16
        /// </summary>
        System = 8,
        /// <summary>
        /// Ikea
        /// Value: true = soft, false = direct
        /// </summary>
        Fade = 16,
        /// <summary>
        /// Ikea
        /// Display: 1-10
        /// Value: 1,5,2,9 (Comma separated int-list)
        /// </summary>
        Units = 32
    }

    [Flags]
    public enum TellStickSettingTypes
    {
        [TellStickSettingsDescription("Code Switch", "codeswitch")]
        CodeSwitch = 1,
        [TellStickSettingsDescription("Selflearning", "selflearning")]
        SelfLearning = 2,
        [TellStickSettingsDescription("Self Learning on/off", "selflearning-switch")]
        SelfLearningSwitch = 4,
        [TellStickSettingsDescription("Self Learning dimmer", "selflearning-dimmer")]
        SelfLearningDimmer = 8,
        [TellStickSettingsDescription("Bell", "bell")]
        Bell = 16
    }

    public class TellStickSettingsDescriptionAttribute : Attribute
    {
        private string _displayName;
        private string _valueName;

        public string DisplayName { get { return _displayName; } }
        public string ValueName { get { return _valueName; } }

        public TellStickSettingsDescriptionAttribute(string displayName, string valueName)
        {
            _displayName = displayName;
            _valueName = valueName;
        }
    }

    public static class EnumHelper
    {
        public static string GetSettingsDisplayName(TellStickSettingTypes type)
        {
            FieldInfo fi = type.GetType().GetField(type.ToString());
            TellStickSettingsDescriptionAttribute[] attributes = (TellStickSettingsDescriptionAttribute[])fi.GetCustomAttributes(typeof(TellStickSettingsDescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].DisplayName : type.ToString();
        }

        public static string GetSettingsValueName(TellStickSettingTypes type)
        {
            FieldInfo fi = type.GetType().GetField(type.ToString());
            TellStickSettingsDescriptionAttribute[] attributes = (TellStickSettingsDescriptionAttribute[])fi.GetCustomAttributes(typeof(TellStickSettingsDescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].ValueName : type.ToString();
        }
    }

    /// <summary>
    /// Currently not in use
    /// </summary>
    public enum Nexa
    {
        YCR3500 = 1,
        YCR300D = 2,
        WSR1000 = 3,
        CMR1000 = 4,
        CMR300 = 5,
        PA33300 = 6,
        EL2000 = 8,
        EL2005 = 9,
        EL2006 = 10,
        SYCR3500 = 12,
        SYCR300 = 13,
        HDR105 = 14,
        ML7100 = 15,
        EL2004 = 16,
        EL2016 = 17,
        EL2010 = 18,
        LYCR1000 = 20,
        LYCR300 = 21,
        LCMR1000 = 22,
        LCMR300 = 23,
        EL2023 = 24,
        EL2024 = 25,
        EL2021 = 26,
        EL2017 = 27,
        EL2019 = 28
    }

    /// <summary>
    /// Currently not in use
    /// </summary>
    public enum IKEA { Koppla = 19 }
}
