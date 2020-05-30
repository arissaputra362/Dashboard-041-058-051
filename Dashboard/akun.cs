using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard
{
    /* Mohammad Aris Saputra (18051204041)
       M. Hafizh Ferdiansyah (18051204058)
       Gregorius Ferdyan S.  (18051204051)
       TI2018 B*/
    public partial class akun : Form
    {
        public akun()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            data f = new data();
            this.Hide();
            f.Show();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            coffe_shop f = new coffe_shop();
            this.Hide();
            f.Show();
        }
    }
}
