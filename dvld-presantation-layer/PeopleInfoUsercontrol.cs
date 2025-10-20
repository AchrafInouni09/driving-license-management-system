using dvld_business_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static dvld_presantation_layer.adddeletepeopleform;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace dvld_presantation_layer
{
    public partial class PeopleInfoUsercontrol : UserControl
    {

        public delegate void EventClickSave (object sender, string FirstName, string LastName, string SecondName,
                 string ThirdName, string Address, DateTime DateOfBirdth, string Phone, string ImagePath, int Gendor, string NationalId, int CountryId, string email);

        public EventClickSave SaveEvent;



        public delegate void EvenCloseControl(object sender);
        public event EvenCloseControl CloseControl;





        public enum enGendor { Male = 0, Female= 1}

        public enGendor gendor;

        public PeopleInfoUsercontrol()
        {
            InitializeComponent();
        }


        private bool _isEmailValid ()
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(Email, pattern, RegexOptions.IgnoreCase);
        }

        private bool Check_Data_Validity()

        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrWhiteSpace(FirstName))
            {
                errorProvider1.SetError(txtBoxFirstName, "important");
                return (false);
            }
            else
            {
                errorProvider1.SetError(txtBoxFirstName, "");
            }
            if (string.IsNullOrEmpty(LastName) || string.IsNullOrWhiteSpace(LastName))
            {
                errorProvider1.SetError(txtBoxLastName, "important");
                return (false);
            }
            else
            {
                errorProvider1.SetError(txtBoxLastName, "");
            }

            if (string.IsNullOrEmpty(NationalNo) || string.IsNullOrWhiteSpace(NationalNo))
            {
                errorProvider1.SetError(txtBoxNationalId, "important");
                return (false);
            }
            else
            {
                errorProvider1.SetError(txtBoxNationalId, "");
            }


            if (!string.IsNullOrEmpty(Email) )
            {
                if (!_isEmailValid())
                {
                    errorProvider1.SetError(txtBoxEmail, "important");
                    return (false);
                }
                else
                {
                    errorProvider1.SetError(txtBoxEmail, "");
                }

            }

            if (string.IsNullOrEmpty(Phone) || string.IsNullOrWhiteSpace(Phone))
            {
                errorProvider1.SetError(txtBoxPhone, "important");
                return (false);
            }
            else
            {
                errorProvider1.SetError(txtBoxPhone, "");
            }

            if (string.IsNullOrEmpty(Address) || string.IsNullOrWhiteSpace(Address))
            {
                errorProvider1.SetError(txtBoxAddress, "important");
                return (false);
            }
            else
            {
                errorProvider1.SetError(txtBoxAddress, "");
            }


            return (true); // just for test;
        }


        private bool _Connect_Data()
        {
            FirstName = txtBoxFirstName.Text;
            LastName = txtBoxLastName.Text;
            SecondName = txtBoxSecondName.Text;
            ThirdName = txtBoxThirdName.Text;
            Address = txtBoxAddress.Text;
            Phone = txtBoxPhone.Text;
            NationalNo = txtBoxNationalId.Text;
            DateOfBirth = dateTimePickerDateOfBirdth.Value;


            Email = txtBoxEmail.Text;
            CountryId = clsCountries.Find (ComboBoxCountry.Text).CountryId;


            // connect country id;
            if (rbMale.Checked)
                gendor = enGendor.Male;
            else
                gendor = enGendor.Female;
            return (true);
        }

        private void btmSave_Click(object sender, EventArgs e)
        {
            _Connect_Data();
            if (Check_Data_Validity())
            {
                SaveEvent?.Invoke(sender, FirstName , LastName, SecondName, ThirdName, Address, DateOfBirth, Phone,ImagePath, (int)gendor, NationalNo, CountryId, Email);
            }
        }

        //public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int CountryId { set; get; }

        public string Address { get; set; }

        public string ImagePath { set; get; }

        public string NationalNo { set; get; }

        private void txtBoxFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBoxNationalId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBoxSecondName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBoxThirdName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBoxLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


       

        private void txtBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private bool Fill_Countries_Combobox ()
        {
            DataTable dt = clsCountries.GetCountries();


            foreach (DataRow row in dt.Rows)
            {
                ComboBoxCountry.Items.Add(row["CountryName"]);
            }
            ComboBoxCountry.SelectedIndex = 100;
            return (true);
        }
        private void PeopleInfoUsercontrol_Load(object sender, EventArgs e)
        {
            this.dateTimePickerDateOfBirdth.MaxDate = DateTime.Today.AddYears(-18);
            Fill_Countries_Combobox();
        }

        private void btmclose_Click(object sender, EventArgs e)
        {
            CloseControl?.Invoke(sender);
        }

        private void linklabelSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImagePath = openFileDialog1.FileName;
                MessageBox.Show(ImagePath);
                
                pictureBoxImage.Image = Image.FromFile(ImagePath);
                linkLabelRemovePic.Visible = true;
            }
        }

        private void linkLabelRemovePic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelRemovePic.Visible = false;
            ImagePath = null;
            pictureBoxImage.Image = null;
        }
    }
}
