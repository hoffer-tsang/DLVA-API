/*==============================================================================
 *
 * Main Menu Class
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

namespace Task_7
{
    public partial class MainMenu : Form
    {
        /// <summary>
        /// Main Menu Screen Constructor
        /// </summary>
        public MainMenu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Open Car Screen and hide current screen 
        /// </summary>
        /// <param name="sender"> car button </param>
        /// <param name="e"> button click</param>
        private void CarListButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var detailsWindow = new CarScreen())
            {
                detailsWindow.ShowDialog();
            }
        }
        /// <summary>
        /// Open Owner Screen and hide current screen 
        /// </summary>
        /// <param name="sender"> owner button </param>
        /// <param name="e"> button click</param>
        private void OwnerListButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var detailsWindow = new OwnerScreen())
            {
                detailsWindow.ShowDialog();
            }
        }
        /// <summary>
        /// Open Camera Screen and hide current screen 
        /// </summary>
        /// <param name="sender"> camera button </param>
        /// <param name="e"> button click</param>

        private void CameraListButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var detailsWindow = new CameraScreen())
            {
                detailsWindow.ShowDialog();
            }
        }
    }
}
