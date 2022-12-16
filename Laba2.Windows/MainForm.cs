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
            if (CoordAxes.BackgroundImage != null) //���� � pictureBox ���� �����������
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
            if (BackgroundColor.ShowDialog() == DialogResult.Cancel)
                return;
            Pen graphicsPen = new Pen(BackgroundColor.Color);
        }
        
        private void CoordAxes_MouseWheel(object? sender, MouseEventArgs e)
        {
            //���������� ��������
            int mouseWheelType = e.Delta;
            
            if (mouseWheelType >= 0)
            {
                _chartDrawer.ZoomIn();
            }
            else
            {
                _chartDrawer.ZoomOut();

                if (_chartDrawer._zoom <= 1)
                {
                    PixelCountOnAxle = 1;
                    ScaleLabel.Visible = false;
                }
                else
                {
                    ScaleLabel.Visible = true;
                    ScaleLabel.Text = "scale = " + PixelCountOnAxle.ToString();
                }
            }
        }

        int startX = 0;
        int startY = 0;
        private void CoordAxes_MouseDown(object sender, MouseEventArgs e)
        {
            // ��� ������� �� ����� ������ ����
            if (e.Button == MouseButtons.Left)
            {
                startX = e.X;
                startY = e.Y;
                MOUSE_DOWN = true;
                Co.Focus();
            }
            else
            {
                MOUSE_DOWN = false;
            }
        }

        private void CoordAxes_MouseUp(object sender, MouseEventArgs e)
        {
            // ��� ���������� ������
            if (e.Button == MouseButtons.Left)
            {
                MOUSE_DOWN = false;               
            }
        }

        private int moveByX = 0;
        private int moveByY = 0;
        private void CoordAxes_MouseMove(object sender, MouseEventArgs e)
        {
            // ��������� ������ ��� ����������� ����
            if (MOUSE_DOWN==true)
            {
                moveByX = moveByX - startX + e.X;
                moveByY = moveByY - startY + e.Y;
                startX = e.X;
                startY = e.Y;
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
                label1.Text = ("���������� �������");
            }
            else if (randomFunction == 1)
            {
                double a = 2;
                double b = 5;
                function = new LinearFunction(a, b);
                _chartDrawer.SetFunction(function);
                label1.Text = ("�������� �������");
            }
            else if (randomFunction == 2)
            {
                function = new QuadraticFunction();
                _chartDrawer.SetFunction(function);
                label1.Text = ("������������ �������");
            }
            else if (randomFunction == 3)
            {
                function = new SinusFunction();
                _chartDrawer.SetFunction(function);
                label1.Text = ("������� ������");
            }
            else if (randomFunction == 4)
            {
                function = new TangentFunction();
                _chartDrawer.SetFunction(function);
                label1.Text = ("������� ��������");
            }
        }

        public Color Color1;
        public Color Color2;
        private void CoordAxes_Paint(object sender, PaintEventArgs e)
        {
            int width = CoordAxes.ClientSize.Width / 2;
            int height = CoordAxes.ClientSize.Height / 2;
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
            else if (choice == 1) //��������
            {
                var firstColor = GradientColor.Color;
                if (GradientColor.ShowDialog() == DialogResult.OK)
                {
                    Color1 = firstColor;
                    Color2 = GradientColor.Color;
                    LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(width * 2, height * 2), Color1, Color2);
                    graphic.Clear(DefaultBackColor);
                    graphic.FillRectangle(brush, CoordAxes.ClientRectangle);
                }
            }
            else if (choice == 2) // ���������
            {
                for (int x = 0; x < width * 2; x += (int)stepScale / 2)
                {
                    graphic.DrawLine(backgroundPen, x, 0, x, height * 2);
                }
            }
            else if (choice == 3) //���������� ���
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
            else if (choice == 4) //���-��������
            {
                CoordAxes.BackgroundImage = Image.FromFile("D:\\repositories\\Laba2.Windows\\1612726633_168-p-krasivie-golubie-foni-neba-222.jpg");
            }
        }
    }
}

    