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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dashboard Das = new Dashboard();
            Das.Show();
            this.Hide();
        }
    }
}
