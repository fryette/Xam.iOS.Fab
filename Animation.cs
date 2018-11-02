// Developed for LilBytes by Softeq Development Corporation
//
using System;

namespace Xam.iOS.Fab
{
    public class Animation
    {
        public Action Action { get; }
        public double Duration { get; }

        public Animation(double duration, Action action)
        {
            Duration = duration;
            Action = action;
        }
    }
}
