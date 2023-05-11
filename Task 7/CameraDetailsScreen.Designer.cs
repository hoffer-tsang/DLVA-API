/*==============================================================================
 *
 * Camera Detail Screen Designer Class
 *
 * Copyright © Dorset Software Services Ltd, 2022
 *
 * TSD Section: P770 DataBase Driven Application Task Set 3 Task 7
 *
 *============================================================================*/
namespace Task_7
{
    /// <summary>
    /// Car Details Screen Desginer
    /// </summary>
    partial class CameraDetailsScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.editButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.latitudeTextBox = new System.Windows.Forms.TextBox();
            this.cameraTypeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cameraTypeLabel = new System.Windows.Forms.Label();
            this.line1TextBox = new System.Windows.Forms.TextBox();
            this.line2TextBox = new System.Windows.Forms.TextBox();
            this.line3TextBox = new System.Windows.Forms.TextBox();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.countyTextBox = new System.Windows.Forms.TextBox();
            this.countryTextBox = new System.Windows.Forms.TextBox();
            this.postCodeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.longitudeTextBox = new System.Windows.Forms.TextBox();
            this.roadNumberTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.roadNameTextBox = new System.Windows.Forms.TextBox();
            this.addressCheckBox = new System.Windows.Forms.CheckBox();
            this.pageNumberComboBox = new System.Windows.Forms.ComboBox();
            this.sightingsDataGridView = new System.Windows.Forms.DataGridView();
            this.SightingTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondAfterRedLightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpeedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateIssuedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatePaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sightingsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(193, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "Camera Details";
            // 
            // editButton
            // 
            this.editButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.Location = new System.Drawing.Point(132, 278);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 29;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(238, 278);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 30;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_ClickAsync);
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(349, 278);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 31;
            this.cancelButton.Text = "Clear";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // latitudeTextBox
            // 
            this.latitudeTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latitudeTextBox.Location = new System.Drawing.Point(142, 181);
            this.latitudeTextBox.Name = "latitudeTextBox";
            this.latitudeTextBox.ReadOnly = true;
            this.latitudeTextBox.Size = new System.Drawing.Size(128, 22);
            this.latitudeTextBox.TabIndex = 35;
            // 
            // cameraTypeTextBox
            // 
            this.cameraTypeTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraTypeTextBox.Location = new System.Drawing.Point(142, 209);
            this.cameraTypeTextBox.Name = "cameraTypeTextBox";
            this.cameraTypeTextBox.ReadOnly = true;
            this.cameraTypeTextBox.Size = new System.Drawing.Size(128, 22);
            this.cameraTypeTextBox.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Latitude:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cameraTypeLabel
            // 
            this.cameraTypeLabel.AutoSize = true;
            this.cameraTypeLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraTypeLabel.Location = new System.Drawing.Point(35, 212);
            this.cameraTypeLabel.Name = "cameraTypeLabel";
            this.cameraTypeLabel.Size = new System.Drawing.Size(101, 13);
            this.cameraTypeLabel.TabIndex = 38;
            this.cameraTypeLabel.Text = "Speed Limit (mph):";
            this.cameraTypeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // line1TextBox
            // 
            this.line1TextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.line1TextBox.Location = new System.Drawing.Point(383, 75);
            this.line1TextBox.Name = "line1TextBox";
            this.line1TextBox.ReadOnly = true;
            this.line1TextBox.Size = new System.Drawing.Size(155, 22);
            this.line1TextBox.TabIndex = 39;
            // 
            // line2TextBox
            // 
            this.line2TextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.line2TextBox.Location = new System.Drawing.Point(383, 103);
            this.line2TextBox.Name = "line2TextBox";
            this.line2TextBox.ReadOnly = true;
            this.line2TextBox.Size = new System.Drawing.Size(155, 22);
            this.line2TextBox.TabIndex = 40;
            // 
            // line3TextBox
            // 
            this.line3TextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.line3TextBox.Location = new System.Drawing.Point(383, 131);
            this.line3TextBox.Name = "line3TextBox";
            this.line3TextBox.ReadOnly = true;
            this.line3TextBox.Size = new System.Drawing.Size(155, 22);
            this.line3TextBox.TabIndex = 41;
            // 
            // cityTextBox
            // 
            this.cityTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityTextBox.Location = new System.Drawing.Point(383, 159);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.ReadOnly = true;
            this.cityTextBox.Size = new System.Drawing.Size(155, 22);
            this.cityTextBox.TabIndex = 42;
            // 
            // countyTextBox
            // 
            this.countyTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countyTextBox.Location = new System.Drawing.Point(383, 187);
            this.countyTextBox.Name = "countyTextBox";
            this.countyTextBox.ReadOnly = true;
            this.countyTextBox.Size = new System.Drawing.Size(155, 22);
            this.countyTextBox.TabIndex = 43;
            // 
            // countryTextBox
            // 
            this.countryTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countryTextBox.Location = new System.Drawing.Point(383, 215);
            this.countryTextBox.Name = "countryTextBox";
            this.countryTextBox.ReadOnly = true;
            this.countryTextBox.Size = new System.Drawing.Size(155, 22);
            this.countryTextBox.TabIndex = 44;
            // 
            // postCodeTextBox
            // 
            this.postCodeTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postCodeTextBox.Location = new System.Drawing.Point(383, 243);
            this.postCodeTextBox.Name = "postCodeTextBox";
            this.postCodeTextBox.ReadOnly = true;
            this.postCodeTextBox.Size = new System.Drawing.Size(155, 22);
            this.postCodeTextBox.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(331, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Line 1:  ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(282, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "Line 2 (optional):  ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(282, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Line 3 (optional):  ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(348, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "City:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(328, 190);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 50;
            this.label9.Text = "County:  ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(324, 218);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 51;
            this.label10.Text = "Country:  ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(313, 246);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 52;
            this.label11.Text = "Post Code:  ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(73, 156);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 56;
            this.label12.Text = "Longitude:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(2, 131);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(134, 13);
            this.label13.TabIndex = 55;
            this.label13.Text = "Road Number (optional):";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // longitudeTextBox
            // 
            this.longitudeTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.longitudeTextBox.Location = new System.Drawing.Point(142, 153);
            this.longitudeTextBox.Name = "longitudeTextBox";
            this.longitudeTextBox.ReadOnly = true;
            this.longitudeTextBox.Size = new System.Drawing.Size(128, 22);
            this.longitudeTextBox.TabIndex = 54;
            // 
            // roadNumberTextBox
            // 
            this.roadNumberTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roadNumberTextBox.Location = new System.Drawing.Point(142, 125);
            this.roadNumberTextBox.Name = "roadNumberTextBox";
            this.roadNumberTextBox.ReadOnly = true;
            this.roadNumberTextBox.Size = new System.Drawing.Size(128, 22);
            this.roadNumberTextBox.TabIndex = 53;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(67, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 58;
            this.label14.Text = "Road Name:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // roadNameTextBox
            // 
            this.roadNameTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roadNameTextBox.Location = new System.Drawing.Point(142, 97);
            this.roadNameTextBox.Name = "roadNameTextBox";
            this.roadNameTextBox.ReadOnly = true;
            this.roadNameTextBox.Size = new System.Drawing.Size(128, 22);
            this.roadNameTextBox.TabIndex = 57;
            // 
            // addressCheckBox
            // 
            this.addressCheckBox.AutoSize = true;
            this.addressCheckBox.Enabled = false;
            this.addressCheckBox.Location = new System.Drawing.Point(383, 52);
            this.addressCheckBox.Name = "addressCheckBox";
            this.addressCheckBox.Size = new System.Drawing.Size(115, 17);
            this.addressCheckBox.TabIndex = 59;
            this.addressCheckBox.Text = "Address (Optional):";
            this.addressCheckBox.UseVisualStyleBackColor = true;
            this.addressCheckBox.Click += new System.EventHandler(this.AddressCheckBox_Click);
            // 
            // pageNumberComboBox
            // 
            this.pageNumberComboBox.FormattingEnabled = true;
            this.pageNumberComboBox.Location = new System.Drawing.Point(988, 275);
            this.pageNumberComboBox.Name = "pageNumberComboBox";
            this.pageNumberComboBox.Size = new System.Drawing.Size(121, 21);
            this.pageNumberComboBox.TabIndex = 62;
            // 
            // sightingsDataGridView
            // 
            this.sightingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sightingsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SightingTimeColumn,
            this.SecondAfterRedLightColumn,
            this.SpeedColumn,
            this.DateIssuedColumn,
            this.DatePaid});
            this.sightingsDataGridView.Location = new System.Drawing.Point(568, 72);
            this.sightingsDataGridView.Name = "sightingsDataGridView";
            this.sightingsDataGridView.Size = new System.Drawing.Size(541, 187);
            this.sightingsDataGridView.TabIndex = 61;
            this.sightingsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SightingsDataGridView_CellClickAsync);
            // 
            // SightingTimeColumn
            // 
            this.SightingTimeColumn.DataPropertyName = "SightingTime";
            this.SightingTimeColumn.HeaderText = "Sighting Time";
            this.SightingTimeColumn.Name = "SightingTimeColumn";
            // 
            // SecondAfterRedLightColumn
            // 
            this.SecondAfterRedLightColumn.DataPropertyName = "SecondsAfterRedLight";
            this.SecondAfterRedLightColumn.HeaderText = "Second After Red Light";
            this.SecondAfterRedLightColumn.Name = "SecondAfterRedLightColumn";
            // 
            // SpeedColumn
            // 
            this.SpeedColumn.DataPropertyName = "Speed";
            this.SpeedColumn.HeaderText = "Speed (Mph)";
            this.SpeedColumn.Name = "SpeedColumn";
            // 
            // DateIssuedColumn
            // 
            this.DateIssuedColumn.DataPropertyName = "DateIssued";
            this.DateIssuedColumn.HeaderText = "Date Issued";
            this.DateIssuedColumn.Name = "DateIssuedColumn";
            // 
            // DatePaid
            // 
            this.DatePaid.DataPropertyName = "DatePaid";
            this.DatePaid.HeaderText = "Date Paid";
            this.DatePaid.Name = "DatePaid";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(793, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 37);
            this.label7.TabIndex = 60;
            this.label7.Text = "Sightings";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(907, 278);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 63;
            this.label8.Text = "Page Number:";
            // 
            // CameraDetailsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 311);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pageNumberComboBox);
            this.Controls.Add(this.sightingsDataGridView);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.addressCheckBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.roadNameTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.longitudeTextBox);
            this.Controls.Add(this.roadNumberTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.postCodeTextBox);
            this.Controls.Add(this.countryTextBox);
            this.Controls.Add(this.countyTextBox);
            this.Controls.Add(this.cityTextBox);
            this.Controls.Add(this.line3TextBox);
            this.Controls.Add(this.line2TextBox);
            this.Controls.Add(this.line1TextBox);
            this.Controls.Add(this.cameraTypeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cameraTypeTextBox);
            this.Controls.Add(this.latitudeTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.label2);
            this.Name = "CameraDetailsScreen";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.sightingsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox latitudeTextBox;
        private System.Windows.Forms.TextBox cameraTypeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label cameraTypeLabel;
        private System.Windows.Forms.TextBox line1TextBox;
        private System.Windows.Forms.TextBox line2TextBox;
        private System.Windows.Forms.TextBox line3TextBox;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.TextBox countyTextBox;
        private System.Windows.Forms.TextBox countryTextBox;
        private System.Windows.Forms.TextBox postCodeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox longitudeTextBox;
        private System.Windows.Forms.TextBox roadNumberTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox roadNameTextBox;
        private System.Windows.Forms.CheckBox addressCheckBox;
        private System.Windows.Forms.ComboBox pageNumberComboBox;
        private System.Windows.Forms.DataGridView sightingsDataGridView;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn SightingTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondAfterRedLightColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpeedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateIssuedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatePaid;
        private System.Windows.Forms.Label label8;
    }
}
