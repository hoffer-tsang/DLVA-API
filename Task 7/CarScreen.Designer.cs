/*==============================================================================
 *
 * Car Screen Designer Class
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
    partial class CarScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.registrationNumberTextBox = new System.Windows.Forms.TextBox();
            this.carSearchButton = new System.Windows.Forms.Button();
            this.carDataGridView = new System.Windows.Forms.DataGridView();
            this.RegistrationNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Make = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OwnerIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.newCarButton = new System.Windows.Forms.Button();
            this.modelComboBox = new System.Windows.Forms.ComboBox();
            this.makeComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pageNumberComboBox = new System.Windows.Forms.ComboBox();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.carDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(221, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Car";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(189, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Car Search Fields";
            // 
            // registrationNumberTextBox
            // 
            this.registrationNumberTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrationNumberTextBox.Location = new System.Drawing.Point(174, 93);
            this.registrationNumberTextBox.Name = "registrationNumberTextBox";
            this.registrationNumberTextBox.Size = new System.Drawing.Size(242, 22);
            this.registrationNumberTextBox.TabIndex = 2;
            // 
            // carSearchButton
            // 
            this.carSearchButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carSearchButton.Location = new System.Drawing.Point(206, 234);
            this.carSearchButton.Name = "carSearchButton";
            this.carSearchButton.Size = new System.Drawing.Size(75, 23);
            this.carSearchButton.TabIndex = 6;
            this.carSearchButton.Text = "Car Search";
            this.carSearchButton.UseVisualStyleBackColor = true;
            this.carSearchButton.Click += new System.EventHandler(this.CarSearchButton_ClickAsync);
            // 
            // carDataGridView
            // 
            this.carDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.carDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RegistrationNumberColumn,
            this.ModelIdColumn,
            this.Make,
            this.OwnerIdColumn});
            this.carDataGridView.Location = new System.Drawing.Point(24, 295);
            this.carDataGridView.Name = "carDataGridView";
            this.carDataGridView.Size = new System.Drawing.Size(437, 163);
            this.carDataGridView.TabIndex = 7;
            this.carDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CarDataGridView_CellClickAsync);
            // 
            // RegistrationNumberColumn
            // 
            this.RegistrationNumberColumn.DataPropertyName = "RegistrationNumber";
            this.RegistrationNumberColumn.HeaderText = "Registration Number";
            this.RegistrationNumberColumn.Name = "RegistrationNumberColumn";
            // 
            // ModelIdColumn
            // 
            this.ModelIdColumn.DataPropertyName = "Model";
            this.ModelIdColumn.HeaderText = "Model ";
            this.ModelIdColumn.Name = "ModelIdColumn";
            // 
            // Make
            // 
            this.Make.DataPropertyName = "Make";
            this.Make.HeaderText = "Make";
            this.Make.Name = "Make";
            // 
            // OwnerIdColumn
            // 
            this.OwnerIdColumn.DataPropertyName = "Owner";
            this.OwnerIdColumn.HeaderText = "Owner ";
            this.OwnerIdColumn.Name = "OwnerIdColumn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(213, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Car List";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Registration Number:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(124, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Model:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // newCarButton
            // 
            this.newCarButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newCarButton.Location = new System.Drawing.Point(386, 269);
            this.newCarButton.Name = "newCarButton";
            this.newCarButton.Size = new System.Drawing.Size(75, 23);
            this.newCarButton.TabIndex = 15;
            this.newCarButton.Text = "New Car ";
            this.newCarButton.UseVisualStyleBackColor = true;
            this.newCarButton.Click += new System.EventHandler(this.NewCarButton_Click);
            // 
            // modelComboBox
            // 
            this.modelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modelComboBox.FormattingEnabled = true;
            this.modelComboBox.Location = new System.Drawing.Point(174, 152);
            this.modelComboBox.Name = "modelComboBox";
            this.modelComboBox.Size = new System.Drawing.Size(242, 21);
            this.modelComboBox.TabIndex = 16;
            // 
            // makeComboBox
            // 
            this.makeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makeComboBox.FormattingEnabled = true;
            this.makeComboBox.Location = new System.Drawing.Point(174, 121);
            this.makeComboBox.Name = "makeComboBox";
            this.makeComboBox.Size = new System.Drawing.Size(242, 21);
            this.makeComboBox.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(129, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Make:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameTextBox.Location = new System.Drawing.Point(174, 207);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(242, 22);
            this.lastNameTextBox.TabIndex = 20;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameTextBox.Location = new System.Drawing.Point(174, 179);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(242, 22);
            this.firstNameTextBox.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(65, 179);
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
            this.label7.Location = new System.Drawing.Point(65, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Owner Last Name:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(263, 467);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Page Number:";
            // 
            // pageNumberComboBox
            // 
            this.pageNumberComboBox.FormattingEnabled = true;
            this.pageNumberComboBox.Location = new System.Drawing.Point(340, 464);
            this.pageNumberComboBox.Name = "pageNumberComboBox";
            this.pageNumberComboBox.Size = new System.Drawing.Size(121, 21);
            this.pageNumberComboBox.TabIndex = 29;
            this.pageNumberComboBox.SelectedIndexChanged += new System.EventHandler(this.PageNumberComboBox_SelectedIndexChangedAsync);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(24, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 31;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // CarScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 489);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pageNumberComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.makeComboBox);
            this.Controls.Add(this.modelComboBox);
            this.Controls.Add(this.newCarButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.carDataGridView);
            this.Controls.Add(this.carSearchButton);
            this.Controls.Add(this.registrationNumberTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CarScreen";
            this.Text = "Car Screen";
            ((System.ComponentModel.ISupportInitialize)(this.carDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox registrationNumberTextBox;
        private System.Windows.Forms.Button carSearchButton;
        private System.Windows.Forms.DataGridView carDataGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button newCarButton;
        private System.Windows.Forms.ComboBox modelComboBox;
        private System.Windows.Forms.ComboBox makeComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegistrationNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Make;
        private System.Windows.Forms.DataGridViewTextBoxColumn OwnerIdColumn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox pageNumberComboBox;
        private System.Windows.Forms.Button backButton;
    }
}

