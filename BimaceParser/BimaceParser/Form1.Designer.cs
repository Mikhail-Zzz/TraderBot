namespace BimaceParser
{
    partial class Form1
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
            this.UpdatePairsButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.PairSelector = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // UpdatePairsButton
            // 
            this.UpdatePairsButton.Location = new System.Drawing.Point(12, 12);
            this.UpdatePairsButton.Name = "UpdatePairsButton";
            this.UpdatePairsButton.Size = new System.Drawing.Size(168, 23);
            this.UpdatePairsButton.TabIndex = 0;
            this.UpdatePairsButton.Text = "Обновить список пар";
            this.UpdatePairsButton.UseVisualStyleBackColor = true;
            this.UpdatePairsButton.Click += new System.EventHandler(this.UpdatePairsButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(12, 41);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(168, 23);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(12, 70);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(168, 23);
            this.StopButton.TabIndex = 2;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(205, 14);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(506, 424);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(717, 14);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(220, 424);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(943, 14);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(330, 424);
            this.textBox3.TabIndex = 5;
            // 
            // PairSelector
            // 
            this.PairSelector.FormattingEnabled = true;
            this.PairSelector.Location = new System.Drawing.Point(12, 99);
            this.PairSelector.Name = "PairSelector";
            this.PairSelector.Size = new System.Drawing.Size(168, 21);
            this.PairSelector.TabIndex = 6;
            this.PairSelector.SelectedIndexChanged += new System.EventHandler(this.PairSelector_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 678);
            this.Controls.Add(this.PairSelector);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.UpdatePairsButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UpdatePairsButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox PairSelector;
    }
}

