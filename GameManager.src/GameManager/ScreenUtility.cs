using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GameManager {
    public class ScreenResolution {
        public int Width { set; get; }
        public int Height { set; get; }

        public ScreenResolution() { }

        public ScreenResolution(int x, int y) {
            Width = x;
            Height = y;
        }

        public override bool Equals(object o) {
            return o is ScreenResolution && ((ScreenResolution)o).Width == Width && ((ScreenResolution)o).Height == Height;
        }

        public override string ToString() {
            return Width + " x " + Height;
        }

        public override int GetHashCode() {
            return ToString().GetHashCode();
        }
    }

    /// <summary>
    /// Container for static helper functions related to retrieving and changing the screen resolution
    /// For more information see http://msdn.microsoft.com/en-us/library/ms812499.aspx
    /// </summary>
    public static class ScreenUtility {
        private static DEVMODE? InitialDeviceMode = null;

        /// <summary>
        /// The exception that is thrown if an attempt to change the screen resolution fails.
        /// </summary>
        [Serializable]
        public class ResolutionChangeFailedException : Exception {
            public ResolutionChangeFailedException() { }
            public ResolutionChangeFailedException(string message) : base(message) { }
            public ResolutionChangeFailedException(string message, Exception inner) : base(message, inner) { }
        }

        /// <summary>
        /// Returns a collection of resolutions supported by the display that is displaying this application.
        /// </summary>
        public static IEnumerable<ScreenResolution> GetSupportedResolutions() {
            DEVMODE deviceMode = CreateDevMode();
            DEVMODE current = GetCurrentDeviceMode();
            var resolutions = new List<ScreenResolution>();

            for (int i = 0; EnumDisplaySettings(null, i, ref deviceMode) != 0; i++) {
                //Exclude resolutions with a different bpp, frequency or screen orientation than the current resolution
                if (deviceMode.dmBitsPerPel == current.dmBitsPerPel &&
                    deviceMode.dmDisplayFrequency == current.dmDisplayFrequency &&
                    deviceMode.dmDisplayOrientation == current.dmDisplayOrientation) 
                {
                    var res = new ScreenResolution(deviceMode.dmPelsWidth, deviceMode.dmPelsHeight);

                    if (!resolutions.Contains(res)) {
                        resolutions.Add(res);
                    }
                }
            }
            return resolutions;
        }

        /// <summary>
        /// Changes the width and height of the display that is displaying this application.
        /// </summary>
        /// <exception cref="ResolutionChangeFailedException">Thrown if changing the resolution fails</exception>
        public static void ChangeResolution(ScreenResolution resolution) {
            var deviceMode = CreateDevMode();
            deviceMode.dmPelsWidth = resolution.Width;
            deviceMode.dmPelsHeight = resolution.Height;
            deviceMode.dmFields = DM_PELSWIDTH | DM_PELSHEIGHT;

            if (InitialDeviceMode == null) {
                InitialDeviceMode = GetCurrentDeviceMode();
            }

            switch (ChangeDisplaySettings(ref deviceMode, 0)) {
                case DISP_CHANGE_SUCCESSFUL:
                    break;
                case DISP_CHANGE_RESTART:
                    throw new ResolutionChangeFailedException("A system reboot is required to change to the specified resolution");
                case DISP_CHANGE_BADMODE:
                    throw new ResolutionChangeFailedException("The display mode is unsupported");
                case DISP_CHANGE_FAILED:
                    throw new ResolutionChangeFailedException("The display driver does not support the specified resolution");
                case DISP_CHANGE_BADDUALVIEW:
                    throw new ResolutionChangeFailedException("The resolution change was unsuccessful because the system is DualView capable");
                case DISP_CHANGE_BADFLAGS:
                     throw new ResolutionChangeFailedException("An invalid set of flags was passed to ChangeDisplaySettings");
                case DISP_CHANGE_BADPARAM:
                     throw new ResolutionChangeFailedException("An invalid parameter was passed to ChangeDisplaySettings. This can include an invalid flag or combination of flags");
                case DISP_CHANGE_NOTUPDATED:
                     throw new ResolutionChangeFailedException("Unable to write the new resolution to the registry");
                default:
                     throw new ResolutionChangeFailedException("Unknown error code returned from ChangeDisplaySettings");
            }
        }

        /// <summary>
        /// Changes the desktop resolution to what it was before the first time it was changed.
        /// </summary>
        public static void RestoreInitialResolution() {
            if (InitialDeviceMode != null) {
                var deviceMode = InitialDeviceMode.Value;
                ChangeDisplaySettings(ref deviceMode, 0);
                InitialDeviceMode = null;
            }
        }

        /// <summary>
        /// Returns the width and height of the display that is displaying this application.
        /// </summary>
        public static ScreenResolution GetCurrentResolution() {
            var current = GetCurrentDeviceMode();
            return new ScreenResolution(current.dmPelsWidth, current.dmPelsHeight);
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct DEVMODE {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmDeviceName;

            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public int dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmFormName;

            public short dmLogPixels;
            public short dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        };

        private static DEVMODE CreateDevMode() {
            DEVMODE dm = new DEVMODE();
            dm.dmDeviceName = new String(new char[32]);
            dm.dmFormName = new String(new char[32]);
            dm.dmSize = (short)Marshal.SizeOf(dm);
            return dm;
        }

        private static DEVMODE GetCurrentDeviceMode() {
            DEVMODE current = CreateDevMode();
            EnumDisplaySettings(null, ENUM_CURRENT_SETTINGS, ref current);
            return current;
        }

        private const int ENUM_CURRENT_SETTINGS = -1;
        private const int DISP_CHANGE_SUCCESSFUL = 0;
        private const int DISP_CHANGE_BADDUALVIEW = -6;
        private const int DISP_CHANGE_BADFLAGS = -4;
        private const int DISP_CHANGE_BADMODE = -2;
        private const int DISP_CHANGE_BADPARAM = -5;
        private const int DISP_CHANGE_FAILED = -1;
        private const int DISP_CHANGE_NOTUPDATED = -3;
        private const int DISP_CHANGE_RESTART = 1;
        private const int DMDO_DEFAULT = 0;
        private const int DMDFO_DEFAULT = 0;
        private const int DMDFO_CENTER = 2;
        private const int DMDFO_STRETCH = 1;
        private const int DMDO_90 = 1;
        private const int DMDO_180 = 2;
        private const int DMDO_270 = 3;
        private const int DM_BITSPERPEL = 0x40000;
        private const int DM_PELSWIDTH = 0x80000;
        private const int DM_PELSHEIGHT = 0x100000;
        private const int DM_DISPLAYFLAGS = 0x200000;
        private const int DM_DISPLAYFREQUENCY = 0x400000;

        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        private static extern int EnumDisplaySettings(string lpszDeviceName, int iModeNum, ref DEVMODE lpDevMode);

        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        private static extern int ChangeDisplaySettings(ref DEVMODE lpDevMode, int dwFlags);
    }
}
