using System.Reflection;
using System.Xml.Schema;

namespace Laba2.Windows
{
    public class ChartDrawer
    {
        private IFunction _function;
        private const int PixelCountOnAxle = 20;
        private const int ArrowLength = 10;
        public readonly Panel _panel;
        private double panelXmax;
        private double panelXmin;
        private double panelYmax;
        private double panelYmin;

        public ChartDrawer(Panel panel)
        {
            _panel = panel;
            _panel.Paint += _panel_Paint;
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
               null, _panel, new object[] { true }); ;
        }
        private void _panel_Paint(object? sender, PaintEventArgs e)
        {
            int w = _panel.ClientSize.Width / 2;
            int h = _panel.Size.Height / 2;
            Graphics graphic = e.Graphics;
            //Смещение начала координат в центр PictureBox
            e.Graphics.TranslateTransform(w, h);
            DrawXAxis(new Point(-w, 0), new Point(w, 0), e.Graphics);
            DrawYAxis(new Point(0, h), new Point(0, -h), e.Graphics);
            //Центр координат
            e.Graphics.FillEllipse(Brushes.Red, -2, -2, 4, 4);
            if (_function != null)
            {
                DrawGraphics(graphic);
            }
        }

        public void DrawXAxis(Point start, Point end, Graphics g)
        {

            double xMax = _panel.ClientSize.Width / 2;
            double xMin = -_panel.ClientSize.Width / 2;
            //Деления в положительном направлении оси
            for (int i = 1; true; i++)
            {
                double x = i * _zoom * PixelCountOnAxle;

                g.DrawLine(Pens.Black, (int)x, -3, (int)x, 3);
                DrawText(new Point((int)x, 3), (i).ToString(), g);
                if (x > xMax)
                {
                    break;
                }
            }
            //Деления в отрицательном направлении оси
            for (int i = -1; true; i--)
            {
                double x = i * _zoom * PixelCountOnAxle;
                g.DrawLine(Pens.Black, (int)x, -3, (int)x, 3);
                DrawText(new Point((int)x, 3), (i).ToString(), g);
                if (x < xMin)
                {
                    break;
                }
            }
            //Ось     
            g.DrawLine(Pens.Black, start, end);
            //Стрелка
            g.DrawLines(Pens.Black, GetArrow(start.X, start.Y, end.X, end.Y, ArrowLength));
        }
        //Рисование оси Y
        public void DrawYAxis(Point start, Point end, Graphics g)
        {
            double yMax = _panel.ClientSize.Height / 2;
            double yMin = -_panel.ClientSize.Height / 2;
            //Деления в отрицательном направлении оси
            for (int i = -1; true; i--)
            {
                double y = i * _zoom * PixelCountOnAxle;
                g.DrawLine(Pens.Black, -3, (int)y, 3, (int)y);
                DrawText(new Point(3, (int)y), (i).ToString(), g, true);
                if (y < yMin)
                {
                    break;
                }
            }
            //Деления в положительном направлении оси
            for (int i = 1; true; i++)
            {
                double y = i * _zoom * PixelCountOnAxle;
                g.DrawLine(Pens.Black, -3, (int)y, 3, (int)y);
                DrawText(new Point(3, (int)y), (i).ToString(), g, true);
                if (y > yMax)
                {
                    break;
                }
            }
            //Ось
            g.DrawLine(Pens.Black, start, end);
            //Стрелка
            g.DrawLines(Pens.Black, GetArrow(start.X, start.Y, end.X, end.Y, ArrowLength));
        }
        //Рисование текста
        public void DrawText(Point point, string text, Graphics g, bool isYAxis = false)
        {
            var f = new Font("Times New Roman", 6);
            var size = g.MeasureString(text, f);
            var pt = isYAxis
                ? new PointF(point.X + 1, point.Y - size.Height / 2)
                : new PointF(point.X - size.Width / 2, point.Y + 1);
            var rect = new RectangleF(pt, size);
            g.DrawString(text, f, Brushes.Black, rect);
        }
        //Вычисление стрелки оси
        public static PointF[] GetArrow(float x1, float y1, float x2, float y2, float len = 10, float width = 4)
        {
            PointF[] result = new PointF[3];
            //направляющий вектор отрезка
            var n = new PointF(x2 - x1, y2 - y1);
            //Длина отрезка
            var l = (float)Math.Sqrt(n.X * n.X + n.Y * n.Y);
            //Единичный вектор
            var v1 = new PointF(n.X / l, n.Y / l);
            //Длина стрелки
            n.X = x2 - v1.X * len;
            n.Y = y2 - v1.Y * len;
            result[0] = new PointF(n.X + v1.Y * width, n.Y - v1.X * width);
            result[1] = new PointF(x2, y2);
            result[2] = new PointF(n.X - v1.Y * width, n.Y + v1.X * width);
            return result;
        }
        public void SetFunction(IFunction function)
        {
            _function = function;
            _panel.Invalidate();
        }
        public void DrawGraphics(Graphics graphic)
        {
            Pen graphicsPen = new Pen(Color.Red);

            double pxMax = _panel.ClientSize.Width / 2;
            double pxMin = -_panel.ClientSize.Width / 2;
            double pyMax = _panel.ClientSize.Height / 2;
            double pyMin = -_panel.ClientSize.Height / 2;
            double fxMax = pxMax/PixelCountOnAxle/_zoom;
            double fxMin = pxMin / PixelCountOnAxle / _zoom;
            var step = (fxMax - fxMin) /_panel.Size.Width;

            for (double fx = fxMin; fx < fxMax; fx += step)
            {
                double fx1 = fx;
                double fx2 = fx + step;
                double fy1 = _function.Calc(fx1);
                double fy2 = _function.Calc(fx2);
                double px1 = _zoom * PixelCountOnAxle * fx1;
                double py1 = _zoom * -PixelCountOnAxle * fy1;
                double px2 = _zoom * PixelCountOnAxle * fx2;
                double py2 = _zoom * -PixelCountOnAxle * fy2;
                if ((py1 > pyMin && py2 > pyMin) || (py1 < pyMax && py2 < pyMax))
                {
                    Point point1 = new Point((int)px1, (int)py1);
                    Point point2 = new Point((int)px2, (int)py2);
                    graphic.DrawLine(graphicsPen, point1, point2);
                }
            }
        }
        private double _zoom = 1;
        public void ZoomIn()
        {
            _zoom *= 1.1;
            _panel.Invalidate();

        }
        public void ZoomOut()
        {
            _zoom /= 1.1;
            //if (_zoom <= 1)
            //{
            //    PixelCountOnAxle = 1;
            //    ScaleLabel.Visible = false;
            //}
            //else
            //{
            //    ScaleLabel.Visible = true;
            //    ScaleLabel.Text = "scale = " + PixelCountOnAxle.ToString();
            //}
            _panel.Invalidate();
        }
    }
}




//private double ZOOMFACTOR = 1.1;
//private double MINMAX = 5;
////if ((_panel.Width < (MINMAX * _panel.Width)) &&
//                  (_panel.Height < (MINMAX * _panel.Height)))
//            {
//    _panel.Width = Convert.ToInt32(_panel.Width / ZOOMFACTOR);
//    _panel.Height = Convert.ToInt32(_panel.Height / ZOOMFACTOR);
//}