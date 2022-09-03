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
    public partial class AddEditVehicle : Form
    {
        private bool isEditMode;
        private ManageVehicleListing _manageVehicleListing;
        private readonly CarRentalEntities _db;
        public AddEditVehicle(ManageVehicleListing manageVehicleListing = null)
        {
            InitializeComponent();
            labelTitle.Text = "Add New Vehicle";
            isEditMode = false;
            _manageVehicleListing = manageVehicleListing;
            _db = new CarRentalEntities();            
        }

        public AddEditVehicle(TypesOfCar carToEdit, ManageVehicleListing manageVehicleListing = null)
        {
            InitializeComponent();
            labelTitle.Text = "Edit Vehicle";
            this.Text = "Edit Vehicle";
            _manageVehicleListing = manageVehicleListing;

            if(carToEdit == null)
            {
                MessageBox.Show("Please ensure that you selected a valid record to edit");
                Close();
            }
            else
            {
                isEditMode = true;
                _db = new CarRentalEntities();
                PopulateFields(carToEdit);
            }
        }

        private void PopulateFields(TypesOfCar car)
        {
            labelId.Text = car.Id.ToString();
            tbMake.Text = car.Make;
            tbModel.Text = car.Model;
            tbVIN.Text = car.VIN;
            tbLicenseNum.Text = car.LicensePlateNumber;
            tbYear.Text = Convert.ToString(car.Year);
        }

        public string ValidateDataCar()
        {
            bool isValid = true;
            string errorMessage = "";

            var licenseNum = tbLicenseNum.Text;
            var make = tbMake.Text;
            var model = tbModel.Text;
            var year = tbYear.Text;
            var VIN = tbVIN.Text;

            if (model == null || model == string.Empty)
            {
                isValid = false;
                errorMessage += "You need to type the model\n";
            }

            if (make == null || make == string.Empty)
            {
                isValid = false;
                errorMessage += "You need to type the make\n";
            }

            if (VIN == null || VIN == string.Empty)
            {
                isValid = false;
                errorMessage += "You need to type the VIN\n";
            }

            if (licenseNum == null || licenseNum == string.Empty)
            {
                isValid = false;
                errorMessage += "You need to type the License Plate Number\n";
            }

            if (year == null || year.ToString() == string.Empty)
            {
                isValid = false;
                errorMessage += "You need to type the year\n";
            }

            if (isValid)
            {                
                return "Success!";
            }
            else
            {
                return errorMessage;
            }
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                if (isEditMode)
                {
                    // Edit code here
                    var id = int.Parse(labelId.Text);                    
                    var licenseNum = tbLicenseNum.Text;
                    var make = tbMake.Text;
                    var model = tbModel.Text;
                    var year = tbYear.Text;
                    var VIN = tbVIN.Text;

                    string result = ValidateDataCar();

                    if (result != "Success!")
                    {
                        MessageBox.Show(result);                        
                    }
                    else
                    {
                        var car = _db.TypesOfCars.FirstOrDefault(q => q.Id == id);
                        car.Model = tbModel.Text;
                        car.Make = tbMake.Text;
                        car.VIN = tbVIN.Text;
                        car.LicensePlateNumber = tbLicenseNum.Text;
                        car.Year = int.Parse(tbYear.Text);

                        _db.SaveChanges();
                        _manageVehicleListing.PopulateGrid();
                        MessageBox.Show("The list has been updated successfully!");
                        this.Close();

                    }
                   
                    
                }
                else
                {
                    // Add code here                    
                    var licenseNum = tbLicenseNum.Text;
                    var make = tbMake.Text;
                    var model = tbModel.Text;
                    var year = tbYear.Text;
                    var VIN = tbVIN.Text;

                    string result = ValidateDataCar();
                    
                    if (result != "Success!")
                    {
                        MessageBox.Show(result);
                    }
                    else
                    {
                        var newCar = new TypesOfCar()
                        {

                            LicensePlateNumber = tbLicenseNum.Text,
                            Make = tbMake.Text,
                            Model = tbModel.Text,
                            VIN = tbVIN.Text,
                            Year = int.Parse(tbYear.Text)
                        };

                        _db.TypesOfCars.Add(newCar);

                        _db.SaveChanges();
                        _manageVehicleListing.PopulateGrid();
                        MessageBox.Show("The list has been added successfully!");
                        this.Close();

                    }
                    
                }                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // this.Close(); is equivalent to:
            Close();
        }

        private void AddEditVehicle_Load(object sender, EventArgs e)
        {

        }
    }
}
