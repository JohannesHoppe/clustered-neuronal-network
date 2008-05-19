using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Clustered_NN.Classes;

namespace Clustered_NN.Forms
{
    public partial class WelcomeForm : Form
    {

        /// <summary>
        /// Shows a welcome screen
        /// </summary>
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}