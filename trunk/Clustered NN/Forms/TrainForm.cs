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
    public partial class TrainForm : Form
    {

        private CNNProject _cnnProject;
        private CollectForm _parentForm;

        private ToolStripContainer _toolStripContainer = new ToolStripContainer();


        public TrainForm(CNNProject cnnProject, CollectForm parentForm)
        {
            this._cnnProject = cnnProject;
            this._parentForm = parentForm;
            
            InitializeComponent();

            MasterForm.InitializeContent(
                 this,
                 this.lblTooltip,
                 this._toolStripContainer,
                 this.pnlContentHolder);
        }

        private void TrainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parentForm.Close();
        }
    }
}