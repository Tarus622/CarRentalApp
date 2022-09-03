using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class MainWindow : Form
    {
        private Login _login;
        public string _RoleName;
        public User _user;
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(Login login, User user)
        {
            InitializeComponent();
            _login = login;
            _user = user;
            _RoleName = user.UserRoles.FirstOrDefault().Role.ShortName;
        }
        private void addRentalRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isOpen = Utils.FormIsOpen("AddEditRentalRecord");
            
            if (!isOpen)
            {
                var addRentalRecord = new AddEditRentalRecord();
                addRentalRecord.MdiParent = this;
                addRentalRecord.Show();
            }
        } 

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (_user.Password == Utils.DefaultHashedPassword())
            {
                var resetPassword = new ResetPassword(_user);
                resetPassword.ShowDialog();
            }

            var username = _user.Username;
            if (_RoleName != "admin")
            {
                manageUsersToolStripMenuItem.Visible = false;
            }
        }

        private void manageVehicleLisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isOpen = Utils.FormIsOpen("ManageVehicleListing");

            if (!isOpen)
            {
                var vehicleListing = new ManageVehicleListing();
                vehicleListing.MdiParent = this;
                vehicleListing.Show();
            }

        }

        private void viewArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isOpen = Utils.FormIsOpen("ManageRentalRecords");

            if (!isOpen)
            {
                var manageRentalRecords = new ManageRentalRecords();
                manageRentalRecords.MdiParent = this;
                manageRentalRecords.Show();
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Close();
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isOpen = Utils.FormIsOpen("ManageUsers");

            if (!isOpen)
            {
                var manageUsers = new ManageUsers();
                manageUsers.MdiParent = this;
                manageUsers.Show();
            }
        }
    }
}
