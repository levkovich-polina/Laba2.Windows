using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba2.Windows
{
    public partial class CreateFormulaForm : Form
    {
        public CreateFormulaForm()
        {
            InitializeComponent();
        }
        public string FormulaExpression => FormulaTextBox.Text;
        private void FormulaTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if( FormulaTextBox.Text == String.Empty)
            {
              MessageBox.Show("You can't add an empty line! Enter a function", "Error", MessageBoxButtons.OK);                
            }
        }
    }
}
