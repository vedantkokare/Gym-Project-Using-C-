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
    public partial class PaymentPage : Form
    {
        public PaymentPage()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vedant\OneDrive\Documents\GymDataBase.mdf;Integrated Security=True;Connect Timeout=30");
        private void FillName()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select MName from Member",Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("MName", typeof(string));
            dt.Load(rdr);
            NameCb.ValueMember = "MName";
            NameCb.DataSource= dt;
            Con.Close();
        }
        private void filterByName()
        {
            Con.Open();
            string query = "select * from PaymentTbl where PMember='"+SearchName.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            PaymentSDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from PaymentTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            PaymentSDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            populate();
            SearchName.Text = "";
        }

        //Addmember Page Button
        private void button4_Click(object sender, EventArgs e)
        {
            AddMember addMember = new AddMember();
            addMember.Show();
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

        private void button5_Click(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //NameCb.Text = "";
            AmountTb.Text = "";
        }

        private void PaymentPage_Load(object sender, EventArgs e)
        {
            FillName();
            populate();
        }
        int key = 1;
        private void button10_Click(object sender, EventArgs e)
        {
            if (NameCb.Text == "" || AmountTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                string payperiode = Periode.Value.Month.ToString() + Periode.Value.Year.ToString();
                Con.Open();
                SqlDataAdapter sda  = new SqlDataAdapter("select count(*) from PaymentTbl where PMember='"+NameCb.SelectedValue.ToString()+"' and PMonth='"+payperiode+"'",Con);
                DataTable dt= new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString()=="1")
                {
                    MessageBox.Show("Already Paid for this Month");
                }
                else
                {
                    string query = "insert into PaymentTbl values('"+payperiode+"','"+NameCb.SelectedValue.ToString()+"','"+AmountTb.Text+"')";
                    SqlCommand cmd = new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Amount Paid Successfully");
                }
                Con.Close();
                populate();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            filterByName();
        }

        private void NameCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
