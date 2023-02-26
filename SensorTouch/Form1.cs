using System;
using System.Drawing;
using System.Runtime.InteropServices;
using static System.Windows.Forms.LinkLabel;

namespace SensorTouch
{
    public partial class Form1 : Form
    {
        private int filterValueMax = 1000;
        private int filterValueMin = 100;
        private string filePath = string.Empty;
        private int[,] primaryArray;
        private int[] arrayY;
        private int[] arrayValue;
        private int currentPointIndex = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = $"{String.Format(trackBar1.Value.ToString())}ms";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics paintDot = pictureBox1.CreateGraphics();

            if (arrayValue[currentPointIndex] >= filterValueMin && arrayValue[currentPointIndex] <= filterValueMax)
            {
                label2_XY.Text = String.Format($"X:{arrayY[currentPointIndex]} - Y:{currentPointIndex}");

                paintDot.FillEllipse(Brushes.Red, arrayY[currentPointIndex], currentPointIndex, 7, 7);
            }

            currentPointIndex++;

            if (currentPointIndex >= primaryArray.GetLength(0))
            {
                timer1.Stop();
                currentPointIndex = 0;
                trackBar1.Enabled = true;
                trackBar1.Enabled = true;
                button1_OpenFile.Enabled = true;
                button4_Clear.Enabled = true;
                button5_AplyMaxValue.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
        }
        private void button1_Click_OpenFile(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "CSV files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        filePath = openFileDialog.FileName;
                        string[] lines = File.ReadAllLines(filePath);
                        string[] size = lines[0].Split(',');
                        int rowCount = lines.Length;
                        int matrixNum1 = int.Parse(size[0]);
                        int matrixNum2 = int.Parse(size[1]);
                        int colCount = matrixNum1 * matrixNum2;
                        primaryArray = new int[rowCount - 1, colCount];

                        for (int i = 1; i < lines.Length; i++)
                        {
                            string[] values = lines[i].Split(',');
                            for (int j = 0; j < colCount; j++)
                            {
                                primaryArray[i - 1, j] = int.Parse(values[j]);
                            }
                        }

                        arrayY = new int[primaryArray.GetLength(0)];
                        arrayValue = new int[primaryArray.GetLength(0)];

                        for (int i = 0; i < primaryArray.GetLength(0); i++)
                        {
                            int pos = 0;
                            int max = primaryArray[i, 0]; // початкове значення максимуму - перше число у рядку

                            for (int j = 1; j < primaryArray.GetLength(1); j++)
                            {
                                if (primaryArray[i, j] > max) // знаходження найбільшого значення у рядку
                                {
                                    max = primaryArray[i, j];
                                    pos = j;
                                }
                            }
                            arrayValue[i] = max;
                            arrayY[i] = pos;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}", "Something wrong", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        Application.Restart();
                    }
                    trackBar1.Enabled = true;
                    trackBar1.Enabled = true;
                    button1_OpenFile.Enabled = true;
                    button2_Start.Enabled = true;
                    button3_Stop.Enabled = true;
                    button4_Clear.Enabled = true;
                    button5_AplyMaxValue.Enabled = true;
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                }
            }
        }
        private void button2_Click_Start(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value;
            trackBar1.Enabled = false;
            button1_OpenFile.Enabled = false;
            button4_Clear.Enabled = false;
            button5_AplyMaxValue.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            timer1.Start();
        }
        private void button3_Click_Stop(object sender, EventArgs e)
        {
            trackBar1.Enabled = true;
            button1_OpenFile.Enabled = true;
            button4_Clear.Enabled = true;
            button5_AplyMaxValue.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            timer1.Stop();

        }
        private void button4_Click_Clear(object sender, EventArgs e)
        {
            currentPointIndex = 0;
            pictureBox1.Image = null;
            label2_XY.Text = $"X:{0} - Y:{0}";
        }
        private void button5_Click_AplyMaxValue(object sender, EventArgs e)
        {

            try
            {
                filterValueMax = int.Parse(textBox2.Text);
                filterValueMin = int.Parse(textBox1.Text);
            }
            catch(Exception ex) 
            {
                MessageBox.Show($"{ex.Message}", "Something wrong", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                Application.Restart();
            }
        }

    }
}