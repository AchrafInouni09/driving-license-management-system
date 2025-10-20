using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dvld_business_layer;

namespace dvld_presantation_layer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }



        private void toolStripbtmPeople_Click(object sender, EventArgs e)
        {
            PeopleMainForm peoplemainform = new PeopleMainForm();

            
            peoplemainform.MdiParent = this;

            peoplemainform.Show();
        }

    }
}
