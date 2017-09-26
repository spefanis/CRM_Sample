using System;

namespace SampleComparer.Classes
{

    //This class is here so that we can return a "true/False" if a 
    //function works properly and details relating to the result of the speaker verifications
    class speakerVerificationResult
    {


        public Boolean Result { get; set; }
        public string Status { get; set; }
        public string IdentifiedProfileId { get; set; }
        public string Confidence { get; set; }
        public string Message { get; set; }
    }
}
