using System;

namespace Citadel.Sdl
{
    internal sealed class Texture : ObjectBase
    {
        public Texture(IntPtr data) : base(data)
        {
        }

        protected override void FreeData()
        {
            Interop.SDL_DestroyRenderer(Data);
        }
    }
}
