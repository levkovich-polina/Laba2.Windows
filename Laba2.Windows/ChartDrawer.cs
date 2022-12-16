using System.Diagnostics;
using System.Reflection;

namespace Laba2.Windows
{
    public class ChartDrawer
    {
        private int _pShiftX;
        private int _pShiftY;
        private IFunction _function;
        private const double _zoomFactor = 1.1;
        private const int PixelCountOnAxle = 20;
        private const int ArrowLength = 10;
        private readonly Panel _panel;

        public ChartDrawer(Panel panel)
        {
            _panel = panel;
            _panel.Paint += _panel_Paint;
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
               null, _panel, new object[] { true }); ;
        }
        public double Zoom = 1;
        

        private void _panel_Paint(object? sender, PaintEventArgs e)
        {
            int pCenterX = _panel.ClientSize.Width / 2 + _pShiftX;
            int pCenterY = _panel.Size.Height / 2 + _pShiftY;
            Graphics graphic = e.Graphics;
            //Смещение начала координат в центр PictureBox
            e.Graphics.TranslateTransform(pCenterX, pCenterY);
            DrawXAxis(e.Graphics);
            DrawYAxis(e.Graphics);
            //Центр координат
            e.Graphics.FillEllipse(Brushes.Red, -2, -2, 4, 4);
            if (_function != null)
            {
                DrawGraphics(graphic);
            }
        }

        public void DrawXAxis(Graphics g)
        {
            int pxMax =  _panel.Size.Width/2 - _pShiftX;
            int pxMin = pxMax - _panel.ClientSize.Width;
            //Деления в положительном направлении оси
            for (int i = 1; true; i++)
            {
                int px =(int)( i * Zoom * PixelCountOnAxle);

                g.DrawLine(Pens.Black, (int)px, -3, (int)px, 3);
                DrawText(new Point((int)px, 3), (i).ToString(), g);
                if (px > pxMax)
                {
                    break;
                }
            }
            //Деления в отрицательном направлении оси
            for (int i = -1; true; i--)
            {
                int px = (int)(i * Zoom * PixelCountOnAxle);
                g.DrawLine(Pens.Black, (int)px, -3, (int)px, 3);
                DrawText(new Point((int)px, 3), (i).ToString(), g);
                if (px < pxMin)
                {
                    break;
                }
            }
            var start = new Point(pxMin,0);
            var end = new Point(pxMax,0);
            //Ось     
            g.DrawLine(Pens.Black, start, end);
            //Стрелка
            g.DrawLines(Pens.Black, GetArrow(start.X, start.Y, end.X, end.Y, ArrowLength));
        }
        //Рисование оси Y
        public void DrawYAxis(Graphics g)
        {
            int pyMax = _panel.Size.Height/2 - _pShiftY;
            int pyMin = pyMax -_panel.ClientSize.Height;
            //Деления в отрицательном направлении оси
            for (int i = -1; true; i--)
            {
                int py = (int)(i * Zoom * PixelCountOnAxle);
                g.DrawLine(Pens.Black, -3, (int)py, 3, (int)py);
                DrawText(new Point(3, (int)py), (i).ToString(), g, true);
                if (py < pyMin)
                {
                    break;
                }
            }
            //Деления в положительном направлении оси
            for (int i = 1; true; i++)
            {
                int py =(int)( i * Zoom * PixelCountOnAxle);
                g.DrawLine(Pens.Black, -3, (int)py, 3, (int)py);
                DrawText(new Point(3, (int)py), (i).ToString(), g, true);
                if (py > pyMax)
                {
                    break;
                }
            }
            var start = new Point(0, pyMin);
            var end = new Point(0, pyMax);
            //Ось
            g.DrawLine(Pens.Black, start, end);
            //Стрелка
            g.DrawLines(Pens.Black, GetArrow(end.X, end.Y, start.X, start.Y, ArrowLength));
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

            int pxMax = _panel.Size.Width / 2 - _pShiftX;
            int pxMin = pxMax - _panel.ClientSize.Width;
            int pyMax = _panel.Size.Height / 2 - _pShiftY;
            int pyMin = pyMax - _panel.ClientSize.Height;
            double fxMax = pxMax / PixelCountOnAxle / Zoom;
            double fxMin = pxMin / PixelCountOnAxle / Zoom;
            var step = ((fxMax - fxMin) / _panel.Size.Width)/100;

            for (double fx = fxMin; fx < fxMax; fx += step)
            {
                double fx1 = fx;
                double fx2 = fx + step;
                double fy1 = _function.Calc(fx1);
                double fy2 = _function.Calc(fx2);
                double px1 = Zoom * PixelCountOnAxle * fx1;
                double py1 = Zoom * -PixelCountOnAxle * fy1;
                double px2 = Zoom * PixelCountOnAxle * fx2;
                double py2 = Zoom * -PixelCountOnAxle * fy2;
                if ((py1 > pyMin && py2 > pyMin) || (py1 < pyMax && py2 < pyMax))
                {
                    Point point1 = new Point((int)px1, (int)py1);
                    Point point2 = new Point((int)px2, (int)py2);
                    graphic.DrawLine(graphicsPen, point1, point2);
                }
            }
        }
        public void ZoomIn()
        {
            Zoom *= _zoomFactor;
            _pShiftX = (int)(_pShiftX *_zoomFactor);
            _pShiftY = (int)(_pShiftY * _zoomFactor);
            _panel.Invalidate();

        }
        public void ZoomOut()
        {
            Zoom /=_zoomFactor;
            _pShiftX = (int)(_pShiftX / _zoomFactor);
            _pShiftY = (int)(_pShiftY / _zoomFactor);
            _panel.Invalidate();
        }

        public void MakeShift(Point pShift)
        {
            _pShiftX += pShift.X;
            _pShiftY += pShift.Y;
            Debug.WriteLine($"shift=({_pShiftX};{_pShiftY})");
            _panel.Invalidate();
        }
    }
}


