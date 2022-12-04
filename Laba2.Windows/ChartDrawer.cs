using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.Windows
{
    public class ChartDrawer
    {
        IFunction function;
        private const int PixelCountOnAxle = 25;
        private const int ArrowLength = 10;
        public readonly Panel _panel;

        const int STEP = 15;
        const float NUM = 45F;
        private float SCALE = 1F;

        private float ellipsX1 = 0;
        private float ellipsX2 = 0;
        private bool drawEllips = false;

        private float moveX = 0;
        private float moveY = 0;

        public ChartDrawer(Panel panel)
        {
            _panel = panel;
            _panel.Paint += _panel_Paint;
        }

        private void _panel_Paint(object? sender, PaintEventArgs e)
        {
            int w = _panel.ClientSize.Width / 2;
            int h = _panel.ClientSize.Height / 2;
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
        public void DrawGraphic (int width, int height, Graphics graphic)
        {
            // Draw graphic
            Pen pen = new Pen(Color.Black);

            // x > 0
            int cnt = 0;
            var stepScale = STEP * SCALE;

            Point[] points = new Point[(int)(width * NUM / stepScale)];

            for (float x = 0F - moveX * SCALE * STEP; x > -width - moveX * SCALE * STEP; x -= (float)(stepScale / NUM))
            {
                double realX = x / stepScale;
                double realY = function.Calc(x) * stepScale;
                points[cnt] = new Point((int)(x + moveX * SCALE * STEP), -(int)(realY - moveY * SCALE * STEP));
                cnt++;
                if (drawEllips)
                {
                    if (Math.Abs(ellipsX1 - x) <= 1 && ellipsX1 != 0)
                    {
                        graphic.FillEllipse(Brushes.Black, new Rectangle((int)(x + moveX * SCALE * STEP), -(int)(realY - moveY * SCALE * STEP) - 10, 15, 15));
                    }
                }
                if (cnt == points.Length)
                {
                    break;
                }
            }
            graphic.DrawLines(pen,points);

            // x < 0
            cnt = 0;
            points = new Point[(int)(width * NUM / stepScale)];

            for (float x = 0F - moveX * stepScale; x < width - moveX * SCALE * STEP; x += (float)(stepScale / NUM))
            {
                double realX = x / stepScale;
                double realY = function.Calc(x) * stepScale;
                points[cnt] = new Point((int)(x + moveX * stepScale), -(int)(realY - moveY * stepScale));
                cnt++;
                if (drawEllips)
                {
                    if (Math.Abs(ellipsX2 - x) <= 1 && ellipsX2 != 0)
                    {
                        graphic.FillEllipse(Brushes.Black, new Rectangle((int)(x + moveX * stepScale), -(int)(realY - moveY * stepScale) - 10, 15, 15));
                    }
                }
                if (cnt == points.Length)
                {
                    break;
                }
            }
            graphic.DrawLines(pen, points);
            graphic.TranslateTransform(-width, -height);
        }
    }
}
