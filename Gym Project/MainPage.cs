using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Project
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //Addmember Page Button
        private void button4_Click(object sender, EventArgs e)
        {
            AddMember addMember = new AddMember();
            addMember.Show();
            this.Hide();
        }

        //Update Delete Page Button
        private void button3_Click(object sender, EventArgs e)
        {
            UpdateDeletePage updateDelete = new UpdateDeletePage();
            updateDelete.Show();
            this.Hide();
        }

        //View Member Button
        private void button2_Click(object sender, EventArgs e)
        {
            ViewMembers viewMembers = new ViewMembers();
            viewMembers.Show();
            this.Hide();
        }

        //Payment Page Button
        private void button1_Click(object sender, EventArgs e)
        {
            PaymentPage paymentPage = new PaymentPage();
            paymentPage.Show();
            this.Hide();
        }
    }
}
