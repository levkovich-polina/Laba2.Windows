namespace Laba2.Windows
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChoiceComboBox = new System.Windows.Forms.ComboBox();
            this.GraphColorButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.RandomFunctionButton = new System.Windows.Forms.Button();
            this.GraphicColor = new System.Windows.Forms.ColorDialog();
            this.BackgroundColor = new System.Windows.Forms.ColorDialog();
            this.CoordinateAxes = new System.Windows.Forms.Panel();
            this.GradientColor = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightCyan;
            this.groupBox1.Controls.Add(this.ChoiceComboBox);
            this.groupBox1.Controls.Add(this.GraphColorButton);
            this.groupBox1.Controls.Add(this.SaveButton);
            this.groupBox1.Controls.Add(this.RandomFunctionButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(550, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 450);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // ChoiceComboBox
            // 
            this.ChoiceComboBox.FormattingEnabled = true;
            this.ChoiceComboBox.Items.AddRange(new object[] {
            "Background color",
            "Gradient",
            "Vertical hatching",
            "Horizontal hatching",
            "Photography"});
            this.ChoiceComboBox.Location = new System.Drawing.Point(34, 198);
            this.ChoiceComboBox.Name = "ChoiceComboBox";
            this.ChoiceComboBox.Size = new System.Drawing.Size(166, 28);
            this.ChoiceComboBox.TabIndex = 4;
            this.ChoiceComboBox.SelectedIndexChanged += new System.EventHandler(this.ChoiceComboBox_SelectedIndexChanged);
            // 
            // GraphColorButton
            // 
            this.GraphColorButton.Location = new System.Drawing.Point(32, 147);
            this.GraphColorButton.Name = "GraphColorButton";
            this.GraphColorButton.Size = new System.Drawing.Size(168, 29);
            this.GraphColorButton.TabIndex = 3;
            this.GraphColorButton.Text = "graph сolor";
            this.GraphColorButton.UseVisualStyleBackColor = true;
            this.GraphColorButton.Click += new System.EventHandler(this.GraphColorButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(32, 105);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(168, 28);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // RandomFunctionButton
            // 
            this.RandomFunctionButton.Location = new System.Drawing.Point(31, 60);
            this.RandomFunctionButton.Name = "RandomFunctionButton";
            this.RandomFunctionButton.Size = new System.Drawing.Size(169, 28);
            this.RandomFunctionButton.TabIndex = 0;
            this.RandomFunctionButton.Text = "random function";
            this.RandomFunctionButton.UseVisualStyleBackColor = true;
            this.RandomFunctionButton.Click += new System.EventHandler(this.RandomFunctionButton_Click);
            // 
            // CoordinateAxes
            // 
            this.CoordinateAxes.Location = new System.Drawing.Point(-3, 0);
            this.CoordinateAxes.Name = "CoordinateAxes";
            this.CoordinateAxes.Size = new System.Drawing.Size(554, 450);
            this.CoordinateAxes.TabIndex = 1;
            this.CoordinateAxes.Paint += new System.Windows.Forms.PaintEventHandler(this.CoordinateAxes_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CoordinateAxes);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Button SaveButton;
        private Button RandomFunctionButton;
        private Button GraphColorButton;
        private ColorDialog GraphicColor;
        private ColorDialog BackgroundColor;
        private Panel CoordinateAxes;
        private ComboBox ChoiceComboBox;
        private ColorDialog GradientColor;
    }
}