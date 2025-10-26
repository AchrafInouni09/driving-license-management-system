using dvld_business_layer;
using System;
using System.Windows.Forms;
using static dvld_presantation_layer.PeopleInfoUsercontrol;

namespace dvld_presantation_layer
{
    public partial class adddeletepeopleform : Form
    {

        public delegate void FinishSaveEvent(object sender, bool isdatasaved);
        public event FinishSaveEvent FinishSave;

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
                peopleInfoUsercontrol1.txtBoxNationalId.ReadOnly = true;
            }
        }

        private bool Load_Data()
        {

            if (_mode == enmode.enAdd)
            {
                labelformname.Text = "Add New People";
                return (false);
            }
            else
            {
                labelformname.Text = "Edit People";
            }


            string FirstName = ""; string LastName = ""; string SecondName = ""; string ThirdName = ""; string Phone = "";
            string Email = ""; DateTime DateOfBirth = DateTime.Today.AddYears(-18);
            int gendor = -1; string Address = ""; string ImagePath = ""; int CountryId = 1; string NationalNo = "";



            if (clsPeople.GetInfoById(_id, ref FirstName, ref LastName, ref SecondName,
                    ref ThirdName, ref Phone, ref Email, ref DateOfBirth, ref gendor, ref Address, ref ImagePath, ref CountryId, ref NationalNo))
            {
                peopleInfoUsercontrol1.txtBoxFirstName.Text = FirstName;
                peopleInfoUsercontrol1.txtBoxLastName.Text = LastName;
                peopleInfoUsercontrol1.txtBoxThirdName.Text = ThirdName;
                peopleInfoUsercontrol1.txtBoxAddress.Text = Address;
                peopleInfoUsercontrol1.txtBoxSecondName.Text = SecondName;
                peopleInfoUsercontrol1.dateTimePickerDateOfBirdth.Value = DateOfBirth;
                peopleInfoUsercontrol1.txtBoxPhone.Text = Phone;
                peopleInfoUsercontrol1.txtBoxNationalId.Text = NationalNo;
                peopleInfoUsercontrol1.CountryId = CountryId;
                peopleInfoUsercontrol1.txtBoxEmail.Text = Email;

                peopleInfoUsercontrol1.ComboBoxCountry.SelectedItem = clsCountries.Find(CountryId).CountryName;

                if ((int)peopleInfoUsercontrol1.gendor == (int)enGendor.Male)
                    peopleInfoUsercontrol1.rbMale.Checked = true;
                else
                    peopleInfoUsercontrol1.rbFemale.Checked = true;
            }
            return (true);
        }


        private void closecontrolevent(object sender)
        {
            this.Close();
        }
        private void adddeletepeopleformDataBack(object sender, string FirstName, string LastName, string SecondName,
                 string ThirdName, string Address, DateTime DateOfBirdth, string Phone, string ImagePath, int Gendor, string NationalNo, int CountryId, string Email)
        {

            try
            {

                if (clsPeople.IsCinExist(NationalNo) && _mode == enmode.enAdd)
                {
                    peopleInfoUsercontrol1.errorProvider1.SetError(peopleInfoUsercontrol1.txtBoxNationalId, "National No Already Found");
                    return;
                }
                else
                {
                    peopleInfoUsercontrol1.errorProvider1.SetError(peopleInfoUsercontrol1.txtBoxNationalId, "");
                }



                if (_mode == enmode.enAdd)
                {
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

                    if (_people.Save())
                    {
                        FinishSave?.Invoke(sender, true);
                    }
                    else
                    {
                        FinishSave?.Invoke(sender, false);
                    }
                }

                else if (_mode == enmode.enUpdate)
                {
                    _people = new clsPeople(this._id, FirstName, LastName, SecondName, ThirdName, Phone, Email, DateOfBirdth, Gendor, Address, ImagePath, CountryId, NationalNo);


                    if (_people.Save())
                    {
                        FinishSave?.Invoke(sender, true);
                    }
                    else
                    {
                        MessageBox.Show("cannot save update ");
                        FinishSave?.Invoke(sender, false);
                    }
                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void adddeletepeopleform_Load(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void peopleInfoUsercontrol1_Load(object sender, EventArgs e)
        {

        }

        public void SetControleReadOnly()
        {
            foreach (Control ctl in this.Controls)
            {
                ctl.Enabled = false;
            }
        }
    }
}
