using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System.Data;
using System.Reflection;

namespace SampleComparer.Classes
{

    //The database Class does all the communication from the application to the database on the remote server
    //The remote server can only accept connections from Localhost so we use a PHP page that does the query and returns the results
    //Results will have "ERROR" if the executed query returns a error. This allows trapping error messages

    class Database
    {
        private HttpClient client = new HttpClient();
        private WebClient webClient = new WebClient();

        private string url = "https://sit374.000webhostapp.com/index.php"; //website that has the remote page on to execute queries againas

        public Database()
        {
            this.url = url + "?sql=";
        }

        //This executes a command on the remote server that returns a dataset
        //INPUT: string of SQL statement
        //OUTPUT: string
        public string executeQueryV2(string sql)
        {
            return webClient.DownloadString(url + sql);
        }

        //This executes a command on the remote server that does UPDATE/INSERT/DELETE. These commands don't return a restultset
        //INPUT: string of SQL statement
        //OUTPUT: string
        public string executeNonQueryV2(string sql)
        {
            return webClient.DownloadString(url + sql);
        }


        #region UserFunctions
        //This function will get a list of users from the database
        //INPUT: 
        //OUTPUT: List of <UserRecord>
        public List<UserRecord> getUserList()
        {
            string sql = "select * from users";
            string temp;
            temp = executeQueryV2(sql);

            //If no results, then return nothing
            if (temp == "0 results")
            {
                return new List<UserRecord>();
            }
            else if (temp.Contains("Error"))
            {
                return new List<UserRecord>();
            }
            // MessageBox.Show(temp);
            List<UserRecord> UserList = JsonConvert.DeserializeObject<List<UserRecord>>(temp);
            return UserList;

        }

        //This function will add a new user
        //INPUT: New user name
        //OUTPUT: functionResult
        public functionResult addNewUser(string userName)
        {
            functionResult result = new functionResult();
            string SQL = "INSERT INTO users (NAME) VALUES ('" + userName + "')";
            string output = executeNonQueryV2(SQL);
            if (output.ToUpper().Contains("ERROR"))
            {
                result.Result = false;
                result.Message = "addNewUser: " + output;
            }
            else
            {
                result.Result = true;
                result.Message = "addNewUser - OK";
            }

            if (result.Result == true)
            {
                SQL = "SELECT MAX(ID) FROM users";
                string output2 = executeQueryV2(SQL);
                if (output2.ToUpper().Contains("ERROR") || output2.ToUpper().Contains("EMPTY"))
                {
                    result.Result = false;
                    result.Message = "addNewUser (get max): " + output;

                }
                else
                {
                    result.Result = true;
                    string temp = output2.Substring(output2.IndexOf(":") + 1);
                    temp = temp.Replace("\"", "");
                    temp = temp.Replace("}", "");
                    temp = temp.Replace("]", "");
                    result.Message = temp;

                }

            }
            return result;
        }

        //This function will update the passed UserID with a new Name and ProfileID
        //INPUT: UserID to update, new Name and ProfileID
        //OUTPUT: functionResult
        public functionResult updateUser(string userID, string name, string ProfileID)
        {
            functionResult r = new functionResult();
            string SQL = @"UPDATE users SET NAME = '" + name + "', ProfileID = '" + ProfileID + "' WHERE ID = '" + userID + "'";
            string output = executeNonQueryV2(SQL);
            if (output.Contains("Error"))
            {
                r.Result = false;
                r.Message = output;

            }
            else
            {
                r.Result = true;
                r.Message = "updateUser - OK";
            }
            return r;
        }

        //This function remove the passed UserID
        //INPUT: userId
        //OUTPUT: functionResult
        public functionResult removeUser(string userID)
        {
            functionResult r = new functionResult();
            string SQL = @"DELETE FROM users  WHERE ID = '" + userID + "'";
            string output = executeNonQueryV2(SQL);
            if (output.ToUpper().Contains("ERROR"))
            {
                r.Result = false;
                r.Message = output;

            }
            else
            {
                r.Result = true;
                r.Message = "removeUser - OK";
            }
            return r;
        }
        #endregion


        #region Logins
        //This function will get the logins for the passed UserID
        //INPUT: UserID
        //OUTPUT: List of <UserLogin>
        public List<UserLogin> getLoginList(int UserID)
        {
            string sql = "select * from Logons WHERE UserID = '" + UserID + "'";
            string temp;
            temp = executeQueryV2(sql);

            //If no results, then return nothing
            if (temp.ToUpper().Contains("EMPTY"))
            {
                return new List<UserLogin>();
            }
            else if (temp.ToUpper().Contains("EMPTY"))
            {
                return new List<UserLogin>();
            }
            List<UserLogin> LoginList = JsonConvert.DeserializeObject<List<UserLogin>>(temp);
            return LoginList;

        }

