using System;
using System.IO;
using NAudio.Wave;
using System.Speech.AudioFormat;
using System.Speech.Recognition;

namespace SampleComparer.Classes
{
    //This class is used to convert Spoken text to words. This uses the desktop system.speech and our implementation is to only try recognised known commands
    public class speechRecognition_system_speech
    {

        //This function will take the passed recording and string to compare againas and do a speect to text
        //INPUT: stream with recording, expected text
        //OUPUT: functionResult
        public functionResult convertToSpeechWithString(Stream ms, string requestString)
        {
            functionResult f = new functionResult();
            //Create a list of choices of phrases we expect
            Choices c = new Choices();
            //Add the exprected phrase to the choices
            c.Add(requestString);
            f = convertToSpeechwithChoices(ms, c);
            return f;
        }

        
        //This function converst the passed memory stream and compares it to the passed Choices
        //INPUT: stream with recording, Text choices to look for
        //OUPUT: FunctionResult
        //This does the speech recognition against the stream and coices
        public functionResult convertToSpeechwithChoices(Stream ms, Choices c)
        {
            functionResult f = new functionResult();
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));


            //Create a dictionary Grammar and assign the coices to it
            Grammar dictationGrammar = new DictationGrammar();
            var gb = new GrammarBuilder(c);
            var g = new Grammar(gb);

            //Load the grammar for the speech recognition engine
            recognizer.LoadGrammar(g);
            try
            {
                //Go to the beginning of the stream
                ms.Position = 0;
                //Conver the stream into a wave stream
                WaveStream pcmStream = new WaveFileReader(ms);
                recognizer.SetInputToAudioStream(pcmStream, new SpeechAudioFormatInfo(16000, AudioBitsPerSample.Sixteen, AudioChannel.Mono));
                //Do the speech recognition
                RecognitionResult result = recognizer.Recognize();

                f.Result = true;
                f.recognitionResult = result;

            }
            catch (Exception ex)
            {
                f.Message = "ERROR: " + ex.Message;
                f.Result = false;
            }
            finally
            {
                recognizer.UnloadAllGrammars();
            }
            return f;
        }


    }
}
