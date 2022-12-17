namespace Laba2.Windows
{
    partial class NewFunction
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
            this.NameFunctionBox = new System.Windows.Forms.TextBox();
            this.FunctionBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameFunctionBox
            // 
            this.NameFunctionBox.Location = new System.Drawing.Point(168, 58);
            this.NameFunctionBox.Name = "NameFunctionBox";
            this.NameFunctionBox.Size = new System.Drawing.Size(207, 27);
            this.NameFunctionBox.TabIndex = 0;
            this.NameFunctionBox.TextChanged += new System.EventHandler(this.NameFunctionBox_TextChanged);
            // 
            // FunctionBox
            // 
            this.FunctionBox.Location = new System.Drawing.Point(169, 110);
            this.FunctionBox.Name = "FunctionBox";
            this.FunctionBox.Size = new System.Drawing.Size(206, 27);
            this.FunctionBox.TabIndex = 1;
            this.FunctionBox.TextChanged += new System.EventHandler(this.FunctionBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name Function:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "y = ";
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.SystemColors.Window;
            this.AddButton.Location = new System.Drawing.Point(170, 158);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(94, 38);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "ADD";
            this.AddButton.UseVisualStyleBackColor = false;
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton.Location = new System.Drawing.Point(281, 158);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(94, 38);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "CANCEL";
            this.CancelButton.UseVisualStyleBackColor = false;
            // 
            // NewFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(531, 218);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FunctionBox);
            this.Controls.Add(this.NameFunctionBox);
            this.Name = "NewFunction";
            this.Text = "NewFunction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox NameFunctionBox;
        private TextBox FunctionBox;
        private Label label1;
        private Label label2;
        private Button AddButton;
        private Button CancelButton;
    }
}