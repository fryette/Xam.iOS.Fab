// Developed for LilBytes by Softeq Development Corporation
//
namespace Xam.iOS.Fab
{
    public class Margin
    {
        public int Left { get; set; }
        public int Right { get; set; }
        public int Top { get; set; }
        public int Bottom { get; set; }

        public Margin()
        {

        }

        public Margin(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public Margin(int leftAndRight, int topAndBottom)
        {
            Left = leftAndRight;
            Top = topAndBottom;
            Right = leftAndRight;
            Bottom = topAndBottom;
        }

        public Margin(int margin)
        {
            Left = margin;
            Top = margin;
            Right = margin;
            Bottom = margin;
        }
    }
}
