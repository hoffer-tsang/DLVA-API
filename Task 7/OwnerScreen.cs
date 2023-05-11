/*==============================================================================
 *
 * Owner Screen Class
 *
 * Copyright © Dorset Software Services Ltd, 2022
 *
 * TSD Section: P770 DataBase Driven Application Task Set 3 Task 7
 *
 *============================================================================*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityFrameWorkModel;
using AddtionalModelsOrBusinessClass.Task_7.OwnerScreen;

namespace Task_7
{

    /// <summary>
    /// Owner Screen Class
    /// </summary>
    public partial class OwnerScreen : Form
    {
        private string _OwnerFirstName;
        private string _OwnerLastName;
        private bool _DateOfBirthEdit;
        private DateTime _DateOfBirth = DateTime.Now;
        private int _ColumnIndex = 0;
        /// <summary>
        /// Constructor of Owner Screen that initalize the component and refresh 
        /// the datagrid
        /// </summary>
        public OwnerScreen()
        {
            InitializeComponent();
            _ColumnIndex = 0;
            OwnerScreenSearchAsync();
            RefreshGridAsync();
        }
        /// <summary>
        /// The New Owner Button to generate a new Owner details screen
        /// </summary>
        /// <param name="sender"> new Owner button </param>
        /// <param name="e"> click event </param>

        private void NewOwnerButton_Click(object sender, EventArgs e)
        {
            using (var detailsWindow = new OwnerDetailsScreen())
            {
                detailsWindow.OwnerSaved += this.DetailsWindow_OwnerSaved;
                detailsWindow.ShowDialog();
            }
        }
        /// <summary>
        /// Show Details in Owner details screen of the selected row in data grid
        /// </summary>
        /// <param name="sender"> data grid view row </param>
        /// <param name="e"> click event </param>
        private async void OwnerDataGridView_CellClickAsync(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var ownerSearch = ownerDataGridView.Rows[e.RowIndex].DataBoundItem as
                    AddtionalModelsOrBusinessClass.Task_7.OwnerScreen.OwnerSearchDisplayList;
                var ownerSearchDisplayList = new OwnerModelDetails();
                OwnerModelDetails owner = await ownerSearchDisplayList.OwnerDetailsToDisplayAsync(ownerSearch);
                if (owner == null)
                {
                    MessageBox.Show("Owner details are not found or owner details have been updated!", "Error");
                }
                else
                {
                    using(var detailsWindow = new OwnerDetailsScreen(owner))
                    {
                        detailsWindow.OwnerSaved += this.DetailsWindow_OwnerSaved;
                        detailsWindow.ShowDialog();
                    }
                }
            }
            else
            {
                _ColumnIndex = e.ColumnIndex;
                var ownerSearchDisplayList = new OwnerSearchDisplayList();
                var ownerDisplayList = await ownerSearchDisplayList.SearchOwnerListAsync(
                    _OwnerFirstName, _OwnerLastName, _DateOfBirthEdit,
                    _DateOfBirth, (int)this.pageNumberComboBox.SelectedValue, _ColumnIndex);
                this.ownerDataGridView.DataSource = ownerDisplayList;
                this.pageNumberComboBox.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// Search the Owner with details in sesarch list and populate in data grid view
        /// </summary>
        /// <param name="sender"> search button </param>
        /// <param name="e"> click event </param>
        private async void OwnerSearchButton_ClickAsync(object sender, EventArgs e)
        {
            if (InputCheck() == false)
            {
                return;
            }
            _OwnerFirstName = this.firstNameTextBox.Text;
            _OwnerLastName = this.lastNameTextBox.Text;
            _DateOfBirth = DateTime.Parse(this.dateOfBirthTimePicker.Value.ToString("yyyy-MM-dd"));
            _DateOfBirthEdit = this.dateOfBirthCheckBox.Checked;
            var ownerSearchDisplayList = new OwnerSearchDisplayList();
            var ownerDisplayList = await ownerSearchDisplayList.SearchOwnerListAsync(
            _OwnerFirstName, _OwnerLastName, _DateOfBirthEdit,
            _DateOfBirth, 1, 0);
            _ColumnIndex = 0;
            this.ownerDataGridView.DataSource = ownerDisplayList;
            List<int> pageNumberList = await ownerSearchDisplayList.TotalOwnerPageNumberAsync(
                _OwnerFirstName, _OwnerLastName, _DateOfBirthEdit, _DateOfBirth);
            this.pageNumberComboBox.SelectedIndexChanged -= PageNumberComboBox_SelectedIndexChangedAsync;
            this.pageNumberComboBox.DataSource = pageNumberList;
            this.pageNumberComboBox.SelectedIndex = 0;
            this.pageNumberComboBox.SelectedIndexChanged += PageNumberComboBox_SelectedIndexChangedAsync;
        }
        /// <summary>
        /// Populate all Owner details in grid view 
        /// </summary>
        private async void RefreshGridAsync()
        {
            var searchDisplayList = new OwnerSearchDisplayList();
            var owner = await searchDisplayList.SearchOwnerListAsync(
                null, null, false, _DateOfBirth, 1, 0);
            this.ownerDataGridView.DataSource = owner;
            List<int> pageNumberList = await searchDisplayList.TotalOwnerPageNumberAsync(
               null, null, false, _DateOfBirth);
            _ColumnIndex = 0;
            _OwnerFirstName = null;
            _OwnerLastName = null;
            _DateOfBirth = DateTime.Now;
            _DateOfBirthEdit = false;
            this.pageNumberComboBox.SelectedIndexChanged -= PageNumberComboBox_SelectedIndexChangedAsync;
            this.pageNumberComboBox.DataSource = pageNumberList;
            this.pageNumberComboBox.SelectedIndex = 0;
            this.pageNumberComboBox.SelectedIndexChanged += PageNumberComboBox_SelectedIndexChangedAsync;
        }
        /// <summary>
        /// Check the input in search field is valid or not
        /// </summary>
        /// <returns> true or false base on validity </returns>
        private bool InputCheck()
        {

            if (this.firstNameTextBox.Text.Length > 40 ||
               !this.firstNameTextBox.Text.All(Char.IsLetter))
            {
                MessageBox.Show("First name input is not in the correct format!", "Error");
                return false;
            }
            else if (this.lastNameTextBox.Text.Length > 40 ||
               !this.lastNameTextBox.Text.All(Char.IsLetter))
            {
                MessageBox.Show("Last name input is not in the correct format!", "Error");
                return false;
            }
            else if (this.dateOfBirthTimePicker.Value > DateTime.Now && dateOfBirthCheckBox.Checked)
            {
                MessageBox.Show("Date of birth has to be in the past!", "Error");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Refreshes the grid when a Owner is saved on a child Owner details window.
        /// </summary>
        private void DetailsWindow_OwnerSaved(object sender, EventArgs e)
        {
            this.RefreshGridAsync();
        }
        /// <summary>
        /// Enabled or disabled Date Of Birth entry 
        /// </summary>
        /// <param name="sender"> date of birth check box </param>
        /// <param name="e"> checked or unchecked </param>
        private void DateOfBirthCheckBox_Click(object sender, EventArgs e)
        {
            if (this.dateOfBirthCheckBox.Checked)
            {
                this.dateOfBirthTimePicker.Enabled = true;
            }
            else
            {
                this.dateOfBirthTimePicker.Enabled = false;
            }
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
                var ownerSearchDisplayList = new OwnerSearchDisplayList();
                var ownerDisplayList = await ownerSearchDisplayList.SearchOwnerListAsync(
                    _OwnerFirstName, _OwnerLastName, _DateOfBirthEdit,
                    _DateOfBirth, (int)pageNumberComboBox.SelectedValue, _ColumnIndex);
                this.ownerDataGridView.DataSource = ownerDisplayList;
            }
        }
        /// <summary>
        /// Button navigate back to main menu
        /// </summary>
        /// <param name="sender"> back button </param>
        /// <param name="e"> button click </param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
            var mainScreen = Application.OpenForms["MainMenu"];
            mainScreen.Show();
        }
        private async void OwnerScreenSearchAsync()
        {
            var displayList = new OwnerSearchDisplayList();
            List<int> pageNumberList = await displayList.TotalOwnerPageNumberAsync(null, null,
                false, _DateOfBirth);
            this.pageNumberComboBox.SelectedIndexChanged -= PageNumberComboBox_SelectedIndexChangedAsync;
            this.pageNumberComboBox.DataSource = pageNumberList;
            this.pageNumberComboBox.SelectedIndex = 0;
            this.pageNumberComboBox.SelectedIndexChanged += PageNumberComboBox_SelectedIndexChangedAsync;
        }
    }
}
