using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SampleComparer.Classes
{
    //DEPRECIATED
    class XMLFunctions
    {
        ////This function will save the data that is in the GridView to XML. The only data we really care about is the 
        ////ID and Name specified.
        //private void saveToXML()
        //{
        //    List<UserRecord> users = new List<UserRecord>();

        //    //Create a list of all the data that is in the grid
        //    foreach (DataGridViewRow row in dgvProfiles.Rows)
        //    {
        //        //Create a temp UserRecord to populate
        //        UserRecord tmp = new UserRecord();
        //        tmp.PROFILEID = (row.Cells["SpeakerID"].Value.ToString());
        //        //Ensure ther is a valid string in the "SpeakerName" column
        //        if (row.Cells["SpeakerName"].Value == null)
        //        {
        //            tmp.NAME = "";
        //        }
        //        else
        //        {
        //            tmp.NAME = row.Cells["SpeakerName"].Value.ToString();
        //        }
        //        //Add the temp UserRecord to the list
        //        users.Add(tmp);
        //    }

        //    //Create settings for the XML file so it is formatted properly
        //    XmlWriterSettings settings = new XmlWriterSettings();
        //    settings.Indent = true;
        //    settings.IndentChars = "\t";
        //    using (XmlWriter writer = XmlWriter.Create(dataFile, settings))
        //    {
        //        //Write the document and create the root node
        //        writer.WriteStartDocument();
        //        writer.WriteStartElement("Users");
        //        foreach (UserRecord user in users)
        //        {
        //            //Create a node for each user
        //            writer.WriteStartElement("User");
        //            //Write the user settings
        //            writer.WriteElementString("SpeakerID", user.PROFILEID.ToString());
        //            writer.WriteElementString("SpeakerName", user.NAME);
        //            //Close the node
        //            writer.WriteEndElement();
        //        }
        //        //Close the root node
        //        writer.WriteEndElement();
        //        //End the document
        //        writer.WriteEndDocument();
        //    }
        //}
        ////This will read from the data xml file and load the found Users into an list to load later
        //private List<UserRecord> readFromXML()
        //{
        //    List<UserRecord> users = new List<UserRecord>();


        //    try
        //    {
        //        //Make sure the file exists before trying to read it
        //        if (File.Exists(dataFile))
        //        {
        //            //Create an XML document to load the data into
        //            XmlDocument xmlDoc = new XmlDocument();
        //            //Load the data into the XML document
        //            xmlDoc.Load(dataFile);
        //            //Navigate to the "Users/User" node
        //            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Users/User");
        //            //Loop through the nodes
        //            foreach (XmlNode node in nodeList)
        //            {
        //                //Create a temp UserRecord
        //                UserRecord tmp = new UserRecord();
        //                tmp.PROFILEID = node.SelectSingleNode("SpeakerID").InnerText;
        //                tmp.NAME = node.SelectSingleNode("SpeakerName").InnerText;
        //                //Add the temp UserRecord to my users list
        //                users.Add(tmp);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logMessage("readFromXML Error: " + ex.Message);
        //    }
        //    //Return my list of users
        //    return users;
        //}

    }
}
