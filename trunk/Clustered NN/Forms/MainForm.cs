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
    public partial class MainForm : Form
    {

        private CollectForm _collectForm;
        public CNNProject _cnnProject;
       
        public MainForm()
        {
            InitializeComponent();
            _cnnProject = new CNNProject();
        }


        /// <summary>
        /// Handles the Click event of the btn_start control.
        /// </summary>
        private void btn_start_Click(object sender, EventArgs e)
        {
            if (this._collectForm == null ||
                this._collectForm.IsDisposed)
            {
                this._collectForm = new CollectForm(this, _cnnProject);
            }
            this._collectForm.Show();

            this.Hide();
        }


        private void timerClickOnStart_Tick(object sender, EventArgs e)
        {
            timerClickOnStart.Stop();
            this.btn_start.PerformClick();
        }

    }
}