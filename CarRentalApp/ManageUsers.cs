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
    public partial class ManageUsers : Form
    {
        private readonly CarRentalEntities _db;
        public ManageUsers()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        public void PopulateGrid()
        {
            // Select custom model collection of cars from database
            var users = _db.Users
                .Select(q => new
                {
                    q.Username,
                    q.isActive,
                    q.UserRoles.FirstOrDefault().Role.Name,
                    q.id
                })
                .ToList();

            gvUserList.DataSource = users;
            gvUserList.Columns["isActive"].HeaderText = "Active";
            gvUserList.Columns["Name"].HeaderText = "Role Name";

            gvUserList.Columns["id"].Visible = false;
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            var formIsOpen = Utils.FormIsOpen("AddEditUser"); 
            if (!formIsOpen)
            {
                var addEditUser = new AddEditUser(this)
                {
                    MdiParent = this.MdiParent
                };
                addEditUser.Show();
            }
        }

        private void buttonResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                // Get Id of selected row
                var id = (int)gvUserList.SelectedRows[0].Cells["Id"].Value;

                // Query database for record
                var user = _db.Users.FirstOrDefault(q => q.id == id);
                var genericPassword = "password";
                var newPassword = Utils.DefaultHashedPassword();

                user.Password = newPassword;
                _db.SaveChanges();
                MessageBox.Show($"{user.Username}'s password has been reset successfully!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void buttonChangeStatus_Click(object sender, EventArgs e)
        {
            try
            {
                // Get Id of selected row
                var id = (int)gvUserList.SelectedRows[0].Cells["Id"].Value;

                // Query database for record
                var user = _db.Users.FirstOrDefault(q => q.id == id);

                user.isActive = user.isActive == true ? false : true;
                _db.SaveChanges();
                this.PopulateGrid();
                MessageBox.Show($"{user.Username}'s active status has changed!");                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }
    }
}
