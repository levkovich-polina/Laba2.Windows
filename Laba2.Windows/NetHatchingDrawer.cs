using System.Drawing;

namespace Laba2.Windows
{
    internal class NetHatchingDrawer : IBackgroundDrawer
    {
        private readonly Color _linesColor;

        public NetHatchingDrawer(Color linesColor)
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
            for (int y = 0; y < height; y += 17)
            {
                graphics.DrawLine(pen, 0, y, width, y);
            }
        }
    }
}
