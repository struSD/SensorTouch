using System;

namespace SensorTouch
{
    public partial class Form1 : Form
    {
        private int[,] pointArray = {
            { 10, 10 },
            { 30, 30 },
            { 60, 60 },
            { 190, 11 },
            { 166, 300 },
            { 6, 222 },
            { 199, 147 },
            {12, 88 }
        };
        int currentPointIndex = 0;
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
            label2_XY.Text = String.Format($"X:{pointArray[currentPointIndex, 1]} - Y:{pointArray[currentPointIndex, 0]}");

            Graphics paintDot = pictureBox1.CreateGraphics();
            paintDot.FillEllipse(Brushes.Red, pointArray[currentPointIndex, 1], pointArray[currentPointIndex, 0], 8, 8);

            currentPointIndex++;

            if (currentPointIndex >= pointArray.GetLength(0))
            {
                timer1.Stop();
                currentPointIndex = 0;
                trackBar1.Enabled = true;
                trackBar1.Enabled = true;
                button1_OpenFile.Enabled = true;
                button4_Clear.Enabled = true;
                button5_AplyMaxValue.Enabled = true;
                textBox1.Enabled = true;
            }
        }
        private void GetMaxNumbers(int[,] mass)
       {
            for (int x = 0; x < mass.GetLength(0); x++)
            {
                int max = mass[x, 0];
                int y = 0;

                for (int j = 1; j < mass.GetLength(1); j++)
                {
                    if (mass[x, j] > max)
                    {
                        max = mass[x, j];
                        y = j;
                    }
                }
                Console.WriteLine("Max value  X:{0},Y:{1}\t num:{2}", x, y, max);
            }
        }

        private void button1_Click_OpenFile(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "CSV files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;

                    string[] lines = File.ReadAllLines(filePath);
                    string[] size = lines[0].Split(',');
                    int rowCount = lines.Length;
                    int matrixNum1 = int.Parse(size[0]);
                    int matrixNum2 = int.Parse(size[1]);
                    int colCount = matrixNum1 * matrixNum2;

                    int[,] data = new int[rowCount - 1, colCount];

                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] values = lines[i].Split(',');
                        for (int j = 0; j < colCount; j++)
                        {
                            data[i - 1, j] = int.Parse(values[j]);
                        }
                    }

                    trackBar1.Enabled = true;
                    trackBar1.Enabled = true;
                    button1_OpenFile.Enabled = true;
                    button2_Start.Enabled = true;
                    button3_Stop.Enabled = true;
                    button4_Clear.Enabled = true;
                    button5_AplyMaxValue.Enabled = true;
                    textBox1.Enabled = true;
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
            timer1.Start();
        }

        private void button3_Click_Stop(object sender, EventArgs e)
        {
            timer1.Stop();
            trackBar1.Enabled = true;
            trackBar1.Enabled = true;
            button1_OpenFile.Enabled = true;
            button4_Clear.Enabled = true;
            button5_AplyMaxValue.Enabled = true;
            textBox1.Enabled = true;
        }

        private void button4_Click_Clear(object sender, EventArgs e)
        {
            currentPointIndex = 0;
            pictureBox1.Image = null;
            label2_XY.Text = $"X:{0} - Y:{0}";
        }

        private void button5_Click_AplyMaxValue(object sender, EventArgs e)
        {

        }
    }
}