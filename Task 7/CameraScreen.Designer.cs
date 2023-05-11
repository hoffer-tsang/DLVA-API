/*==============================================================================
 *
 * Camera Screen Designer Class
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
    partial class CameraScreen
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
            this.longitudeFromTextBox = new System.Windows.Forms.TextBox();
            this.cameraSearchButton = new System.Windows.Forms.Button();
            this.cameraDataGridView = new System.Windows.Forms.DataGridView();
            this.CameraTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoadNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LongitudeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LatitudeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.newSpeedCamearButton = new System.Windows.Forms.Button();
            this.latitudeToTextBox = new System.Windows.Forms.TextBox();
            this.latitudeFromTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.longitudeToTextBox = new System.Windows.Forms.TextBox();
            this.labela = new System.Windows.Forms.Label();
            this.newTrafficLightCameraButton = new System.Windows.Forms.Button();
            this.pageNumberComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.newANPRCamearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cameraDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(187, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Camera";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(166, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Camera Search Fields";
            // 
            // longitudeFromTextBox
            // 
            this.longitudeFromTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.longitudeFromTextBox.Location = new System.Drawing.Point(160, 88);
            this.longitudeFromTextBox.Name = "longitudeFromTextBox";
            this.longitudeFromTextBox.Size = new System.Drawing.Size(242, 22);
            this.longitudeFromTextBox.TabIndex = 2;
            // 
            // cameraSearchButton
            // 
            this.cameraSearchButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraSearchButton.Location = new System.Drawing.Point(203, 200);
            this.cameraSearchButton.Name = "cameraSearchButton";
            this.cameraSearchButton.Size = new System.Drawing.Size(99, 23);
            this.cameraSearchButton.TabIndex = 6;
            this.cameraSearchButton.Text = "Camera Search";
            this.cameraSearchButton.UseVisualStyleBackColor = true;
            this.cameraSearchButton.Click += new System.EventHandler(this.CameraSearchButton_ClickAsync);
            // 
            // cameraDataGridView
            // 
            this.cameraDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cameraDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CameraTypeColumn,
            this.RoadNameColumn,
            this.LongitudeColumn,
            this.LatitudeColumn});
            this.cameraDataGridView.Location = new System.Drawing.Point(26, 299);
            this.cameraDataGridView.Name = "cameraDataGridView";
            this.cameraDataGridView.Size = new System.Drawing.Size(437, 163);
            this.cameraDataGridView.TabIndex = 7;
            this.cameraDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CameraDataGridView_CellClickAsync);
            // 
            // CameraTypeColumn
            // 
            this.CameraTypeColumn.DataPropertyName = "CameraType";
            this.CameraTypeColumn.HeaderText = "Camera Type";
            this.CameraTypeColumn.Name = "CameraTypeColumn";
            // 
            // RoadNameColumn
            // 
            this.RoadNameColumn.DataPropertyName = "RoadName";
            this.RoadNameColumn.HeaderText = "Road Name";
            this.RoadNameColumn.Name = "RoadNameColumn";
            // 
            // LongitudeColumn
            // 
            this.LongitudeColumn.DataPropertyName = "Longitude";
            this.LongitudeColumn.HeaderText = "Longitude";
            this.LongitudeColumn.Name = "LongitudeColumn";
            // 
            // LatitudeColumn
            // 
            this.LatitudeColumn.DataPropertyName = "Latitude";
            this.LatitudeColumn.HeaderText = "Latitude";
            this.LatitudeColumn.Name = "LatitudeColumn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(199, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Camera List";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Longitude From:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // newSpeedCamearButton
            // 
            this.newSpeedCamearButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newSpeedCamearButton.Location = new System.Drawing.Point(179, 270);
            this.newSpeedCamearButton.Name = "newSpeedCamearButton";
            this.newSpeedCamearButton.Size = new System.Drawing.Size(124, 23);
            this.newSpeedCamearButton.TabIndex = 15;
            this.newSpeedCamearButton.Text = "New Speed Camera";
            this.newSpeedCamearButton.UseVisualStyleBackColor = true;
            this.newSpeedCamearButton.Click += new System.EventHandler(this.NewSpeedCameraButton_Click);
            // 
            // latitudeToTextBox
            // 
            this.latitudeToTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latitudeToTextBox.Location = new System.Drawing.Point(160, 172);
            this.latitudeToTextBox.Name = "latitudeToTextBox";
            this.latitudeToTextBox.Size = new System.Drawing.Size(242, 22);
            this.latitudeToTextBox.TabIndex = 20;
            // 
            // latitudeFromTextBox
            // 
            this.latitudeFromTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latitudeFromTextBox.Location = new System.Drawing.Point(160, 144);
            this.latitudeFromTextBox.Name = "latitudeFromTextBox";
            this.latitudeFromTextBox.Size = new System.Drawing.Size(242, 22);
            this.latitudeFromTextBox.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(73, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Latitude From:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(87, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Latitude To:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // longitudeToTextBox
            // 
            this.longitudeToTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.longitudeToTextBox.Location = new System.Drawing.Point(160, 116);
            this.longitudeToTextBox.Name = "longitudeToTextBox";
            this.longitudeToTextBox.Size = new System.Drawing.Size(242, 22);
            this.longitudeToTextBox.TabIndex = 24;
            // 
            // labela
            // 
            this.labela.AutoSize = true;
            this.labela.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labela.Location = new System.Drawing.Point(76, 119);
            this.labela.Name = "labela";
            this.labela.Size = new System.Drawing.Size(78, 13);
            this.labela.TabIndex = 25;
            this.labela.Text = "Longitude To:";
            this.labela.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // newTrafficLightCameraButton
            // 
            this.newTrafficLightCameraButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newTrafficLightCameraButton.Location = new System.Drawing.Point(309, 270);
            this.newTrafficLightCameraButton.Name = "newTrafficLightCameraButton";
            this.newTrafficLightCameraButton.Size = new System.Drawing.Size(154, 23);
            this.newTrafficLightCameraButton.TabIndex = 26;
            this.newTrafficLightCameraButton.Text = "New Traffic Light Camera";
            this.newTrafficLightCameraButton.UseVisualStyleBackColor = true;
            this.newTrafficLightCameraButton.Click += new System.EventHandler(this.NewTrafficLightCameraButton_Click);
            // 
            // pageNumberComboBox
            // 
            this.pageNumberComboBox.FormattingEnabled = true;
            this.pageNumberComboBox.Location = new System.Drawing.Point(342, 468);
            this.pageNumberComboBox.Name = "pageNumberComboBox";
            this.pageNumberComboBox.Size = new System.Drawing.Size(121, 21);
            this.pageNumberComboBox.TabIndex = 27;
            this.pageNumberComboBox.SelectedIndexChanged += new System.EventHandler(this.PageNumberComboBox_SelectedIndexChangedAsync);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(265, 471);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Page Number:";
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(26, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 32;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // newANPRCamearButton
            // 
            this.newANPRCamearButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newANPRCamearButton.Location = new System.Drawing.Point(30, 270);
            this.newANPRCamearButton.Name = "newANPRCamearButton";
            this.newANPRCamearButton.Size = new System.Drawing.Size(124, 23);
            this.newANPRCamearButton.TabIndex = 33;
            this.newANPRCamearButton.Text = "New ANPR Camera";
            this.newANPRCamearButton.UseVisualStyleBackColor = true;
            this.newANPRCamearButton.Click += new System.EventHandler(this.NewANPRCamearButton_Click);
            // 
            // CameraScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 493);
            this.Controls.Add(this.newANPRCamearButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pageNumberComboBox);
            this.Controls.Add(this.newTrafficLightCameraButton);
            this.Controls.Add(this.labela);
            this.Controls.Add(this.longitudeToTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.latitudeFromTextBox);
            this.Controls.Add(this.latitudeToTextBox);
            this.Controls.Add(this.newSpeedCamearButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cameraDataGridView);
            this.Controls.Add(this.cameraSearchButton);
            this.Controls.Add(this.longitudeFromTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CameraScreen";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.cameraDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox longitudeFromTextBox;
        private System.Windows.Forms.Button cameraSearchButton;
        private System.Windows.Forms.DataGridView cameraDataGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button newSpeedCamearButton;
        private System.Windows.Forms.TextBox latitudeToTextBox;
        private System.Windows.Forms.TextBox latitudeFromTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox longitudeToTextBox;
        private System.Windows.Forms.Label labela;
        private System.Windows.Forms.Button newTrafficLightCameraButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn CameraTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoadNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LongitudeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LatitudeColumn;
        private System.Windows.Forms.ComboBox pageNumberComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button newANPRCamearButton;
    }
}

