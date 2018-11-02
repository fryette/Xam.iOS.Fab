// Developed for LilBytes by Softeq Development Corporation
//
namespace Xam.iOS.Fab
{
    public interface ISwitchableUIView
    {
        bool IsSelected { get; }
        void SwitchState();
    }
}
