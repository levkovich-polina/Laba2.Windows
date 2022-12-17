using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Laba2.Windows
{
    public partial class NewFunction : Form
    {
        public NewFunction()
        {
            InitializeComponent();
        }

        private void FunctionBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void NameFunctionBox_TextChanged(object sender, EventArgs e)
        {
            var nameFunction = NameFunctionBox.Text;
        }
    }
}
