namespace GOS_KAMASHEVA.Views
{
    partial class UserView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserView));
            this.ExitButton = new System.Windows.Forms.Button();
            this.HiLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SpentTimeLabel = new System.Windows.Forms.Label();
            this.CrushesCountLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Location = new System.Drawing.Point(10, 3);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(66, 23);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // HiLabel
            // 
            this.HiLabel.AutoSize = true;
            this.HiLabel.Location = new System.Drawing.Point(30, 44);
            this.HiLabel.Name = "HiLabel";
            this.HiLabel.Size = new System.Drawing.Size(44, 17);
            this.HiLabel.TabIndex = 3;
            this.HiLabel.Text = "label1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 154);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(931, 405);
            this.dataGridView1.TabIndex = 4;
            // 
            // SpentTimeLabel
            // 
            this.SpentTimeLabel.AutoSize = true;
            this.SpentTimeLabel.Location = new System.Drawing.Point(456, 66);
            this.SpentTimeLabel.Name = "SpentTimeLabel";
            this.SpentTimeLabel.Size = new System.Drawing.Size(44, 17);
            this.SpentTimeLabel.TabIndex = 5;
            this.SpentTimeLabel.Text = "label1";
            // 
            // CrushesCountLabel
            // 
            this.CrushesCountLabel.AutoSize = true;
            this.CrushesCountLabel.Location = new System.Drawing.Point(459, 98);
            this.CrushesCountLabel.Name = "CrushesCountLabel";
            this.CrushesCountLabel.Size = new System.Drawing.Size(46, 17);
            this.CrushesCountLabel.TabIndex = 6;
            this.CrushesCountLabel.Text = "label2";
            // 
            // UserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 571);
            this.Controls.Add(this.CrushesCountLabel);
            this.Controls.Add(this.SpentTimeLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.HiLabel);
            this.Controls.Add(this.ExitButton);
            this.Font = new System.Drawing.Font("Bahnschrift SemiBold", 7.8F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(963, 618);
            this.MinimumSize = new System.Drawing.Size(963, 618);
            this.Name = "UserView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AMONIC Airlines Automation System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label HiLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label SpentTimeLabel;
        private System.Windows.Forms.Label CrushesCountLabel;
    }
}