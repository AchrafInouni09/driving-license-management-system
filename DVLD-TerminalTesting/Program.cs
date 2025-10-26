using dvld_data_access_layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace DVLD_TerminalTesting
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string FirstName = ""; string LastName = ""; string SecondName = ""; string ThirdName = ""; string Phone = "";
            string Email = ""; DateTime DateOfBirth = DateTime.Today.AddYears(-18);
            int gendor = -1; string Address = ""; string ImagePath = ""; int CountryId = -1; string NationalNo = "";

            int id = 1024;

            if (clsPeopleDataAccess.GetPeopleById(id, ref FirstName, ref LastName, ref SecondName,
                    ref ThirdName, ref Phone, ref Email, ref DateOfBirth, ref gendor, ref Address, ref ImagePath, ref CountryId, ref NationalNo))
            {

                Console.WriteLine(CountryId);
                Console.WriteLine(NationalNo);
            }
            else
            {
                Console.WriteLine("badly");
            }

            FirstName = "siucuiwcw";

            if (clsPeopleDataAccess.Update_Person(id,  FirstName,  LastName,  SecondName,
                     ThirdName,   Email, Phone, Address , CountryId , DateOfBirth,  ImagePath,   NationalNo, gendor))
            {

                Console.WriteLine(CountryId);
                Console.WriteLine(NationalNo);
            }
            else
            {
                Console.WriteLine("error in update");
            }

            //string Name="";
            //int Id = 90;

            //if (clsCountriesDataAccess.GetCountryByID(Id, ref Name))
            //{
            //    Console.WriteLine(Name);
            //}
            //else
            //    Console.WriteLine("Cannot retrieve it");
        }
    }
}
