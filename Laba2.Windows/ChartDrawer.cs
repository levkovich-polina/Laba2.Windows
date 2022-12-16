using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
               null, _panel, new object[] { true }); ;  // Double buffer for graphic
        }
        private void _panel_Paint(object? sender, PaintEventArgs e)
        {
            int w = _panel.ClientSize.Width/ 2;
            int h = _panel.Size.Height / 2;
            Graphics graphic = e.Graphics;
            //Смещение начала координат в центр PictureBox
            e.Graphics.TranslateTransform(w, h);
            DrawXAxis(new Point(-w, 0), new Point(w, 0), e.Graphics);
            DrawYAxis(new Point(0, h), new Point(0, -h), e.Graphics);
            //Центр координат
            e.Graphics.FillEllipse(Brushes.Red, -2, -2, 4, 4);
            //Рисование оси X
            if(_function!=null)
            {
                DrawGraphics(graphic);
            }
        }
        private double displacement;
        public void DrawXAxis(Point start, Point end, Graphics g)
        {
            int w = _panel.ClientSize.Width / 2;       
            double X= (_panel.Size.Width / 2) / PixelCountOnAxle;         
            //Деления в положительном направлении оси
            for (int i = 1; true; i++)
            {
                displacement = i *_zoom * PixelCountOnAxle + w;
                g.DrawLine(Pens.Black, i*PixelCountOnAxle, -3, i * PixelCountOnAxle, 3);
                DrawText(new Point(i * PixelCountOnAxle, 3), (i * PixelCountOnAxle / PixelCountOnAxle).ToString(), g);
                if (i > X)
                {
                    break;
                }
            }
            //Деления в отрицательном направлении оси
            for (int i = 1; true; i++)
            {
                displacement = i * _zoom * PixelCountOnAxle + w;
                g.DrawLine(Pens.Black, i * -PixelCountOnAxle, -3, i * -PixelCountOnAxle, 3);
                DrawText(new Point(i * -PixelCountOnAxle, 3), (-i * -PixelCountOnAxle / PixelCountOnAxle).ToString(), g);
                if (i > X)
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
            int h = _panel.Size.Height / 2;
            double Y = (_panel.Size.Height / 2) / PixelCountOnAxle;
            //Деления в отрицательном направлении оси
            for (int i = 1; true; i++)
            {
                displacement = i  * _zoom * PixelCountOnAxle + h;
                g.DrawLine(Pens.Black, -3, i * PixelCountOnAxle, 3, i * PixelCountOnAxle);
                DrawText(new Point(3, i * PixelCountOnAxle), (i * PixelCountOnAxle / PixelCountOnAxle).ToString(), g, true);
                if (i > Y)
                {
                    break;
                }
            }
            //Деления в положительном направлении оси
            for (int i = 1; true; i++)
            {
                displacement = i * _zoom * PixelCountOnAxle + h;
                g.DrawLine(Pens.Black, -3, i * -PixelCountOnAxle, 3, i * -PixelCountOnAxle);
                DrawText(new Point(3, i * -PixelCountOnAxle), (-i * -PixelCountOnAxle / PixelCountOnAxle).ToString(), g, true);
                if (i > Y)
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
        public  void DrawGraphics(Graphics graphic)
        {
            Pen graphicsPen = new Pen(Color.Red);
            var step = 0.1;
            panelXmax = _zoom * (_panel.Size.Width/2) / PixelCountOnAxle;
            panelXmin = _zoom * -(_panel.Size.Width / 2) / PixelCountOnAxle;
            panelYmax = _zoom * (_panel.Size.Height / 2) / PixelCountOnAxle;
            panelYmin = _zoom * -(_panel.Size.Height / 2) / PixelCountOnAxle;
            for (double x = panelXmin; x < panelXmax; x+=step)
            {
                double fx1 = x;
                double fx2 = x + step;
                double fy1 = _function.Calc(fx1);
                double fy2 = _function.Calc(fx2);
                double px1 = _zoom * PixelCountOnAxle * fx1;
                double py1 = _zoom * - PixelCountOnAxle * fy1;
                double px2 = _zoom * PixelCountOnAxle * fx2;
                double py2 = _zoom * - PixelCountOnAxle * fy2;
                Point point1 = new Point((int)px1,(int) py1);
                Point point2 = new Point((int)px2,(int) py2);
                if ((fy1 > panelYmin && fy2 > panelYmin) || (fy1 < panelYmax && fy2 < panelYmax))
                {
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