using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hospital_Mangement_System
{
    public partial class Add_New_User : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DELL;Initial Catalog=Hospital_db;Integrated Security=True");
        public Add_New_User()
        {
            InitializeComponent();
        }
        public void auto_ID()
        {
            con.Open();
            string sqlQuery = "SELECT TOP 1 User_ID from Login order by User_ID desc";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string input = dr["User_ID"].ToString();
                string angka = input.Substring(input.Length - Math.Min(3, input.Length));
                int number = Convert.ToInt32(angka);
                number += 1;
                string str = number.ToString("D3");

                textBox10.Text = "" + str;
            }
            con.Close();
        }
        private void clearText()
        {
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            

        }
        public void gridviewUpdate()
        {
            con.Open();
            string select = "SELECT * from Login";
            SqlDataAdapter da = new SqlDataAdapter(select, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Login");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Login";
            con.Close();
        }

        private void Add_New_User_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospital_dbDataSet8.Login' table. You can move, or remove it, as needed.
            this.loginTableAdapter.Fill(this.hospital_dbDataSet8.Login);

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            // selcet insert query
            if (textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "" || textBox14.Text == "")
            {
                MessageBox.Show("Fillout the empty fields");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Login(User_ID,Name,Username,Password,Role)values('" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "', '" +textBox14.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("New Login Added Successfully!!!", "Login Addition", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                con.Close();
                clearText();
                gridviewUpdate();
                auto_ID();
            }
        }
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            // selcet update query
            SqlCommand cmd = new SqlCommand("update Login set Name='" + textBox11.Text + "',Username='" + textBox12.Text + "',Password='" + textBox13.Text + "',Role='" + textBox14.Text + "' WHERE User_ID='" + textBox10.Text + "' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Existing Login details Updated Successfully", "Existing Login Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            con.Close();
            clearText();
            gridviewUpdate();
            auto_ID();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            // selcet search query
            SqlCommand cmd = new SqlCommand("select * from Login where User_ID like'" + textBox10.Text + "' ", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                textBox11.Text = sdr["Name"].ToString();
                textBox12.Text = sdr["Username"].ToString();
                textBox13.Text = sdr["Password"].ToString();
                textBox14.Text = sdr["Role"].ToString();
            }
            con.Close();
        }

        private void pictureBox11_Click_1(object sender, EventArgs e)
        {
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
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
