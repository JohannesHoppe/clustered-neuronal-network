using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using BrainNet.NeuralFramework;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Threading;

namespace Clustered_NN.Classes
{
    /// <summary>
    /// Wrapper for the BrainNet Neural Framework, more networks are planned
    /// 
    /// TODO: intern network network serialization
    /// </summary>
    [Serializable]
    public class ImageDetectionNeuralNetwork
    {
        
        //A private variable to hold our network.
        [NonSerialized]
        private INeuralNetwork _network;

        [NonSerialized]
        private bool _stopTraining;
        [NonSerialized]
        private bool _stopTrainingSilently;
        [NonSerialized]
        private ProgressBar _pbTrain;
        [NonSerialized]
        private Label _lblTrainInfo;
        [NonSerialized]
        private List<Size> _oberserveSizes;
        
        [NonSerialized]
        private List<ImageDetectionNeuralNetworkThreadWork> _threadWorkList;
        
        [NonSerialized]
        private List<Thread> _threadList;


        private DateTime _trainStart;
        private DateTime _networkInitialized;

        /// <summary>
        /// the total number of solved training rounds
        /// </summary>
        public Counter TotalTrainingRounds;


        /// <summary>
        /// Don't forget to set _pbTrain (ProgressBar) and _lblTrainInfo (Label) afterwards
        /// </summary>
        public ImageDetectionNeuralNetwork()
        {
            TotalTrainingRounds = new Counter();

        }


        /// <summary>
        /// Ready to go (not used atm)
        /// </summary>
        public ImageDetectionNeuralNetwork(ProgressBar pbTrain, Label lblTrainInfo)
        {
            SetVars(pbTrain, lblTrainInfo);
            TotalTrainingRounds = new Counter();
        }


        /// <summary>
        /// Sets the vars.
        /// all recognized sizes are defined here
        /// 
        /// TODO: for development (and because of a silly bug) only one size is active
        /// </summary>
        public void SetVars(ProgressBar pbTrain, Label lblTrainInfo)
        {            
            this._pbTrain = pbTrain;
            this._lblTrainInfo = lblTrainInfo;

            _oberserveSizes = new List<Size>();
            //_oberserveSizes.Add(new Size(20, 20));
            //_oberserveSizes.Add(new Size(40, 40));
            //_oberserveSizes.Add(new Size(60, 60));
            //_oberserveSizes.Add(new Size(80, 80));
            //_oberserveSizes.Add(new Size(100, 100));
            //_oberserveSizes.Add(new Size(120, 120));
            _oberserveSizes.Add(new Size(150, 150));
            //_oberserveSizes.Add(new Size(240, 240));
        }


        /// <summary>
        /// Initialize our network for a pixel picture
        /// </summary>
        public void InitNetwork(Size size)
        {

            // Example: We are analyzing a 20x20 pixel picture, so let us take the number
            // of total inputs as 20 x 20 = 400 neurons

            // So let us initialize a 400-400-1 network. I.e, 400 neurons in
            // input layer, 400 neurons in hidden layer and 1 neuron in the output
            // layer to represent a boolean value

            // the factory creates a Backward Propagation Neural Network
            BackPropNetworkFactory factory = new BackPropNetworkFactory();

            // the arralist holds the number of neurons in each layer
            ArrayList layers = new ArrayList();

            // 400 neurons in first layer
            layers.Add(size.Width * size.Height);
            // 400 neurons in the second layer (the second layer is the first hidden layer)
            layers.Add(size.Width * size.Height);
            // 1 neurons in the output layer
            layers.Add(1);

            // provide the arraylist as the parameter, to create a network
            _network = factory.CreateNetwork(layers);

            
            _networkInitialized = DateTime.Now;
            TotalTrainingRounds.Reset();

        }

        #region network training

        /// <summary>
        /// just used to store the training data temporarely
        /// </summary>
        private class TrainingItem
        {
            private Image _image;
            
            /// <summary>
            /// Gets or sets the image.
            /// </summary>
            /// <value>The image.</value>
            public Image Image
            {
                get { return _image; }
                set { _image = value; }
            }


            private bool _matching;

            /// <summary>
            /// Gets or sets a value indicating whether the caontaining image is a matching one
            /// </summary>
            /// <value><c>true</c> if matchin; otherwise, <c>false</c>.</value>
            public bool Matching
            {
                get { return _matching; }
                set { _matching = value; }
            }


            /// <summary>
            /// Initializes a new instance of the <see cref="TrainingItem"/> class.
            /// Values are assigned
            /// </summary>
            /// <param name="image">The image.</param>
            /// <param name="matching">if set to <c>true</c> [matching].</param>
            public TrainingItem(Image image, bool matching)
            {
                _image = image;
                _matching = matching;
            }
        }


