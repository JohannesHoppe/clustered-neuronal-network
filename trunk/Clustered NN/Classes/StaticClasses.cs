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



        #region list shuffle

        /// <summary>
        /// used by Shuffle
        /// </summary>
        private static Random _rand = new Random();

        /// <summary>
        /// Shuffles the specified list.
        /// </summary>
        /// <typeparam name="T">items of the list</typeparam>
        /// <param name="ilist">The list.</param>
        /*
        List<int> list = new List <int> ();

        for (int i = 0; i < 10; ++i) {
            list.Add (i);
        }

        Shuffle<int> (list);

        foreach (int i in list) {
            Console.WriteLine (i);
        }
        */
        public static void Shuffle<T>(IList<T> shuffledList)
        {
            int iIndex;
            T tTmp;
            for (int i = 1; i < shuffledList.Count; ++i)
            {
                iIndex = _rand.Next(i + 1);
                tTmp = shuffledList[i];
                shuffledList[i] = shuffledList[iIndex];
                shuffledList[iIndex] = tTmp;
            }
        }

        #endregion
    }
}
