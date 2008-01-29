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

        public CNNProjectHolder _cnnProjectHolder;
        private ToolStripContainer _toolStripContainer = new ToolStripContainer();


        public MasterFormExample()
        {
                        
            InitializeComponent();

            this._cnnProjectHolder = new CNNProjectHolder();


            MasterForm.InitializeContent(
                 this,
                 this.lblTooltip,
                 this._toolStripContainer,
                 this.pnlContentHolder,
                 this._cnnProjectHolder);
        }
    }
}