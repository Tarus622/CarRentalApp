using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{ 
    public partial class AddEditRentalRecord : Form
    {
        private bool isEditMode;
        private readonly CarRentalEntities _db;
        public AddEditRentalRecord()
        {
            InitializeComponent();
            labelTitle.Text = "Add Rental Record";
            this.Text = "Add Rental Record";            
            isEditMode = false;
            _db = new CarRentalEntities();
        }

        public AddEditRentalRecord(CarRentalRecord recordToEdit)
        {
            InitializeComponent();
            labelTitle.Text = "Edit Rental Record";
            this.Text = "Edit Rental Record";
            isEditMode = true;
            _db = new CarRentalEntities();
            PopulateFields(recordToEdit);
        }

        public void PopulateFields(CarRentalRecord recordToEdit)
        {
            labelRecordId.Text = recordToEdit.Id.ToString();
            tbCustomerName.Text = recordToEdit.CustomerName;
            tbPrice.Text = recordToEdit.Cost.ToString();
            dtRented.Value = (DateTime)recordToEdit.DateRented;
            dtReturned.Value = (DateTime)recordToEdit.DateReturned;
            cbCarType.Text = recordToEdit.TypesOfCar.Make + " " + recordToEdit.TypesOfCar.Model;
        }
        
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public string validateDataRecord()
        {
                var errorMessage = "";
                var isValid = true;
                string customerName = tbCustomerName.Text;
                var dateOut = dtRented.Value;
                var dateIn = dtReturned.Value;
                string priceString = tbPrice.Text;
                var carType = cbCarType.Text;

                if (carType == string.Empty || string.IsNullOrWhiteSpace(carType))
                    {
                        isValid = false;
                        errorMessage += "Error: You need to select a car \n";
                    }

                if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(priceString))
                {
                    isValid = false;
                    errorMessage += "Error: You need to enter missing data \n";
                }

                if (dateIn < dateOut)
                {
                    isValid = false;
                    errorMessage += "Error: The rental date cannot be less than the return date \n";
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

        private string messageOfSuccess()
        {
            string customerName = tbCustomerName.Text;
            var dateOut = dtRented.Value;
            var dateIn = dtReturned.Value;            
            string priceString = tbPrice.Text;
            var carType = cbCarType.Text;

            double price = Convert.ToDouble(priceString);
           return $"Customer Name: {customerName} \n" +
            $"Car Type: {carType} \n" +
            $"Date Rented: {dateOut} \n" +
            $"Date of return: {dateIn} \n" +
            $"Price: {price} \n" +
            $"Thanks for doing business with us!";
        }
         
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                
                var rentalRecord = new CarRentalRecord();                

                if (isEditMode)
                {
                    var id = int.Parse(labelRecordId.Text);
                    string result = validateDataRecord();

                    if (result != "Success!")
                    {
                        MessageBox.Show(result);
                    }    
                    else
                    {
                        string customerName = tbCustomerName.Text;
                        var dateOut = dtRented.Value;
                        var dateIn = dtReturned.Value;
                        string priceString = tbPrice.Text;
                        var carType = cbCarType.Text;

                        var record = _db.CarRentalRecords
                            .FirstOrDefault(q => q.Id == id);

                        record.CustomerName = customerName;
                        record.DateRented = dateOut;
                        record.DateReturned = dateIn;
                        record.Cost = Convert.ToDecimal(priceString);
                        record.TypeOfCarId = (int)cbCarType.SelectedValue;

                        _db.SaveChanges();                        
                        MessageBox.Show(messageOfSuccess());
                        Close();
                    }
                }
                else
                {
                    var result = validateDataRecord();

                    if(result != "Success!")
                    {
                        MessageBox.Show(result);
                    }
                    else
                    {
                        string customerName = tbCustomerName.Text;
                        var dateOut = dtRented.Value;
                        var dateIn = dtReturned.Value;
                        string priceString = tbPrice.Text;
                        var carType = cbCarType.Text;

                        var newRecord = new CarRentalRecord()
                        {
                            CustomerName = customerName,
                            DateRented = dateOut,
                            DateReturned = dateIn,
                            Cost = Convert.ToDecimal(priceString),
                            TypeOfCarId = (int)cbCarType.SelectedValue
                        };

                        _db.CarRentalRecords.Add(newRecord);
                        _db.SaveChanges();
                        MessageBox.Show(messageOfSuccess());
                        Close();
                    }
                }             
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Select * from TypesOfCars
            //var cars = carRentalEntities.TypesOfCars.ToList();
            var cars = _db.TypesOfCars
                .Select(q => new { Id = q.Id, Name = q.Make + " " + q.Model })
                .ToList();

            cbCarType.DisplayMember = "Name";
            cbCarType.ValueMember = "Id";
            cbCarType.DataSource = cars;
        }
    }
}
