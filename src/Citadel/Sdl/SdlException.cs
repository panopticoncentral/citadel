using System;

namespace Citadel.Sdl
{
    internal sealed class SdlException : Exception
    {
        public SdlException() : base(Interop.SDL_GetError())
        {
        }

        public SdlException(string message) : base(message)
        {
        }

        public SdlException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
