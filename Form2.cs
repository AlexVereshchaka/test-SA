using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LB1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap b;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            // Устанавливаем свойства для OpenFileDialog
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            // Отображаем диалоговое окно выбора файла
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Получаем выбранный путь к файлу
                string filePath = openFileDialog1.FileName;

                // Выводим путь к файлу в текстовое поле на форме
                textBox1.Text = filePath;
                b = new Bitmap(Image.FromFile(textBox1.Text));
                pictureBox1.Image = b;
            }
        }

          

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            double I, minI, maxI;
            Color c;
            double sum = 0, srI = 0;

            minI = 255;
            maxI = 0;
            for (int x = 0; x < b.Width; x = x + 1)
            {
                for (int y = 0; y < b.Height; y = y + 1)
                {
                    c = b.GetPixel(x, y);
                    I = (c.R + c.G + c.B) / 3;
                    sum = sum + I;
                    if (minI > I) minI = I;
                    if (maxI > I) maxI = I;
                }
            }
            srI = sum / (b.Width * b.Height);
            MessageBox.Show("середня яскравість" + srI + "min" + minI + "max" + maxI);
        }
    }
}
