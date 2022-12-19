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
            this.AddFunctionButton = new System.Windows.Forms.Button();
            this.FunctionsComboBox = new System.Windows.Forms.ComboBox();
            this.ChoiceComboBox = new System.Windows.Forms.ComboBox();
            this.GraphColorButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ScaleLabel = new System.Windows.Forms.Label();
            this.GraphicColor = new System.Windows.Forms.ColorDialog();
            this.BackgroundColor = new System.Windows.Forms.ColorDialog();
            this.DrawingPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.GradientColor = new System.Windows.Forms.ColorDialog();
            this.GroupBox.SuspendLayout();
            this.DrawingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox
            // 
            this.GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox.BackColor = System.Drawing.Color.LightCyan;
            this.GroupBox.Controls.Add(this.AddFunctionButton);
            this.GroupBox.Controls.Add(this.FunctionsComboBox);
            this.GroupBox.Controls.Add(this.ChoiceComboBox);
            this.GroupBox.Controls.Add(this.GraphColorButton);
            this.GroupBox.Controls.Add(this.SaveButton);
            this.GroupBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GroupBox.Location = new System.Drawing.Point(550, 0);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(250, 450);
            this.GroupBox.TabIndex = 0;
            this.GroupBox.TabStop = false;
            // 
            // AddFunctionButton
            // 
            this.AddFunctionButton.Location = new System.Drawing.Point(36, 246);
            this.AddFunctionButton.Name = "AddFunctionButton";
            this.AddFunctionButton.Size = new System.Drawing.Size(164, 29);
            this.AddFunctionButton.TabIndex = 6;
            this.AddFunctionButton.Text = "add function";
            this.AddFunctionButton.UseVisualStyleBackColor = true;
            this.AddFunctionButton.Click += new System.EventHandler(this.AddFunctionButton_Click);
            // 
            // FunctionsComboBox
            // 
            this.FunctionsComboBox.DisplayMember = "Name";
            this.FunctionsComboBox.FormattingEnabled = true;
            this.FunctionsComboBox.Location = new System.Drawing.Point(31, 61);
            this.FunctionsComboBox.Name = "FunctionsComboBox";
            this.FunctionsComboBox.Size = new System.Drawing.Size(169, 28);
            this.FunctionsComboBox.TabIndex = 5;
            this.FunctionsComboBox.SelectedIndexChanged += new System.EventHandler(this.FunctionsComboBox_SelectedIndexChanged);
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
            // ScaleLabel
            // 
            this.ScaleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScaleLabel.AutoSize = true;
            this.ScaleLabel.Location = new System.Drawing.Point(477, 24);
            this.ScaleLabel.Name = "ScaleLabel";
            this.ScaleLabel.Size = new System.Drawing.Size(42, 20);
            this.ScaleLabel.TabIndex = 0;
            this.ScaleLabel.Text = "scale";
            // 
            // DrawingPanel
            // 
            this.DrawingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawingPanel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.DrawingPanel.Controls.Add(this.label1);
            this.DrawingPanel.Controls.Add(this.ScaleLabel);
            this.DrawingPanel.Location = new System.Drawing.Point(-3, 0);
            this.DrawingPanel.Name = "DrawingPanel";
            this.DrawingPanel.Size = new System.Drawing.Size(557, 450);
            this.DrawingPanel.TabIndex = 1;
            this.DrawingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CoordAxes_MouseDown);
            this.DrawingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CoordAxes_MouseMove);
            this.DrawingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CoordAxes_MouseUp);
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
            this.Controls.Add(this.DrawingPanel);
            this.Controls.Add(this.GroupBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.GroupBox.ResumeLayout(false);
            this.DrawingPanel.ResumeLayout(false);
            this.DrawingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox GroupBox;
        private Button SaveButton;
        private Button GraphColorButton;
        private ColorDialog GraphicColor;
        private ColorDialog BackgroundColor;
        private Panel DrawingPanel;
        private ComboBox ChoiceComboBox;
        private ColorDialog GradientColor;
        private Label ScaleLabel;
        private Label label1;
        private ComboBox FunctionsComboBox;
        private Button AddFunctionButton;
    }
}