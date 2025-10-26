using dvld_data_access_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvld_business_layer
{
    public class clsPeople
    {
        private bool _Add_New_Person()
        {
            this._Id = clsPeopleDataAccess.Add_New_Person(this._FirstName, this._LastName, this._SecondName, this._ThirdName , this._Email, this._Phone,
                this._Address, this._CountryId, this._DateOfBirth, this._ImagePath, this._NationalNo, this._gendor);
            return (this._Id != -1);
        }

        

        private bool _Update_Person()
        {
            return (clsPeopleDataAccess.Update_Person(this._Id,this._FirstName, this._LastName, this._SecondName, this._ThirdName, this._Email, this._Phone,
                this._Address, this._CountryId, this._DateOfBirth, this._ImagePath, this._NationalNo, this._gendor));
        }


        public clsPeople()
        {
            _FirstName = "";
            _LastName = "";
            _SecondName = "";
            _ThirdName = "";
            _Id = -1;
            _Email = "";
            _CountryId = -1;
            _Address = "";
            _ImagePath = "";
            _mode = enMode.enAdd;
        }

        public clsPeople(int Id, string FirstName, string LastName, string SecondName, string ThirdName, string Phone, string Email, DateTime DateOfBirth, int gendor, string Address, string ImagePath, int CountryId, string NationalNo)
        {
            _FirstName = FirstName;
            _LastName = LastName;
            _SecondName = SecondName;
            _ThirdName = ThirdName;
            _DateOfBirth = DateOfBirth;
            _Phone = Phone;
            _gendor = gendor;
            _Id = Id;
            _Email = Email;
            _CountryId = CountryId;
            _Address = Address;
            _ImagePath = ImagePath;
            _NationalNo = NationalNo;
            _mode = enMode.enUpdate;
        }

        public static DataTable GetAllPeoples()
        {
            return (clsPeopleDataAccess.GetAllPeoples());
        }

        enum enMode { enAdd = 1, enUpdate = 2 };
        public int _Id { get; set; }
        public string _FirstName { get; set; }
        public string _LastName { get; set; }

        public string _SecondName { get; set; }
        public string _ThirdName { get; set; }
        public string _Email { get; set; }
        public string _Phone { get; set; }
        public DateTime _DateOfBirth { get; set; }

        public int _CountryId { set; get; }

        public string _Address { get; set; }

        public string _ImagePath { set; get; }

        public string _NationalNo { get; set; }
        public int      _gendor { get; set; }

        private enMode _mode;
        public static bool IsCinExist(string cin)
        {
            return (clsPeopleDataAccess.IsCinExist(cin));
        }
        public bool Save ()
        {

            switch (_mode)
            {
                case enMode.enAdd:
                {
                        if (_Add_New_Person())
                        {
                            _mode = enMode.enUpdate;
                            return (true);
                        }
                        else
                            return (false);
                }

                case enMode.enUpdate:
                    {
                        if (_Update_Person())
                            return (true);
                        
                        return (false);
                    }

            }

            return (false);
        }


        public static DataTable getSchemableColumn()
        {
            return (clsPeopleDataAccess.GetSchemableColumn());
        }

        public static bool GetInfoById( int Id, ref string FirstName, ref string LastName, ref  string SecondName,
                   ref  string ThirdName,ref string Phone,ref string Email,ref DateTime DateOfBirth,ref int gendor, ref string Address, ref string ImagePath,ref int CountryId,ref string NationalNo)
        {
            return (clsPeopleDataAccess.GetPeopleById(Id, ref FirstName, ref LastName,ref SecondName,
                   ref  ThirdName,ref Phone, ref Email,ref  DateOfBirth,ref  gendor, ref Address,ref  ImagePath, ref CountryId,ref  NationalNo));
        }

        public static bool  DeletePeople (int Id)
        {
            return (clsPeopleDataAccess.DeletePeople(Id));
        }
    }
}

