using dvld_database_access_parameter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dvld_data_access_layer
{
    public static  class clsCountriesDataAccess
    {
        public static DataTable GetALlCountries()
        {
            DataTable dt = new DataTable();

            SqlConnection cnx = new SqlConnection(clsdvld_database_access_parameter.ConnectionString);

            string query = "Select * from Countries;";

            SqlCommand cmd = new SqlCommand(query, cnx);

            try
            {
                cnx.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cnx.Close();
            }
            return (dt);
        }


        public static bool GetCountryByName (string CountryName, ref int CountryId)
        {
            SqlConnection cnx = new SqlConnection(clsdvld_database_access_parameter.ConnectionString);

            string query = "Select * from Countries where CountryName=@CountryName";

            SqlCommand cmd = new SqlCommand(query, cnx);

            bool isfound = false;


            cmd.Parameters.AddWithValue("@CountryName", CountryName);


            try
            {
                cnx.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isfound = true;
                     CountryId = (int)reader["CountryID"];
                    
                }

                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                isfound = false;
            }
            finally
            {
                cnx.Close();
            }

            return isfound;
        }

        public static bool GetCountryByID(  int CountryId ,  ref string CountryName)
        {
            SqlConnection cnx = new SqlConnection(clsdvld_database_access_parameter.ConnectionString);

            string query = "Select * from Countries where CountryID=@CountryId";

            SqlCommand cmd = new SqlCommand(query, cnx);

            bool isfound = false;

            cmd.Parameters.AddWithValue("@CountryId", CountryId);

            try
            {
                cnx.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isfound = true;
                    CountryName = (string)reader["CountryName"];
                }

                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                isfound = false;
            }
            finally
            {
                cnx.Close();
            }

            return isfound;
        }
    }
}
