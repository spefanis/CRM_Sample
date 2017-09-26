//using System;
//using System.Collections.Generic;
//using System.IO;
//using NAudio.Wave;
////using Microsoft.CognitiveServices.SpeechRecognition;
//using SampleComparer.Forms;

//namespace SampleComparer.Classes
//{

//    ////NOT USED AT THIS STAGE
//    //public class projectOxfordSpeech


//    //{

//    //    /// <summary>
//    //    /// The data recognition client
//    //    /// </summary>
//    //    private DataRecognitionClient dataClient;

//    //    private Stream audioStream;

//    //    private string bingSpeakKey = "d26b954751b346bba59b249f25c07e3a";

//    //    private List<String> loglist = new List<String>();

//    //    frmLogin _refControl;
//    //    //This is required so that we can call the "PublicLogMessage" function on the main form
//    //    //This function will take the passed memory stream and convert it to Text. The output
//    //    //of this function should be the TEXT the user spoke.
//    //    public void convertToSpeech(Stream ms, frmLogin refControl)
//    //    {
//    //        audioStream = ms;
//    //        _refControl = refControl;
//    //        if (null == this.dataClient)
//    //        {

//    //            this.CreateDataRecoClient();
//    //        }

//    //        this.SendAudioHelper(audioStream);

//    //    }
//    //    /// <summary>
//    //    /// Creates a data client without LUIS intent support.
//    //    /// Speech recognition with data (for example from a file or audio source).  
//    //    /// The data is broken up into buffers and each buffer is sent to the Speech Recognition Service.
//    //    /// No modification is done to the buffers, so the user can apply their
//    //    /// own Silence Detection if desired.
//    //    /// </summary>
//    //    private void CreateDataRecoClient()
//    //    {
//    //        this.dataClient = SpeechRecognitionServiceFactory.CreateDataClient(
//    //            SpeechRecognitionMode.ShortPhrase,
//    //            "en-US",
//    //            bingSpeakKey);
//    //        this.dataClient.AuthenticationUri = @"https://westus.api.cognitive.microsoft.com/sts/v1.0/issuetoken";

//    //        //// Event handlers for speech recognition results
//    //        //if (this.Mode == SpeechRecognitionMode.ShortPhrase)
//    //        //{
//    //        //    
//    //        //}
//    //        //else
//    //        //{
//    //        //    this.dataClient.OnResponseReceived += this.OnDataDictationResponseReceivedHandler;
//    //        //}
//    //        this.dataClient.OnResponseReceived += this.OnDataShortPhraseResponseReceivedHandler;


//    //        this.dataClient.OnPartialResponseReceived += this.OnPartialResponseReceivedHandler;
//    //        this.dataClient.OnConversationError += this.OnConversationErrorHandler;
//    //    }

//    //    /// <summary>
//    //    /// Sends the audio helper.
//    //    /// </summary>
//    //    /// <param name="wavFileName">Name of the wav file.</param>
//    //    private void SendAudioHelper(Stream ms)
//    //    {
//    //        ms.Position = 0;
//    //        WaveStream pcmStream = new WaveFileReader(ms);

//    //        using (WaveStream memStream = new WaveFileReader(ms))
//    //        {
//    //            // Note for wave files, we can just send data from the file right to the server.
//    //            // In the case you are not an audio file in wave format, and instead you have just
//    //            // raw data (for example audio coming over bluetooth), then before sending up any 
//    //            // audio data, you must first send up an SpeechAudioFormat descriptor to describe 
//    //            // the layout and format of your raw audio data via DataRecognitionClient's sendAudioFormat() method.
//    //            int bytesRead = 0;
//    //            byte[] buffer = new byte[1024];

//    //            try
//    //            {
//    //                do
//    //                {
//    //                    // Get more Audio data to send into byte buffer.
//    //                    bytesRead = memStream.Read(buffer, 0, buffer.Length);

//    //                    // Send of audio data to service. 
//    //                    this.dataClient.SendAudio(buffer, bytesRead);
//    //                }
//    //                while (bytesRead > 0);
//    //            }
//    //            finally
//    //            {
//    //                // We are done sending audio.  Final recognition results will arrive in OnResponseReceived event call.
//    //                this.dataClient.EndAudio();
//    //            }
//    //        }
//    //    }

//    //    /// <summary>
//    //    /// Called when a final response is received;
//    //    /// </summary>
//    //    /// <param name="sender">The sender.</param>
//    //    /// <param name="e">The <see cref="SpeechResponseEventArgs"/> instance containing the event data.</param>
//    //    private void OnDataShortPhraseResponseReceivedHandler(object sender, SpeechResponseEventArgs e)
//    //    {
//    //        loglist.Add("--- OnDataShortPhraseResponseReceivedHandler ---");

//    //        // we got the final result, so it we can end the mic reco.  No need to do this
//    //        // for dataReco, since we already called endAudio() on it as soon as we were done
//    //        // sending all the data.
//    //        this.WriteResponseResult(e);

//    //    }

//    //    /// <summary>
//    //    /// Called when a partial response is received.
//    //    /// </summary>
//    //    /// <param name="sender">The sender.</param>
//    //    /// <param name="e">The <see cref="PartialSpeechResponseEventArgs"/> instance containing the event data.</param>
//    //    private void OnPartialResponseReceivedHandler(object sender, PartialSpeechResponseEventArgs e)
//    //    {
//    //        loglist.Add("--- Partial result received by OnPartialResponseReceivedHandler() ---");
//    //        loglist.Add(string.Format("{0}", e.PartialResult));
//    //        loglist.Add("");
//    //    }

//    //    /// <summary>
//    //    /// Called when an error is received.
//    //    /// </summary>
//    //    /// <param name="sender">The sender.</param>
//    //    /// <param name="e">The <see cref="SpeechErrorEventArgs"/> instance containing the event data.</param>
//    //    private void OnConversationErrorHandler(object sender, SpeechErrorEventArgs e)
//    //    {
//    //        loglist.Add("--- Error received by OnConversationErrorHandler() ---");
//    //        loglist.Add(string.Format("Error code: {0}", e.SpeechErrorCode.ToString()));
//    //        loglist.Add(string.Format("Error text: {0}", e.SpeechErrorText));
//    //        loglist.Add("");
//    //    }


//    //    /// <summary>
//    //    /// Writes the response result.
//    //    /// </summary>
//    //    /// <param name="e">The <see cref="SpeechResponseEventArgs"/> instance containing the event data.</param>
//    //    private void WriteResponseResult(SpeechResponseEventArgs e)
//    //    {
//    //        if (e.PhraseResponse.Results.Length == 0)
//    //        {
//    //            loglist.Add("No phrase response is available.");
//    //        }
//    //        else
//    //        {
//    //            loglist.Add("********* Final n-BEST Results *********");
//    //            for (int i = 0; i < e.PhraseResponse.Results.Length; i++)
//    //            {
//    //                loglist.Add(string.Format(
//    //                    "[{0}] Confidence={1}, Text=\"{2}\"",
//    //                    i,
//    //                    e.PhraseResponse.Results[i].Confidence,
//    //                    e.PhraseResponse.Results[i].DisplayText));
//    //            }

//    //            loglist.Add("");
//    //            //_refControl.Log(loglist);

//    //        }
//    //    }


//    //}
//}
