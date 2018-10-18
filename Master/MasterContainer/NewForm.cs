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

namespace MasterContainer
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
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO masterContainer" +
                            "(code, ownership, relationCode, note, available, status, updated, created, username) VALUES " +
                            "(@code, @ownership, @relationCode, @note, @available, @status, getdate(), getdate(), @username)", con))
                        {
                            cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = txtCode1.Text.Replace(" ", string.Empty).Replace("-", string.Empty) + " " + txtCode2.Text.Replace(" ", string.Empty).Replace("-", string.Empty) + "-" + txtCode3.Text.Replace(" ", string.Empty).Replace("-", string.Empty);
                            cmd.Parameters.Add("@note", SqlDbType.VarChar).Value = txtNote.Text;
                            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;

                            string ownership = "Milik Sendiri";
                            int available = 1;

                            if (rbMilikLuar.Checked)
                            {
                                available = 0;
                                ownership = "Milik Luar";
                                cmd.Parameters.Add("@relationCode", SqlDbType.VarChar).Value = txtRelation.Text;
                            }
                            else
                            {
                                available = 1;
                                cmd.Parameters.Add("@relationCode", SqlDbType.VarChar).Value = DBNull.Value;
                            }

                            int status = 0;

                            if(chkStatus.Checked == true)
                            {
                                status = 1;
                            }

                            cmd.Parameters.Add("@available", SqlDbType.SmallInt).Value = available;
                            cmd.Parameters.Add("@ownership", SqlDbType.VarChar).Value = ownership;
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
            rbMilikSendiri.Checked = true;
            rbMilikLuar.Checked = false;
            lblRelation.Visible = false;
            btnRelation.Enabled = false;
            btnRelation.Visible = false;
            txtRelation.Text = "";
            txtRelation.Visible = false;
            txtCode1.Text = "";
            txtNote.Text = "";
            chkStatus.Checked = true;
            txtRelation.Focus();
        }

        private Boolean isValid()
        {
            Boolean isValidated = true;

            if(rbMilikLuar.Checked)
            {
                if (String.IsNullOrEmpty(txtRelation.Text))
                {
                    isValidated = false;
                    MessageBox.Show("Kode Relasi harus diisi!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRelation.Select();
                }
            }

            if (isValidated)
            {
                if (String.IsNullOrEmpty(txtCode1.Text) || String.IsNullOrEmpty(txtCode2.Text) || String.IsNullOrEmpty(txtCode3.Text))
                {
                    isValidated = false;
                    MessageBox.Show("Nomor Kontainer harus diisi!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode1.Select();
                }
            }

            return isValidated;
        }

        private void radioMilikSendiri_CheckedChanged(object sender, EventArgs e)
        {
            if(rbMilikSendiri.Checked == true)
            {
                lblRelation.Visible = false;
                txtRelation.Visible = false;
                btnRelation.Enabled = false;
                btnRelation.Visible = false;
                txtRelation.Text = "";
                txtCode1.Text = "";
            }
        }

        private void radioMilikLuar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMilikLuar.Checked == true)
            {
                lblRelation.Visible = true;
                txtRelation.Visible = true;
                btnRelation.Enabled = true;
                btnRelation.Visible = true;
            }
        }

        private void btnRelation_Click(object sender, EventArgs e)
        {
            Form dialogForm = new dialogRelationForm(username, "NewForm");
            dialogForm.ShowDialog(this);
        }

        public void btnRelationClick(string relationCode, string extension)
        {
            txtRelation.Text = relationCode;
            txtCode1.Text = extension;
        }

        private void txtCode1_TextChanged(object sender, EventArgs e)
        {
            if(txtCode1.Text.Length >= 4)
            {
                txtCode2.Select();
            }
        }

        private void txtCode2_TextChanged(object sender, EventArgs e)
        {
            if (txtCode2.Text.Length >= 6)
            {
                txtCode3.Select();
            }
        }
    }
}
