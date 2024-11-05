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

namespace Gym_Project
{
    public partial class AddMember : Form
    {
        public AddMember()
        {
            InitializeComponent();
        }
        private void AddMember_Load(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vedant\OneDrive\Documents\GymDataBase.mdf;Integrated Security=True;Connect Timeout=30");
        private void button6_Click(object sender, EventArgs e)
        {
            if(NameTb.Text=="" || PhoneTb.Text=="" || AgeTb.Text=="" || AmountTb.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String query = "insert into Member values('" + NameTb.Text + "','" + PhoneTb.Text + "','" + GenderCb.SelectedItem.ToString() + "','" + AgeTb.Text + "'," + Convert.ToInt32(AmountTb.Text) + ",'" + TimingCb.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Has Successfully Added");
                    Con.Close();
                    NameTb.Text = "";
                    PhoneTb.Text = "";
                    AgeTb.Text = "";
                    GenderCb.Text = "";
                    AmountTb.Text = "";
                    TimingCb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NameTb.Text = "";
            PhoneTb.Text = "";
            AgeTb.Text = "";
            GenderCb.Text = "";
            AmountTb.Text = "";
            TimingCb.Text = "";
        }

        //Addmember Page Button
        private void button4_Click(object sender, EventArgs e)
        {
            AddMember addMember = new AddMember();
            addMember.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            UpdateDeletePage updateDelete = new UpdateDeletePage();
            updateDelete.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ViewMembers viewMembers = new ViewMembers();
            viewMembers.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PaymentPage paymentPage = new PaymentPage();
            paymentPage.Show();
            this.Hide();
        }
    }
}
