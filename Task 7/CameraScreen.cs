/*==============================================================================
 *
 * Camera Screen Class
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
using AddtionalModelsOrBusinessClass.Task_7.CameraScreen;

namespace Task_7
{
    /// <summary>
    /// Camera Screen Class
    /// </summary>
    public partial class CameraScreen : Form
    {
        private string _LongitudeFrom;
        private string _LatitudeFrom;
        private string _LatitudeTo;
        private string _LongitudeTo;
        private int _ColumnIndex = 1;
        /// <summary>
        /// Constructor of Camera Screen that initalize the component, and refresh 
        /// the datagrid, and update pagenumber list
        /// </summary>
        public CameraScreen()
        {
            InitializeComponent();
            _ColumnIndex = 1;
            PageNumberGenerateAsync();
            RefreshGridAsync();
        }
        /// <summary>
        /// The New ANPR Camera Button to generate a new Camera details screen
        /// </summary>
        /// <param name="sender"> new Camera button </param>
        /// <param name="e"> click event </param>
        private void NewANPRCamearButton_Click(object sender, EventArgs e)
        {
            using (var detailsWindow = new CameraDetailsScreen(0))
            {
                detailsWindow.CameraSaved += this.DetailsWindow_CarSaved;
                detailsWindow.ShowDialog();
            }
        }
        /// <summary>
        /// The New speed Camera Button to generate a new Camera details screen
        /// </summary>
        /// <param name="sender"> new Camera button </param>
        /// <param name="e"> click event </param>
        private void NewSpeedCameraButton_Click(object sender, EventArgs e)
        {
            using (var detailsWindow = new CameraDetailsScreen(1))
            {
                detailsWindow.CameraSaved += this.DetailsWindow_CarSaved;
                detailsWindow.ShowDialog();
            }
        }
        /// <summary>
        /// The New traffic light Camera Button to generate a new Camera details screen
        /// </summary>
        /// <param name="sender"> new Camera button </param>
        /// <param name="e"> click event </param>
        private void NewTrafficLightCameraButton_Click(object sender, EventArgs e)
        {
            using (var detailsWindow = new CameraDetailsScreen(2))
            {
                detailsWindow.CameraSaved += this.DetailsWindow_CarSaved;
                detailsWindow.ShowDialog();
            }
        }
        /// <summary>
        /// Show Details in camera details screen of the selected row in data grid
        /// </summary>
        /// <param name="sender"> data grid view row </param>
        /// <param name="e"> click event </param>
        private async void CameraDataGridView_CellClickAsync(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var cameraSearch = cameraDataGridView.Rows[e.RowIndex].DataBoundItem as
                    AddtionalModelsOrBusinessClass.Task_7.CameraScreen.CameraSearchDisplayList;
                var cameraSearchDisplayList = new CameraModelDetails();
                CameraModelDetails camera = await cameraSearchDisplayList.CameraDetailsToDisplayAsync(cameraSearch);
                using (var detailsWindow = new CameraDetailsScreen(camera, cameraSearch.CameraType))
                {
                    detailsWindow.CameraSaved += this.DetailsWindow_CarSaved;
                    detailsWindow.ShowDialog();
                }              
            }
            else
            {
                _ColumnIndex = e.ColumnIndex;
                var cameraSearchDisplayList = new CameraSearchDisplayList();
                var cameraDisplayList = await cameraSearchDisplayList.SearchCameraListAsync(
                     _LongitudeFrom, _LongitudeTo, _LatitudeFrom, 
                     _LatitudeTo, (int)this.pageNumberComboBox.SelectedValue, _ColumnIndex);
                this.cameraDataGridView.DataSource = cameraDisplayList;
                this.pageNumberComboBox.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// Search the camera with details in sesarch list and populate in data grid view
        /// </summary>
        /// <param name="sender"> search button </param>
        /// <param name="e"> click event </param>
        private async void CameraSearchButton_ClickAsync(object sender, EventArgs e)
        {
            if (InputCheck() == false)
            {
                return;
            }
            _LongitudeFrom = this.longitudeFromTextBox.Text;
            _LongitudeTo = this.longitudeToTextBox.Text;
            _LatitudeFrom = this.latitudeFromTextBox.Text;
            _LatitudeTo = this.latitudeToTextBox.Text;
            var cameraSearchDisplayList = new CameraSearchDisplayList();
            var cameraList = await cameraSearchDisplayList.SearchCameraListAsync(
                _LongitudeFrom,
                _LongitudeTo,
                _LatitudeFrom,
                _LatitudeTo, 1, 1);
            _ColumnIndex = 1;
            this.cameraDataGridView.DataSource = cameraList;
            List<int> pageNumberList = await cameraSearchDisplayList.TotalCameraPageNumberAsync(
                _LongitudeFrom,
                _LongitudeTo,
                _LatitudeFrom,
                _LatitudeTo);
            this.pageNumberComboBox.SelectedIndexChanged -= PageNumberComboBox_SelectedIndexChangedAsync;
            this.pageNumberComboBox.DataSource = pageNumberList;
            this.pageNumberComboBox.SelectedIndex = 0;
            this.pageNumberComboBox.SelectedIndexChanged += PageNumberComboBox_SelectedIndexChangedAsync;
        }
        /// <summary>
        /// Populate all camera details in grid view 
        /// </summary>
        private async void RefreshGridAsync()
        {
            var searchDisplayList = new CameraSearchDisplayList();
            var camera = await searchDisplayList.SearchCameraListAsync(null, null, null, null, 1, 1);
            _ColumnIndex = 1;
            this.cameraDataGridView.DataSource = camera;
            List<int> pageNumberList = await searchDisplayList.TotalCameraPageNumberAsync(null, null, null, null);
            this.pageNumberComboBox.SelectedIndexChanged -= PageNumberComboBox_SelectedIndexChangedAsync;
            this.pageNumberComboBox.DataSource = pageNumberList;
            this.pageNumberComboBox.SelectedIndex = 0;
            this.pageNumberComboBox.SelectedIndexChanged += PageNumberComboBox_SelectedIndexChangedAsync;
            _LongitudeFrom = null;
            _LongitudeTo = null;
            _LatitudeFrom = null;
            _LatitudeTo = null;
        }
        /// <summary>
        /// Check the input in search field is valid or not
        /// </summary>
        /// <returns> true or false base on validity </returns>
        private bool InputCheck()
        {
            decimal[] tryParseResult = new decimal[4];
            if (!string.IsNullOrWhiteSpace(this.longitudeFromTextBox.Text) &&
                (!decimal.TryParse(this.longitudeFromTextBox.Text, out tryParseResult[0])))
            {
                MessageBox.Show("Longitude From input is not a decimal!", "Error");
                return false;
            }
            else if (!string.IsNullOrWhiteSpace(this.longitudeToTextBox.Text) &&
                (!decimal.TryParse(this.longitudeToTextBox.Text, out tryParseResult[1])))
            {
                MessageBox.Show("Longitude To input is not a decimal!", "Error");
                return false;
            }
            else if (!string.IsNullOrWhiteSpace(this.latitudeFromTextBox.Text) &&
                (!decimal.TryParse(this.latitudeFromTextBox.Text, out tryParseResult[2])))
            {
                MessageBox.Show("Latitude From input is not a decimal!", "Error");
                return false;
            }
            else if (!string.IsNullOrWhiteSpace(this.latitudeToTextBox.Text) &&
                (!decimal.TryParse(this.latitudeToTextBox.Text, out tryParseResult[3])))
            {
                MessageBox.Show("Latitude To input is not a decimal!", "Error");
                return false;
            }
            else if (!string.IsNullOrWhiteSpace(this.longitudeFromTextBox.Text) &&
                this.longitudeFromTextBox.Text.Length > 8)
            {
                MessageBox.Show("Longitude From input need to be less than 8 digits!", "Error");
                return false;
            }
            else if (!string.IsNullOrWhiteSpace(this.longitudeToTextBox.Text) &&
                this.longitudeToTextBox.Text.Length > 8)
            {
                MessageBox.Show("Longitude To input need to be less than 8 digits!", "Error");
                return false;
            }
            else if (!string.IsNullOrWhiteSpace(this.latitudeFromTextBox.Text) &&
                this.latitudeFromTextBox.Text.Length > 8)
            {
                MessageBox.Show("Latitude From input need to be less than 8 digits!", "Error");
                return false;
            }
            else if (!string.IsNullOrWhiteSpace(this.latitudeToTextBox.Text) &&
                this.latitudeToTextBox.Text.Length > 8)
            {
                MessageBox.Show("Latitude To input need to be less than 8 digits!", "Error");
                return false;
            }
            else if (!string.IsNullOrWhiteSpace(this.longitudeFromTextBox.Text) &&
                ((int)(tryParseResult[0] * 1000000 % 10)) != 0)
            {
                MessageBox.Show("5 Decimal Maximum for longitude from input!", "Error");
                return false;
            }
            else if (!string.IsNullOrWhiteSpace(this.longitudeToTextBox.Text) &&
                ((int)(tryParseResult[1] * 1000000 % 10)) != 0)
            {
                MessageBox.Show("5 Decimal Maximum for longitude to input!", "Error");
                return false;
            }
            else if (!string.IsNullOrWhiteSpace(this.latitudeFromTextBox.Text) &&
                ((int)(tryParseResult[2] * 1000000 % 10)) != 0)
            {
                MessageBox.Show("5 Decimal Maximum for latitude from input!", "Error");
                return false;
            }
            else if (!string.IsNullOrWhiteSpace(this.latitudeToTextBox.Text) &&
                ((int)(tryParseResult[3] * 1000000 % 10)) != 0)
            {
                MessageBox.Show("5 Decimal Maximum for latitude to input!", "Error");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Refreshes the grid when a camera is saved on a child camera details window.
        /// </summary>
        private void DetailsWindow_CarSaved(object sender, EventArgs e)
        {
            this.RefreshGridAsync();
        }
        /// <summary>
        /// get the other page selected to display in data grid view
        /// </summary>
        /// <param name="sender"> selected page number drop box </param>
        /// <param name="e"> click drop box </param>
        private async void PageNumberComboBox_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            var pageNumber = this.pageNumberComboBox.SelectedItem;
            if (pageNumber != null)
            {
                var cameraSearchDisplayList = new CameraSearchDisplayList();
                var cameraList = await cameraSearchDisplayList.SearchCameraListAsync(
                    _LongitudeFrom,
                    _LongitudeTo,
                    _LatitudeFrom,
                    _LatitudeTo, (int)this.pageNumberComboBox.SelectedValue, _ColumnIndex);
                this.cameraDataGridView.DataSource = cameraList;
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
        private async void PageNumberGenerateAsync()
        {
            var displayList = new CameraSearchDisplayList();
            List<int> pageNumberList = await displayList.TotalCameraPageNumberAsync(null, null, null, null);
            this.pageNumberComboBox.SelectedIndexChanged -= PageNumberComboBox_SelectedIndexChangedAsync;
            this.pageNumberComboBox.DataSource = pageNumberList;
            this.pageNumberComboBox.SelectedIndex = 0;
            this.pageNumberComboBox.SelectedIndexChanged += PageNumberComboBox_SelectedIndexChangedAsync;
        }
    }
}
