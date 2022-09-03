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
    public partial class ManageVehicleListing : Form
    {        
        private readonly CarRentalEntities _db;
        public ManageVehicleListing()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        // New Function to PopulateGrid. Can be called anytime we need a grid refresh.
        public void PopulateGrid()
        {
            // Select custom model collection of cars from database
            var cars = _db.TypesOfCars
                .Select(q => new
                {
                    Make = q.Make,
                    Model = q.Model,
                    VIN = q.VIN,
                    LicensePlateNumber = q.LicensePlateNumber,
                    Year = q.Year,
                    q.Id
                })
                .ToList();

            gvVehicleList.DataSource = cars;
            gvVehicleList.Columns[3].HeaderText = "License Plate Number";
            gvVehicleList.Columns["Id"].Visible = false;
        }

        private void ManageVehicleListing_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void buttonAddCar_Click(object sender, EventArgs e)
        {
           var addEditVehicle = new AddEditVehicle(this);
            addEditVehicle.MdiParent = this.MdiParent;
            addEditVehicle.Show();
        }

        private void buttonEditCar_Click(object sender, EventArgs e)
        {
            // Get Id of selected row
            var id = (int)gvVehicleList.SelectedRows[0].Cells["Id"].Value;

            // Query database for record
            var car = _db.TypesOfCars.FirstOrDefault(q => q.Id == id);
                        
            // Launch AddEditVehicle window with data
            var addEditVehicle = new AddEditVehicle(car, this);
            addEditVehicle.MdiParent = this.MdiParent;
            addEditVehicle.Show();

        }

        private void buttonDeleteCar_Click(object sender, EventArgs e)
        {
            // Get Id of selected row
            var id = (int)gvVehicleList.SelectedRows[0].Cells["Id"].Value;

            // Query database for record
            var car = _db.TypesOfCars.FirstOrDefault(q => q.Id == id);

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this record?",
                "Delete", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);

            // Delete vehicle from table
            if(dr == DialogResult.Yes)
            {
                _db.TypesOfCars.Remove(car);
                _db.SaveChanges();
                PopulateGrid();
                MessageBox.Show("The vehicle has been deleted successfully");
            }

            //gvVehicleList.Refresh();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
            
        }
    }
}
