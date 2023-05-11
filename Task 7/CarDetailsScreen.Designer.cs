/*==============================================================================
 *
 * Car Detail Screen Designer Class
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
    partial class CarDetailsScreen
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.registrationNumberTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.registrationDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.editButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.modelComboBox = new System.Windows.Forms.ComboBox();
            this.makeComboBox = new System.Windows.Forms.ComboBox();
            this.colourComboBox = new System.Windows.Forms.ComboBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.sightingsDataGridView = new System.Windows.Forms.DataGridView();
            this.SightingTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondAfterRedLightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpeedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateIssuedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatePaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageNumberComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sightingsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(156, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "Car Details";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(97, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Model:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(102, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Make:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Registration Number:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // registrationNumberTextBox
            // 
            this.registrationNumberTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrationNumberTextBox.Location = new System.Drawing.Point(149, 59);
            this.registrationNumberTextBox.Name = "registrationNumberTextBox";
            this.registrationNumberTextBox.ReadOnly = true;
            this.registrationNumberTextBox.Size = new System.Drawing.Size(243, 22);
            this.registrationNumberTextBox.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(95, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Colour:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // registrationDateTimePicker
            // 
            this.registrationDateTimePicker.Enabled = false;
            this.registrationDateTimePicker.Location = new System.Drawing.Point(149, 229);
            this.registrationDateTimePicker.Name = "registrationDateTimePicker";
            this.registrationDateTimePicker.Size = new System.Drawing.Size(243, 20);
            this.registrationDateTimePicker.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(41, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Registration Date:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // editButton
            // 
            this.editButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.Location = new System.Drawing.Point(66, 267);
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
            this.saveButton.Location = new System.Drawing.Point(172, 267);
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
            this.cancelButton.Location = new System.Drawing.Point(283, 267);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 31;
            this.cancelButton.Text = "Clear";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_ClickAsync);
            // 
            // modelComboBox
            // 
            this.modelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modelComboBox.Enabled = false;
            this.modelComboBox.FormattingEnabled = true;
            this.modelComboBox.Location = new System.Drawing.Point(149, 119);
            this.modelComboBox.Name = "modelComboBox";
            this.modelComboBox.Size = new System.Drawing.Size(243, 21);
            this.modelComboBox.TabIndex = 32;
            // 
            // makeComboBox
            // 
            this.makeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makeComboBox.Enabled = false;
            this.makeComboBox.FormattingEnabled = true;
            this.makeComboBox.Location = new System.Drawing.Point(149, 87);
            this.makeComboBox.Name = "makeComboBox";
            this.makeComboBox.Size = new System.Drawing.Size(243, 21);
            this.makeComboBox.TabIndex = 33;
            // 
            // colourComboBox
            // 
            this.colourComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colourComboBox.Enabled = false;
            this.colourComboBox.FormattingEnabled = true;
            this.colourComboBox.Location = new System.Drawing.Point(149, 146);
            this.colourComboBox.Name = "colourComboBox";
            this.colourComboBox.Size = new System.Drawing.Size(243, 21);
            this.colourComboBox.TabIndex = 34;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameTextBox.Location = new System.Drawing.Point(149, 173);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.ReadOnly = true;
            this.firstNameTextBox.Size = new System.Drawing.Size(243, 22);
            this.firstNameTextBox.TabIndex = 35;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameTextBox.Location = new System.Drawing.Point(149, 201);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.ReadOnly = true;
            this.lastNameTextBox.Size = new System.Drawing.Size(243, 22);
            this.lastNameTextBox.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Owner First Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(40, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Owner Last Name:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(658, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 37);
            this.label9.TabIndex = 39;
            this.label9.Text = "Sightings";
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
            this.sightingsDataGridView.Location = new System.Drawing.Point(434, 62);
            this.sightingsDataGridView.Name = "sightingsDataGridView";
            this.sightingsDataGridView.Size = new System.Drawing.Size(600, 187);
            this.sightingsDataGridView.TabIndex = 40;
            this.sightingsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SightingsDataGridView_CellClickAsync);
            // 
            // SightingTimeColumn
            // 
            this.SightingTimeColumn.DataPropertyName = "SightingTime";
            this.SightingTimeColumn.FillWeight = 120F;
            this.SightingTimeColumn.HeaderText = "Sighting Time";
            this.SightingTimeColumn.Name = "SightingTimeColumn";
            this.SightingTimeColumn.Width = 120;
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
            // pageNumberComboBox
            // 
            this.pageNumberComboBox.FormattingEnabled = true;
            this.pageNumberComboBox.Location = new System.Drawing.Point(913, 265);
            this.pageNumberComboBox.Name = "pageNumberComboBox";
            this.pageNumberComboBox.Size = new System.Drawing.Size(121, 21);
            this.pageNumberComboBox.TabIndex = 41;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(832, 267);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "Page Number:";
            // 
            // CarDetailsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 298);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pageNumberComboBox);
            this.Controls.Add(this.sightingsDataGridView);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.colourComboBox);
            this.Controls.Add(this.makeComboBox);
            this.Controls.Add(this.modelComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.registrationDateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.registrationNumberTextBox);
            this.Controls.Add(this.label2);
            this.Name = "CarDetailsScreen";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.sightingsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox registrationNumberTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker registrationDateTimePicker;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox modelComboBox;
        private System.Windows.Forms.ComboBox makeComboBox;
        private System.Windows.Forms.ComboBox colourComboBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView sightingsDataGridView;
        private System.Windows.Forms.ComboBox pageNumberComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn SightingTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondAfterRedLightColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpeedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateIssuedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatePaid;
        private System.Windows.Forms.Label label10;
    }
}
