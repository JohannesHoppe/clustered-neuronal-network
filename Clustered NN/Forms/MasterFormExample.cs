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

    public partial class MasterFormExample : Form
    {
        public MainForm _parentForm;
        public CNNProject _cnnProject;

        private ToolStripContainer _toolStripContainer = new ToolStripContainer();


        public MasterFormExample()
        {
            InitializeComponent();

            MasterFormContents.InitializeContent(
                 this,
                 this.lblTooltip,
                 this._toolStripContainer,
                 this.pnlContentHolder);
        }


        public MasterFormExample(MainForm parentForm, CNNProject cnnProject) : this()
        {
            this._parentForm = parentForm;
            this._cnnProject = cnnProject;
        }





    }
}