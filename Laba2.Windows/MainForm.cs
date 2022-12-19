using System.Drawing.Imaging;
using System.Reflection;

namespace Laba2.Windows
{
    public partial class MainForm : Form
    {
        IFunction function;
        public readonly ChartDrawer _chartDrawer;
        private Point? _previousMouseLocation;
        private CreateFormulaForm _createFormulaForm;
        public MainForm()
        {
            InitializeComponent();
            FunctionsComboBox.Items.Add(new LinearFunction(2, 5));
            FunctionsComboBox.Items.Add(new SinusFunction());
            FunctionsComboBox.Items.Add(new CubicFunction());
            FunctionsComboBox.Items.Add(new TangentFunction());
            FunctionsComboBox.Items.Add(new QuadraticFunction());

            _chartDrawer = new ChartDrawer(DrawingPanel);
            _chartDrawer.SetBackgroundDrawer(new SolidDrawer(Color.White));
            _chartDrawer.SetGraphicsColor(Color.Green);
            DrawingPanel.MouseWheel += new MouseEventHandler(CoordAxes_MouseWheel);
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
               null, DrawingPanel, new object[] { true }); ;  // Double buffer for graphic
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            int width = DrawingPanel.ClientSize.Width;
            int height = DrawingPanel.ClientSize.Height;

            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Images (*.png,*.jpeg)|*.png;*.jpeg";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                DialogResult dialogResult = MessageBox.Show("Are you really want to save file?", "Save your plot", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Bitmap bmp = new Bitmap(width, height);
                    DrawingPanel.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    bmp.Save(saveDialog.FileName, ImageFormat.Png);
                }
            }
        }
        private void GraphColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _chartDrawer.SetGraphicsColor(colorDialog.Color);
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
   

        private void CoordAxes_MouseDown(object sender, MouseEventArgs e)
        {
            // При нажатии на левую кнопку мыши
            if (e.Button == MouseButtons.Left)
            {
                DrawingPanel.Capture = true;

            }
        }
        private void CoordAxes_MouseUp(object sender, MouseEventArgs e)
        {
            // При отпускании кнопки
            if (e.Button == MouseButtons.Left)
            {
                DrawingPanel.Capture = false;
                _previousMouseLocation = null;
            }
        }

        private void CoordAxes_MouseMove(object sender, MouseEventArgs e)
        {
            // Двигается график при перемешение мыши
            if (DrawingPanel.Capture)
            {
                if (_previousMouseLocation != null)
                {
                    var mouseShift = new Point()
                    {
                        X = e.Location.X - _previousMouseLocation.Value.X,
                        Y = e.Location.Y - _previousMouseLocation.Value.Y,
                    };
                    _chartDrawer.MakeShift(mouseShift);
                }
                _previousMouseLocation = e.Location;
            }
        }
        private void RandomFunctionButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int randomFunction = random.Next(0, 5);

        }

        private void ChoiceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            int choice = ChoiceComboBox.SelectedIndex;
            if (choice == 0)
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    DrawingPanel.BackgroundImage = null;
                    DrawingPanel.BackColor = colorDialog.Color;
                    _chartDrawer.SetBackgroundDrawer(new SolidDrawer(colorDialog.Color));
                }
            }
            else if (choice == 1) //градиент
            {
                DrawingPanel.BackgroundImage = null;
                DrawingPanel.BackColor = Color.Transparent;
                _chartDrawer.SetBackgroundDrawer(new GradientDrawer());
            }
            else if (choice == 2) // штриховка
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    DrawingPanel.BackgroundImage = null;
                    DrawingPanel.BackColor = colorDialog.Color;
                    _chartDrawer.SetBackgroundDrawer(new VerticalHatchingDrawer(colorDialog.Color));
                }
            }
            else if (choice == 3) //квадратный фон
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    DrawingPanel.BackgroundImage = null;
                    DrawingPanel.BackColor = colorDialog.Color;
                    _chartDrawer.SetBackgroundDrawer(new NetHatchingDrawer(colorDialog.Color));
                }
            }
            else if (choice == 4) //фон-картинка
            {
                DrawingPanel.BackColor = Color.Transparent;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    DrawingPanel.BackgroundImage = Image.FromFile(openFileDialog.FileName);


                }
                _chartDrawer.SetBackgroundDrawer(null);
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {

            DrawingPanel.Invalidate();
        }

       
        private void AddFunctionButton_Click(object sender, EventArgs e)
        {

            CreateFormulaForm form = new CreateFormulaForm();
            form.ShowDialog();
            CustomFunction customFormula = new CustomFunction(form.FormulaExpression);
            FunctionsComboBox.Items.Add(customFormula);
        }

        private void FunctionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedFunction = (IFunction)FunctionsComboBox.SelectedItem;
            _chartDrawer.SetFunction(selectedFunction);
            
        }
    }
}

