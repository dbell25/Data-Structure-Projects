namespace Ksu.Cis300.BTrees
{
    partial class NameLookup
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
            this.uxMinDegree = new System.Windows.Forms.NumericUpDown();
            this.uxRank = new System.Windows.Forms.TextBox();
            this.uxRankLabel = new System.Windows.Forms.Label();
            this.uxFrequency = new System.Windows.Forms.TextBox();
            this.uxFrequencyLabel = new System.Windows.Forms.Label();
            this.uxGetStatButton = new System.Windows.Forms.Button();
            this.uxName = new System.Windows.Forms.TextBox();
            this.uxNameLabel = new System.Windows.Forms.Label();
            this.uxOpen = new System.Windows.Forms.Button();
            this.uxMakeTree = new System.Windows.Forms.Button();
            this.uxNumItemsLabel = new System.Windows.Forms.Label();
            this.uxMinLabel = new System.Windows.Forms.Label();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxCount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.uxMinDegree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxCount)).BeginInit();
            this.SuspendLayout();
            // 
            // uxMinDegree
            // 
            this.uxMinDegree.Location = new System.Drawing.Point(103, 4);
            this.uxMinDegree.Margin = new System.Windows.Forms.Padding(2);
            this.uxMinDegree.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.uxMinDegree.Name = "uxMinDegree";
            this.uxMinDegree.Size = new System.Drawing.Size(51, 20);
            this.uxMinDegree.TabIndex = 26;
            this.uxMinDegree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uxMinDegree.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // uxRank
            // 
            this.uxRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxRank.Location = new System.Drawing.Point(68, 203);
            this.uxRank.Margin = new System.Windows.Forms.Padding(2);
            this.uxRank.Name = "uxRank";
            this.uxRank.ReadOnly = true;
            this.uxRank.Size = new System.Drawing.Size(243, 26);
            this.uxRank.TabIndex = 25;
            this.uxRank.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxRankLabel
            // 
            this.uxRankLabel.AutoSize = true;
            this.uxRankLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxRankLabel.Location = new System.Drawing.Point(8, 205);
            this.uxRankLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uxRankLabel.Name = "uxRankLabel";
            this.uxRankLabel.Size = new System.Drawing.Size(51, 20);
            this.uxRankLabel.TabIndex = 24;
            this.uxRankLabel.Text = "Rank:";
            // 
            // uxFrequency
            // 
            this.uxFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxFrequency.Location = new System.Drawing.Point(103, 172);
            this.uxFrequency.Margin = new System.Windows.Forms.Padding(2);
            this.uxFrequency.Name = "uxFrequency";
            this.uxFrequency.ReadOnly = true;
            this.uxFrequency.Size = new System.Drawing.Size(208, 26);
            this.uxFrequency.TabIndex = 23;
            this.uxFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxFrequencyLabel
            // 
            this.uxFrequencyLabel.AutoSize = true;
            this.uxFrequencyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxFrequencyLabel.Location = new System.Drawing.Point(8, 172);
            this.uxFrequencyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uxFrequencyLabel.Name = "uxFrequencyLabel";
            this.uxFrequencyLabel.Size = new System.Drawing.Size(88, 20);
            this.uxFrequencyLabel.TabIndex = 22;
            this.uxFrequencyLabel.Text = "Frequency:";
            // 
            // uxGetStatButton
            // 
            this.uxGetStatButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxGetStatButton.Location = new System.Drawing.Point(8, 129);
            this.uxGetStatButton.Margin = new System.Windows.Forms.Padding(2);
            this.uxGetStatButton.Name = "uxGetStatButton";
            this.uxGetStatButton.Size = new System.Drawing.Size(303, 36);
            this.uxGetStatButton.TabIndex = 21;
            this.uxGetStatButton.Text = "Get Statistics";
            this.uxGetStatButton.UseVisualStyleBackColor = true;
            this.uxGetStatButton.Click += new System.EventHandler(this.uxLookup_Click);
            // 
            // uxName
            // 
            this.uxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxName.Location = new System.Drawing.Point(68, 96);
            this.uxName.Margin = new System.Windows.Forms.Padding(2);
            this.uxName.Name = "uxName";
            this.uxName.Size = new System.Drawing.Size(243, 26);
            this.uxName.TabIndex = 20;
            // 
            // uxNameLabel
            // 
            this.uxNameLabel.AutoSize = true;
            this.uxNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxNameLabel.Location = new System.Drawing.Point(7, 99);
            this.uxNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uxNameLabel.Name = "uxNameLabel";
            this.uxNameLabel.Size = new System.Drawing.Size(55, 20);
            this.uxNameLabel.TabIndex = 19;
            this.uxNameLabel.Text = "Name:";
            // 
            // uxOpen
            // 
            this.uxOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxOpen.Location = new System.Drawing.Point(8, 49);
            this.uxOpen.Margin = new System.Windows.Forms.Padding(2);
            this.uxOpen.Name = "uxOpen";
            this.uxOpen.Size = new System.Drawing.Size(303, 36);
            this.uxOpen.TabIndex = 18;
            this.uxOpen.Text = "Open Data File";
            this.uxOpen.UseVisualStyleBackColor = true;
            this.uxOpen.Click += new System.EventHandler(this.uxOpen_Click);
            // 
            // uxMakeTree
            // 
            this.uxMakeTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxMakeTree.Location = new System.Drawing.Point(159, 4);
            this.uxMakeTree.Margin = new System.Windows.Forms.Padding(2);
            this.uxMakeTree.Name = "uxMakeTree";
            this.uxMakeTree.Size = new System.Drawing.Size(152, 41);
            this.uxMakeTree.TabIndex = 17;
            this.uxMakeTree.Text = "Make Tree";
            this.uxMakeTree.UseVisualStyleBackColor = true;
            this.uxMakeTree.Click += new System.EventHandler(this.uxMakeTree_Click);
            // 
            // uxNumItemsLabel
            // 
            this.uxNumItemsLabel.AutoSize = true;
            this.uxNumItemsLabel.Location = new System.Drawing.Point(15, 27);
            this.uxNumItemsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uxNumItemsLabel.Name = "uxNumItemsLabel";
            this.uxNumItemsLabel.Size = new System.Drawing.Size(84, 13);
            this.uxNumItemsLabel.TabIndex = 15;
            this.uxNumItemsLabel.Text = "Number of Items";
            // 
            // uxMinLabel
            // 
            this.uxMinLabel.AutoSize = true;
            this.uxMinLabel.Location = new System.Drawing.Point(8, 6);
            this.uxMinLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uxMinLabel.Name = "uxMinLabel";
            this.uxMinLabel.Size = new System.Drawing.Size(91, 13);
            this.uxMinLabel.TabIndex = 14;
            this.uxMinLabel.Text = "Minimum Degrees";
            // 
            // uxOpenDialog
            // 
            this.uxOpenDialog.FileName = "uxOpenFileDialog";
            // 
            // uxCount
            // 
            this.uxCount.Location = new System.Drawing.Point(103, 25);
            this.uxCount.Margin = new System.Windows.Forms.Padding(2);
            this.uxCount.Name = "uxCount";
            this.uxCount.Size = new System.Drawing.Size(51, 20);
            this.uxCount.TabIndex = 27;
            this.uxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NameLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 236);
            this.Controls.Add(this.uxCount);
            this.Controls.Add(this.uxMinDegree);
            this.Controls.Add(this.uxRank);
            this.Controls.Add(this.uxRankLabel);
            this.Controls.Add(this.uxFrequency);
            this.Controls.Add(this.uxFrequencyLabel);
            this.Controls.Add(this.uxGetStatButton);
            this.Controls.Add(this.uxName);
            this.Controls.Add(this.uxNameLabel);
            this.Controls.Add(this.uxOpen);
            this.Controls.Add(this.uxMakeTree);
            this.Controls.Add(this.uxNumItemsLabel);
            this.Controls.Add(this.uxMinLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "NameLookup";
            this.Text = "B Trees";
            ((System.ComponentModel.ISupportInitialize)(this.uxMinDegree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown uxMinDegree;
        private System.Windows.Forms.TextBox uxRank;
        private System.Windows.Forms.Label uxRankLabel;
        private System.Windows.Forms.TextBox uxFrequency;
        private System.Windows.Forms.Label uxFrequencyLabel;
        private System.Windows.Forms.Button uxGetStatButton;
        private System.Windows.Forms.TextBox uxName;
        private System.Windows.Forms.Label uxNameLabel;
        private System.Windows.Forms.Button uxOpen;
        private System.Windows.Forms.Button uxMakeTree;
        private System.Windows.Forms.Label uxNumItemsLabel;
        private System.Windows.Forms.Label uxMinLabel;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
        private System.Windows.Forms.NumericUpDown uxCount;
    }
}

