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
    public partial class ManageRentalRecords : Form

    {
        private readonly CarRentalEntities _db;
        public ManageRentalRecords()
        {
            InitializeComponent(); 
            _db = new CarRentalEntities();
        }

        private void buttonAddRecord_Click(object sender, EventArgs e)
        {
            var addRentalRecord = new AddEditRentalRecord()
            {
                MdiParent = this.MdiParent
            };
            addRentalRecord.Show();
        }

        private void buttonEditRecord_Click(object sender, EventArgs e)
        {
            // Get Id of selected row
            var id = (int)gvRecordList.SelectedRows[0].Cells["Id"].Value;

            // Query database for record
            var record = _db.CarRentalRecords.FirstOrDefault(q => q.Id == id);

            // Launch AddEditVehicle window with data
            var editRecord = new AddEditRentalRecord(record)
            {
                MdiParent = this.MdiParent
            };
            editRecord.Show();
        }

        private void buttonDeleteRecord_Click(object sender, EventArgs e)
        {
            // Get Id of selected row
            var id = (int)gvRecordList.SelectedRows[0].Cells["Id"].Value;

            // Query database for record
            var record = _db.CarRentalRecords.FirstOrDefault(q => q.Id == id);

            // Delete record from table
            _db.CarRentalRecords.Remove(record);
            _db.SaveChanges();
            MessageBox.Show("The record has been deleted successfully");

            gvRecordList.Refresh();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        public void PopulateGrid()
        {
            // Select custom model collection of cars from database
            var records = _db.CarRentalRecords
                .Select(q => new
                {
                    Customer = q.CustomerName,
                    DateOut = q.DateRented,
                    DateIn = q.DateReturned,
                    q.Cost,
                    q.Id,
                    Car = q.TypesOfCar.Make + " " + q.TypesOfCar.Model

                })
                .ToList();

            gvRecordList.DataSource = records;
            gvRecordList.Columns["DateOut"].HeaderText = "Date Out";
            gvRecordList.Columns["DateIn"].HeaderText = "Date In";
            gvRecordList.Columns["Id"].Visible = false;
        }

        private void ManageRentalRecords_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }
    }
}
