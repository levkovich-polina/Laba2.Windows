using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Laba2.Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            colorDialog.ShowDialog();
            GraphColorButton.ForeColor = colorDialog.Color;
        }

        private void BackgroundStyleButton_Click(object sender, EventArgs e)
        {

        }
    }
}