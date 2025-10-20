using dvld_business_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dvld_presantation_layer
{
    public partial class PeopleMainForm : Form
    {
        public PeopleMainForm()
        {
            InitializeComponent();
        }

        adddeletepeopleform frm;

        private void _Refreash_form()
        {
            dataGridView1.DataSource = clsPeople.GetAllPeoples();
            lblnbrecords.Text = dataGridView1.RowCount.ToString();
        }

        private bool _Load_Filer_combo()
        {
            DataTable dt =  clsPeople.getSchemableColumn();


            foreach  (DataRow row in dt.Rows)
            {
                comboBoxFilter.Items.Add(row["ColumnName"]);
            }

            comboBoxFilter.SelectedIndex = 0;

            return (true);
        }

        private void PeopleMainForm_Load(object sender, EventArgs e)
        {
            _Refreash_form();
            _Load_Filer_combo();
        }

        private void btmClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btmAddPeople_Click(object sender, EventArgs e)
        {
             frm = new adddeletepeopleform(-1);

            frm.MdiParent  = this.MdiParent;

            frm.FinishSave += recuperate_finish_event;
            frm.Show();
        }

        private void recuperate_finish_event (object sender, bool issaved)
        {
             if (issaved)
            {
                MessageBox.Show("Person Added Succuss");
                _Refreash_form();
                frm.Close();
                return;
            }
            else 
                MessageBox.Show("cannot add Person Succuss");
        }
        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
