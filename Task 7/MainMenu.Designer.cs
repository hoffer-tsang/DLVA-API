/*==============================================================================
 *
 * Main Menu Designer Class
 *
 * Copyright © Dorset Software Services Ltd, 2022
 *
 * TSD Section: P770 DataBase Driven Application Task Set 3 Task 7
 *
 *============================================================================*/
namespace Task_7
{
    partial class MainMenu
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
            this.label7 = new System.Windows.Forms.Label();
            this.carListButton = new System.Windows.Forms.Button();
            this.ownerListButton = new System.Windows.Forms.Button();
            this.cameraListButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 37);
            this.label7.TabIndex = 61;
            this.label7.Text = "Main Menu";
            // 
            // carListButton
            // 
            this.carListButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carListButton.Location = new System.Drawing.Point(61, 59);
            this.carListButton.Name = "carListButton";
            this.carListButton.Size = new System.Drawing.Size(75, 23);
            this.carListButton.TabIndex = 62;
            this.carListButton.Text = "Car List";
            this.carListButton.UseVisualStyleBackColor = true;
            this.carListButton.Click += new System.EventHandler(this.CarListButton_Click);
            // 
            // ownerListButton
            // 
            this.ownerListButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ownerListButton.Location = new System.Drawing.Point(61, 88);
            this.ownerListButton.Name = "ownerListButton";
            this.ownerListButton.Size = new System.Drawing.Size(75, 23);
            this.ownerListButton.TabIndex = 63;
            this.ownerListButton.Text = "Owner List";
            this.ownerListButton.UseVisualStyleBackColor = true;
            this.ownerListButton.Click += new System.EventHandler(this.OwnerListButton_Click);
            // 
            // cameraListButton
            // 
            this.cameraListButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraListButton.Location = new System.Drawing.Point(61, 117);
            this.cameraListButton.Name = "cameraListButton";
            this.cameraListButton.Size = new System.Drawing.Size(75, 23);
            this.cameraListButton.TabIndex = 64;
            this.cameraListButton.Text = "Camera List";
            this.cameraListButton.UseVisualStyleBackColor = true;
            this.cameraListButton.Click += new System.EventHandler(this.CameraListButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 157);
            this.Controls.Add(this.cameraListButton);
            this.Controls.Add(this.ownerListButton);
            this.Controls.Add(this.carListButton);
            this.Controls.Add(this.label7);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button carListButton;
        private System.Windows.Forms.Button ownerListButton;
        private System.Windows.Forms.Button cameraListButton;
    }
}
