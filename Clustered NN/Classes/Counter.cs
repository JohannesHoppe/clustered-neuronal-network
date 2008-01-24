using System;
using System.Collections.Generic;
using System.Text;

namespace Clustered_NN.Classes
{
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
        public Counter()
        {
            _i = 0;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Counter"/> class.
        /// sets the current count
        /// </summary>
        /// <param name="startValue">The start value.</param>
        public Counter(int startValue)
        {
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
        /// <returns>the new value</returns>
        public int Increment()
        {

            return ++_i;
        }


        /// <summary>
        /// value = 0
        /// </summary>
        public void Reset()
        {
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
