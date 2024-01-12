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
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
        }

        private void Appointment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospital_dbDataSet1.Appointment' table. You can move, or remove it, as needed.
            this.appointmentTableAdapter.Fill(this.hospital_dbDataSet1.Appointment);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dashboard Das = new Dashboard();
            Das.Show();
            this.Hide();
        }
    }
}
