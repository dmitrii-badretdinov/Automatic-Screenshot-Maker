using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Screenshot_Maker
{
    public partial class Form1 : Form
    {
        public static int ticks = 1;

        int period = 300;
        string path = "C:\\scrcapture";
        TickingTimer timer = new TickingTimer(1000, "C:\\scrcapture");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PeriodTextBox.Text = period.ToString();
            LocationTextBox.Text = path;
            Start_Click(null, null);
        }

        private void SetStatusOff()
        {
            StatusTextBox.Text = "off";
        }

        private void SetStatusOn()
        {
            StatusTextBox.Text = "on";
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            SetStatusOff();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            timer.Stop();
            path = LocationTextBox.Text;
            period = Convert.ToInt32(PeriodTextBox.Text);
            timer = new TickingTimer(period * 1000, path);
            timer.Elapsed += TickingTimer.t_Elapsed;
            TickingTimer.t_Elapsed(null, null);
            timer.Start();
            SetStatusOn();
        }
    }
}
