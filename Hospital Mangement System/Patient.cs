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
    public partial class Patient : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DELL;Initial Catalog=Hospital_db;Integrated Security=True");

        public Patient()
        {
            InitializeComponent();
        }

        public void auto_ID()
        {
            con.Open();
            string sqlQuery = "SELECT TOP 1 Patient_ID from Patient order by Patient_ID desc";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string input = dr["Patient_ID"].ToString();
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
            textBox15.Text = "";
            
        }
        public void gridviewUpdate()
        {
            con.Open();
            string select = "SELECT * from Patient";
            SqlDataAdapter da = new SqlDataAdapter(select, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Patient");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Patient";
            con.Close();
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            // selcet insert query
            if (textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "" || textBox14.Text == "" || textBox15.Text == "")
            {
                MessageBox.Show("Fillout the empty fields");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Patient(Patient_ID,P_Name,Address,Age,Gender,Phone_No,Disease)values('" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + comboBox1.SelectedItem + "','" + textBox14.Text + "','" + textBox15.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("New Patient Added Successfully!!!", "Patient Addition", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                con.Close();
                clearText();
                gridviewUpdate();
                auto_ID();
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            // selcet update query
            SqlCommand cmd = new SqlCommand("update Patient set P_Name='" + textBox11.Text + "',Address='" + textBox12.Text + "',Age='" + textBox13.Text + "',Gender='" + comboBox1.SelectedItem + "',Phone_No='" + textBox14.Text + "',Disease='" + textBox15.Text + "' WHERE Patient_ID='" + textBox10.Text + "' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Existing Patient details Updated Successfully", "Existing Patient Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            con.Close();
            clearText();
            gridviewUpdate();
            auto_ID();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            // selcet delete query
            SqlCommand cmd = new SqlCommand("delete from Patient where Patient_ID like '" + textBox10.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Existing Patient details Removed Successfully!!!", "Remove Existing Patient", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            con.Close();
            clearText();
            gridviewUpdate();
            auto_ID();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            // selcet search query
            SqlCommand cmd = new SqlCommand("select * from Patient where Patient_ID like'" + textBox10.Text + "' ", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                textBox11.Text = sdr["P_Name"].ToString();
                textBox12.Text = sdr["Address"].ToString();
                textBox13.Text = sdr["Age"].ToString();
                comboBox1.SelectedItem = sdr["Gender"].ToString();
                textBox14.Text = sdr["Phone_No"].ToString();
                textBox15.Text = sdr["Disease"].ToString();

            }
            con.Close();
        }
        private void pictureBox15_Click(object sender, EventArgs e)
        {
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
        }
        private void Patient_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospital_dbDataSet.Patient' table. You can move, or remove it, as needed.
            this.patientTableAdapter.Fill(this.hospital_dbDataSet.Patient);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dashboard Das = new Dashboard();
            Das.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Staff sa = new Staff();
            sa.Show();
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
