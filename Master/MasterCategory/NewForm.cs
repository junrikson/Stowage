#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MasterCategory
{
    public partial class NewForm : Syncfusion.Windows.Forms.MetroForm 
    {
        string connString = ConfigurationManager.ConnectionStrings["stowageConnection"].ToString();
        string username = "";

        public NewForm(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void NewForm_Load(object sender, EventArgs e)
        {
            doClear();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            doClear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connString))
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO masterCategory" +
                            "(code, name, min, max, note, status, updated, created, username) VALUES " +
                            "(@code, @name, @min, @max, @note, @status, getdate(), getdate(), @username)", con))
                        {
                            cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = txtCode.Text;
                            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = txtName.Text;
                            cmd.Parameters.Add("@min", SqlDbType.Decimal).Value = txtMin.Value;
                            cmd.Parameters.Add("@max", SqlDbType.Decimal).Value = txtMax.Value;
                            cmd.Parameters.Add("@note", SqlDbType.VarChar).Value = txtNote.Text;
                            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;

                            int status = 0;

                            if(chkStatus.Checked == true)
                            {
                                status = 1;
                            }

                            cmd.Parameters.Add("@status", SqlDbType.SmallInt).Value = status;

                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                this.Close();
            }
        }

        private void doClear()
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtMin.Value = 0;
            txtMax.Value = 0;
            txtNote.Text = "";
            chkStatus.Checked = true;
            txtCode.Focus();
        }

        private Boolean isValid()
        {
            Boolean isValidated = true;
            
            if (String.IsNullOrEmpty(txtCode.Text))
            {
                isValidated = false;
                MessageBox.Show("Kode Kategori harus diisi!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
            }
            else if (String.IsNullOrEmpty(txtName.Text))
            {
                isValidated = false;
                MessageBox.Show("Nama Kategori harus diisi!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }
            else if (!(txtMin.Value >= 0))
            {
                isValidated = false;
                MessageBox.Show("Batas Bawah harus lebih besar daripada Nol!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }
            else if (!(txtMax.Value >= 0))
            {
                isValidated = false;
                MessageBox.Show("Batas Atas harus lebih besar daripada Nol!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }

            return isValidated;
        }
    }
}
