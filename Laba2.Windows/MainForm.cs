using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Laba2.Windows
{
    public partial class MainForm : Form
    {
        IFunction function;
        public readonly ChartDrawer _chartDrawer;
        private bool MOUSE_DOWN = false;        
        private  int PixelCountOnAxle = 20;
        public MainForm()
        {
            InitializeComponent();
            _chartDrawer = new ChartDrawer(CoordAxes);
            CoordAxes.MouseWheel += new MouseEventHandler(CoordAxes_MouseWheel);
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
               null, CoordAxes, new object[] { true }); ;  // Double buffer for graphic
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            int width = CoordAxes.ClientSize.Width;
            int height = CoordAxes.ClientSize.Height;

            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Images (*.png,*.jpeg)|*.png;*.jpeg";
            if (CoordAxes.BackgroundImage != null) //если в pictureBox есть изображение
            {
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you really want to save file?", "Save your plot", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Bitmap bmp = new Bitmap(width, height);
                        CoordAxes.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width - GroupBox.Width, bmp.Height));
                        bmp.Save(saveDialog.FileName, ImageFormat.Png);
                    }
                }
            }
        }
        private void GraphColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog BackgroundColor = new ColorDialog();
            if (BackgroundColor.ShowDialog() == DialogResult.OK)
            {
               
            }
        }
        private void CoordAxes_MouseWheel(object? sender, MouseEventArgs e)
        {
            
            //обновление масштаба
            int mouseWheelType = e.Delta;
            
            if (mouseWheelType >= 0)
            {
                _chartDrawer.ZoomIn();               
            }
            else
            {
                _chartDrawer.ZoomOut();                   
            }
            if (Math.Abs(_chartDrawer.Zoom - 1) > 0.0001)
            {
                ScaleLabel.Text = "scale = " + _chartDrawer.Zoom.ToString("F2");
            }
            else
            {
                ScaleLabel.Text = null;
            }
        }
        int startX = 0;
        int startY = 0;
        private void CoordAxes_MouseDown(object sender, MouseEventArgs e)
        {
            // При нажатии на левую кнопку мыши
            if (e.Button == MouseButtons.Left)
            {
                MOUSE_DOWN = true;
                startX = (CoordAxes.Size.Width / 2)/ PixelCountOnAxle;
                startY = (CoordAxes.Size.Height / 2) / PixelCountOnAxle;
            }
            else
            {
                MOUSE_DOWN = false;
            }
        }
        private void CoordAxes_MouseUp(object sender, MouseEventArgs e)
        {
            // При отпускании кнопки
            if (e.Button == MouseButtons.Left)
            {
                MOUSE_DOWN = false;               
            }
        }
        int moveByX = 0;
        int moveByY = 0;
        private void CoordAxes_MouseMove(object sender, MouseEventArgs e)
        {
            // Двигается график при перемешение мыши
            if (MOUSE_DOWN)
            {
                moveByX = e.X / PixelCountOnAxle - startX;
                moveByY = e.Y / PixelCountOnAxle - startY;
                startX = (CoordAxes.Size.Width / 2) / PixelCountOnAxle;
                startY = (CoordAxes.Size.Height / 2) / PixelCountOnAxle;
                CoordAxes.Invalidate();
            }
        }
        private void RandomFunctionButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int randomFunction = random.Next(0, 5);
            if (randomFunction == 0)
            {
                function = new CubicFunction();
                _chartDrawer.SetFunction(function);
                label1.Text = ("Кубическая функция");
            }
            else if (randomFunction == 1)
            {
                double a = 2;
                double b = 5;
                function = new LinearFunction(a, b);
                _chartDrawer.SetFunction(function);
                label1.Text = ("Линейная функция");
            }
            else if (randomFunction == 2)
            {
                function = new QuadraticFunction();
                _chartDrawer.SetFunction(function);
                label1.Text = ("Квадратичная функция");
            }
            else if (randomFunction == 3)
            {
                function = new SinusFunction();
                _chartDrawer.SetFunction(function);
                label1.Text = ("Функция синуса");
            }
            else if (randomFunction == 4)
            {
                function = new TangentFunction();
                _chartDrawer.SetFunction(function);
                label1.Text = ("Функция тангенса");
            }
        }
        public Color Color1;
        public Color Color2;
        private void CoordAxes_Paint(object sender, PaintEventArgs e)
        {
            int width = CoordAxes.ClientSize.Width / 2;
            int height = CoordAxes.ClientSize.Height / 2;
            int w = CoordAxes.ClientSize.Width;
            int h = CoordAxes.ClientSize.Height;
            int choice = ChoiceComboBox.SelectedIndex;
            var stepScale = PixelCountOnAxle;
            Graphics graphic = e.Graphics;
            Pen backgroundPen = new Pen(Color.Black);
            if (choice == 0)
            {
                if (BackgroundColor.ShowDialog() == DialogResult.OK)
                {
                    CoordAxes.BackColor = BackgroundColor.Color;
                }
            }
            else if (choice == 1) //градиент
            {               
                   LinearGradientBrush linGrBrush = new LinearGradientBrush(
                   new Point(0, 0),
                   new Point(w, h),
                   Color.Blue,
                   Color.Red);
                   graphic.FillRectangle(linGrBrush, 0, 0, w, h);                                 
            }
            else if (choice == 2) // штриховка
            {
                for (int x = 0; x < width * 2; x += (int)stepScale / 2)
                {
                    graphic.DrawLine(backgroundPen, x, 0, x, height * 2);
                }
            }
            else if (choice == 3) //квадратный фон
            {
                for (int x = 0; x < width * 2; x += (int)stepScale)
                {
                    graphic.DrawLine(backgroundPen, x, 0, x, height * 2);
                }
                for (int y = 0; y < height * 2; y += (int)stepScale)
                {
                    graphic.DrawLine(backgroundPen, 0, y, width * 2, y);
                }
            }
            else if (choice == 4) //фон-картинка
            {
                CoordAxes.BackgroundImage = Image.FromFile("D:\\repositories\\Laba2.Windows\\1612726633_168-p-krasivie-golubie-foni-neba-222.jpg");
            }
        }
    }
}

    