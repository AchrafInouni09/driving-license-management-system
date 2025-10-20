using dvld_business_layer;
using System;
using System.Windows.Forms;

namespace dvld_presantation_layer
{
    public partial class adddeletepeopleform : Form
    {

        public delegate void FinishSaveEvent(object sender, bool isdatasaved);
        public event FinishSaveEvent  FinishSave;

        private clsPeople _people;
        private int _id;

        public enum enmode { enAdd = 1, enUpdate = 2 }
        public enmode _mode;
        public adddeletepeopleform(int id)
        {
            InitializeComponent();
            peopleInfoUsercontrol1.SaveEvent += adddeletepeopleformDataBack;
            peopleInfoUsercontrol1.CloseControl += closecontrolevent;

            _id = id;
            if (_id == -1)
            {
                _mode = enmode.enAdd;
            }
            else
            {
                _mode = enmode.enUpdate;
            }
        }

        private bool Load_Data()
        {

            if (_mode == enmode.enAdd)
            {
                labelformname.Text = "Add New People";
                return (false);
            }

            // find it ; 

            return (true);
        }


        private void closecontrolevent (object sender)
        {
            this.Close();
        }




        private void adddeletepeopleformDataBack(object sender, string FirstName, string LastName, string SecondName,
                 string ThirdName, string Address, DateTime DateOfBirdth, string Phone, string ImagePath, int Gendor,  string NationalNo, int CountryId, string Email)
        {
            MessageBox.Show("from adddeletepeople  data just received");

            if (clsPeople.IsCinExist(NationalNo))
            {
                peopleInfoUsercontrol1.errorProvider1.SetError(peopleInfoUsercontrol1.txtBoxNationalId, "National No Already Found");
                return;
            }
            else
            {
                peopleInfoUsercontrol1.errorProvider1.SetError(peopleInfoUsercontrol1.txtBoxNationalId, "");
            }

            _people = new clsPeople();

            _people._FirstName = FirstName;
            _people._LastName = LastName;
            _people._ThirdName = ThirdName;
            _people._Address = Address;
            _people._SecondName = SecondName;
            _people._DateOfBirth = DateOfBirdth;
            _people._Phone = Phone;
            _people._ImagePath = ImagePath;
            _people._NationalNo = NationalNo;
            _people._CountryId = CountryId;
            _people._gendor = Gendor;
            _people._Email = Email;

            if (_people.Save ())
            {
                FinishSave?.Invoke(sender, true);
            }
            else
            {
                FinishSave?.Invoke(sender, false);
            }

        }

        private void adddeletepeopleform_Load(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void peopleInfoUsercontrol1_Load(object sender, EventArgs e)
        {

        }
    }
}
