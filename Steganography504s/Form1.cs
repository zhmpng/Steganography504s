using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace Steganography504s
{
    public partial class Form1 : Form
    {
        private Bitmap bmp = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bmp = (Bitmap)pictureBox1.Image;

            string text = textBox1.Text;

            if (text.Equals(""))
            {
                MessageBox.Show("Для скрытия информации в изображении необходимо заполнить окно ввода. \nОкно ввода не может быть пустым", "Ошибка");

                return;
            }

            bmp = Steganography.embedText(text, bmp);

            MessageBox.Show("Ваш текст был успешно спрятан в изображении", "Успех!");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            bmp = (Bitmap)pictureBox1.Image;

            string extractedText = Steganography.extractText(bmp);

            textBox1.Text = extractedText;
        }

        private void ОткрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files (*.jpeg; *.png; *.bmp)|*.jpg; *.png; *.bmp";

            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open_dialog.FileName);
            }
        }

        private void СохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save_dialog = new SaveFileDialog();
            save_dialog.Filter = "Png Изображение|*.png|Bitmap Изображение|*.bmp";

            if (save_dialog.ShowDialog() == DialogResult.OK)
            {
                switch (save_dialog.FilterIndex)
                {
                    case 1:
                        {
                            bmp.Save(save_dialog.FileName, ImageFormat.Png);
                        }
                        break;
                    case 2:
                        {
                            bmp.Save(save_dialog.FileName, ImageFormat.Bmp);
                        }
                        break;
                }
            }
        }

        private void ИнформацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данная опытная программа была создана студентом группы М4О-504С-16, в рамках учебно-исследовательской работы студента", "Жмылев М.А.");
        }
    }
}
