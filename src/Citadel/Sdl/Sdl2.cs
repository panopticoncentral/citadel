﻿using System;

namespace Citadel.Sdl
{
    internal sealed class Sdl2 : IDisposable
    {
        public Sdl2(InitializationFlags flags)
        {
            Interop.CheckError(Interop.SDL_Init(flags));
        }

        public event EventHandler<WindowEventArgs> OnWindowEvent;

        public Window CreateWindow(string title, int x, int y, int width, int height, WindowFlags flags) =>
            new Window(Interop.CheckPointer(Interop.SDL_CreateWindow(title.ToUtf8(), x, y, width, height, flags)));

        public void Delay(uint milliseconds) => Interop.SDL_Delay(milliseconds);

        public void WaitForEvent()
        {
            if (!Interop.SDL_WaitEvent(out var e))
            {
                throw new SdlException();
            }

            switch (e._type)
            {
                case Interop.EventType.WindowEvent:
                    OnWindowEvent?.Invoke(this, new WindowEventArgs(e._timestamp, e._window._windowId, e._window._windowEventType, e._window._data1, e._window._data2));
                    break;
            }
        }

        public Surface LoadBitmap(string file) =>
            new Surface(Interop.CheckPointer(Interop.SDL_LoadBMP(file)));

        public void Dispose()
        {
            Interop.SDL_Quit();
        }
    }
}
