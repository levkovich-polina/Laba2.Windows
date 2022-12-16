using System.Drawing.Drawing2D;

namespace Laba2.Windows
{
    public class GradientDrawer : IBackgroundDrawer
    {
        public void Draw(Graphics graphics, int height, int widht)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(
             new Point(0, 0),
             new Point(widht, height),
            Color.Blue,
             Color.Red);
            graphics.FillRectangle(linGrBrush, 0, 0, widht, height);
        }
    }
}
