namespace dvld_presantation_layer
{
    partial class adddeletepeopleform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adddeletepeopleform));
            this.peopleInfoUsercontrol1 = new dvld_presantation_layer.PeopleInfoUsercontrol();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelformname = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // peopleInfoUsercontrol1
            // 
            this.peopleInfoUsercontrol1.Address = null;
            this.peopleInfoUsercontrol1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.peopleInfoUsercontrol1.CountryId = 0;
            this.peopleInfoUsercontrol1.DateOfBirth = new System.DateTime(((long)(0)));
            this.peopleInfoUsercontrol1.Email = null;
            this.peopleInfoUsercontrol1.FirstName = null;
            this.peopleInfoUsercontrol1.ImagePath = null;
            this.peopleInfoUsercontrol1.LastName = null;
            this.peopleInfoUsercontrol1.Location = new System.Drawing.Point(14, 90);
            this.peopleInfoUsercontrol1.Name = "peopleInfoUsercontrol1";
            this.peopleInfoUsercontrol1.NationalNo = null;
            this.peopleInfoUsercontrol1.Phone = null;
            this.peopleInfoUsercontrol1.SecondName = null;
            this.peopleInfoUsercontrol1.Size = new System.Drawing.Size(751, 293);
            this.peopleInfoUsercontrol1.TabIndex = 0;
            this.peopleInfoUsercontrol1.ThirdName = null;
            this.peopleInfoUsercontrol1.Load += new System.EventHandler(this.peopleInfoUsercontrol1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Person ID:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(132, 47);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(19, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // labelformname
            // 
            this.labelformname.AutoSize = true;
            this.labelformname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelformname.ForeColor = System.Drawing.Color.Brown;
            this.labelformname.Location = new System.Drawing.Point(337, 33);
            this.labelformname.Name = "labelformname";
            this.labelformname.Size = new System.Drawing.Size(164, 20);
            this.labelformname.TabIndex = 24;
            this.labelformname.Text = "Test Add Edit Form";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(170, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "N/A";
            // 
            // adddeletepeopleform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(777, 388);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelformname);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.peopleInfoUsercontrol1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "adddeletepeopleform";
            this.Text = "adddeletepeopleform";
            this.Load += new System.EventHandler(this.adddeletepeopleform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelformname;
        private System.Windows.Forms.Label label2;
        protected internal PeopleInfoUsercontrol peopleInfoUsercontrol1;
    }
}