        //This function will get the specific login for the passed AccountIDS
        //INPUT: Account ID
        //OUTPUT: List of <UserLogin> - this can be changed to a just the User login in the future. Done this way to simplify the capture incause there is database errors
        public List<UserLogin> getSpecificLogin(int AccountID)
        {
            string sql = "select * from Logons WHERE AccountID = '" + AccountID + "'";
            string temp;
            temp = executeQueryV2(sql);

            //If no results, then return nothing
            if (temp.ToUpper().Contains("EMPTY"))
            {
                return new List<UserLogin>();
            }
            else if (temp.ToUpper().Contains("EMPTY"))
            {
                return new List<UserLogin>();
            }

            //Return the list of logins (Using a JSON converted with the type of "UserLogin"
            List<UserLogin> LoginList = JsonConvert.DeserializeObject<List<UserLogin>>(temp);
            return LoginList;

        }

        //This function add a new login
        //INPUT: UserLogin (contains all details)
        //OUTPUT: functionResult
        public functionResult AddAccountLogin(UserLogin u)
        {
            functionResult result = new functionResult();
            EncryptionDecrypt edde = new EncryptionDecrypt();
            //Create the SQL string. Encrypt the password we are storing
            string SQL = "INSERT INTO Logons (UserID, SiteKey, username, password, website) VALUES ('" + u.UserID + "','" + u.SiteKey + "', '" + u.username + "','" + edde.EncryptString(u.password) + "','" + u.website + "')";
            string output = executeNonQueryV2(SQL);
            if (output.ToUpper().Contains("ERROR"))
            {
                result.Result = false;
                result.Message = "AddAccountLogin: " + output;
            }
            else
            {
                result.Result = true;
                result.Message = "AddAccountLogin - OK";
            }


            return result;
        }

        //This function will uppdate the passed userlogin
        //INPUT: UserLogin
        //OUTPUT: functionResult
        public functionResult UpdateAccountLogin(UserLogin u)
        {
            functionResult result = new functionResult();
            EncryptionDecrypt edde = new EncryptionDecrypt();
            //Create the SQL string. Encrypt the password we are storing
            string SQL = "UPDATE Logons SET SiteKey = '" + u.SiteKey + "' , username = '" + u.username + "', password = '" + edde.EncryptString(u.password) + "', website = '" + u.website + "' WHERE AccountID ='" + u.AccountID + "'";
            string output = executeNonQueryV2(SQL);
            if (output.ToUpper().Contains("ERROR"))
            {
                result.Result = false;
                result.Message = "UpdateAccountLogin: " + output;
            }
            else
            {
                result.Result = true;
                result.Message = "UpdateAccountLogin - OK";
            }


            return result;
        }

        //This function will remove the passed AccountID
        //INPUT: AccountID
        //OUTPUT: functionResult
        public functionResult RemoveAccountLogin(int AccountID)
        {
            functionResult result = new functionResult();
            EncryptionDecrypt edde = new EncryptionDecrypt();
            //Create the SQL string. Encrypt the password we are storing
            string SQL = "DELETE FROM Logons WHERE AccountID ='" + AccountID + "'";
            string output = executeNonQueryV2(SQL);
            if (output.ToUpper().Contains("ERROR"))
            {
                result.Result = false;
                result.Message = "RemoveAccountLogin: " + output;
            }
            else
            {
                result.Result = true;
                result.Message = "RemoveAccountLogin - OK";
            }


            return result;
        }
        #endregion

        //This function will convert any passed list to a datatable. This will contain headers for each type element and rows
        //INPUT: Generic List of any type
        //OUTPUT: Datatable
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;


        }

        //DEPRECIATE - This will write the list of userdata to the database
        //INPUT: List of <UserRecord>
        //OUTPUT: boolean
        public Boolean writeUserList(List<UserRecord> userData)
        {
            //formToOutput.publicLogMessage("writeUserList");

            try
            {
                string SQL;
                foreach (UserRecord u in userData)
                {
                    int u_ID = u.ID;
                    string u_Name = u.NAME;
                    string u_ProfileID = u.PROFILEID;

                    if (u.ID == 0)
                    {
                        SQL = @"REPLACE into users (NAME, ProfileID) VALUES ('" + u.NAME + "', '" + u.PROFILEID + "')";
                    }
                    else
                    {
                        SQL = @"REPLACE into users (iD, NAME, ProfileID) VALUES ('" + u.ID + "','" + u.NAME + "', '" + u.PROFILEID + "')";
                    }

                    //Check if there is an "ERROR" in the return string
                    string output = executeNonQueryV2(SQL);
                    if (output.Contains("Error"))
                    {
                        //formToOutput.publicLogMessage("writeUserList: " + output);
                    }
                }
                return true;
            }

            catch (Exception ex)
            {
                //formToOutput.publicLogMessage("writeUserList: " + ex.ToString());
                return false;

            }

        }
    }
}
