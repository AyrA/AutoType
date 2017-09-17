using System;
using System.Windows.Forms;

namespace AutoType
{
    /// <summary>
    /// Suspends and Resumes Control updates
    /// </summary>
    public static class SuspendUpdate
    {
        /// <summary>
        /// Redraw Function constant
        /// </summary>
        private const int WM_SETREDRAW = 0x000B;

        /// <summary>
        /// Suspends updating the given Control
        /// </summary>
        /// <param name="control">Control</param>
        public static void Suspend(Control control)
        {
            Message msgSuspendUpdate = Message.Create(control.Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);
            NativeWindow window = NativeWindow.FromHandle(control.Handle);
            window.DefWndProc(ref msgSuspendUpdate);
        }

        /// <summary>
        /// Resumes updating the given Control
        /// </summary>
        /// <param name="control">Control</param>
        public static void Resume(Control control)
        {
            Message msgResumeUpdate = Message.Create(control.Handle, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero);

            NativeWindow window = NativeWindow.FromHandle(control.Handle);
            window.DefWndProc(ref msgResumeUpdate);
            control.Invalidate();
        }
    }
}
