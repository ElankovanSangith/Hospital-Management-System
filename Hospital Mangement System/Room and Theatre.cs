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
    public partial class Room_and_Theatre : Form
    {
        public Room_and_Theatre()
        {
            InitializeComponent();
        }

        private void Room_and_Theatre_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospital_dbDataSet4.Room' table. You can move, or remove it, as needed.
            this.roomTableAdapter.Fill(this.hospital_dbDataSet4.Room);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dashboard Das = new Dashboard();
            Das.Show();
            this.Hide();
        }
    }
}
