using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dvld_data_access_layer;
using System.Data;

namespace dvld_business_layer
{
    public  class clsCountries
    {
        public int CountryId;
        public string CountryName;
        public static DataTable GetCountries()
        {
            return (clsCountriesDataAccess.GetALlCountries());
        }

        public clsCountries (int Id, string Name)
        {
            CountryId = Id;
            CountryName = Name;
        }


        public static clsCountries Find (string Name)
        {
            int Id = -1;
            if (clsCountriesDataAccess.GetCountryByName(Name, ref Id))
            {
                return (new clsCountries(Id, Name));
            }
            else
                return (null);
        }

        public static clsCountries Find(int  Id)
        {
            string Name = "";
            if (clsCountriesDataAccess.GetCountryByID(Id, ref Name))
            {
                return (new clsCountries(Id, Name));
            }
            else
                return (null);
        }


    }
}
