using System;
using System.IO;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.ProjectOxford.SpeakerRecognition;
using Microsoft.ProjectOxford.SpeakerRecognition.Contract;
using Microsoft.ProjectOxford.SpeakerRecognition.Contract.Identification;


namespace SampleComparer.Classes
{
    //This is the library that does the Speaker recognition. This is based on the Microsoft Project Oxford API and a lot of the code below is replicated form their project
    //and adapted to use within this applicaiton

    class projectOxfordSpeaker
    {
        private SpeakerIdentificationServiceClient _serviceClient;
        private string _subscriptionKey = "aa0b9b0624be47298f0dbe4e2e94200a";


        public projectOxfordSpeaker()
        {
            if (_serviceClient == null)
            {
                _serviceClient = new SpeakerIdentificationServiceClient(_subscriptionKey);
            }
        }

        //This loads the speakers from the Web Server and adds them to the grid. This will also load the "Name" for the user if it exists in the data.xml file
        //INPUT:
        //OUTPUT: Datatable
        public async Task<DataTable> UpdateAllSpeakers()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("SpeakerID", typeof(string));
            dt.Columns.Add("EnrollmentStatus", typeof(string));
            dt.Columns.Add("RemainingTime", typeof(string));
            dt.Columns.Add("SpeakerName", typeof(string));

            try
            {

                //Retrieve the profiles from the server
                Profile[] allProfiles = await _serviceClient.GetProfilesAsync();

                //Load the data from the database
                Database db = new Database();
                List<UserRecord> users = db.getUserList();

                //Add each profile loaded
                foreach (Profile profile in allProfiles)
                {
                    //Check if the ProfileID exists in the list
                    //Using LINQ we can search the users list for a matching profileID
                    UserRecord foundRow = users.Find(i => i.PROFILEID == profile.ProfileId.ToString());
                    //Create a temp variable for the username
                    string username = "";
                    int ID = -1;
                    //Only try assign the UserName to the variable if we found matching row (handles if we don't have a valid GUID)
                    if (foundRow != null)
                    {
                        username = foundRow.NAME;
                        ID = foundRow.ID;
                    }
                    //Add the data to the datatable
                    if (ID >= 0)
                    {
                        dt.Rows.Add(ID, profile.ProfileId, profile.EnrollmentStatus, profile.RemainingEnrollmentSpeechSeconds, username);
                    }
                    else
                    {
                        dt.Rows.Add(DBNull.Value, profile.ProfileId, profile.EnrollmentStatus, profile.RemainingEnrollmentSpeechSeconds, username);
                    }
                }

                return dt;
            }
            catch (GetProfileException ex)
            {
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }

        }

        //This Creates a new speaker in the database
        //INPUT:
        //OUTPUT: functionResult
        public async Task<functionResult> addSpeaker()
        {
            functionResult result = new functionResult();

            //If the _serviceClient is null, create it with the subsciption key stored
            if (_serviceClient == null)
            {
                _serviceClient = new SpeakerIdentificationServiceClient(_subscriptionKey);
            }
            try
            {
                //Create the new profile and assign it to the Profile Tag
                CreateProfileResponse creationResponse = await _serviceClient.CreateProfileAsync("en-us");
                Profile profile = await _serviceClient.GetProfileAsync(creationResponse.ProfileId);
                result.Result = true;
                result.Message = profile.ProfileId.ToString();
            }
            catch (CreateProfileException ex)
            {
                result.Result = false;
                result.Message = "Error Creating The Profile: " + ex.Message.ToString();
            }
            catch (GetProfileException ex)
            {
                result.Result = false;
                result.Message = "Error Retrieving The Profile: " + ex.Message.ToString();
            }
            catch (Exception ex)
            {

                result.Result = false;
                result.Message = "Error: " + ex.Message.ToString();
            }
            return result;
        }

