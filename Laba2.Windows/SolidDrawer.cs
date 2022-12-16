using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.Windows
{
    public class SolidDrawer : IBackgroundDrawer
    {
        private readonly Color _color;
        
        public SolidDrawer(Color color)
        {
            _color = color;
        }
        public void Draw(Graphics graphics, int height, int width)
        {
            graphics.FillRectangle( new SolidBrush(_color), 0, 0, width, height);
        }
    }
}
