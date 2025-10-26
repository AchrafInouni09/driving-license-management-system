using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvld_data_access_layer
{
    public class clsUsersDataAccess
    {
        
        public static bool Find (string UserName , string Password)
        {
            // get user Info;


            SqlConnection cnx = new SqlConnection(dvld_database_access_parameter.clsdvld_database_access_parameter.ConnectionString);


            string query = "Select *  from Users where UserName=@username and Password=@password";

            SqlCommand cmd = new SqlCommand(query, cnx);

            cmd.Parameters.AddWithValue("@username", UserName);
            cmd.Parameters.AddWithValue("@password", Password);

            bool isactive=false;


            try
            {
                cnx.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read ())
                {
                    isactive = (bool)reader["IsActive"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cnx.Close();
            }
            return (isactive);
        }
    }
}
