using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using BrainNet.NeuralFramework;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace Clustered_NN.Classes
{
    [Serializable]
    public class ImageDetectionNeuralNetwork
    {
        
        //A private variable to hold our network.
        [NonSerialized]
        private INeuralNetwork _network;

        [NonSerialized]
        private bool _stopTraining;
        [NonSerialized]
        private ProgressBar _pbTrain;
        [NonSerialized]
        private Label _lblTrainInfo;
        
        private DateTime _trainStart;
        private DateTime _networkInitialized;

        public Counter TotalTrainingRounds;


        /// <summary>
        /// Don't forget to set _pbTrain and _lblTrainInfo afterwards
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
        /// </summary>
        public void SetVars(ProgressBar pbTrain, Label lblTrainInfo)
        {            
            this._pbTrain = pbTrain;
            this._lblTrainInfo = lblTrainInfo;
        }


        /// <summary>
        /// Initialize our network for a pixel picture
        /// </summary>
        public void InitNetwork(Size size)
        {

            // Example: We are analyzing a 20x20 pixel picture, so let us take the number
            // of total inputs as 20 x 20 = 400 neurons

            // So let us initialize a 400-400-8 network. I.e, 400 neurons in
            // input layer, 400 neurons in hidden layer and 8 neurons in the output
            // layer to represent a ASCII character

            // the factory creates a Backward Propagation Neural Network
            BackPropNetworkFactory factory = new BackPropNetworkFactory();

            // the arralist holds the number of neurons in each layer
            ArrayList layers = new ArrayList();

            // 400 neurons in first layer
            layers.Add(size.Width * size.Height);
            // 400 neurons in the second layer (the second layer is the first hidden layer)
            layers.Add(size.Width * size.Height);
            // 8 neurons in the output layer
            layers.Add(8); //TODO: temp!

            // provide the arraylist as the parameter, to create a network
            _network = factory.CreateNetwork(layers);


            _networkInitialized = DateTime.Now;

        }


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
            _trainStart = DateTime.Now;

            // ShowProgress delegate
            helper.TrainingProgress += new NetworkHelper.TrainingProgressEventHandler(ShowProgress);
            
            // Start training
            // --- here we are going to wait --
            helper.Train(numberOfRounds, true); // <-- 

            // releasing
            helper.TrainingProgress -= new NetworkHelper.TrainingProgressEventHandler(ShowProgress);


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
        /// Save the network data to a file 
        /// </summary>
        public void SaveToFile()
        {
            NetworkSerializer serializer = new NetworkSerializer();

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.SupportMultiDottedExtensions = true;
            dialog.Filter = "Clustered NN XML Files|*.cnn.xml";
            dialog.DefaultExt = "cnn.xml";
            dialog.FileName = "network.cnn.xml";


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
        public void LoadFromFile()
        {
           
            NetworkSerializer serializer = new NetworkSerializer();

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.SupportMultiDottedExtensions = true;
            dialog.Filter = "Clustered NN XML Files|*.cnn.xml";


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



        /// <summary>
        /// Gets the time when the network was initialized.
        /// </summary>
        /// <value>Initialization time</value>
        public DateTime NetworkInitialized
        {
            get { return _networkInitialized;  }
        }


        /// <summary>
        /// Gets the network.
        /// </summary>
        /// <value>The network.</value>
        public INeuralNetwork Network
        {
            get { return _network; }

        }
    }
}
