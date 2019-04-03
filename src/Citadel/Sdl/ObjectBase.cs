using System;

namespace Citadel.Sdl
{
    internal abstract class ObjectBase : IDisposable
    {
        private bool _shouldFree;

        public IntPtr Data { get; private set; }

        protected ObjectBase(IntPtr data, bool shouldFree = true)
        {
            Data = data;
            _shouldFree = shouldFree;
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
            if (_shouldFree)
            {
                FreeData();
            }
            Data = IntPtr.Zero;
        }
    }
}
