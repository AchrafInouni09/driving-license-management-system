using dvld_data_access_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvld_business_layer
{
    public class clsUsers
    {
        public static bool  Find  (string UserName, string Password)
        {
            return (clsUsersDataAccess.Find (UserName, Password));
        }
    }
}
