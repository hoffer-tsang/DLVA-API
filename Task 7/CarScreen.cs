/*==============================================================================
 *
 * Car Screen Class
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityFrameWorkModel;
using AddtionalModelsOrBusinessClass.Task_7.CarScreen;

namespace Task_7
{
    /// <summary>
    /// Car Screen Class
    /// </summary>
    public partial class CarScreen : Form
    {
        private string _RegistrationNumberSearch;
        private object _MakeSearch;
        private object _ModelSearch;
        private string _FirstNameSearch;
        private string _LastNameSearch;
        private bool _IsModelChanged = false;
        private int _ColumnIndex = 0;
        /// <summary>
        /// Constructor of Car Screen that initalize the component and refresh 
        /// the datagrid
        /// </summary>
        public CarScreen()
        {
            InitializeComponent();
            ComboBoxConstructorAsync();
            RefreshGridAsync();
        }
        /// <summary>
        /// The New Car Button to generate a new car details screen
        /// </summary>
        /// <param name="sender"> new car button </param>
        /// <param name="e"> click event </param>

        private void NewCarButton_Click(object sender, EventArgs e)
        {
            using (var detailsWindow = new CarDetailsScreen())
            {
                detailsWindow.CarSaved += this.DetailsWindow_CarSaved;
                detailsWindow.ShowDialog();
            }
        }
        /// <summary>
        /// Show Details in car details screen of the selected row in data grid
        /// </summary>
        /// <param name="sender"> data grid view row </param>
        /// <param name="e"> click event </param>
        private async void CarDataGridView_CellClickAsync(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var carSearch = carDataGridView.Rows[e.RowIndex].DataBoundItem as
                    AddtionalModelsOrBusinessClass.Task_7.CarScreen.CarSearchDisplayList;
                var carSearchDisplayList = new CarModelDetails();
                CarModelDetails car = await carSearchDisplayList.CarDetailsToDisplayAsync(carSearch.RegistrationNumber);
                using (var detailsWindow = new CarDetailsScreen(car))
                {
                    detailsWindow.CarSaved += this.DetailsWindow_CarSaved;
                    detailsWindow.ShowDialog();
                }
            }
            else
            {
                _ColumnIndex = e.ColumnIndex; 
                var carSearchDisplayList = new CarSearchDisplayList();
                var carDisplayList = await carSearchDisplayList.SearchCarListAsync(
                    _RegistrationNumberSearch, _ModelSearch, _MakeSearch,
                    _FirstNameSearch, _LastNameSearch, (int)this.pageNumberComboBox.SelectedItem, _ColumnIndex);
                this.carDataGridView.DataSource = carDisplayList;
            }
        }
        /// <summary>
        /// Search the car with details in sesarch list and populate in data grid view
        /// </summary>
        /// <param name="sender"> search button </param>
        /// <param name="e"> click event </param>
        private async void CarSearchButton_ClickAsync(object sender, EventArgs e)
        {
            if (InputCheck() == false)
            {
                return;
            }
            _RegistrationNumberSearch = this.registrationNumberTextBox.Text;
            _ModelSearch = this.modelComboBox.SelectedItem;
            _MakeSearch = this.makeComboBox.SelectedItem;
            _FirstNameSearch = this.firstNameTextBox.Text;
            _LastNameSearch = this.lastNameTextBox.Text;
            var carSearchDisplayList = new CarSearchDisplayList();
            var carDisplayList = await carSearchDisplayList.SearchCarListAsync(
                _RegistrationNumberSearch, _ModelSearch, _MakeSearch,
                _FirstNameSearch, _LastNameSearch, 1, 0);
            this.carDataGridView.DataSource = carDisplayList;
            _ColumnIndex = 0;
            var generate = new GenerateComboBoxOption();
            this.modelComboBox.DataSource = await generate.AvaliableModelAsync();
            this.modelComboBox.SelectedItem = null;
            this.makeComboBox.SelectedItem = null;
            _IsModelChanged = false;
            List<int> pageNumberList = await carSearchDisplayList.TotalCarPageNumberAsync(
                    _RegistrationNumberSearch, _ModelSearch, _MakeSearch,
                    _FirstNameSearch, _LastNameSearch);
            this.pageNumberComboBox.SelectedIndexChanged -= new System.EventHandler(this.PageNumberComboBox_SelectedIndexChangedAsync);
            this.pageNumberComboBox.DataSource = pageNumberList;
            this.pageNumberComboBox.SelectedIndex = 0;
            this.pageNumberComboBox.SelectedIndexChanged += new System.EventHandler(this.PageNumberComboBox_SelectedIndexChangedAsync);
        }
        /// <summary>
        /// Populate all car details in grid view 
        /// </summary>
        private async void RefreshGridAsync()
        {
            var searchDisplayList = new CarSearchDisplayList();
            var car = await searchDisplayList.SearchCarListAsync(
                null, null, null, null, null, 1, 0);
            this.carDataGridView.DataSource = car;
            _ColumnIndex = 0;
            List<int> pageNumberList = await searchDisplayList.TotalCarPageNumberAsync(
                    null, null, null, null, null);
            this.pageNumberComboBox.SelectedIndexChanged -= new System.EventHandler(this.PageNumberComboBox_SelectedIndexChangedAsync);
            this.pageNumberComboBox.DataSource = pageNumberList;
            this.pageNumberComboBox.SelectedIndex = 0;
            this.pageNumberComboBox.SelectedIndexChanged += new System.EventHandler(this.PageNumberComboBox_SelectedIndexChangedAsync);
            _RegistrationNumberSearch = null;
            _ModelSearch = null;
            _MakeSearch = null;
            _FirstNameSearch = null;
            _LastNameSearch = null;
        }
        /// <summary>
        /// Check the input in search field is valid or not
        /// </summary>
        /// <returns> true or false base on validity </returns>
        private bool InputCheck()
        {
            if (this.registrationNumberTextBox.Text.Length > 7 ||
               !this.registrationNumberTextBox.Text.All(Char.IsLetterOrDigit))
            {
                MessageBox.Show("Registration number input is not in the correct format!", "Error");
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
                return false;
            }
            return true;
        }
        /// <summary>
        /// Refreshes the grid when a car is saved on a child car details window.
        /// </summary>
        private void DetailsWindow_CarSaved(object sender, EventArgs e)
        {
            this.RefreshGridAsync();
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
                var carSearchDisplayList = new CarSearchDisplayList();
                var carDisplayList = await carSearchDisplayList.SearchCarListAsync(
                    _RegistrationNumberSearch, _ModelSearch, _MakeSearch,
                    _FirstNameSearch, _LastNameSearch,
                    (int)pageNumberComboBox.SelectedValue, _ColumnIndex);
                this.carDataGridView.DataSource = carDisplayList;
            }
        }
        /// <summary>
        /// update avaliable model drop down for specific make 
        /// </summary>
        /// <param name="sender"> make drop box </param>
        /// <param name="e"> click item </param>
        private async void MakeComboBox_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            this.modelComboBox.SelectedIndexChanged -= new System.EventHandler(this.ModelComboBox_SelectedIndexChangedAsync);

            var makeSearch = this.makeComboBox.SelectedItem;
            var generate = new GenerateComboBoxOption();
            if (makeSearch != null)
            {
                _IsModelChanged = true;
                this.modelComboBox.DataSource = await generate.ModelValueUpdateAsync((string)makeSearch);
                this.modelComboBox.SelectedItem = null;
            }
            else
            {
                this.modelComboBox.DataSource = await generate.AvaliableModelAsync();
                this.modelComboBox.SelectedItem = null;
            }
            this.modelComboBox.SelectedIndexChanged += new System.EventHandler(this.ModelComboBox_SelectedIndexChangedAsync);
        }
        /// <summary>
        /// update avalibale make drop down for specific model
        /// </summary>
        /// <param name="sender"> model drop box</param>
        /// <param name="e"> click item </param>
        private async void ModelComboBox_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            this.makeComboBox.SelectedIndexChanged -= new System.EventHandler(this.MakeComboBox_SelectedIndexChangedAsync);
            var modelSearch = this.modelComboBox.SelectedItem;
            var generate = new GenerateComboBoxOption();
            if (modelSearch != null)
            {
                List<string> make = await generate.MakeValueUpdateAsync((string)modelSearch, _IsModelChanged);
                if (make != null)
                {
                    this.makeComboBox.DataSource = make;
                }
            }
            else
            {
                this.makeComboBox.DataSource = await generate.AvaliableMakeAsync();
                this.makeComboBox.SelectedItem = null;
            }
            this.makeComboBox.SelectedIndexChanged += new System.EventHandler(this.MakeComboBox_SelectedIndexChangedAsync);
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
        private async void ComboBoxConstructorAsync()
        {
            GenerateComboBoxOption carSearchDisplay = new GenerateComboBoxOption();
            List<string> models = await carSearchDisplay.AvaliableModelAsync();
            List<string> makes = await carSearchDisplay.AvaliableMakeAsync();
            this.modelComboBox.DataSource = models; 
            this.modelComboBox.SelectedItem = null;
            this.makeComboBox.DataSource = makes; 
            this.makeComboBox.SelectedItem = null;
            this.modelComboBox.SelectedIndexChanged += new System.EventHandler(this.ModelComboBox_SelectedIndexChangedAsync);
            this.makeComboBox.SelectedIndexChanged += new System.EventHandler(this.MakeComboBox_SelectedIndexChangedAsync);
        }
    }
}
