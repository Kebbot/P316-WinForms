using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P316Win
{
    public partial class Form1 : Form
    {
       Timer vTimer = new Timer();
        private static Timer Utimer = new Timer();
        public Form1()
        {
            InitializeComponent();
            button3.Enabled = false;
            //определяем обработчик события для таймера
            vTimer.Tick += new EventHandler(ShowTimer);
            //button1.Hide();

            /////////////////////
            Utime.Text = DateTime.Now.ToLongTimeString();
            Utimer.Tick += new EventHandler(ShowTime);
            Utimer.Interval = 500;
            Utimer.Start();
        }
        private void ShowTime(object vObject, EventArgs e)
        {
            Utime.Text = DateTime.Now.ToLongTimeString();
        }
        private void ShowTimer(object vObject, EventArgs e)
        {
            vTimer.Stop();
            button3.Enabled = false;
            button2.Enabled = true;
            MessageBox.Show("Таймер отработал!", "Таймер");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String message = "Окно для проверки тествого сообщения";
            MessageBox.Show(message);

        }
        public delegate void MouseEventHendler(object sender, MouseEventArgs e);
        private String CoordinatesToString(MouseEventArgs e)
        {
            return "Координаты мыши: X = " + e.X.ToString() + "; Y = " + e.Y.ToString();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = CoordinatesToString(e);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            String message = "";
            if(e.Button == MouseButtons.Right)
            {
                message = "Вы нажали правую кнопку мыши. ";
            }
            if(e.Button == MouseButtons.Left)
            {
                message = "Вы нажали левую кнопку мыши. ";
            }
            message += "\n" + CoordinatesToString(e);

            String caption = "Клик мыши";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(numericUpDown1.Value < 5)
            {
                MessageBox.Show("Количество секунд должно быть не меньше 5!");
                return;
            }
            button3.Enabled = true;

            vTimer.Interval = Decimal.ToInt32(numericUpDown1.Value) * 1000;
            button2.Enabled = false;
            vTimer.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vTimer.Stop();
            MessageBox.Show("Таймер не успел отработать!", "Таймер");
            button2.Enabled = true;
            button3.Enabled = false;
        }
    }

}
