using System;

namespace Citadel.Sdl
{
    internal sealed class Window : IDisposable
    {
        private IntPtr _data;

        public const int UndefinedWindowPosition = 0x1FFF0000;

        public Window(IntPtr data)
        {
            _data = data;
        }

        private void ThrowIfDisposed()
        {
            if (_data == IntPtr.Zero)
            {
                throw new ObjectDisposedException(nameof(Window));
            }
        }

        public void Dispose()
        {
            ThrowIfDisposed();
            Interop.SDL_DestroyWindow(_data);
            _data = IntPtr.Zero;
        }
    }
}
