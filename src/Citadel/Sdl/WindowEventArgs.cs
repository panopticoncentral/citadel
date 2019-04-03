using System;

namespace Citadel.Sdl
{
    internal sealed class WindowEventArgs : EventArgs
    {
        public uint Timestamp { get; }
        public uint WindowId { get; }
        public WindowEventType Type { get; }
        public int Data1 { get; }
        public int Data2 { get; }

        public WindowEventArgs(uint timestamp, uint windowId, WindowEventType type, int data1, int data2)
        {
            Timestamp = timestamp;
            WindowId = windowId;
            Type = type;
            Data1 = data1;
            Data2 = data2;
        }
    }
}
