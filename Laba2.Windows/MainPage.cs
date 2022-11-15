using System.Reflection.PortableExecutable;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Laba2.Windows
{
    public partial class MainPage : Form
    {
        //Пикселей в одном делении оси
        const int PIX_IN_ONE = 25;
        //Длина стрелки
        const int ARR_LEN = 10;
        public MainPage()
        {
            InitializeComponent();
            panel1.Paint += panel1_Paint;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".txt";
            saveFile.Filter = "Text files|*.txt";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFile.FileName;
                //System.IO.File.WriteAllText(filename, textBox1.Text);
                MessageBox.Show("File saved");
            }
        }

        private void GraphColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.Cancel)
                return;
            //график.ForeColor = colorDialog1.Color;
        }

        private void BackgroundStyleButton_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.Cancel)
                return;
            panel1.BackColor = colorDialog2.Color;
        }

        private void RandomFunctionButton_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int w = panel1.ClientSize.Width / 2;
            int h = panel1.ClientSize.Height / 2;
            //Смещение начала координат в центр PictureBox
            e.Graphics.TranslateTransform(w, h);
            DrawXAxis(new Point(-w, 0), new Point(w, 0), e.Graphics);
            DrawYAxis(new Point(0, h), new Point(0, -h), e.Graphics);
            //Центр координат
            e.Graphics.FillEllipse(Brushes.Red, -2, -2, 4, 4);
        }
        //Рисование оси X
        private void DrawXAxis(Point start, Point end, Graphics g)
        {
            //Деления в положительном направлении оси
            for (int i = PIX_IN_ONE; i < end.X - ARR_LEN; i += PIX_IN_ONE)
            {
                g.DrawLine(Pens.Black, i, -5, i, 5);
                DrawText(new Point(i, 5), (i / PIX_IN_ONE).ToString(), g);
            }
            //Деления в отрицательном направлении оси
            for (int i = -PIX_IN_ONE; i > start.X; i -= PIX_IN_ONE)
            {
                g.DrawLine(Pens.Black, i, -5, i, 5);
                DrawText(new Point(i, 5), (i / PIX_IN_ONE).ToString(), g);
            }
            //Ось
            g.DrawLine(Pens.Black, start, end);
            //Стрелка
            g.DrawLines(Pens.Black, GetArrow(start.X, start.Y, end.X, end.Y, ARR_LEN));
        }

        //Рисование оси Y
        private void DrawYAxis(Point start, Point end, Graphics g)
        {
            //Деления в отрицательном направлении оси
            for (int i = PIX_IN_ONE; i < start.Y; i += PIX_IN_ONE)
            {
                g.DrawLine(Pens.Black, -5, i, 5, i);
                DrawText(new Point(5, i), (-i / PIX_IN_ONE).ToString(), g, true);
            }
            //Деления в положительном направлении оси
            for (int i = -PIX_IN_ONE; i > end.Y + ARR_LEN; i -= PIX_IN_ONE)
            {
                g.DrawLine(Pens.Black, -5, i, 5, i);
                DrawText(new Point(5, i), (-i / PIX_IN_ONE).ToString(), g, true);
            }
            //Ось
            g.DrawLine(Pens.Black, start, end);
            //Стрелка
            g.DrawLines(Pens.Black, GetArrow(start.X, start.Y, end.X, end.Y, ARR_LEN));
        }
        //Рисование текста
        private void DrawText(Point point, string text, Graphics g, bool isYAxis = false)
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
        private static PointF[] GetArrow(float x1, float y1, float x2, float y2, float len = 10, float width = 4)
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