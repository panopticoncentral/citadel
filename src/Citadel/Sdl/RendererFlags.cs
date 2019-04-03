﻿using System;

namespace Citadel.Sdl
{
    [Flags]
    public enum RendererFlags : uint
    {
        Software = 0x00000001,
        Accelerated = 0x00000002,
        PresentVSync = 0x00000004,
        TargetTexture = 0x00000008
    }
}
