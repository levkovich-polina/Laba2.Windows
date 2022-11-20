using System.Drawing.Drawing2D;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Laba2.Windows
{
    public partial class MainForm : Form
    {
        IFunction function;
        private readonly CoordinateAxes _coordinateAxes;

        public MainForm(CoordinateAxes coordinateAxes)
        {
            InitializeComponent();
            _coordinateAxes = coordinateAxes;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (CoordinateAxes.BackgroundImage != null) //если в pictureBox есть изображение
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
            //график.ForeColor = colorDialog1.Color;
        }

        private void RandomFunctionButton_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randomFunction = rnd.Next(0, 4);
            if (randomFunction == 0)
            {
                function = new CubicFunction();
            }
            else if (randomFunction == 1)
            {
                double a = 2;
                double b = 5;
                function = new LinearFunction(a, b);
            }
            else if (randomFunction == 2)
            {
                function = new QuadraticFunction();
            }
            else if (randomFunction == 3)
            {
                function = new SinusFunction();
            }
            else if (randomFunction == 4)
            {
                function = new TangentFunction();
            }
        }

        private void CoordinateAxes_Paint(object sender, PaintEventArgs e)
        {
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

                LinearGradientBrush lgb = new LinearGradientBrush(startPoint, endPoint, Color.FromArgb(255, 255, 0, 0),
                    Color.FromArgb(255, 255, 255, 0));
                Graphics g = e.Graphics;
                g.FillRectangle(lgb, 0, 0, 150, 150);
            }
            else if (choice == 2) //вертикальная штриховка
            {
            }
            else if (choice == 3) //горизонтальная штриховка
            {
            }
            else if (choice == 4) //фон-картинка
            {
                CoordinateAxes.BackgroundImage = Image.FromFile("1612726633_168-p-krasivie-golubie-foni-neba-222.jpg");
            }
        }
    }
}