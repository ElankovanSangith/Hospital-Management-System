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

namespace Hospital_Mangement_System
{
    public partial class Invoice : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DELL;Initial Catalog=Hospital_db;Integrated Security=True");
        public Invoice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validation message

            if (textBox10.Text == "" || textBox11.Text == "" || textBox14.Text == "" || textBox15.Text == "" || textBox19.Text == "" || textBox20.Text == "")
            {
                MessageBox.Show("Fillout the empty fields");
            }
            else
            {
                // Balance Calculation 
                int Balance, Paid, Total_Cost;
                Paid = int.Parse(textBox21.Text);
                Total_Cost = int.Parse(textBox13.Text);
                Balance = Paid - Total_Cost;
                textBox22.Text = Balance.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //btnReceipt
            rtfReceipt.Clear();

            // rtfReceipt.AppendText(Environment.NewLine);
            rtfReceipt.AppendText("---------------------------------------------------------------------------" + Environment.NewLine);
            rtfReceipt.AppendText("\t\t" + "HealthCare Plus" + Environment.NewLine);
            rtfReceipt.AppendText("---------------------------------------------------------------------------" + Environment.NewLine);
            rtfReceipt.AppendText(lblTimer.Text + "\t\t" + lblDate.Text + Environment.NewLine);
            rtfReceipt.AppendText("---------------------------------------------------------------------------" + Environment.NewLine);
            rtfReceipt.AppendText("Invoice_ID \t\t\t" + textBox10.Text + Environment.NewLine);
            rtfReceipt.AppendText("Patient_ID \t\t\t" + textBox11.Text + Environment.NewLine);
            rtfReceipt.AppendText("Name \t\t\t\t" + textBox12.Text + Environment.NewLine);
            rtfReceipt.AppendText("---------------------------------------------------------------------------" + Environment.NewLine);
            rtfReceipt.AppendText("Appointment_fee \t\t\t" + textBox14.Text + Environment.NewLine);
            rtfReceipt.AppendText("Doctor_fee \t\t\t" + textBox15.Text + Environment.NewLine);
            rtfReceipt.AppendText("Consultation_fee \t\t\t" + textBox16.Text + Environment.NewLine);
            rtfReceipt.AppendText("Procedures_fee \t\t\t" + textBox17.Text + Environment.NewLine);
            rtfReceipt.AppendText("Room_Charge \t\t\t" + textBox18.Text + Environment.NewLine);
            rtfReceipt.AppendText("Medications_fee \t\t\t" + textBox19.Text + Environment.NewLine);
            rtfReceipt.AppendText("Hospital_fee \t\t\t" + textBox20.Text + Environment.NewLine);
            rtfReceipt.AppendText("---------------------------------------------------------------------------" + Environment.NewLine);
            rtfReceipt.AppendText("Total Cost \t\t\t" + textBox13.Text + Environment.NewLine);
            rtfReceipt.AppendText("---------------------------------------------------------------------------" + Environment.NewLine);
            rtfReceipt.AppendText("Paid \t\t\t\t" + textBox21.Text + Environment.NewLine);
            rtfReceipt.AppendText("Balance \t\t\t\t" + textBox22.Text + Environment.NewLine);
            rtfReceipt.AppendText("---------------------------------------------------------------------------" + Environment.NewLine);
            rtfReceipt.AppendText("\t\t" + "Thank You" + Environment.NewLine);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToLongTimeString();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(rtfReceipt.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, 120, 120);
        }

        private void Invoice_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospital_dbDataSet3.Invoice' table. You can move, or remove it, as needed.
            this.invoiceTableAdapter.Fill(this.hospital_dbDataSet3.Invoice);
            rtfReceipt.Clear();


            lblDate.Text = DateTime.Now.ToShortDateString();
            timer1.Start();


            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            rtfReceipt.Clear();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            //this code will open text files
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rtfReceipt.LoadFile(openFile.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            //this code will save text files
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.FileName = "Notepad Text";
            saveFile.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";


            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFile.FileName))
                    sw.WriteLine(rtfReceipt.Text);
            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            rtfReceipt.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            rtfReceipt.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            rtfReceipt.Paste();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            // Total_Cost Calculation 
            int Appointment_fee, Medications_fee, Doctor_fee, Hospital_fee, Total_Cost, Consultation_fee, procedures_fee, Room_Charge;
            Appointment_fee = int.Parse(textBox14.Text);
            Medications_fee = int.Parse(textBox19.Text);
            Doctor_fee = int.Parse(textBox15.Text);
            Hospital_fee = int.Parse(textBox20.Text);
            Consultation_fee = int.Parse(textBox16.Text);
            procedures_fee = int.Parse(textBox17.Text);
            Room_Charge = int.Parse(textBox18.Text);

            Total_Cost = Appointment_fee + Medications_fee + Doctor_fee + Hospital_fee+ Consultation_fee + procedures_fee + Room_Charge;
            textBox13.Text = Total_Cost.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dashboard pa = new Dashboard();
            pa.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Patient pa = new Patient();
            pa.Show();
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

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Report Rep = new Report();
            Rep.Show();
            this.Hide();
        }


        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTimer_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Patient where Patient_ID like'" + textBox11.Text + "' ", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                textBox12.Text = sdr["P_Name"].ToString();
            }
            con.Close();
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
