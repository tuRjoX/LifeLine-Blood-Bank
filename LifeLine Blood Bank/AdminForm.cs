using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LifeLineBloodBank
{
    public partial class AdminForm : Form
    {
        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public AdminForm()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //Methods
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(116, 86, 174);
                    previousBtn.ForeColor = Color.Honeydew;
                    previousBtn.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender, bool updateTitle = true)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = "LifeLine Blood Bank";
        }
        private void Reset()
        {
            DisableButton();
            currentButton = null;
            btnCloseChildForm.Visible = false;
            lblTitle.Text = "Blood Bank Management System";
        }
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
                Reset();
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Dashboard(), sender);
        }

        private void btnDonor_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Donor(), sender);
        }
        private void btnBloodTransfer_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.BloodTransfer(), sender);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.UpdateDonor(), sender);
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Donate(), sender);
        }

        private void btnViewDonor_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.ViewDonor(), sender);
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Patients(), sender);
        }

        private void btnViewPatient_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.ViewPatients(), sender);
        }

        private void btnBloodStock_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.BloodStock(), sender);
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide(); 
                Login loginForm = new Login();
                loginForm.FormClosed += (s, args) => this.Close(); 
                loginForm.Show(); 
            }
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void bntMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRequestList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.RequestList(), sender);
        }
    }
}
