using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Laba2.Windows
{
    public partial class MainForm : Form
    {
        IFunction function;
        public readonly ChartDrawer _chartDrawer;

        private float SCALE = 1F;
        private float startX = 0F;
        private float startY = 0F;
        private const int STEP = 15;
        private bool MOUSE_DOWN = false;
        private float moveByX = 0;
        private float moveByY = 0;

        public MainForm()
        {
            InitializeComponent();
            _chartDrawer = new ChartDrawer(CoordAxes);
            this.MouseWheel += new MouseEventHandler(CoordAxes_MouseWheel);
        }

        private void CoordAxes_MouseWheel(object? sender, MouseEventArgs e)
        {
            //обновление масштаба
            int mouseWheelType = e.Delta / 120;

            if (mouseWheelType >= 0)
            {
                SCALE += 1F;
            }
            else
            {
                SCALE -= 1F;

                if (SCALE <= 1F)
                {
                    SCALE = 1F;
                    ScaleLabel.Visible = false;
                }
                else
                {
                    ScaleLabel.Visible = true;
                    ScaleLabel.Text = "scale = " + SCALE.ToString();
                }
            }
            CoordAxes.Invalidate();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (CoordAxes.BackgroundImage != null) //если в pictureBox есть изображение
            {
                //создание диалогового окна "Сохранить как..", для сохранения изображения
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
                savedialog.OverwritePrompt = true;
                //отображать ли предупреждение, если пользователь указывает несуществующий путь
                savedialog.CheckPathExists = true;
                //список форматов файла, отображаемый в поле "Тип файла"
                savedialog.Filter =
                    "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                //отображается ли кнопка "Справка" в диалоговом окне
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
                {
                    BackgroundImage.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }

        private void GraphColorButton_Click(object sender, EventArgs e)
        {
            if (BackgroundColor.ShowDialog() == DialogResult.Cancel)
                return;
            //function. = GraphicColor.Color;
        }
       
        private void RandomFunctionButton_Click(object sender, EventArgs g, PaintEventArgs e)
        {
            int width = (CoordAxes.ClientSize.Width - groupBox1.Width) / 2;
            int height = CoordAxes.ClientSize.Height / 2;
            Graphics graphic = e.Graphics;
            Random rnd = new Random();
            int randomFunction = rnd.Next(0, 5);
            if (randomFunction == 0)
            {
                function = new CubicFunction();
                _chartDrawer.DrawGraphic(width, height, graphic);
            }
            else if (randomFunction == 1)
            {
                double a = 2;
                double b = 5;
                function = new LinearFunction(a, b);
                _chartDrawer.DrawGraphic(width, height, graphic);
            }
            else if (randomFunction == 2)
            {
                function = new QuadraticFunction();
                _chartDrawer.DrawGraphic(width, height, graphic);
            }
            else if (randomFunction == 3)
            {
                function = new SinusFunction();
                _chartDrawer.DrawGraphic(width, height, graphic);
            }
            else if (randomFunction == 4)
            {
                function = new TangentFunction();
                _chartDrawer.DrawGraphic(width, height, graphic);
            }
        }

        private void ChoiceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            int choice = ChoiceComboBox.SelectedIndex;
            if (choice == 0) //задний фон
            {
                if (BackgroundColor.ShowDialog() == DialogResult.OK)
                {
                    BackColor = BackgroundColor.Color;
                }
            }
            else if (choice == 1) //градиент
            {
                Point startPoint = new Point(0, 0);
                Point endPoint = new Point(150, 150);

                //LinearGradientBrush lgb = new LinearGradientBrush(startPoint, endPoint, Color.FromArgb(255, 255, 0, 0),
                //    Color.FromArgb(255, 255, 255, 0));
                //Graphics g = e.Graphics;
                //g.FillRectangle(lgb, 0, 0, 150, 150);
            }
            else if (choice == 2) //вертикальная штриховка
            {
            }
            else if (choice == 3) //горизонтальная штриховка
            {
            }
            else if (choice == 4) //фон-картинка
            {
                CoordAxes.BackgroundImage = Image.FromFile("1612726633_168-p-krasivie-golubie-foni-neba-222.jpg");
            }
        }

        private void CoordAxes_MouseDown(object sender, MouseEventArgs e)
        {
            // При нажатии на левую кнопку мыши
            if (e.Button == MouseButtons.Left)
            {
                startX = e.X / (SCALE * STEP);
                startY = e.Y / (SCALE * STEP);

                MOUSE_DOWN = true;
            }
            else
            {
                MOUSE_DOWN = false;
            }
        }

        private void CoordAxes_MouseUp(object sender, MouseEventArgs e)
        {
            // Up left mouse button
            if (e.Button == MouseButtons.Left)
            {
                MOUSE_DOWN = false;
            }
        }

        private void CoordAxes_MouseMove(object sender, MouseEventArgs e)
        {
            // Move mouse and move graphic
            if (MOUSE_DOWN)
            {
                moveByX += e.X / (SCALE * STEP) - startX;
                moveByY += e.Y / (SCALE * STEP) - startY;

                startX = e.X / (SCALE * STEP);
                startY = e.Y / (SCALE * STEP);

                CoordAxes.Refresh();
            }
        }
    }
}

    