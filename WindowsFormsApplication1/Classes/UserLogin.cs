using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleComparer.Classes
{
    //This contains a class for the userlogins. This allows us to load/save them by passing the set of variables in a single variable
    public class UserLogin 
    {

        public int AccountID { get; set; }
        public int UserID { get; set; }
        public string SiteKey { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string website { get; set; }

    }
}
