using System;
using NAudio.Wave;
using NAudio.Utils;
using System.IO;

namespace SampleComparer.Classes
{
    //This module is used for doing the recoding, playback and saving of the data from the microphone
    //This uses the NAudio dll and needs to be included within the application
    public class audioCapture
    {

        //This is the input from the microphone
        private static IWaveIn waveIn;
        //This is used for writing the data to the audio stream
        private static WaveFileWriter writer;

        //These are used to display the length of the audio sample
        public static DateTime recordingStarted;
        public static DateTime recordingEnded;


        //This function will create the audio into the passed stream.
        //We pass the required audio stream to to record to.
        //INPUT: the memoryStream to store the recorded audio in
        //OUTPUT: runctionResult
        public functionResult onRecord(ref Stream memoryStream)
        {
                        functionResult result = new functionResult();
            if (waveIn == null)
            {
                try
                {
                    waveIn = new WaveIn();
                    //Need to configure to 16kz and Mono for the library
                    waveIn.WaveFormat = new WaveFormat(16000, 1);

                    //Create a new memory stream
                    memoryStream = new MemoryStream();

                    //Allocate the writer to the wavefilre writer. Need to ifnoredisposestream as if we don't it caused some
                    //issues within the Project Oxford items
                    writer = new WaveFileWriter(new IgnoreDisposeStream(memoryStream), waveIn.WaveFormat);

                    waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(OnDataAvailable);
                    waveIn.RecordingStopped += new EventHandler<StoppedEventArgs>(OnRecordingStopped);

                    //Start recording from the input device
                    waveIn.StartRecording();

                    //store the date/time the recoriding started to be used for calculating the length
                    recordingStarted = DateTime.Now;
                    result.Result = true;
                    result.Message = ("onRecord - Sucess");
                }
                catch (Exception ex)
                {
                    result.Result = false;
                    result.Message = ("ERROR - onRecord - " + ex.ToString());
                    OnRecordingStopped(null, null);
                }

            }
            return result;
        }

        //As data becomes vailable, add it to the writer.
        //INPUT: sender and waveEventArgs
        //OUTPUT: 
        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {

            functionResult result = new functionResult();
            try
            {
                writer.Write(e.Buffer, 0, e.BytesRecorded);
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = "ERROR - OnDataAvailable - " + ex.ToString();
            }

        }

        //Once we stop recording, clean up and store recording end date/time
        //INPUT: sender and StoppedEventArgs
        //OUTPUT: 
        public void OnRecordingStopped(object sender, StoppedEventArgs e)
        {

            functionResult result = new functionResult();
            try
            {
                //Clean up everytyhing used within the recording
                if (waveIn != null)
                {
                    waveIn.Dispose();
                    waveIn = null;
                }

                if (writer != null)
                {
                    writer.Close();
                    writer = null;
                }

                //Store the date/time the recording ended to be used for calculating the sample length
                recordingEnded = DateTime.Now;
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = "ERROR - OnDataAvailable - " + ex.ToString();
            }
        }

        //Functionality that plays the passed stream back to the user.
        //This will "freeze" the UI untill playback is completed.
        //INPUT: memoryStream
        //OUTPUT: Function result
        public functionResult onPlayback(ref Stream ms)
        {
            functionResult result = new functionResult();

            try
            {
                //Go to position 0 of the audio stream
                ms.Position = 0;
                //Conver the stream to a wavefile and create the required heades
                using (WaveStream blockAlignedStream = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new WaveFileReader(ms))))
                {
                    using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                    {
                        //Start playing
                        waveOut.Init(blockAlignedStream);
                        waveOut.Play();
                        //While we are playing, prevent anything from happenign on the UI. Might be worth expanding this to have a "Stop" button
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            System.Threading.Thread.Sleep(100);
                        }
                    }
                }
                result.Result = true;
                result.Message = "onPlayback - OK";
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = "ERROR - onPlayback - " + ex.ToString();
            }
            return result;

        }

        //This function will save the passed audio stream to the file name specified. This wills save in the same directory as the application
        //INPUT: memory stream, Filename
        //OUPUT: FunctionResult
        public functionResult onSaveFile(ref Stream ms, string filename)
        {
            functionResult result = new functionResult();

            try
            {
                //Reset the audio stream position to 0, and save it to a new file.
                ms.Position = 0;
                using (WaveStream pcmStream = WaveFormatConversionStream.CreatePcmStream(new WaveFileReader(ms)))
                {
                    //step 3: write wave data into file with WaveFileWriter.
                    WaveFileWriter.CreateWaveFile(filename, pcmStream);
                }

                result.Result = true;
                result.Message = "onSaveFile - ok";
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = "ERROR - onSaveFile - " + ex.ToString();
            }
            return result;
        }


    }
}
