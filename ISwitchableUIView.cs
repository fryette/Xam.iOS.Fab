namespace Xam.iOS.Fab
{
    public interface ISwitchableUIView
    {
        bool IsSelected { get; }
        void SwitchState();
    }
}
