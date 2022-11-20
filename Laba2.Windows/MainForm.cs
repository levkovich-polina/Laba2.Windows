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
            if (CoordinateAxes.BackgroundImage != null) //���� � pictureBox ���� �����������
            {
                //�������� ����������� ���� "��������� ���..", ��� ���������� �����������
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "��������� �������� ���...";
                //���������� �� ��������������, ���� ������������ ��������� ��� ��� ������������� �����
                savedialog.OverwritePrompt = true;
                //���������� �� ��������������, ���� ������������ ��������� �������������� ����
                savedialog.CheckPathExists = true;
                //������ �������� �����, ������������ � ���� "��� �����"
                savedialog.Filter =
                    "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                //������������ �� ������ "�������" � ���������� ����
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK) //���� � ���������� ���� ������ ������ "��"
                {
                    BackgroundImage.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }

        private void GraphColorButton_Click(object sender, EventArgs e)
        {
            if (BackgroundColor.ShowDialog() == DialogResult.Cancel)
                return;
            //������.ForeColor = colorDialog1.Color;
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
            if (choice == 0) //������ ���
            {
                if (BackgroundColor.ShowDialog() == DialogResult.OK)
                {
                    BackColor = BackgroundColor.Color;
                }
            }
            else if (choice == 1) //��������
            {
                Point startPoint = new Point(0, 0);
                Point endPoint = new Point(150, 150);

                LinearGradientBrush lgb = new LinearGradientBrush(startPoint, endPoint, Color.FromArgb(255, 255, 0, 0),
                    Color.FromArgb(255, 255, 255, 0));
                Graphics g = e.Graphics;
                g.FillRectangle(lgb, 0, 0, 150, 150);
            }
            else if (choice == 2) //������������ ���������
            {
            }
            else if (choice == 3) //�������������� ���������
            {
            }
            else if (choice == 4) //���-��������
            {
                CoordinateAxes.BackgroundImage = Image.FromFile("1612726633_168-p-krasivie-golubie-foni-neba-222.jpg");
            }
        }
    }
}