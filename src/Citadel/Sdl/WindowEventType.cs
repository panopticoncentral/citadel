namespace Citadel.Sdl
{
    internal enum WindowEventType : byte
    {
        None,
        Shown,
        Hidden,
        Exposed,
        Moved,
        Resized,
        SizeChanged,
        Minimized,
        Maximized,
        Restored,
        Enter,
        Leave,
        FocusGained,
        FocusLost,
        Close,
        /* Available in 2.0.5 or higher */
        TakeFocus,
        HitTest
    }
}
