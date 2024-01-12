using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Mangement_System
{
    public partial class Splash_Screen : Form
    {
        public Splash_Screen()
        {
            InitializeComponent();
        }
         Timer tmr;
        private void Form_Shown(object sender, EventArgs e)
        {
            tmr = new Timer();
            //set time interval 3 sec
            tmr.Interval = 30;
            //starts the timer
            tmr.Start();
            tmr.Tick += timer1_Tick;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //after 3 sec stop the timer
            tmr.Stop();
            //display mainform
            Login frm = new Login();
            frm.Show();
            //hide this form
            this.Hide();
        }
    }
}