        //This function will remove the passed GUID from the database
        //INPUT: speaker GUID
        //OUTPUT: functionResult
        public async Task<functionResult> removeSpeaker(Guid speakerID)
        {
            functionResult result = new functionResult();
            Console.WriteLine(speakerID.ToString());
            try
            {
                //Remove the speaker from the database
                await _serviceClient.DeleteProfileAsync(speakerID);
                result.Result = true;
                result.Message = "The selected profile has been remove";

            }
            catch (CreateProfileException ex)
            {

                result.Result = false;
                result.Message = "Profile Creation Error: " + ex.Message;
            }
            catch (DeleteProfileException ex)
            {
                //If the error contains "speakerInvalid" we can assume the speakerID doesn't exist. So return can be true to continue removing from the database
                if (ex.Message.ToUpper().Contains("SPEAKERINVALID"))
                {
                    result.Result = true;
                    result.Message = "Missing Profile: " + ex.ToString();

                }
                else
                {
                    result.Result = false;
                    result.Message = "Error deleting The Profile: " + ex.ToString();

                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.Message = "Error: " + ex.Message + " - " + ex.GetType();
            }
            return result;
        }

        //This functionality will used the passed audio stream to enroll a speaker with the passed GUID
        //INPUT: enrollment audio sample, Speaker ID, Sample Length
        //OUTPUT: FunctionResult
        public async Task<functionResult> enrollSpeaker(Stream ms, Guid speakerID, double sampleLength)
        {
            functionResult result = new functionResult();
            //Ensure the stream isnot null
            if (ms != null)
            {
                //Ensure we have a sample lenght of more than 5 seconds to enroll
                if (sampleLength > 5)
                {
                    try
                    {
                        {
                            OperationLocation processPollingLocation;
                            using (Stream audioStream = ms)
                            {
                                audioStream.Position = 0;
                                processPollingLocation = await _serviceClient.EnrollAsync(audioStream, speakerID, true);
                            }

                            EnrollmentOperation enrollmentResult;
                            int numOfRetries = 10;
                            TimeSpan timeBetweenRetries = TimeSpan.FromSeconds(5.0);
                            while (numOfRetries > 0)
                            {
                                await Task.Delay(timeBetweenRetries);
                                enrollmentResult = await _serviceClient.CheckEnrollmentStatusAsync(processPollingLocation);

                                if (enrollmentResult.Status == Status.Succeeded)
                                {
                                    break;
                                }
                                else if (enrollmentResult.Status == Status.Failed)
                                {
                                    throw new EnrollmentException(enrollmentResult.Message);
                                }
                                numOfRetries--;
                            }
                            if (numOfRetries <= 0)
                            {
                                result.Result = false;
                                result.Message = ("Enrollment Error: Enrollment operation timeout.");
                            }
                            result.Result = true;
                            result.Message = ("User has been enrolled successfully");
                        }
                    }
                    catch (EnrollmentException ex)
                    {
                        result.Result = false;
                        result.Message = ("Enrollment Error: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        result.Result = false;
                        result.Message = ("Error: " + ex.Message);
                    }
                }
                else
                {
                    result.Result = false;
                    result.Message = ("Enroll: Audio sample need to be > 5 seconds");

                }
            }
            else
            {
                result.Result = false;
                result.Message = ("Enroll: No valid sample recorded");
            }
            return result;
        }

        //This functionality will Verify the speaker with the passed Audio stream and the passed GUID
        //INPUT: Audio stream to veridy, Speaker ID, SampleLength
        //speakerVerificatioResult
        public async Task<speakerVerificationResult> verifySpeaker(Stream ms, Guid speakerID, double sampleLength)
        {
            speakerVerificationResult result = new speakerVerificationResult();

            if (sampleLength > 2.5)
            {
                try
                {
                    
                    //If the audio stream is emtpy, then trow an error
                    if (ms == null)
                        throw new Exception("No Audio stream found.");
                    
                    //Create a array of prifiles to be used. We only authenticate against one, 
                    //In the future we can add multiple speakers into this array and then the system could tell us "who" is speaking, but this isn't what
                    //the aim of this project is. We only want to get true/false if the current speaker is who we expect is is
                    Guid[] testProfileIds = new Guid[1];

                    //Assign the selected enrollment item to the array
                    testProfileIds[0] = speakerID;

                    OperationLocation processPollingLocation;
                    using (Stream audioStream = ms)
                    {
                        audioStream.Position = 0;
                        processPollingLocation = await _serviceClient.IdentifyAsync(audioStream, testProfileIds, true);
                    }

                    IdentificationOperation identificationResponse = null;
                    int numOfRetries = 10;
                    TimeSpan timeBetweenRetries = TimeSpan.FromSeconds(5.0);
                    while (numOfRetries > 0)
                    {
                        await Task.Delay(timeBetweenRetries);
                        identificationResponse = await _serviceClient.CheckIdentificationStatusAsync(processPollingLocation);

                        if (identificationResponse.Status == Status.Succeeded)
                        {
                            break;
                        }
                        else if (identificationResponse.Status == Status.Failed)
                        {
                            throw new IdentificationException(identificationResponse.Message);
                        }
                        numOfRetries--;
                    }
                    if (numOfRetries <= 0)
                    {
                        throw new IdentificationException("Identification operation timeout.");
                    }

                    result.Status = identificationResponse.Status.ToString();
                    result.IdentifiedProfileId = identificationResponse.ProcessingResult.IdentifiedProfileId.ToString();
                    result.Confidence = identificationResponse.ProcessingResult.Confidence.ToString();

                    result.Result = true;
                    result.Message = ("VerifciationResult passed back");

                }
                catch (IdentificationException ex)
                {
                    result.Result = false;
                    if (ex.Message.ToUpper().Contains("SPEAKERINVALID"))
                    {
                        result.Message = "Your voice sample could not be verified against the enrolled sample";
                    }
                    else
                    {
                        result.Message = ("Speaker Identification Error: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    result.Result = false;
                    result.Message = ("Error: " + ex.Message);
                }
            }
            else
            {
                result.Result = false;
                result.Message = ("Enroll: Audio sample need to be > 2.5 seconds");

            }
            return result;
        }
    }
}
