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
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.ChoiceComboBox = new System.Windows.Forms.ComboBox();
            this.GraphColorButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.RandomFunctionButton = new System.Windows.Forms.Button();
            this.ScaleLabel = new System.Windows.Forms.Label();
            this.GraphicColor = new System.Windows.Forms.ColorDialog();
            this.BackgroundColor = new System.Windows.Forms.ColorDialog();
            this.CoordAxes = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.GradientColor = new System.Windows.Forms.ColorDialog();
            this.GroupBox.SuspendLayout();
            this.CoordAxes.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox
            // 
            this.GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox.BackColor = System.Drawing.Color.LightCyan;
            this.GroupBox.Controls.Add(this.ChoiceComboBox);
            this.GroupBox.Controls.Add(this.GraphColorButton);
            this.GroupBox.Controls.Add(this.SaveButton);
            this.GroupBox.Controls.Add(this.RandomFunctionButton);
            this.GroupBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GroupBox.Location = new System.Drawing.Point(550, 0);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(250, 450);
            this.GroupBox.TabIndex = 0;
            this.GroupBox.TabStop = false;
            // 
            // ChoiceComboBox
            // 
            this.ChoiceComboBox.FormattingEnabled = true;
            this.ChoiceComboBox.Items.AddRange(new object[] {
            "Background color",
            "Gradient",
            "Hatching",
            "Square",
            "Photography"});
            this.ChoiceComboBox.Location = new System.Drawing.Point(34, 198);
            this.ChoiceComboBox.Name = "ChoiceComboBox";
            this.ChoiceComboBox.Size = new System.Drawing.Size(166, 28);
            this.ChoiceComboBox.TabIndex = 4;
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
            // ScaleLabel
            // 
            this.ScaleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScaleLabel.AutoSize = true;
            this.ScaleLabel.Location = new System.Drawing.Point(467, 24);
            this.ScaleLabel.Name = "ScaleLabel";
            this.ScaleLabel.Size = new System.Drawing.Size(42, 20);
            this.ScaleLabel.TabIndex = 0;
            this.ScaleLabel.Text = "scale";
            // 
            // CoordAxes
            // 
            this.CoordAxes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CoordAxes.Controls.Add(this.label1);
            this.CoordAxes.Controls.Add(this.ScaleLabel);
            this.CoordAxes.Location = new System.Drawing.Point(-3, 0);
            this.CoordAxes.Name = "CoordAxes";
            this.CoordAxes.Size = new System.Drawing.Size(547, 450);
            this.CoordAxes.TabIndex = 1;
            this.CoordAxes.Paint += new System.Windows.Forms.PaintEventHandler(this.CoordAxes_Paint);
            this.CoordAxes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CoordAxes_MouseDown);
            this.CoordAxes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CoordAxes_MouseMove);
            this.CoordAxes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CoordAxes_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CoordAxes);
            this.Controls.Add(this.GroupBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.GroupBox.ResumeLayout(false);
            this.CoordAxes.ResumeLayout(false);
            this.CoordAxes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox GroupBox;
        private Button SaveButton;
        private Button RandomFunctionButton;
        private Button GraphColorButton;
        private ColorDialog GraphicColor;
        private ColorDialog BackgroundColor;
        private Panel CoordAxes;
        private ComboBox ChoiceComboBox;
        private ColorDialog GradientColor;
        private Label ScaleLabel;
        private Label label1;
    }
}