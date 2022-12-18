namespace Laba2.Windows
{
    partial class CreateFormulaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FormulaTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FormulaTextBox
            // 
            this.FormulaTextBox.Location = new System.Drawing.Point(168, 83);
            this.FormulaTextBox.Name = "FormulaTextBox";
            this.FormulaTextBox.Size = new System.Drawing.Size(194, 27);
            this.FormulaTextBox.TabIndex = 0;
            this.FormulaTextBox.TextChanged += new System.EventHandler(this.FormulaTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "y = ";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(152, 146);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(94, 42);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "ADD";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(287, 146);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(94, 41);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "CANCEL";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // CreateFormulaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 243);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FormulaTextBox);
            this.Name = "CreateFormulaForm";
            this.Text = "CreateFormulaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox FormulaTextBox;
        private Label label1;
        private Button AddButton;
        private Button CancelButton;
    }
}