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
    public partial class Resources : Form
    {
        public Resources()
        {
            InitializeComponent();
        }

        private void Resources_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospital_dbDataSet7.Resource' table. You can move, or remove it, as needed.
            this.resourceTableAdapter.Fill(this.hospital_dbDataSet7.Resource);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dashboard Das = new Dashboard();
            Das.Show();
            this.Hide();
        }
    }
}
