using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Citadel.Sdl
{
    internal static class Interop
    {
        private const string Sdl2 = "SDL2";

        public static void CheckError(int ret)
        {
            if (ret < 0)
            {
                throw new SdlException();
            }
        }

        public static IntPtr CheckPointer(IntPtr ret) => (ret == IntPtr.Zero) ? throw new SdlException() : ret;

        public static byte[] ToUtf8(this string s) => s == null ? null : Encoding.UTF8.GetBytes(s + '\0');

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateRenderer(IntPtr window, int index, RendererFlags flags);

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateTextureFromSurface(IntPtr renderer, IntPtr surface);
        
        [DllImport(Sdl2, EntryPoint = "SDL_CreateWindow", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateWindow(byte[] title, int x, int y, int w, int h, WindowFlags flags);

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Delay(uint ms);

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DestroyRenderer(IntPtr renderer);

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DestroyTexture(IntPtr texture);

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DestroyWindow(IntPtr window);

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_FillRect(IntPtr dst, ref Rectangle rect, Color color);

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeSurface(IntPtr surface);

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern string SDL_GetError();

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetWindowSurface(IntPtr window);

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_MapRGB(IntPtr format, byte r, byte g, byte b);

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_Init(InitializationFlags flags);

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_LoadBMP_RW(IntPtr src, bool freesrc);

        public static IntPtr SDL_LoadBMP(string file) => SDL_LoadBMP_RW(SDL_RWFromFile(file.ToUtf8(), "rb".ToUtf8()), true);

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderClear(IntPtr renderer);

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopy(IntPtr renderer, IntPtr texture, ref Rectangle srcrect, ref Rectangle dstrect);

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderPresent(IntPtr renderer);

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Quit();

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RWFromFile(byte[] file, byte[] mode);

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateWindowSurface(IntPtr window);

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SDL_WaitEvent(out Event @event);

        public enum EventType : uint
        {
            FirstEvent = 0,

            /* Application events */
            Quit = 0x100,

            /* iOS/Android/WinRT app events */
            AppTerminating,
            AppLowMemory,
            AppWillEnterBackground,
            AppDidEnterBackgroun,
            AppWillEnterForeground,
            AppDidEnterForeground,

            /* Display events */
            /* Only available in SDL 2.0.9 or higher */
            DisplayEvent = 0x150,

            /* Window events */
            WindowEvent = 0x200,
            SysWindowManagerEvent,

            /* Keyboard events */
            KeyDown = 0x300,
            KeyUp,
            TextEditing,
            TextInput,
            KeyMapChanged,

            /* Mouse events */
            MouseMotion = 0x400,
            MouseButtonDown,
            MouseButtonUp,
            MouseWheel,

            /* Joystick events */
            JoystickAxisMotion = 0x600,
            JoystickBallMotion,
            JoystickHatMotion,
            JoystickButtonDown,
            JoystickButtonUp,
            JoystickDeviceAdded,
            JoystickDeviceRemoved,

            /* Game controller events */
            ControllerAxisMotion = 0x650,
            ControllerButtonDown,
            ControllerButtonUp,
            ControllerDeviceAdded,
            ControllerDeviceRemoved,
            ControllerDeviceRemapped,

            /* Touch events */
            FingerDown = 0x700,
            FingerUp,
            FingerMotion,

            /* Gesture eHvents */
            DollarGesture = 0x800,
            DollarRecord,
            MultiGesture,

            /* Clipboard events */
            ClipboardUpdate = 0x900,

            /* Drag and drop events */
            DropFile = 0x1000,
            /* Only available in 2.0.4 or higher */
            DropText,
            DropBegin,
            DropComplete,

            /* Audio hotplug events */
            /* Only available in SDL 2.0.4 or higher */
            AudioDeviceAdded = 0x1100,
            AudioDeviceRemoved,

            /* Sensor events */
            /* Only available in SDL 2.0.9 or higher */
            SensorUpdate = 0x1200,

            /* Render events */
            /* Only available in SDL 2.0.2 or higher */
            RenderTargetsReset = 0x2000,
            /* Only available in SDL 2.0.4 or higher */
            RenderDeviceReset,

            /* Events USEREVENT through LASTEVENT are for
             * your use, and should be allocated with
             * RegisterEvents()
             */
            UserEvent = 0x8000,

            /* The last event, used for bouding arrays. */
            LastEvent = 0xFFFF
        }

        public enum DisplayEventType : byte
        {
            None,
            Orientation
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DisplayEvent
        {
            public uint _display;
            public DisplayEventType _displayEventType;
            private byte _padding1;
            private byte _padding2;
            private byte _padding3;
            public int _data1;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WindowEvent
        {
            public uint _windowId;
            public WindowEventType _windowEventType;
            private readonly byte _padding1;
            private readonly byte _padding2;
            private readonly byte _padding3;
            public int _data1;
            public int _data2;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Keysym
        {
            public Scancode _scancode;
            public Keycode _keycode;
            public KeyModifier _modifier;
            public uint _unicode;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KeyboardEvent
        {
            public uint _windowId;
            public byte _state;
            public byte _repeat;
            private byte _padding2;
            private byte _padding3;
            public Keysym _keysym;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct TextEditingEvent
        {
            public const int TextSize = 32;

            public uint _windowId;
            public fixed byte _text[TextSize];
            public int _start;
            public int _length;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct TextInputEvent
        {
            public const int TextSize = 32;

            public uint _windowId;
            public fixed byte _text[TextSize];
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MouseMotionEvent
        {
            public uint _windowId;
            public uint _which;
            public byte _state; /* bitmask of buttons */
            private byte _padding1;
            private byte _padding2;
            private byte _padding3;
            public int _x;
            public int _y;
            public int _xrel;
            public int _yrel;
        }

        
        [StructLayout(LayoutKind.Sequential)]
        public struct MouseButtonEvent
        {
            public uint _windowId;
            public uint _which;
            public byte _button; /* button id */
            public byte _state; /* SDL_PRESSED or SDL_RELEASED */
            public byte _clicks; /* 1 for single-click, 2 for double-click, etc. */
            private byte _padding1;
            public int _x;
            public int _y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MouseWheelEvent
        {
            public uint _windowId;
            public uint which;
            public int _x; /* amount scrolled horizontally */
            public int _y; /* amount scrolled vertically */
            public uint _direction; /* Set to one of the SDL_MOUSEWHEEL_* defines */
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct JoyAxisEvent
        {
            public int _which; /* SDL_JoystickID */
            public byte _axis;
            private byte _padding1;
            private byte _padding2;
            private byte _padding3;
            public short _axisValue; /* value, lolC# */
            public ushort _padding4;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct JoyBallEvent
        {
            public int _which; /* SDL_JoystickID */
            public byte _ball;
            private byte _padding1;
            private byte _padding2;
            private byte _padding3;
            public short _xrel;
            public short _yrel;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct JoyHatEvent
        {
            public int _which; /* SDL_JoystickID */
            public byte _hat; /* index of the hat */
            public byte _hatValue; /* value, lolC# */
            private byte _padding1;
            private byte _padding2;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct JoyButtonEvent
        {
            public int _which; /* SDL_JoystickID */
            public byte _button;
            public byte _state; /* SDL_PRESSED or SDL_RELEASED */
            private byte _padding1;
            private byte _padding2;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct JoyDeviceEvent
        {
            public int _which; /* SDL_JoystickID */
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct ControllerAxisEvent
        {
            public int _which; /* SDL_JoystickID */
            public byte _axis;
            private byte _padding1;
            private byte _padding2;
            private byte _padding3;
            public short _axisValue;
            private ushort _padding4;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ControllerButtonEvent
        {
            public int _which; /* SDL_JoystickID */
            public byte _button;
            public byte _state;
            private byte _padding1;
            private byte _padding2;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ControllerDeviceEvent
        {
            public int _which; /* joystick id for ADDED,
						 * else instance id
						 */
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct AudioDeviceEvent
        {
            public uint _which;
            public byte _iscapture;
            private byte _padding1;
            private byte _padding2;
            private byte _padding3;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TouchFingerEvent
        {
            public long _touchId; // SDL_TouchID
            public long _fingerId; // SDL_GestureID
            public float _x;
            public float _y;
            public float _dx;
            public float _dy;
            public float _pressure;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MultiGestureEvent
        {
            public long _touchId; // SDL_TouchID
            public float _dTheta;
            public float _dDist;
            public float _x;
            public float _y;
            public ushort _numFingers;
            public ushort _padding;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DollarGestureEvent
        {
            public long _touchId; // SDL_TouchID
            public long _gestureId; // SDL_GestureID
            public uint _numFingers;
            public float _error;
            public float _x;
            public float _y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DropEvent
        {
            /* char* filename, to be freed.
			 * Access the variable EXACTLY ONCE like this:
			 * string s = SDL.UTF8_ToManaged(evt.drop.file, true);
			 */
            public IntPtr _file;
            public uint _windowId;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SensorEvent
        {
            public int _which;
            public fixed float _data[6];
        }

        /* The "quit requested" event */
        [StructLayout(LayoutKind.Sequential)]
        public struct QuitEvent
        {
        }

        /* A user defined event (event.user.*) */
        [StructLayout(LayoutKind.Sequential)]
        public struct UserEvent
        {
            public uint _windowId;
            public int _code;
            public IntPtr _data1; /* user-defined */
            public IntPtr _data2; /* user-defined */
        }

        /* A video driver dependent event (event.syswm.*), disabled */
        [StructLayout(LayoutKind.Sequential)]
        public struct SysWMEvent
        {
            public IntPtr _msg; /* SDL_SysWMmsg*, system-dependent*/
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct Event
        {
            private const int TypeOffset = 0;
            private const int TimestampOffset = TypeOffset + sizeof(EventType);
            private const int UnionOffset = TimestampOffset + sizeof(uint);

            [FieldOffset(TypeOffset)]
            public readonly EventType _type;

            [FieldOffset(TimestampOffset)]
            public readonly uint _timestamp;

            [FieldOffset(UnionOffset)]
            public readonly DisplayEvent _display;

            [FieldOffset(UnionOffset)]
            public readonly WindowEvent _window;

            [FieldOffset(UnionOffset)]
            public readonly KeyboardEvent _key;

            [FieldOffset(UnionOffset)]
            public readonly TextEditingEvent _edit;

            [FieldOffset(UnionOffset)]
            public readonly TextInputEvent _text;

            [FieldOffset(UnionOffset)]
            public readonly MouseMotionEvent _motion;

            [FieldOffset(UnionOffset)]
            public readonly MouseButtonEvent _button;

            [FieldOffset(UnionOffset)]
            public readonly MouseWheelEvent _wheel;

            [FieldOffset(UnionOffset)]
            public readonly JoyAxisEvent _jaxis;

            [FieldOffset(UnionOffset)]
            public readonly JoyBallEvent _jball;

            [FieldOffset(UnionOffset)]
            public readonly JoyHatEvent _jhat;

            [FieldOffset(UnionOffset)]
            public readonly JoyButtonEvent _jbutton;

            [FieldOffset(UnionOffset)]
            public readonly JoyDeviceEvent _jdevice;

            [FieldOffset(UnionOffset)]
            public readonly ControllerAxisEvent _caxis;

            [FieldOffset(UnionOffset)]
            public readonly ControllerButtonEvent _cbutton;

            [FieldOffset(UnionOffset)]
            public readonly ControllerDeviceEvent _cdevice;

            [FieldOffset(UnionOffset)]
            public readonly AudioDeviceEvent _adevice;

            [FieldOffset(UnionOffset)]
            public readonly SensorEvent _sensor;

            [FieldOffset(UnionOffset)]
            public readonly QuitEvent _quit;

            [FieldOffset(UnionOffset)]
            public readonly UserEvent _user;

            [FieldOffset(UnionOffset)]
            public readonly SysWMEvent _syswm;

            [FieldOffset(UnionOffset)]
            public readonly TouchFingerEvent _tfinger;

            [FieldOffset(UnionOffset)]
            public readonly MultiGestureEvent _mgesture;

            [FieldOffset(UnionOffset)]
            public readonly DollarGestureEvent _dgesture;

            [FieldOffset(UnionOffset)]
            public readonly DropEvent _drop;
        }
    }
}
