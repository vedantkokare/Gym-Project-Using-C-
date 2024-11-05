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
    public partial class UpdateDeletePage : Form
    {
        public UpdateDeletePage()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vedant\OneDrive\Documents\GymDataBase.mdf;Integrated Security=True;Connect Timeout=30");

        // Display Table On Screen Start
        private void populate()
        {
            Con.Open();
            string query = "select * from Member";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            MemberSDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void UpdateDeletePage_Load(object sender, EventArgs e)
        {
            populate();
        }
        int key = 0;
        private void MemberSDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(MemberSDGV.SelectedRows[0].Cells[0].Value.ToString());
            NameTb.Text = MemberSDGV.SelectedRows[0].Cells[1].Value.ToString();
            PhoneTb.Text = MemberSDGV.SelectedRows[0].Cells[2].Value.ToString();
            GenderCb.Text = MemberSDGV.SelectedRows[0].Cells[3].Value.ToString();
            AgeTb.Text = MemberSDGV.SelectedRows[0].Cells[4].Value.ToString();
            AmountTb.Text = MemberSDGV.SelectedRows[0].Cells[5].Value.ToString();
            TimingCb.Text = MemberSDGV.SelectedRows[0].Cells[6].Value.ToString();
        }
        // Display Table On Screen End //

        // Delete Button Code Start
        private void button7_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Member To Delete");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from Member where MId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Deleted Successfully");
                    NameTb.Text = "";
                    PhoneTb.Text = "";
                    GenderCb.Text = "";
                    AgeTb.Text = "";
                    AmountTb.Text = "";
                    TimingCb.Text = "";
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        // Delete Button Code End.//

        // Reset Button Code Start
        private void button8_Click(object sender, EventArgs e)
        {
            NameTb.Text = "";
            PhoneTb.Text = "";
            GenderCb.Text = "";
            AgeTb.Text = "";
            AmountTb.Text = "";
            TimingCb.Text = "";
        }
        // Reset Button Code End //

        //Update Button Code Start
        private void button6_Click(object sender, EventArgs e)
        {
            if (key == 0 || NameTb.Text == "" || PhoneTb.Text == "" || GenderCb.Text=="" || AgeTb.Text=="" || AmountTb.Text=="" || TimingCb.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update Member set MName='"+NameTb.Text+"',MPhone='"+PhoneTb.Text+ "',MGender='"+GenderCb.Text+"',MAge=" + AgeTb.Text+",MAmount="+AmountTb.Text+",MTiming='"+TimingCb.Text+"'where MId="+key+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Details Updated Successfully");
                    NameTb.Text = "";
                    PhoneTb.Text = "";
                    GenderCb.Text = "";
                    AgeTb.Text = "";
                    AmountTb.Text = "";
                    TimingCb.Text = "";
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        //Update Button Code End //

        //Back Button
        private void button5_Click(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.Show();
            this.Hide();
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
    }
}
