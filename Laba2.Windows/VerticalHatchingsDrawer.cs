using System.Drawing;

namespace Laba2.Windows
{
    public class VerticalHatchingDrawer : IBackgroundDrawer
    {
        private readonly Color _linesColor;

        public VerticalHatchingDrawer(Color linesColor)
        {
            _linesColor = linesColor;
        }
        public void Draw(Graphics graphics, int height, int width)
        {
            graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);
            Pen pen = new Pen(_linesColor, 3);
            for (int x = 0; x < width; x += 17)
            {
                graphics.DrawLine(pen, x, 0, x, height);
            }
        }
    }
}
