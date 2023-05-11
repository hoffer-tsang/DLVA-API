/*==============================================================================
 *
 * Camera Details Screen Class
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
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddtionalModelsOrBusinessClass.Task_7.Sightings;
using AddtionalModelsOrBusinessClass.Task_7.CameraScreen;
using EntityFrameWorkModel;
using System.Windows.Forms.VisualStyles;

namespace Task_7
{
    /// <summary>
    /// Camera Details Screen Class
    /// </summary>
    public partial class CameraDetailsScreen : Form
    {
        /// <summary>
        /// Occurs when a  Camera has been saved.
        /// </summary>
        public event EventHandler CameraSaved;
        private CameraModelDetails _Camera;
        private bool _InputNewCameraOrNot = false;
        private int _ColumnIndex = 0;
        /// <summary>
        /// Camera Detail Consturctor 
        /// </summary>
        /// <param name="speedCameraOrNot"> 0 for anpr, 1 for speed camera, 2 for traffic light camera </param>
        public CameraDetailsScreen(int speedCameraOrNot)
        {
            InitializeComponent();
            if (speedCameraOrNot == 0)
            {
                this.cameraTypeLabel.Text = "Not Available";
                this.cameraTypeTextBox.ReadOnly = true;
            }
            else if (speedCameraOrNot == 1)
            {
                this.cameraTypeTextBox.ReadOnly = false;
            }
            else if (speedCameraOrNot == 2)
            {
                this.cameraTypeLabel.Text = "Seconds After Red \n Light Threshold:";
                this.cameraTypeTextBox.ReadOnly = false;
            }
            _InputNewCameraOrNot = true;
            this.roadNameTextBox.ReadOnly = false;
            this.roadNumberTextBox.ReadOnly = false;
            this.longitudeTextBox.ReadOnly = false;
            this.latitudeTextBox.ReadOnly = false;
            this.addressCheckBox.Enabled = true;
            this.editButton.Enabled = false;
            this.saveButton.Enabled = true;
            this.cancelButton.Enabled = true;
        }
        /// <summary>
        /// Override constructor with detail of camera to display in details
        /// screen and the type of camera
        /// </summary>
        /// <param name="camera"> camera details </param>
        /// <param name="cameraType"> camera type to be display </param>
        public CameraDetailsScreen(CameraModelDetails camera, string cameraType)
        {
            InitializeComponent();
            _Camera = camera;
            if(cameraType == "Speed Camera")
            {
                this.cameraTypeTextBox.Text = camera.CameraTypeValue.ToString();
            }
            if (cameraType == "Traffic Light Camera")
            {
                this.cameraTypeLabel.Text = "Seconds After Red \n Light Threshold:";
                this.cameraTypeTextBox.Text = camera.CameraTypeValue.ToString();
            }
            else if (cameraType == "ANPR")
            {
                this.cameraTypeLabel.Text = "Not Available";
                this.cameraTypeTextBox.ReadOnly = true;
                this.cameraTypeTextBox.Text = null;
            }
            this.roadNameTextBox.Text = camera.RoadName;
            this.roadNumberTextBox.Text = camera.RoadNumber;
            this.longitudeTextBox.Text = camera.Longitude.ToString();
            this.latitudeTextBox.Text = camera.Latitude.ToString();
            this.cameraTypeTextBox.Text = camera.CameraTypeValue.ToString();
            this.line1TextBox.Text = camera.Line1;
            this.line2TextBox.Text = camera.Line2;
            this.line3TextBox.Text = camera.Line3;
            this.cityTextBox.Text = camera.City;
            this.countyTextBox.Text = camera.County;
            this.countryTextBox.Text = camera.Country;
            this.postCodeTextBox.Text = camera.PostCode;
            GeneratePageNumberOptionAsync();
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
                var generateSightings = new SightingsListDisplay();
                var sightingList = await generateSightings.GetSightingsListAsync (_Camera.CameraId, (int)pageNumber, false, _ColumnIndex);
                this.sightingsDataGridView.DataSource = sightingList;
            }
        }
        /// <summary>
        /// Cancel all field input when editing
        /// </summary>
        /// <param name="sender"> cancel button </param>
        /// <param name="e"> button click </param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.roadNameTextBox.Text = null;
            this.roadNumberTextBox.Text = null;
            this.longitudeTextBox.Text = null;
            this.latitudeTextBox.Text = null;
            this.cameraTypeTextBox.Text = null;
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
            this.addressCheckBox.Enabled = true;
            this.roadNameTextBox.ReadOnly = false;
            this.roadNumberTextBox.ReadOnly = false;
            this.longitudeTextBox.ReadOnly = false;
            this.latitudeTextBox.ReadOnly = false;
            if (_Camera.CameraType == "Speed Camera" || _Camera.CameraType == "Traffic Light Camera")
            {
                this.cameraTypeTextBox.ReadOnly = false;
            }
        }
        /// <summary>
        /// Save the edit or new entry of camera
        /// </summary>
        /// <param name="sender"> save btuton </param>
        /// <param name="e"> button click </param>
        /// 
        private async void SaveButton_ClickAsync(object sender, EventArgs e)
        {
            if (InputCheck() == true)
            {
                if (_InputNewCameraOrNot == true)
                {
                    var dummycamera = new CameraModelDetails { CameraId = -1 };
                    _Camera = dummycamera;
                }
                var updateDetails = new CameraModelDetails();
                int saveStatus = await updateDetails.SaveCameraDetailsAsync(_InputNewCameraOrNot,
                    this.roadNameTextBox.Text,
                    this.roadNumberTextBox.Text,
                    this.longitudeTextBox.Text,
                    this.latitudeTextBox.Text,
                    this.cameraTypeTextBox.Text,
                    this.addressCheckBox.Checked,
                    this.line1TextBox.Text,
                    this.line2TextBox.Text,
                    this.line3TextBox.Text,
                    this.cityTextBox.Text,
                    this.countyTextBox.Text,
                    this.countryTextBox.Text,
                    this.postCodeTextBox.Text,
                    _Camera.CameraId,
                    this.cameraTypeLabel.Text);
                if (saveStatus == -1)
                {
                    MessageBox.Show("Address Id does not exist in the database!", "Error");
                }
                else
                {
                    this.OnCameraSaved();
                    this.Close();
                }
            }
        }
        /// <summary>
        /// Raises the <see cref="CameraSaved"/> event.
        /// </summary>
        protected virtual void OnCameraSaved()
        {
            var handler = this.CameraSaved;

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
            decimal[] tryParseResult = new decimal[2];
            if (string.IsNullOrWhiteSpace(this.latitudeTextBox.Text) ||
                string.IsNullOrWhiteSpace(this.longitudeTextBox.Text) ||
                string.IsNullOrWhiteSpace(this.roadNameTextBox.Text) ||
                (this.cameraTypeLabel.Text != "Not Available" && 
                string.IsNullOrWhiteSpace(this.cameraTypeTextBox.Text)) ||
                (this.addressCheckBox.Checked &&
                (string.IsNullOrWhiteSpace(this.line1TextBox.Text) ||
                string.IsNullOrWhiteSpace(this.cityTextBox.Text) ||
                string.IsNullOrWhiteSpace(this.countyTextBox.Text) ||
                string.IsNullOrWhiteSpace(this.countryTextBox.Text) ||
                string.IsNullOrWhiteSpace(this.postCodeTextBox.Text)))
                )
            {
                MessageBox.Show("All Field has to be filled in!", "Error");
                return false;
            }
            else if (this.roadNameTextBox.Text.Length > 50)
            {
                MessageBox.Show("Road Name can't be longer than 50 characters!", "Error");
                return true;
            }
            else if (!string.IsNullOrWhiteSpace(roadNumberTextBox.Text)
                && roadNumberTextBox.Text.Length > 5)
            {
                MessageBox.Show("Road Number can't be longer than 5 digits!", "Error");
                return true;
            }
            else if (!decimal.TryParse(this.longitudeTextBox.Text, out tryParseResult[0]))
            {
                MessageBox.Show("Longitude input is not a decimal!", "Error");
                return false;
            }
            else if (!decimal.TryParse(this.latitudeTextBox.Text, out tryParseResult[1]))
            {
                MessageBox.Show("Latitude input is not a decimal!", "Error");
                return false;
            }
            else if (this.longitudeTextBox.Text.Length > 8)
            {
                MessageBox.Show("Longitude input need to be less than 8 digits!", "Error");
                return false;
            }
            else if (this.latitudeTextBox.Text.Length > 8)
            {
                MessageBox.Show("Latitude input need to be less than 8 digits!", "Error");
                return false;
            }

            else if (((int)(tryParseResult[0] * 1000000 % 10)) != 0)
            {
                MessageBox.Show("5 Decimal Maximum for longitude input!", "Error");
                return false;
            }
            else if (((int)(tryParseResult[1] * 1000000 % 10)) != 0)
            {
                MessageBox.Show("5 Decimal Maximum for latitude input!", "Error");
                return false;
            }
            else if (!this.cameraTypeTextBox.Text.All(Char.IsDigit))
            {
                MessageBox.Show("CameraType details Format is not correct!", "Error");
                return false;
            }
            else if (this.addressCheckBox.Checked && this.line1TextBox.Text.Length > 100)
            {
                MessageBox.Show("line1 need to be 100 characters or below!", "Error");
            }
            else if (this.addressCheckBox.Checked &&
                !string.IsNullOrWhiteSpace(this.line2TextBox.Text) &&
                this.line2TextBox.Text.Length > 100)
            {
                MessageBox.Show("line2 need to be 100 characters or below!", "Error");
            }
            else if (this.addressCheckBox.Checked &&
                !string.IsNullOrWhiteSpace(this.line3TextBox.Text) &&
                this.line3TextBox.Text.Length > 100)
            {
                MessageBox.Show("line3 need to be 100 characters or below!", "Error");
            }
            else if (this.addressCheckBox.Checked &&
                this.cityTextBox.Text.Length > 50)
            {
                MessageBox.Show("City need to be 50 characters or below!", "Error");
            }
            else if (this.addressCheckBox.Checked &&
                this.countyTextBox.Text.Length > 50)
            {
                MessageBox.Show("County need to be 50 characters or below!", "Error");
            }
            else if (this.addressCheckBox.Checked &&
                this.countryTextBox.Text.Length > 50)
            {
                MessageBox.Show("Country need to be 50 characters or below!", "Error");
            }
            else if (this.addressCheckBox.Checked &&
                this.postCodeTextBox.Text.Length > 16)
            {
                MessageBox.Show("Post Code need to be 16 characters or below!", "Error");
            }
            return true;
        }
        /// <summary>
        /// Enable edit to address details 
        /// </summary>
        /// <param name="sender"> address check box </param>
        /// <param name="e"> checked or unchecked </param>
        private void AddressCheckBox_Click(object sender, EventArgs e)
        {
            if (this.addressCheckBox.Checked)
            {
                this.line1TextBox.ReadOnly = false;
                this.line2TextBox.ReadOnly = false;
                this.line3TextBox.ReadOnly = false;
                this.cityTextBox.ReadOnly = false;
                this.countyTextBox.ReadOnly = false;
                this.countryTextBox.ReadOnly = false;
                this.postCodeTextBox.ReadOnly = false;
            }
            else
            {
                this.line1TextBox.ReadOnly = true;
                this.line2TextBox.ReadOnly = true;
                this.line3TextBox.ReadOnly = true;
                this.cityTextBox.ReadOnly = true;
                this.countyTextBox.ReadOnly = true;
                this.countryTextBox.ReadOnly = true;
                this.postCodeTextBox.ReadOnly = true;
            }
        }
        /// <summary>
        /// when sighting grid column title is click, sort by the specific column
        /// </summary>
        /// <param name="sender"> sighting data grid view </param>
        /// <param name="e"> click event </param>
        private async void SightingsDataGridView_CellClickAsync(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                _ColumnIndex = e.ColumnIndex;
                var generateSightings = new SightingsListDisplay();
                this.sightingsDataGridView.DataSource = await generateSightings.GetSightingsListAsync(_Camera.CameraId, (int)this.pageNumberComboBox.SelectedValue, false, _ColumnIndex);
                this.pageNumberComboBox.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// Generate Page Number option async
        /// </summary>
        private async void GeneratePageNumberOptionAsync()
        {
            var generateSightings = new SightingsListDisplay();
            this.sightingsDataGridView.DataSource = await generateSightings.GetSightingsListAsync(_Camera.CameraId, 1, false, 0);
            this.pageNumberComboBox.DataSource = await generateSightings.TotalSightingsPageNumberAsync(_Camera.CameraId, false);
            this.pageNumberComboBox.SelectedIndex = 0;
            this.pageNumberComboBox.SelectedIndexChanged += new System.EventHandler(this.PageNumberComboBox_SelectedIndexChangedAsync);
        }
    }
}
