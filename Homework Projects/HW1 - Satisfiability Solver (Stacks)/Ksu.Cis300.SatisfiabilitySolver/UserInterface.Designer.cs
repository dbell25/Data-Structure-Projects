namespace Ksu.Cis300.SatisfiabilitySolver
{
    partial class UserInterface
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
            this.uxButton = new System.Windows.Forms.Button();
            this.uxSolutionLabel = new System.Windows.Forms.Label();
            this.uxTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // uxButton
            // 
            this.uxButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxButton.Location = new System.Drawing.Point(12, 12);
            this.uxButton.Name = "uxButton";
            this.uxButton.Size = new System.Drawing.Size(260, 37);
            this.uxButton.TabIndex = 0;
            this.uxButton.Text = "Read Formula";
            this.uxButton.UseVisualStyleBackColor = true;
            this.uxButton.Click += new System.EventHandler(this.uxButton_Click);
            // 
            // uxSolutionLabel
            // 
            this.uxSolutionLabel.AutoSize = true;
            this.uxSolutionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSolutionLabel.Location = new System.Drawing.Point(12, 59);
            this.uxSolutionLabel.MaximumSize = new System.Drawing.Size(83, 24);
            this.uxSolutionLabel.MinimumSize = new System.Drawing.Size(83, 24);
            this.uxSolutionLabel.Name = "uxSolutionLabel";
            this.uxSolutionLabel.Size = new System.Drawing.Size(83, 24);
            this.uxSolutionLabel.TabIndex = 1;
            this.uxSolutionLabel.Text = "Solution:";
            // 
            // uxTextBox
            // 
            this.uxTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.uxTextBox.Location = new System.Drawing.Point(101, 59);
            this.uxTextBox.MaximumSize = new System.Drawing.Size(171, 26);
            this.uxTextBox.MinimumSize = new System.Drawing.Size(171, 26);
            this.uxTextBox.Name = "uxTextBox";
            this.uxTextBox.ReadOnly = true;
            this.uxTextBox.Size = new System.Drawing.Size(171, 26);
            this.uxTextBox.TabIndex = 2;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(280, 107);
            this.Controls.Add(this.uxTextBox);
            this.Controls.Add(this.uxSolutionLabel);
            this.Controls.Add(this.uxButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 150);
            this.MinimumSize = new System.Drawing.Size(300, 150);
            this.Name = "UserInterface";
            this.Text = "Satisfiability Solver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxButton;
        private System.Windows.Forms.Label uxSolutionLabel;
        private System.Windows.Forms.TextBox uxTextBox;
    }
}

