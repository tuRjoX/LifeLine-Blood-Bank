using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeLineBloodBank
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        int startpos = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpos += 4;
            MyProgressBar.Value = startpos;
            if (MyProgressBar.Value == 100)
            {
                MyProgressBar.Value = 0;
                timer1.Stop();

                Login log = new Login();
                log.Show();
                this.Hide();
            }
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
