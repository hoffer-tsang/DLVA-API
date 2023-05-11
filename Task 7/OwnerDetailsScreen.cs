/*==============================================================================
 *
 * Owner Details Screen Class
 *
 * Copyright © Dorset Software Services Ltd, 2023
 *
 * TSD Section: P775 Web API Task Set 1 Task 3
 *
 *============================================================================*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddtionalModelsOrBusinessClass.Task_7.OwnerScreen;
using AddtionalModelsOrBusinessClass.Task_7.CarScreen;
using EntityFrameWorkModel;

namespace Task_7
{
    /// <summary>
    /// Owner Details Screen Class
    /// </summary>
    public partial class OwnerDetailsScreen : Form
    {
        /// <summary>
        /// Occurs when a Owner has been saved.
        /// </summary>
        public event EventHandler OwnerSaved;
        private OwnerModelDetails _Owner;
        private bool _InputNewOwnerOrNot = false;
        private int _ColumnIndex = 0;
        /// <summary>
        /// Owner Details Constructor 
        /// </summary>
        public OwnerDetailsScreen()
        {
            InitializeComponent();
            _InputNewOwnerOrNot = true;
            var displayCarScreen = new OwnerScreenCarList();
            this.pageNumberComboBox.DataSource = new List<int>(1);
            this.dateOfBirthTimePicker.Enabled = true;
            this.firstNameTextBox.ReadOnly = false;
            this.lastNameTextBox.ReadOnly = false;
            this.line1TextBox.ReadOnly = false;
            this.line2TextBox.ReadOnly = false;
            this.line3TextBox.ReadOnly = false;
            this.cityTextBox.ReadOnly = false;
            this.countyTextBox.ReadOnly = false;
            this.countryTextBox.ReadOnly = false;
            this.postCodeTextBox.ReadOnly = false;
            this.editButton.Enabled = false;
            this.saveButton.Enabled = true;
            this.cancelButton.Enabled = true;
        }
        /// <summary>
        /// Override constructor when owner details not found to input new car
        /// </summary>
        /// <param name="firstName"> first name of owner </param>
        /// <param name="lastName"> last name of owner </param>
        public OwnerDetailsScreen(string firstName, string lastName)
        {
            InitializeComponent();
            _InputNewOwnerOrNot = true;
            var displayCarScreen = new OwnerScreenCarList();
            this.pageNumberComboBox.DataSource = new List<int>(1);
            this.dateOfBirthTimePicker.Enabled = true;
            this.firstNameTextBox.ReadOnly = false;
            this.lastNameTextBox.ReadOnly = false;
            this.firstNameTextBox.Text = firstName;
            this.lastNameTextBox.Text = lastName;
            this.line1TextBox.ReadOnly = false;
            this.line2TextBox.ReadOnly = false;
            this.line3TextBox.ReadOnly = false;
            this.cityTextBox.ReadOnly = false;
            this.countyTextBox.ReadOnly = false;
            this.countryTextBox.ReadOnly = false;
            this.postCodeTextBox.ReadOnly = false;
            this.editButton.Enabled = false;
            this.saveButton.Enabled = true;
            this.cancelButton.Enabled = true;
        }
        /// <summary>
        /// Over ride Owner Details Construcotr to construct the form with Owner details
        /// </summary>
        /// <param name="owner"> Owner Model with details </param>
        public OwnerDetailsScreen(OwnerModelDetails owner)
        {
            InitializeComponent();
            _Owner = owner;
            _ColumnIndex = 0;
            OwnerCarScreenGenerateAsync();
            this.firstNameTextBox.Text = owner.FirstName;
            this.lastNameTextBox.Text = owner.LastName;
            this.dateOfBirthTimePicker.Value = owner.DateOfBirth;
            this.line1TextBox.Text = owner.Line1;
            this.line2TextBox.Text = owner.Line2;
            this.line3TextBox.Text = owner.Line3;
            this.cityTextBox.Text = owner.City;
            this.countyTextBox.Text = owner.County;
            this.countryTextBox.Text = owner.Country;
            this.postCodeTextBox.Text = owner.PostCode;
        }
        /// <summary>
        /// Show Details in Owner details screen of the selected row in data grid
        /// </summary>
        /// <param name="sender"> data grid view row </param>
        /// <param name="e"> click event </param>
        private async void CarDataGridView_CellClickAsync(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var registrationNumber = carDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                var carSearchDisplayList = new CarModelDetails();
                CarModelDetails car = await carSearchDisplayList.CarDetailsToDisplayAsync(registrationNumber);
                using (var detailsWindow = new CarDetailsScreen(car))
                {
                    detailsWindow.CarSaved += this.DetailsWindow_CarSavedAsync;
                    detailsWindow.ShowDialog();
                }
            }
            else
            {
                _ColumnIndex = e.ColumnIndex;
                var generateCarList = new OwnerScreenCarList();
                this.carDataGridView.DataSource = await generateCarList.GetCarListAsync(_Owner.OwnerId, (int)this.pageNumberComboBox.SelectedValue, _ColumnIndex);
                this.pageNumberComboBox.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// Refreshes the grid when a Owner is saved on a child Owner details window.
        /// </summary>
        private async void DetailsWindow_CarSavedAsync(object sender, EventArgs e)
        {
            var displayCarScreen = new OwnerScreenCarList();
            _ColumnIndex = 0;
            var carList = await displayCarScreen.GetCarListAsync(_Owner.OwnerId, 1, 0);
            this.carDataGridView.DataSource = carList;
            this.pageNumberComboBox.SelectedIndex = 0;
        }
        /// <summary>
        /// Cancel all field input when editing
        /// </summary>
        /// <param name="sender"> cancel button </param>
        /// <param name="e"> button click </param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.firstNameTextBox.Text = null;
            this.lastNameTextBox.Text = null;
            this.dateOfBirthTimePicker.Value = DateTime.Now;
            this.line1TextBox.Text = null;
            this.line2TextBox.Text = null;
            this.line3TextBox.Text = null;
            this.cityTextBox.Text = null;
            this.countyTextBox.Text = null;
            this.countryTextBox.Text = null;
            this.postCodeTextBox.Text = null;
        }
        /// <summary>
        /// Enable editing in details page 
        /// </summary>
        /// <param name="sender"> edit button </param>
        /// <param name="e"> button click </param>
        private void EditButton_Click(object sender, EventArgs e)
        {
            this.editButton.Enabled = false;
            this.saveButton.Enabled = true;
            this.cancelButton.Enabled = true;
            this.dateOfBirthTimePicker.Enabled = true;
            this.firstNameTextBox.ReadOnly = false;
            this.lastNameTextBox.ReadOnly = false;
            this.line1TextBox.ReadOnly = false;
            this.line2TextBox.ReadOnly = false;
            this.line3TextBox.ReadOnly = false;
            this.cityTextBox.ReadOnly = false;
            this.countyTextBox.ReadOnly = false;
            this.countryTextBox.ReadOnly = false;
            this.postCodeTextBox.ReadOnly = false;
        }
        /// <summary>
        /// Save the edit or new entry of car
        /// </summary>
        /// <param name="sender"> save btuton </param>
        /// <param name="e"> button click </param>
        private async void SaveButton_ClickAsync(object sender, EventArgs e)
        {
            if (InputCheck() == true)
            {
                if (_InputNewOwnerOrNot == true)
                {
                    var dummyowner = new OwnerModelDetails { OwnerId = -1 };
                    _Owner = dummyowner;
                }
                var updateDetails = new OwnerModelDetails();
                int saveStatus = await updateDetails.SaveOwnerDetailsAsync(_InputNewOwnerOrNot,
                    DateTime.Parse(this.dateOfBirthTimePicker.Value.ToString("yyyy-MM-dd")),
                    this.firstNameTextBox.Text,
                    this.lastNameTextBox.Text,
                    this.line1TextBox.Text,
                    this.line2TextBox.Text,
                    this.line3TextBox.Text,
                    this.cityTextBox.Text,
                    this.countyTextBox.Text,
                    this.countryTextBox.Text,
                    this.postCodeTextBox.Text,
                    _Owner.OwnerId,
                    _Owner.RowVersion);
                if (saveStatus == -1)
                {
                    MessageBox.Show("Address does not match existed Address in the database!", "Error");
                }
                else if(saveStatus == -2)
                {
                    MessageBox.Show("Details has been updated by other user already!", "Error");
                }
                else
                {
                    this.OnOwnerSaved();
                    this.Close();
                }
            }
        }
        /// <summary>
        /// Raises the <see cref="OwnerSaved"/> event.
        /// </summary>
        protected virtual void OnOwnerSaved()
        {
            var handler = this.OwnerSaved;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Check the input in search field is valid or not
        /// </summary>
        /// <returns> true or false base on validity </returns>
        private bool InputCheck()
        {
            if (this.firstNameTextBox.Text == "" ||
                this.lastNameTextBox.Text == "" ||
                this.line1TextBox.Text == "" ||
                this.cityTextBox.Text == "" ||
                this.countyTextBox.Text == "" ||
                this.countryTextBox.Text == "" ||
                this.postCodeTextBox.Text == "")
            {
                MessageBox.Show("All required field has to be filled in!", "Error");
                return false;
            }
            else if (this.firstNameTextBox.Text.Length > 40 ||
               !this.firstNameTextBox.Text.All(Char.IsLetter))
            {
                MessageBox.Show("First name input is not in the correct format!", "Error");
                return false;
            }
            else if (this.lastNameTextBox.Text.Length > 40 ||
               !this.lastNameTextBox.Text.All(Char.IsLetter))
            {
                MessageBox.Show("Last name input is not in the correct format!", "Error");
            }
            else if (this.dateOfBirthTimePicker.Value > DateTime.Now)
            {
                MessageBox.Show("Registration Date has to be in the past", "Error");
                return false;
            }
            else if (this.line1TextBox.Text.Length > 100)
            {
                MessageBox.Show("line1 need to be 100 characters or below!", "Error");
            }
            else if (!string.IsNullOrWhiteSpace(this.line2TextBox.Text) &&
                this.line2TextBox.Text.Length > 100)
            {
                MessageBox.Show("line2 need to be 100 characters or below!", "Error");
            }
            else if (!string.IsNullOrWhiteSpace(this.line3TextBox.Text) &&
                this.line3TextBox.Text.Length > 100)
            {
                MessageBox.Show("line3 need to be 100 characters or below!", "Error");
            }
            else if (this.cityTextBox.Text.Length > 50)
            {
                MessageBox.Show("City need to be 50 characters or below!", "Error");
            }
            else if (this.countyTextBox.Text.Length > 50)
            {
                MessageBox.Show("County need to be 50 characters or below!", "Error");
            }
            else if (this.countryTextBox.Text.Length > 50)
            {
                MessageBox.Show("Country need to be 50 characters or below!", "Error");
            }
            else if (this.postCodeTextBox.Text.Length > 16)
            {
                MessageBox.Show("Post Code need to be 16 characters or below!", "Error");
            }
            return true;
        }
        /// <summary>
        /// get the other page selected to display in data grid view
        /// </summary>
        /// <param name="sender"> selected combo box </param>
        /// <param name="e"> clicked item in combo box </param>
        private async void PageNumberComboBox_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            var pageNumber = this.pageNumberComboBox.SelectedItem;
            if (pageNumber != null)
            {
                var displayCarScreen = new OwnerScreenCarList();
                var carList = await displayCarScreen.GetCarListAsync(_Owner.OwnerId, (int)pageNumber, _ColumnIndex);
                this.carDataGridView.DataSource = carList;
            }
        }
        private async void OwnerCarScreenGenerateAsync()
        {
            var displayCarScreen = new OwnerScreenCarList();
            var carList = await displayCarScreen.GetCarListAsync(_Owner.OwnerId, 1, 0);
            this.carDataGridView.DataSource = carList;
            this.pageNumberComboBox.DataSource = await displayCarScreen.TotalCarPageNumberAsync(_Owner.OwnerId);
            this.pageNumberComboBox.SelectedIndex = 0;
        }
    }
}
