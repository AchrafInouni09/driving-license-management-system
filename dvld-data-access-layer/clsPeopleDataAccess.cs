using dvld_database_access_parameter;
using System;
using System.Data;
using System.Data.SqlClient;

namespace dvld_data_access_layer
{
    public class clsPeopleDataAccess
    {
        public static int Add_New_Person(string FirstName, string LastName, string SecondName, string ThirdName, string Email, string Phone, string Address, int CountryId, DateTime DateofBirth, string ImagePath, string NationalNo, int gendor)
        {

            int ContactId = -1;

            SqlConnection cnx = new SqlConnection(clsdvld_database_access_parameter.ConnectionString);


            string cmd = @"insert into People(FirstName, LastName, SecondName , ThirdName , DateOfBirth,Gendor, Address, Phone, Email,NationalityCountryID, NationalNo, ImagePath )
                        values (@FirstName, @LastName, @SecondName, @ThirdName , @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID,@NationalNo , @ImagePath) 
                        Select Scope_Identity()";


            SqlCommand sqlcmd = new SqlCommand(cmd, cnx);



            sqlcmd.Parameters.AddWithValue("@FirstName", FirstName);
            sqlcmd.Parameters.AddWithValue("@LastName", LastName);
            sqlcmd.Parameters.AddWithValue("@SecondName", SecondName);
            sqlcmd.Parameters.AddWithValue("@ThirdName", ThirdName);
            sqlcmd.Parameters.AddWithValue("@DateOfBirth", DateofBirth);
            sqlcmd.Parameters.AddWithValue("@Gendor", gendor);
            sqlcmd.Parameters.AddWithValue("@Address", Address);
            sqlcmd.Parameters.AddWithValue("@Phone", Phone);
            sqlcmd.Parameters.AddWithValue("@Email", Email);
            sqlcmd.Parameters.AddWithValue("@NationalityCountryID", CountryId);
            sqlcmd.Parameters.AddWithValue("@NationalNo", NationalNo);




            if (ImagePath != null)
                sqlcmd.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                sqlcmd.Parameters.AddWithValue("@ImagePath", DBNull.Value);





            try
            {
                cnx.Open();

                object obj = sqlcmd.ExecuteScalar();

                if (obj != null && int.TryParse(obj.ToString(), out int result))
                {
                    ContactId = result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ContactId = -1;
            }
            finally
            {
                cnx.Close();
            }

            return (ContactId);
        }




        public static bool Update_Person(int id, string FirstName, string LastName, string SecondName, string ThirdName, string Email, string Phone, string Address, int CountryId, DateTime DateofBirth, string ImagePath, string NationalNo, int gendor)
        {

            SqlConnection cnx = new SqlConnection(clsdvld_database_access_parameter.ConnectionString);


            string cmd = @"update People set FirstName=@FirstName, LastName=@LastName, SecondName=@SecondName , ThirdName=@ThirdName ,
                            DateOfBirth=@DateOfBirth,Gendor=@Gendor, Address= @Address, Phone=@Phone, Email=@Email,NationalityCountryID= @NationalityCountryID,
                            NationalNo=@NationalNo, ImagePath=@ImagePath    where PersonID=@id";


            SqlCommand sqlcmd = new SqlCommand(cmd, cnx);



            sqlcmd.Parameters.AddWithValue("@FirstName", FirstName);
            sqlcmd.Parameters.AddWithValue("@LastName", LastName);
            sqlcmd.Parameters.AddWithValue("@SecondName", SecondName);
            sqlcmd.Parameters.AddWithValue("@ThirdName", ThirdName);
            sqlcmd.Parameters.AddWithValue("@DateOfBirth", DateofBirth);
            sqlcmd.Parameters.AddWithValue("@Gendor", gendor);
            sqlcmd.Parameters.AddWithValue("@Address", Address);
            sqlcmd.Parameters.AddWithValue("@Phone", Phone);
            sqlcmd.Parameters.AddWithValue("@Email", Email);
            sqlcmd.Parameters.AddWithValue("@NationalityCountryID", CountryId);
            sqlcmd.Parameters.AddWithValue("@NationalNo", NationalNo);
            sqlcmd.Parameters.AddWithValue("@id", id);



            if (ImagePath != null)
                sqlcmd.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                sqlcmd.Parameters.AddWithValue("@ImagePath", DBNull.Value);



            int rowaffected = 0;

            try
            {
                cnx.Open();

                 rowaffected = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cnx.Close();
            }

            return ( rowaffected > 0);
        }
        public static DataTable GetAllPeoples()
        {
            DataTable dt = new DataTable();

            SqlConnection cnx = new SqlConnection(clsdvld_database_access_parameter.ConnectionString);

            string query = "Select * from People";

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
            return dt;
        }

        public static bool IsCinExist(string cin)
        {
            SqlConnection cnx = new SqlConnection(clsdvld_database_access_parameter.ConnectionString);


            string query = "Select found=1 from People where NationalNo=@No";


            SqlCommand cmd = new SqlCommand(query, cnx);

            cmd.Parameters.AddWithValue("@No", cin);

            bool isfound = false;

            try
            {
                cnx.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                    isfound = true;

                reader.Close();
            }
            catch (Exception e)
            {
                isfound = false;
                Console.WriteLine(e.Message);
            }
            finally
            {
                cnx.Close();
            }
            return (isfound);
        }


        public static DataTable GetSchemableColumn()
        {
            DataTable dt = new DataTable();

            SqlConnection cnx = new SqlConnection(clsdvld_database_access_parameter.ConnectionString);

            string query = "Select * from People where 1=0";

            SqlCommand cmd = new SqlCommand(query, cnx);


            try
            {
                cnx.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                dt = reader.GetSchemaTable();
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
            return dt;
        }

        public static bool GetPeopleById(int Id, ref string FirstName, ref string LastName, ref string SecondName,
                     ref string ThirdName, ref string Phone, ref string Email, ref DateTime DateOfBirth,
                    ref int gendor, ref string Address, ref string ImagePath, ref int CountryId, ref string NationalNo)
        {
            SqlConnection cnx = new SqlConnection(clsdvld_database_access_parameter.ConnectionString);

            string query = "Select * from People where PersonID=@Id";

            SqlCommand cmd = new SqlCommand(query, cnx);


            cmd.Parameters.AddWithValue("@Id", Id);

            bool isfound = false;

            try
            {
                cnx.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isfound = true;
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    int.TryParse(reader["Gendor"].ToString(), out gendor);
                    Address = (string)reader["Address"];
                    ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : null;
                    NationalNo = (string)reader["NationalNo"];
                    int.TryParse(reader["NationalityCountryId"].ToString(), out CountryId);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("exception catched " + e.Message);
            }
            finally
            {
                cnx.Close();
            }
            return (isfound);
        }

        public static bool DeletePeople(int PeopleId)
        {
            SqlConnection cnx = new SqlConnection(clsdvld_database_access_parameter.ConnectionString);

            string query = "Delete from People where PersonID=@PersonId";

            SqlCommand cmd = new SqlCommand(query, cnx);

            int rowaffected = 0;

            cmd.Parameters.AddWithValue("@PersonID", PeopleId);

            try
            {
                cnx.Open();
                rowaffected = cmd.ExecuteNonQuery();

                cnx.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("exception : " + e.Message);
                rowaffected = 0;
            }
            finally
            {
                cnx.Close();
            }

            return (rowaffected > 0);
        }
    }
}
