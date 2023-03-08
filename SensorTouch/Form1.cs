using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace SensorTouch
{
    public partial class Form1 : Form
    {
        private int filterValueMax = 1000, filterValueMin = 100;
        private string filePath = string.Empty;
        private int[,] primaryArray;
        private int[] arrayX, arrayY, arrayValue;
        private int currentPointIndex = 0;
        private string[] size, lines;
        private int rowCount, colCount, matrixNum1, matrixNum2;
        List<Point> pointsList = new List<Point>();
        private Size oldSize;
        private Size newSize;
        public Form1()
        {
            InitializeComponent();
            oldSize = pictureBox1.Size;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = $"{String.Format(trackBar1.Value.ToString())}ms";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            PaintDot();

            if (currentPointIndex >= pointsList.Count)
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
            GetDataFromCsv();
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

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            oldSize = this.oldSize;
            newSize = this.Size;
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
                pointsList.Clear();
                FilterArr();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wrong input value! {ex.Message}", "Something wrong", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                Application.Restart();
            }
        }
        private void PaintDot()
        {
            try
            {
                Graphics paintDot = pictureBox1.CreateGraphics();

                double originalX = pointsList[currentPointIndex].X;
                double originalY = pointsList[currentPointIndex].Y;

                double X = (originalX / oldSize.Width) * pictureBox1.Width;
                double Y = (originalY / oldSize.Height) * pictureBox1.Height;

                label2_XY.Text = String.Format($"X:{(int)X} - Y:{(int)Y}");

                paintDot.FillEllipse(Brushes.Red, (int)X, (int)Y, 7, 7);
                currentPointIndex++;
            }
            catch(Exception ex) 
            {
                MessageBox.Show($"{ex.Message}", "Something wrong", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                Application.Restart();
            }
        }
        private void FilterArr() 
        {
            for (int i = 0; i< arrayValue.Length; i++)
            {
                if (arrayValue[i] >= filterValueMin && arrayValue[i] <= filterValueMax)
                {
                    Point filterPoint = new Point(arrayX[i], arrayY[i]);
                    pointsList.Add(filterPoint);
                }
            }
        }
        private void GetDataFromCsv()
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
                        lines = File.ReadAllLines(filePath);
                        size = lines[0].Split(',');
                        rowCount = lines.Length;
                        matrixNum1 = int.Parse(size[0]);
                        matrixNum2 = int.Parse(size[1]);
                        colCount = matrixNum1 * matrixNum2;
                        primaryArray = new int[rowCount - 1, colCount];
                        GetArray();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}", "Something wrong", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        Application.Restart();
                    }
                }
            }
        }
        private void GetArray()
        {
            try
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(',');
                    for (int j = 0; j < colCount; j++)
                    {
                        primaryArray[i - 1, j] = int.Parse(values[j]);
                    }
                }

                arrayX = new int[primaryArray.GetLength(0)];
                arrayY = new int[primaryArray.GetLength(1)];
                arrayValue = new int[primaryArray.GetLength(0)];

                for (int i = 0; i < primaryArray.GetLength(0); i++)
                {
                    int pos = 0;
                    int max = primaryArray[i, 0];

                    for (int j = 1; j < primaryArray.GetLength(1); j++)
                    {
                        arrayY[j] = j;
                        if (primaryArray[i, j] > max)
                        {
                            max = primaryArray[i, j];
                            pos = j;
                        }
                    }
                    arrayValue[i] = max;
                    arrayX[i] = pos;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"{ex.Message}", "Something wrong", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                Application.Restart();
            }
            FilterArr();
        }
    }
}




