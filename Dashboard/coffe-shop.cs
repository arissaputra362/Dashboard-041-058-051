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
    public partial class coffe_shop : Form
    {
        public coffe_shop()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tambah_form f = new tambah_form();
            this.Hide();
            f.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            akun f = new akun();
            this.Hide();
            f.Show();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            data f = new data();
            this.Hide();
            f.Show();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            if (!bunifuCards3.Visible)
            {
                bunifuTransition1.ShowSync(bunifuCards3);
                bunifuTransition1.ShowSync(bunifuCards1);
            }
            else
            {
                bunifuTransition1.HideSync(bunifuCards3);
                bunifuTransition1.HideSync(bunifuCards1);
            }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
