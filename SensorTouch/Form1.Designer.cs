namespace SensorTouch
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button1_OpenFile = new System.Windows.Forms.Button();
            this.button2_Start = new System.Windows.Forms.Button();
            this.button3_Stop = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2_XY = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4_Clear = new System.Windows.Forms.Button();
            this.button5_AplyMaxValue = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1_OpenFile
            // 
            this.button1_OpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1_OpenFile.Location = new System.Drawing.Point(773, 12);
            this.button1_OpenFile.Name = "button1_OpenFile";
            this.button1_OpenFile.Size = new System.Drawing.Size(197, 29);
            this.button1_OpenFile.TabIndex = 0;
            this.button1_OpenFile.Text = "Open File";
            this.button1_OpenFile.UseVisualStyleBackColor = true;
            this.button1_OpenFile.Click += new System.EventHandler(this.button1_Click_OpenFile);
            // 
            // button2_Start
            // 
            this.button2_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2_Start.Enabled = false;
            this.button2_Start.Location = new System.Drawing.Point(773, 47);
            this.button2_Start.Name = "button2_Start";
            this.button2_Start.Size = new System.Drawing.Size(197, 29);
            this.button2_Start.TabIndex = 1;
            this.button2_Start.Text = "Start";
            this.button2_Start.UseVisualStyleBackColor = true;
            this.button2_Start.Click += new System.EventHandler(this.button2_Click_Start);
            // 
            // button3_Stop
            // 
            this.button3_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3_Stop.Enabled = false;
            this.button3_Stop.Location = new System.Drawing.Point(773, 82);
            this.button3_Stop.Name = "button3_Stop";
            this.button3_Stop.Size = new System.Drawing.Size(197, 29);
            this.button3_Stop.TabIndex = 2;
            this.button3_Stop.Text = "Stop";
            this.button3_Stop.UseVisualStyleBackColor = true;
            this.button3_Stop.Click += new System.EventHandler(this.button3_Click_Stop);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(773, 152);
            this.trackBar1.Maximum = 2500;
            this.trackBar1.Minimum = 50;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(197, 56);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Tag = "";
            this.trackBar1.TickFrequency = 50;
            this.trackBar1.Value = 100;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(926, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "50ms";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(755, 909);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label2_XY
            // 
            this.label2_XY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2_XY.AutoSize = true;
            this.label2_XY.Location = new System.Drawing.Point(12, 924);
            this.label2_XY.Name = "label2_XY";
            this.label2_XY.Size = new System.Drawing.Size(62, 20);
            this.label2_XY.TabIndex = 7;
            this.label2_XY.Text = "X:0 - Y:0";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(773, 214);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(90, 27);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "100";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button4_Clear
            // 
            this.button4_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4_Clear.Enabled = false;
            this.button4_Clear.Location = new System.Drawing.Point(773, 117);
            this.button4_Clear.Name = "button4_Clear";
            this.button4_Clear.Size = new System.Drawing.Size(197, 29);
            this.button4_Clear.TabIndex = 12;
            this.button4_Clear.Text = "Clear";
            this.button4_Clear.UseVisualStyleBackColor = true;
            this.button4_Clear.Click += new System.EventHandler(this.button4_Click_Clear);
            // 
            // button5_AplyMaxValue
            // 
            this.button5_AplyMaxValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5_AplyMaxValue.Enabled = false;
            this.button5_AplyMaxValue.Location = new System.Drawing.Point(773, 247);
            this.button5_AplyMaxValue.Name = "button5_AplyMaxValue";
            this.button5_AplyMaxValue.Size = new System.Drawing.Size(197, 29);
            this.button5_AplyMaxValue.TabIndex = 13;
            this.button5_AplyMaxValue.Text = "Aply max min value";
            this.button5_AplyMaxValue.UseVisualStyleBackColor = true;
            this.button5_AplyMaxValue.Click += new System.EventHandler(this.button5_Click_AplyMaxValue);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(880, 214);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(90, 27);
            this.textBox2.TabIndex = 14;
            this.textBox2.Text = "1000";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 953);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button5_AplyMaxValue);
            this.Controls.Add(this.button4_Clear);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2_XY);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button3_Stop);
            this.Controls.Add(this.button2_Start);
            this.Controls.Add(this.button1_OpenFile);
            this.Name = "Form1";
            this.Text = "SensorTouch";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1_OpenFile;
        private Button button2_Start;
        private Button button3_Stop;
        private TrackBar trackBar1;
        private Label label1;
        private System.Windows.Forms.Timer timer1;
        private PictureBox pictureBox1;
        private Label label2_XY;
        private TextBox textBox1;
        private Button button4_Clear;
        private Button button5_AplyMaxValue;
        private TextBox textBox2;
    }
}