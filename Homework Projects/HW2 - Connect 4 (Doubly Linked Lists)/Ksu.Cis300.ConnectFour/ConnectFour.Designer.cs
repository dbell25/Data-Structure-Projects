namespace Ksu.Cis300.ConnectFour
{
    partial class ConnectFour
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
            this.uxTopContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.uxTurnLabel = new System.Windows.Forms.Label();
            this.uxPlayerLabel = new System.Windows.Forms.Label();
            this.uxPlaceButtonContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.uxBoardContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.uxTopContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxTopContainer
            // 
            this.uxTopContainer.Controls.Add(this.uxTurnLabel);
            this.uxTopContainer.Controls.Add(this.uxPlayerLabel);
            this.uxTopContainer.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.uxTopContainer.Location = new System.Drawing.Point(10, 5);
            this.uxTopContainer.Name = "uxTopContainer";
            this.uxTopContainer.Size = new System.Drawing.Size(387, 21);
            this.uxTopContainer.TabIndex = 0;
            // 
            // uxTurnLabel
            // 
            this.uxTurnLabel.AutoSize = true;
            this.uxTurnLabel.BackColor = System.Drawing.Color.Red;
            this.uxTurnLabel.Location = new System.Drawing.Point(348, 0);
            this.uxTurnLabel.Name = "uxTurnLabel";
            this.uxTurnLabel.Size = new System.Drawing.Size(36, 21);
            this.uxTurnLabel.TabIndex = 0;
            this.uxTurnLabel.Text = "Red";
            this.uxTurnLabel.UseCompatibleTextRendering = true;
            // 
            // uxPlayerLabel
            // 
            this.uxPlayerLabel.AutoSize = true;
            this.uxPlayerLabel.BackColor = System.Drawing.Color.Transparent;
            this.uxPlayerLabel.Location = new System.Drawing.Point(235, 0);
            this.uxPlayerLabel.Name = "uxPlayerLabel";
            this.uxPlayerLabel.Size = new System.Drawing.Size(107, 21);
            this.uxPlayerLabel.TabIndex = 1;
            this.uxPlayerLabel.Text = "Player\'s Turn:";
            this.uxPlayerLabel.UseCompatibleTextRendering = true;
            // 
            // uxPlaceButtonContainer
            // 
            this.uxPlaceButtonContainer.Location = new System.Drawing.Point(10, 22);
            this.uxPlaceButtonContainer.Margin = new System.Windows.Forms.Padding(5);
            this.uxPlaceButtonContainer.Name = "uxPlaceButtonContainer";
            this.uxPlaceButtonContainer.Size = new System.Drawing.Size(390, 29);
            this.uxPlaceButtonContainer.TabIndex = 1;
            // 
            // uxBoardContainer
            // 
            this.uxBoardContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.uxBoardContainer.Location = new System.Drawing.Point(10, 51);
            this.uxBoardContainer.Name = "uxBoardContainer";
            this.uxBoardContainer.Size = new System.Drawing.Size(390, 331);
            this.uxBoardContainer.TabIndex = 2;
            // 
            // ConnectFour
            // 
            this.ClientSize = new System.Drawing.Size(408, 394);
            this.Controls.Add(this.uxBoardContainer);
            this.Controls.Add(this.uxPlaceButtonContainer);
            this.Controls.Add(this.uxTopContainer);
            this.MaximizeBox = false;
            this.Name = "ConnectFour";
            this.Text = "Connect Four";
            this.uxTopContainer.ResumeLayout(false);
            this.uxTopContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label PlayerNameLabel;
        private System.Windows.Forms.Label PlayerName;
        private System.Windows.Forms.FlowLayoutPanel uxTopContainer;
        private System.Windows.Forms.Label uxTurnLabel;
        private System.Windows.Forms.Label uxPlayerLabel;
        private System.Windows.Forms.FlowLayoutPanel uxPlaceButtonContainer;
        private System.Windows.Forms.FlowLayoutPanel uxBoardContainer;
    }
}

