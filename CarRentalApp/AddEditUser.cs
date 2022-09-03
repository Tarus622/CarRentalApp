using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class AddEditUser : Form
    {
        private bool isEditMode;
        private ManageUsers _manageUsers;
        private readonly CarRentalEntities _db;
        public AddEditUser(ManageUsers manageUsers = null)
        {
            InitializeComponent();            
            labelTitle.Text = "Add New User";
            this.Text = "Add New User";
            isEditMode = false;
            _manageUsers = manageUsers;
            _db = new CarRentalEntities();
        }

        public AddEditUser(User userToEdit, ManageUsers manageUsers = null)
        {
            InitializeComponent();
            labelTitle.Text = "Edit User";
            this.Text = "Edit User";
                        
            _manageUsers = manageUsers;
            
            if (userToEdit == null)
            {
                MessageBox.Show("Please ensure that you selected a valid user to edit");
                Close();
            }
            else
            {
                isEditMode = true;
                _db = new CarRentalEntities();
                PopulateFields(userToEdit);
            }
        }

        private void PopulateFields(User user)
        {
            labelId.Text = user.id.ToString();
            tbUsername.Text = user.Username;            
            
        }

        private void AddEditUser_Load(object sender, EventArgs e)
        {
            var roles = _db.Roles.ToList();
            cbRoles.DataSource = roles;
            cbRoles.ValueMember = "id";
            cbRoles.DisplayMember = "Name";
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {            
            try
            {
                var username = tbUsername.Text;
                var roleId = (int)cbRoles.SelectedValue;
                var password = Utils.DefaultHashedPassword();
                var user = new User
                {
                    Username = username,
                    Password = password,
                    isActive = true

                };
                _db.Users.Add(user);
                
                var userId = user.id;

                var userRole = new UserRole
                {
                    RoleId = roleId,
                    UserId = userId
                };
                _db.UserRoles.Add(userRole);

                _db.SaveChanges();
                _manageUsers.PopulateGrid();

                MessageBox.Show("New user added successfully!");
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("An error has occured.");
            }
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
