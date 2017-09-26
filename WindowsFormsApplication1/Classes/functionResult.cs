using System;
using System.Speech.Recognition;

namespace SampleComparer.Classes
{
    //This class is here so that we can return a "true/False" if a 
    //function works properly and message relating to the output.
    //As we have various classes, thhis makes it easier to pass multiple pieces of information back and forth
    public class functionResult
    {

        public Boolean Result { get; set; }
        public string Message { get; set; }
        public RecognitionResult recognitionResult { get; set; }

    }
}


