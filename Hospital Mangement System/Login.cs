using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;


namespace Hospital_Mangement_System
{
    public partial class Login : Form
    {


        public Login()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("Data Source=DELL;Initial Catalog=Hospital_db;Integrated Security=True"); // database parth

        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        // Login Funcation
        private void button1_Click(object sender, EventArgs e)
        {
            try  // Exception Handler
            {
                SqlConnection con = new SqlConnection("Data Source=DELL;Initial Catalog=Hospital_db;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Select * from Login where Username = '" + textBox1.Text + "' and Password = '" + textBox2.Text + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                String cmdItemValue = comboBox1.SelectedItem.ToString();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Role"].ToString() == cmdItemValue) // comboBox
                        {
                            MessageBox.Show(" Login Successfully " + dt.Rows[i][4]);

                            if (comboBox1.SelectedIndex == 00)
                            {
                                Dashboard f = new Dashboard();
                                f.Show();
                                this.Hide();
                            }
                            else
                            {
                                Staff_Panel s = new Staff_Panel();
                                s.Show();
                                this.Hide();

                            }
                        }
                    }
                }
                else
            {
                MessageBox.Show("Plese Enter a valid Username & Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
            catch 
            {
                MessageBox.Show("Plese Enter a valid Username & Password","Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
