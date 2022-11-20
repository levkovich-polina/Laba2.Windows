using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.Windows
{
    public  class CoordinateAxes
    {
        private const int PixelCountOnAxle = 25;
        private const int ArrowLength = 10;

        private void CoordinateAxes_Paint(object sender, PaintEventArgs e)
        {
            int w = CoordinateAxes.ClientSize.Width / 2;
            int h = CoordinateAxes.ClientSize.Height / 2;
            //Смещение начала координат в центр PictureBox
            e.Graphics.TranslateTransform(w, h);
            DrawXAxis(new Point(-w, 0), new Point(w, 0), e.Graphics);
            DrawYAxis(new Point(0, h), new Point(0, -h), e.Graphics);
            //Центр координат
            e.Graphics.FillEllipse(Brushes.Red, -2, -2, 4, 4);
            //Рисование оси X
        }
        public void DrawXAxis(Point start, Point end, Graphics g)
        {
            //Деления в положительном направлении оси
            for (int i = PixelCountOnAxle; i < end.X - ArrowLength; i += PixelCountOnAxle)
            {
                g.DrawLine(Pens.Black, i, -5, i, 5);
                DrawText(new Point(i, 5), (i / PixelCountOnAxle).ToString(), g);
            }
            //Деления в отрицательном направлении оси
            for (int i = -PixelCountOnAxle; i > start.X; i -= PixelCountOnAxle)
            {
                g.DrawLine(Pens.Black, i, -5, i, 5);
                DrawText(new Point(i, 5), (i / PixelCountOnAxle).ToString(), g);
            }
            //Ось
            g.DrawLine(Pens.Black, start, end);
            //Стрелка
            g.DrawLines(Pens.Black, GetArrow(start.X, start.Y, end.X, end.Y, ArrowLength));
        }

        //Рисование оси Y
        public void DrawYAxis(Point start, Point end, Graphics g)
        {
            //Деления в отрицательном направлении оси
            for (int i = PixelCountOnAxle; i < start.Y; i += PixelCountOnAxle)
            {
                g.DrawLine(Pens.Black, -5, i, 5, i);
                DrawText(new Point(5, i), (-i / PixelCountOnAxle).ToString(), g, true);
            }
            //Деления в положительном направлении оси
            for (int i = -PixelCountOnAxle; i > end.Y + ArrowLength; i -= PixelCountOnAxle)
            {
                g.DrawLine(Pens.Black, -5, i, 5, i);
                DrawText(new Point(5, i), (-i / PixelCountOnAxle).ToString(), g, true);
            }
            //Ось
            g.DrawLine(Pens.Black, start, end);
            //Стрелка
            g.DrawLines(Pens.Black, GetArrow(start.X, start.Y, end.X, end.Y, ArrowLength));
        }
        //Рисование текста
        public void DrawText(Point point, string text, Graphics g, bool isYAxis = false)
        {
            var f = new Font(Font.FontFamily, 6);
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
    }
}