        /*
        /// <summary>
        /// Routine to train the network
        /// </summary>
        /// <param name="cnnProject">The CNN project.</param>
        /// <param name="numberOfRounds">The number of training rounds.</param>
        public void TrainPattern(CNNProject cnnProject, long numberOfTrainingRounds)
        {
            
            List<TrainingItem> trainingItemList = new List<TrainingItem>();
            ImageList imgList;
            bool matching; 

            // fills the list
            for (int i = 0; i < 2; i++)
            {

                // at first we include the first the matching images
                if (i == 0)
                {
                    imgList = cnnProject.Matching;
                    matching = true;
                }
                // and then the not matching images
                else
                {
                    imgList = cnnProject.Matching;
                    matching = false;
                }

                foreach (Image img in imgList.Images)
                {
                    PatternProcessingHelper patHelper = new PatternProcessingHelper();
                    ImageProcessingHelper imgHelper = new ImageProcessingHelper();


                    Debug.WriteLine("Added : " + patHelper.PatternFromArraylist(imgHelper.ArrayListFromImage(img)));

                }
            }


            // list get shuffled
            trainingItemList.i

            // Let's go!
            _trainStart = DateTime.Now;

        }
        */


        /// <summary>
        /// Routine to train the network
        /// with a NetworkHelper object
        /// </summary>
        public void TrainPattern(CNNProject cnnProject, long numberOfRounds)
        {

            // Create a helper object
            NetworkHelper helper = new NetworkHelper(_network);

            // A helper object helps you to train the network more
            // efficiently. First of all, you add each training data to the
            // Training Queue using the helper. For this, you can use the
            // AddTrainingData method of the helper

            // Next, you can call the Train function of the helper to
            // randomize entries to the training queue and train the network more
            // efficiently

            // Step 1 - Add the training data to the helper
            for (int i = 0; i < 2; i++)
            {
                ImageList imgList;
                long asciiVal;

                // Matching => Yes
                if (i == 0)
                {
                    imgList = cnnProject.Matching;
                    asciiVal = System.Convert.ToInt32('Y');
                }
                // Not Matching => No
                else
                {
                    imgList = cnnProject.Matching;
                    asciiVal = System.Convert.ToInt32('N');
                }



                foreach (Image img in imgList.Images)
                {

                    //The AddTrainingData method of Network helper helps you to
                    //add an image and its corresponding ASCII value directly

                    PatternProcessingHelper patHelper = new PatternProcessingHelper();
                    ImageProcessingHelper imgHelper = new ImageProcessingHelper();


                    Debug.WriteLine("Added : " + patHelper.PatternFromArraylist(imgHelper.ArrayListFromImage(img)));

                    helper.AddTrainingData(img, asciiVal);
                }
            }

            //Step 2 - Train the network using the helper

            StopTraining = false;
            StopTrainingSilently = false;

            _trainStart = DateTime.Now;

            // ShowProgress delegate
            helper.TrainingProgress += new NetworkHelper.TrainingProgressEventHandler(ShowProgress);
            
            // Start training
            // --- here we are going to wait --
            helper.Train(numberOfRounds, true); // <-- 

            // releasing
            helper.TrainingProgress -= new NetworkHelper.TrainingProgressEventHandler(ShowProgress);


            if (StopTrainingSilently == false)
            {

                MessageBox.Show("Training of the neuronal network completed at " + DateTime.Now,
                                "Training Completed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }



        ///<summary>
        /// Call back to show the progress bar, used from the TrainPattern function 
        ///</summary>
        public void ShowProgress(long CurrentRound, long MaxRound, ref bool cancel)
        {

            if (_pbTrain == null || _lblTrainInfo == null)
            {
                throw new Exception("Please use SetVars() to set _pbTrain and _lblTrainInfo!"); 
            }

            
            _pbTrain.Maximum = Convert.ToInt32(MaxRound);
            _pbTrain.Value = Convert.ToInt32(CurrentRound);

            
            TotalTrainingRounds.Increment();


            TimeSpan completed = DateTime.Now - _trainStart;
            double oneRoundNeeds = (completed.TotalSeconds / CurrentRound);
            int allRoundsNeed = Convert.ToInt32((MaxRound - CurrentRound) * oneRoundNeeds);
            TimeSpan remaining = new TimeSpan(0, 0, allRoundsNeed);


            _lblTrainInfo.Text = CurrentRound + " / " + MaxRound + " rounds finished" + StaticClasses.NL
                                + "Completed: " + completed.Hours + " hours : " + completed.Minutes + " minutes : " + completed.Seconds + " seconds" + StaticClasses.NL
                                + "Remaining: " + remaining.Hours + " hours : " + remaining.Minutes + " minutes : " + remaining.Seconds + " seconds" + StaticClasses.NL;



            //Check whether our used clicked the cancel button
            if (this.StopTraining == true)
            {
                cancel = true;
            }

        }


        /// <summary>
        /// Should be set to TRUE when ever the training should stop
        /// </summary>
        /// <value><c>true</c> if true stop training; otherwise leave it false</value>
        public bool StopTraining
        {
            get { return _stopTraining; }
            set { _stopTraining = value; }
        }


        /// <summary>
        /// Should be set to true when the training should stop without a message
        /// (if we reload the project while training)
        /// </summary>
        /// <value><c>true</c> if true stop training; otherwise leave it false</value>
        public bool StopTrainingSilently
        {
            get { return _stopTrainingSilently; }
            set { _stopTrainingSilently = value; }
        }

        #endregion


        #region detect network - thread contest


        /// <summary>
        /// Starts the pattern process
        /// </summary>
        /// <param name="pictureBox">The picture box.</param>
        /// <param name="imagePatternSize">Working size of a detection pattern</param>
        public void StartDetectPattern(ScanSelectingPictureBox pictureBox, Size imagePatternSize,
                                       PictureBox currentImage, PictureBox currentImageSmall)
        {
            try
            {

                DetectPatternDelegate detectPatternDelegate = new DetectPatternDelegate(DetectPattern);


                _threadWorkList = new List<ImageDetectionNeuralNetworkThreadWork>();
                _threadList = new List<Thread>();

                int i = 0;
                foreach (Size oberserveSize in _oberserveSizes)
                {
                    i++;

                    ImageDetectionNeuralNetworkThreadWork threadWork =
                        new ImageDetectionNeuralNetworkThreadWork(pictureBox.Image,
                                                                  imagePatternSize,
                                                                  oberserveSize,
                                                                  10,
                                                                  detectPatternDelegate,
                                                                  currentImage,
                                                                  currentImageSmall);
                    threadWork.Name = "Thread " + i;
                    _threadWorkList.Add(threadWork);

                    Thread thread = new Thread(new ThreadStart(threadWork.ThreadWork));
                    thread.Start();

                    _threadList.Add(thread);
                }
          
            }
            catch (ImageNotInitializedException ex)
            {
                StaticClasses.ShowError(ex.Message);
            }
        }


        public delegate bool DetectPatternDelegate(Image detectImage);


        /// <summary>
        /// Routine to detect an image (right sized!)
        /// </summary>
        public bool DetectPattern(Image detectImage)
        {

            long asciiValMatching = System.Convert.ToInt32('Y');
            long asciiValNotMatching = System.Convert.ToInt32('N');


            //Step 1 : Convert the image to detect to an arraylist
            ImageProcessingHelper imgHelper = new ImageProcessingHelper();
            ArrayList input = null;

            input = imgHelper.ArrayListFromImage(detectImage);

            //Step 2: Run the network and obtain the output
            ArrayList output = null;
            output = _network.RunNetwork(input);

            //Step 3: Convert the output arraylist to long value
            //so that we will get the ascii character code
            PatternProcessingHelper patternHelper = new PatternProcessingHelper();
            long asciiVal = patternHelper.NumberFromArraylist(output);


            if (asciiVal == asciiValMatching)
            {
                return true;
            }
            else if (asciiVal == asciiValNotMatching)
            {
                return false;
            }
            else
            {
                //TODO: damn this should not happen :-(
                return false;
            }
        }

        #endregion


        #region file IO

        /// <summary>
        /// Save the network data to a file 
        /// </summary>
        public void SaveToFile(string fileFilter, string fileExt, string fileName)
        {
            NetworkSerializer serializer = new NetworkSerializer();

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.SupportMultiDottedExtensions = true;
            dialog.Filter = fileFilter;
            dialog.DefaultExt = fileExt;
            dialog.FileName = fileName;


            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    serializer.SaveNetwork(dialog.FileName, _network);
                    MessageBox.Show("Saved to file " + dialog.FileName,
                                    "File Saved",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    StaticClasses.ShowError("Error: Invalid File? " + ex.Message);
                }
            }
        }


        /// <summary>
        /// Loads the network data from file.
        /// </summary>
        public void LoadFromFile(string fileFilter)
        {
           
            NetworkSerializer serializer = new NetworkSerializer();

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.SupportMultiDottedExtensions = true;
            dialog.Filter = fileFilter;


            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    serializer.LoadNetwork(dialog.FileName, ref _network);
                    MessageBox.Show("File " + dialog.FileName + " loaded",
                                    "File Loaded",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    StaticClasses.ShowError("Error: Invalid File? " + ex.Message);
                }
            }
        }

        #endregion


        /// <summary>
        /// Gets the time when the network was initialized.
        /// </summary>
        /// <value>Initialization time</value>
        public DateTime NetworkInitialized
        {
            get { return _networkInitialized;  }
        }


        /// <summary>
        /// Gets or sets the network.
        /// </summary>
        /// <value>The network.</value>
        public INeuralNetwork Network
        {
            get { return _network; }
            set { _network = value; }

        }


        /// <summary>
        /// Gets the thread work list.
        /// </summary>
        /// <value>The thread work list.</value>
        public List<ImageDetectionNeuralNetworkThreadWork> ThreadWorkList
        {
            get { return _threadWorkList; }
        }

    }
}
