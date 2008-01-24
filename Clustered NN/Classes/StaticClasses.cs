using System;
using System.Collections.Generic;
using System.Text;
using Clustered_NN.Forms;

namespace Clustered_NN.Classes
{
    static class StaticClasses
    {


        private static string _nl = System.Environment.NewLine;

        /// <summary>
        /// just our System.Environment.NewLine
        /// </summary>
        public static string NL
        {
            get { return _nl; }
        }


        /// <summary>
        /// Shows an exception in the ErrorBox
        /// </summary>
        /// <param name="e">The exception</param>
        static public void ShowException(Exception e)
        {
            ErrorBox errorBox = new ErrorBox();

            string message = e.Message + "\r\n" +
                            "Data: " + e.Data + "\r\n\r\n" +
                            "Stack Trace:\r\n" + e.StackTrace;

            errorBox.txtMessage.Text = message;
            errorBox.lblheadline.Text = "Exception";
            errorBox.ShowDialog();

            
        }


        /// <summary>
        /// Shows an error string in the ErrorBox
        /// </summary>
        static public void ShowError(string message)
        {
            ErrorBox errorBox = new ErrorBox();

            errorBox.txtMessage.Text = message;
            errorBox.lblheadline.Text = "Error";
            errorBox.ShowDialog();
        }
    }
}
