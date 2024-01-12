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

namespace Hospital_Mangement_System
{
    public partial class Staff : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DELL;Initial Catalog=Hospital_db;Integrated Security=True");

        public Staff()
        {
            InitializeComponent();
        }
        public void auto_ID()
        {
            con.Open();
            string sqlQuery = "SELECT TOP 1 Staff_ID from Staff order by Staff_ID desc";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string input = dr["Staff_ID"].ToString();
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
            comboBox1.SelectedItem = "";
            comboBox2.SelectedItem = "";
        }
        public void gridviewUpdate()
        {
            con.Open();
            string select = "SELECT * from Staff";
            SqlDataAdapter da = new SqlDataAdapter(select, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Staff");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Staff";
            con.Close();
        }

        private void Staff_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospital_dbDataSet5.Staff' table. You can move, or remove it, as needed.
            this.staffTableAdapter.Fill(this.hospital_dbDataSet5.Staff);
            // TODO: This line of code loads data into the 'hospital_dbDataSet5.Staff' table. You can move, or remove it, as needed.


        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "" || textBox14.Text == "" || textBox10.Text == "")
            {
                MessageBox.Show("Fillout the empty fields");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Staff(Staff_ID,S_Name,Address,Phone_No,Age,Gender,Role)values('" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + comboBox1.SelectedItem + "','" + comboBox2.SelectedItem + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("New Staff Added Successfully!!!", "Staff Addition", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                con.Close();
                clearText();
                gridviewUpdate();
                auto_ID();
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Staff set S_Name='" + textBox11.Text + "',Address='" + textBox12.Text + "',Phone_No='" + textBox13.Text + "',Age='" + textBox14.Text + "',Gender='" + comboBox1.SelectedItem + "',Role='" + comboBox2.SelectedItem + "'WHERE Staff_ID='" + textBox10.Text + "' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Existing Staff details Updated Successfully", "Existing Staff Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            con.Close();
            clearText();
            gridviewUpdate();
            auto_ID();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from Staff where Staff_ID like '" + textBox10.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Existing Staff details Removed Successfully!!!", "Remove Existing Staff", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            con.Close();
            clearText();
            gridviewUpdate();
            auto_ID();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Staff where Staff_ID like'" + textBox10.Text + "' ", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                textBox11.Text = sdr["S_Name"].ToString();
                textBox12.Text = sdr["Address"].ToString();
                textBox13.Text = sdr["Phone_No"].ToString();
                textBox14.Text = sdr["Age"].ToString();
                comboBox1.SelectedItem = sdr["Gender"].ToString();
                comboBox1.SelectedItem = sdr["Role"].ToString();
            }
            con.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dashboard Das = new Dashboard();
            Das.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Patient Pa = new Patient();
            Pa.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Doctor doc = new Doctor();
            doc.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Appointment App = new Appointment();
            App.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Resources RAI = new Resources();
            RAI.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Meditation med = new Meditation();
            med.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Room_and_Theatre RAT = new Room_and_Theatre();
            RAT.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Invoice inv = new Invoice();
            inv.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Report Rep = new Report();
            Rep.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
