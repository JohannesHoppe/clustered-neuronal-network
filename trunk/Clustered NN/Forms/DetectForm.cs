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
    public partial class DetectForm : Form
    {
        /// <summary>
        /// holds the imported form elemets,
        /// you also need following controls: lblTooltip + pnlContentHolder !
        /// </summary>
        private ToolStripContainer _toolStripContainer = new ToolStripContainer();

        private CNNProjectHolder _cnnProjectHolder;
        
        private TrainForm _parentForm;



        public DetectForm(CNNProjectHolder cnnProjectHolder, TrainForm parentForm)
        {
            InitializeComponent();


            this._cnnProjectHolder = cnnProjectHolder;
            this._parentForm = parentForm;


            MasterForm.InitializeContent(
                 this,
                 this.lblTooltip,
                 this._toolStripContainer,
                 this.pnlContentHolder,
                 this._cnnProjectHolder);

            this._cnnProjectHolder.ProjectChanged += new CNNProjectHolder.ProjectChangedDelegate(CnnProjectHolder_ProjectChanged);

        }


        /// <summary>
        /// closes the parentForm
        /// </summary>
        private void DetectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parentForm.Close();
        }

        /// <summary>
        /// The project has changed, we have to rereference and rebuild some things
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CnnProjectHolder_ProjectChanged(object sender, EventArgs e)
        {
            // nothing to do
        }

    }
}