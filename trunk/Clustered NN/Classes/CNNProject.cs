using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Clustered_NN.Classes
{
    /// <summary>
    /// holds all configuration as well as usage data of a complete project
    /// </summary>
    public class CNNProject
    {
        // config
        public Size _imagePatternSize = new Size(20, 20);
        // config
        
        private ImageList _imlMatching;
        private ImageList _imlNotMatching;
        
        private Counter _matchingCounter;
        private Counter _notMatchingCounter;


        /// <summary>
        /// Initializes a new instance of the <see cref="CNNProject"/> class.
        /// </summary>
        public CNNProject()
        {

            this._imlMatching = new ImageList();
            this._imlMatching.ColorDepth = ColorDepth.Depth8Bit;
            this._imlMatching.ImageSize = this._imagePatternSize;
            this._imlMatching.TransparentColor = Color.Transparent;

            this._imlNotMatching = new ImageList();
            this._imlNotMatching.ColorDepth = ColorDepth.Depth8Bit;
            this._imlNotMatching.ImageSize = this._imagePatternSize;
            this._imlNotMatching.TransparentColor = Color.Transparent;

            this._matchingCounter = new Counter();
            this._notMatchingCounter = new Counter();
        }


        /// <summary>
        /// The global size of a training pattern
        /// </summary>
        /// <value>The size of the image pattern.</value>
        public Size ImagePatternSize
        {
            get
            {
                return _imagePatternSize;
            }
        }


        /// <summary>
        /// A list with matching images
        /// </summary>
        /// <value>The matching.</value>
        public ImageList Matching
        {
            get { return _imlMatching; }
            set { _imlMatching = value; }
        }


        /// <summary>
        /// Gets the matching counter.
        /// </summary>
        /// <value>The matching counter.</value>
        public Counter MatchingCounter
        {
            get { return _matchingCounter; }
        }


        /// <summary>
        ///A list with images that don't match
        /// </summary>
        /// <value>The not matching.</value>
        public ImageList NotMatching
        {
            get { return _imlNotMatching; }
            set { _imlNotMatching = value; }
        }


        /// <summary>
        /// Gets the not matching counter.
        /// </summary>
        /// <value>The not matching counter.</value>
        public Counter NotMatchingCounter
        {
            get { return _notMatchingCounter; }
        }


        /// <summary>
        /// Counter that is used to create unique numbers
        /// 
        /// Only increment operations are allowed for the counter
        /// (to avoid number collisions)
        /// </summary>
        public class Counter
        {
            private int _i;

            /// <summary>
            /// Initializes a new instance of the <see cref="Counter"/> class.
            /// </summary>
            public Counter() {
                _i = 0;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Counter"/> class.
            /// sets the current count
            /// </summary>
            /// <param name="startValue">The start value.</param>
            public Counter(int startValue) {
                _i = startValue;
            } 

            /// <summary>
            /// Gets the current count
            /// </summary>
            /// <value>The value.</value>
            public int Value
            {
                get { return _i; }
            }

            /// <summary>
            /// Increments this count and returns the new value
            /// </summary>
            /// <returns></returns>
            public int Increment() {
                
                return ++_i;
            }

            /// <summary>
            /// value = 0
            /// </summary>
            public void Reset() {
                _i = 0;
            }


            /// <summary>
            ///returns the Value
            /// </summary>
            /// <returns>just the Value</returns>
            public override string ToString()
            {
                return _i.ToString();
            }
        }


    }
}




class CounterOnlyAllowsIncrementsException : Exception
{

    /// <summary>
    /// Gets a message that describes the current exception.
    /// Thrown by CNNProject.MatchingCounter and CNNProject.NotMatchingCounter
    /// </summary>
    /// <value></value>
    /// <returns>The error message that explains the reason for the exception</returns>
    public override string Message
    {
        get
        {
            return "Only increment operations are allowed for the counter." + System.Environment.NewLine
                 + "(to avoid number collisions)";
        }
    }
}
