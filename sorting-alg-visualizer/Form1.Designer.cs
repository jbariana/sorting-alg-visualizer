namespace sorting_alg_visualizer
{
    partial class MainWindow
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
            this.displayBox = new System.Windows.Forms.PictureBox();
            this.sortingAlgComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.RandomizeButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.AmountComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.displayBox)).BeginInit();
            this.SuspendLayout();
            // 
            // displayBox
            // 
            this.displayBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.displayBox.Location = new System.Drawing.Point(50, 71);
            this.displayBox.Name = "displayBox";
            this.displayBox.Size = new System.Drawing.Size(775, 350);
            this.displayBox.TabIndex = 0;
            this.displayBox.TabStop = false;
            this.displayBox.Paint += new System.Windows.Forms.PaintEventHandler(this.displayBox_Paint);
            // 
            // sortingAlgComboBox
            // 
            this.sortingAlgComboBox.FormattingEnabled = true;
            this.sortingAlgComboBox.Items.AddRange(new object[] {
            "Bubble Sort",
            "Selection Sort",
            "Insertion Sort",
            "Quick Sort",
            "Heap Sort",
            "Radix Sort",
            "Shell Sort"});
            this.sortingAlgComboBox.Location = new System.Drawing.Point(557, 29);
            this.sortingAlgComboBox.Name = "sortingAlgComboBox";
            this.sortingAlgComboBox.Size = new System.Drawing.Size(121, 21);
            this.sortingAlgComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(420, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose Sorting Algorithm: ";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(767, 41);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Start!";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // RandomizeButton
            // 
            this.RandomizeButton.Location = new System.Drawing.Point(767, 12);
            this.RandomizeButton.Name = "RandomizeButton";
            this.RandomizeButton.Size = new System.Drawing.Size(75, 23);
            this.RandomizeButton.TabIndex = 4;
            this.RandomizeButton.Text = "Randomize!";
            this.RandomizeButton.UseVisualStyleBackColor = true;
            this.RandomizeButton.Click += new System.EventHandler(this.RandomizeButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Choose Amount of Items: ";
            // 
            // AmountComboBox
            // 
            this.AmountComboBox.FormattingEnabled = true;
            this.AmountComboBox.Items.AddRange(new object[] {
            "10",
            "25",
            "50",
            "100"});
            this.AmountComboBox.Location = new System.Drawing.Point(258, 29);
            this.AmountComboBox.Name = "AmountComboBox";
            this.AmountComboBox.Size = new System.Drawing.Size(121, 21);
            this.AmountComboBox.TabIndex = 7;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.AmountComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RandomizeButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sortingAlgComboBox);
            this.Controls.Add(this.displayBox);
            this.MaximumSize = new System.Drawing.Size(900, 500);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "Sorting Algorithm Visualizer";
            ((System.ComponentModel.ISupportInitialize)(this.displayBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox displayBox;
        private System.Windows.Forms.ComboBox sortingAlgComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button RandomizeButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox AmountComboBox;
    }
}

