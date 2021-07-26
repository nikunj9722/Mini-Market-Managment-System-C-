using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_market
{
    public partial class SpalshForm : Form
    {
        public SpalshForm()
        {
            InitializeComponent();
        }

        private void SpalshForm_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }

        int Startpoint = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Startpoint += 2;
            myProgressBar.Value = Startpoint;
            if(myProgressBar.Value==100)
            {
                myProgressBar.Value = 0;
                timer1.Stop();
                LoginForm loginForm = new LoginForm();
                this.Hide();
                loginForm.Show();

            }

        }
    }
}
