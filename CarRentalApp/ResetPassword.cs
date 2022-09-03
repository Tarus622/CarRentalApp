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
    public partial class ResetPassword : Form
    {
        private readonly CarRentalEntities _db;
        public User _user;
        public ResetPassword(User user)
        {
            InitializeComponent();
            _db = new CarRentalEntities();
            _user = user;
        }

        private void buttonResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbEnterPassword.Text == tbConfirmPassword.Text)
                {
                    var password = tbEnterPassword.Text;
                    var hasedPassword = Utils.HashPassword(password);
                    var user = _db.Users.FirstOrDefault(q => q.Username == _user.Username);

                    user.Password = hasedPassword;                  
                    _db.SaveChanges();                    
                    Close();
                }
                else
                {
                    MessageBox.Show("The passwords don't match.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error has occurred.");
            }
        }
    }
}
