using dvld_business_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
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

        private DataTable schemableTable;
        private DataTable dt;
        private string last_selected_item;
        private string  selected_item;



        private void _Refreash_form()
        {
            dt = clsPeople.GetAllPeoples();
            dataGridView1.DataSource = dt;
            lblnbrecords.Text = dataGridView1.RowCount.ToString();
            dataGridView1.AllowUserToAddRows = false;
            // remove free ones;
        }

        private bool _Load_Filer_combo()
        {
            schemableTable =  clsPeople.getSchemableColumn();


            foreach  (DataRow row in schemableTable.Rows)
            {
                comboBoxFilter.Items.Add(row["ColumnName"]);
            }

            comboBoxFilter.SelectedIndex = 0;
            last_selected_item =  comboBoxFilter.SelectedItem?.ToString();

            return (true);
        }

        private void PeopleMainForm_Load(object sender, EventArgs e)
        {
            _Refreash_form();
            _Load_Filer_combo();
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
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

        private void comboBoxFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }


        private bool iscolumnin(string col)
        {
            foreach (DataRow row in schemableTable.Rows)
            {
                comboBoxFilter.Items.Add(row["ColumnName"]);

                if (col == (string)row["ColumnName"])
                    return (true);
            }

            return (false);
        }
        private void ApplyFilter()
        {
            if (schemableTable == null) return;
            string column = comboBoxFilter.Text;
            string value = "";
            bool isText = false;

            if (iscolumnin(column))
            {
                last_selected_item = column;
                value = "*";
            }
            else
            {
                value = comboBoxFilter.Text;
                isText = true;
            }

            try
            {

                if (isText)
                {
                    DataView dv = new DataView(dt);

                    if (dt.Columns[last_selected_item].DataType == typeof(string))
                    {
                        dv.RowFilter = $"[{last_selected_item}] LIKE '%{value}%'";
                    }
                    else
                    {
                        dv.RowFilter = $"CONVERT([{last_selected_item}], 'System.String') LIKE '%{value}%'";
                    }
                    dataGridView1.DataSource = dv;
                }
                else
                {
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void heyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new adddeletepeopleform(-1);

            frm.MdiParent = this.MdiParent;

            frm.FinishSave += recuperate_finish_event;
            frm.Show();
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e) // edit
        {
            try
            {

                if (!int.TryParse(selected_item, out  int PeopleId))
                    return;

                frm = new adddeletepeopleform(PeopleId);

                //MessageBox.Show(PeopleId.ToString ());


                frm.MdiParent = this.MdiParent;

                frm.FinishSave += recuperate_finish_event;
                frm.Show();

        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
}


        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dataGridView1.HitTest (e.X, e.Y);

                if (hit.RowIndex >= 0)
                {
                    dataGridView1.ClearSelection();

                    dataGridView1.Rows[hit.RowIndex].Selected = true;

                    selected_item = dataGridView1.Rows[hit.RowIndex].Cells["PersonID"].Value.ToString ();
                }
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (!int.TryParse(selected_item, out int PeopleId))
                    return;

                frm = new adddeletepeopleform(PeopleId);


                frm.MdiParent = this.MdiParent;

                frm.FinishSave += recuperate_finish_event;
                frm.SetControleReadOnly();
                frm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure ? ", "Delete People" ,  MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {

                if (!int.TryParse(selected_item, out int PeopleId))
                {
                    MessageBox.Show("Cannot Delete " + PeopleId);
                    return;
                }
                    

                if (clsPeople.DeletePeople(PeopleId))
                {
                    _Refreash_form();
                    MessageBox.Show(PeopleId + " Deleted Succuss");
                }
                else
                    MessageBox.Show("Cannot Delete " + PeopleId);
            }       

        }
    }
}
