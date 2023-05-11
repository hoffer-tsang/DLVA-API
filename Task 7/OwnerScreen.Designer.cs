/*==============================================================================
 *
 * Owner Screen Designer Class
 *
 * Copyright © Dorset Software Services Ltd, 2022
 *
 * TSD Section: P770 DataBase Driven Application Task Set 3 Task 7
 *
 *============================================================================*/
namespace Task_7
{
    /// <summary>
    /// Car Screen Desginer Class
    /// </summary>
    partial class OwnerScreen
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ownerSearchButton = new System.Windows.Forms.Button();
            this.ownerDataGridView = new System.Windows.Forms.DataGridView();
            this.FirstNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateofBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressLine1Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.newOwnerButton = new System.Windows.Forms.Button();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateOfBirthTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateOfBirthCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pageNumberComboBox = new System.Windows.Forms.ComboBox();
            this.backButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ownerDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(201, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Owner";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(172, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Owner Search Fields";
            // 
            // ownerSearchButton
            // 
            this.ownerSearchButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ownerSearchButton.Location = new System.Drawing.Point(208, 172);
            this.ownerSearchButton.Name = "ownerSearchButton";
            this.ownerSearchButton.Size = new System.Drawing.Size(97, 23);
            this.ownerSearchButton.TabIndex = 6;
            this.ownerSearchButton.Text = "Owner Search";
            this.ownerSearchButton.UseVisualStyleBackColor = true;
            this.ownerSearchButton.Click += new System.EventHandler(this.OwnerSearchButton_ClickAsync);
            // 
            // ownerDataGridView
            // 
            this.ownerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ownerDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstNameColumn,
            this.LastNameColumn,
            this.DateofBirth,
            this.AddressLine1Column});
            this.ownerDataGridView.Location = new System.Drawing.Point(26, 232);
            this.ownerDataGridView.Name = "ownerDataGridView";
            this.ownerDataGridView.Size = new System.Drawing.Size(437, 163);
            this.ownerDataGridView.TabIndex = 7;
            this.ownerDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OwnerDataGridView_CellClickAsync);
            // 
            // FirstNameColumn
            // 
            this.FirstNameColumn.DataPropertyName = "FirstName";
            this.FirstNameColumn.HeaderText = "First Name";
            this.FirstNameColumn.Name = "FirstNameColumn";
            // 
            // LastNameColumn
            // 
            this.LastNameColumn.DataPropertyName = "LastName";
            this.LastNameColumn.HeaderText = "Last Name";
            this.LastNameColumn.Name = "LastNameColumn";
            // 
            // DateofBirth
            // 
            this.DateofBirth.DataPropertyName = "DateOfBirth";
            this.DateofBirth.HeaderText = "Date Of Birth";
            this.DateofBirth.Name = "DateofBirth";
            // 
            // AddressLine1Column
            // 
            this.AddressLine1Column.DataPropertyName = "AddressLine1";
            this.AddressLine1Column.HeaderText = "Address Line 1";
            this.AddressLine1Column.Name = "AddressLine1Column";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(215, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Owner List";
            // 
            // newOwnerButton
            // 
            this.newOwnerButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newOwnerButton.Location = new System.Drawing.Point(378, 206);
            this.newOwnerButton.Name = "newOwnerButton";
            this.newOwnerButton.Size = new System.Drawing.Size(85, 23);
            this.newOwnerButton.TabIndex = 15;
            this.newOwnerButton.Text = "New Owner";
            this.newOwnerButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.newOwnerButton.UseVisualStyleBackColor = true;
            this.newOwnerButton.Click += new System.EventHandler(this.NewOwnerButton_Click);
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameTextBox.Location = new System.Drawing.Point(163, 109);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(242, 22);
            this.lastNameTextBox.TabIndex = 20;
            this.toolTip2.SetToolTip(this.lastNameTextBox, "Last name has to be less then 40 characters.");
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameTextBox.Location = new System.Drawing.Point(163, 81);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(242, 22);
            this.firstNameTextBox.TabIndex = 21;
            this.toolTip1.SetToolTip(this.firstNameTextBox, "First name has to be less then 40 characters.");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(55, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Owner First Name:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(57, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Owner Last Name:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dateOfBirthTimePicker
            // 
            this.dateOfBirthTimePicker.Enabled = false;
            this.dateOfBirthTimePicker.Location = new System.Drawing.Point(163, 137);
            this.dateOfBirthTimePicker.Name = "dateOfBirthTimePicker";
            this.dateOfBirthTimePicker.Size = new System.Drawing.Size(242, 20);
            this.dateOfBirthTimePicker.TabIndex = 25;
            this.toolTip3.SetToolTip(this.dateOfBirthTimePicker, "Date of birth has to be in the past.");
            // 
            // dateOfBirthCheckBox
            // 
            this.dateOfBirthCheckBox.AutoSize = true;
            this.dateOfBirthCheckBox.Location = new System.Drawing.Point(67, 140);
            this.dateOfBirthCheckBox.Name = "dateOfBirthCheckBox";
            this.dateOfBirthCheckBox.Size = new System.Drawing.Size(90, 17);
            this.dateOfBirthCheckBox.TabIndex = 26;
            this.dateOfBirthCheckBox.Text = "Date Of Birth:";
            this.dateOfBirthCheckBox.UseVisualStyleBackColor = true;
            this.dateOfBirthCheckBox.Click += new System.EventHandler(this.DateOfBirthCheckBox_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(265, 404);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Page Number:";
            // 
            // pageNumberComboBox
            // 
            this.pageNumberComboBox.FormattingEnabled = true;
            this.pageNumberComboBox.Location = new System.Drawing.Point(342, 401);
            this.pageNumberComboBox.Name = "pageNumberComboBox";
            this.pageNumberComboBox.Size = new System.Drawing.Size(121, 21);
            this.pageNumberComboBox.TabIndex = 29;
            this.pageNumberComboBox.SelectedIndexChanged += new System.EventHandler(this.PageNumberComboBox_SelectedIndexChangedAsync);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(26, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 32;
            this.backButton.Text = "Back";
            this.toolTip4.SetToolTip(this.backButton, "Navigate back to main menu");
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // OwnerScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 430);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pageNumberComboBox);
            this.Controls.Add(this.dateOfBirthCheckBox);
            this.Controls.Add(this.dateOfBirthTimePicker);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.newOwnerButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ownerDataGridView);
            this.Controls.Add(this.ownerSearchButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OwnerScreen";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ownerDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ownerSearchButton;
        private System.Windows.Forms.DataGridView ownerDataGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button newOwnerButton;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateOfBirthTimePicker;
        private System.Windows.Forms.CheckBox dateOfBirthCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox pageNumberComboBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateofBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressLine1Column;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip4;
    }
}

