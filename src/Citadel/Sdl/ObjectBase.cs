using System;

namespace Citadel.Sdl
{
    internal abstract class ObjectBase : IDisposable
    {
        public IntPtr Data { get; private set; }

        protected ObjectBase(IntPtr data)
        {
            Data = data;
        }

        protected void ThrowIfDisposed()
        {
            if (Data == IntPtr.Zero)
            {
                throw new ObjectDisposedException(GetType().ToString());
            }
        }

        protected virtual void FreeData()
        {
        }

        public void Dispose()
        {
            ThrowIfDisposed();
            FreeData();
            Data = IntPtr.Zero;
        }
    }
}
