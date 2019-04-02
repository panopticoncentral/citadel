using System;

namespace Citadel.Sdl
{
    internal sealed class SdlException : Exception
    {
        public SdlException()
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
