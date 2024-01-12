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
    public partial class Meditation : Form
    {
        public Meditation()
        {
            InitializeComponent();
        }

        private void Meditation_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospital_dbDataSet6.Medication' table. You can move, or remove it, as needed.
            this.medicationTableAdapter.Fill(this.hospital_dbDataSet6.Medication);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dashboard Das = new Dashboard();
            Das.Show();
            this.Hide();
        }
    }
}
