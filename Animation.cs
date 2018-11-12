using System;

namespace Xam.iOS.Fab
{
    public class Animation
    {
        public Action Action { get; }
        public Action CompletedAction { get; }
        public double Duration { get; }

        public Animation(double duration, Action action = null, Action completedAction = null)
        {
            Duration = duration;
            Action = action;
            CompletedAction = completedAction;
        }
    }
}
