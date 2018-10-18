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
    public partial class EditForm : Syncfusion.Windows.Forms.MetroForm 
    {
        string connString = ConfigurationManager.ConnectionStrings["stowageConnection"].ToString();
        string id = "";
        string username = "";

        public EditForm(string id, string username)
        {
            InitializeComponent();
            this.id = id;
            this.username = username;
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connString))
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE masterContainer " +
                            "SET ownership = @ownership, " +
                            "relationCode = @relationCode, " +
                            "note = @note, " +
                            "status = @status, " +
                            "updated = getdate(), " +
                            "username = @username " +
                            "WHERE id = @id", con))
                        {

                            string ownership = "Milik Sendiri";

                            if (rbMilikLuar.Checked)
                            {
                                ownership = "Milik Luar";
                                cmd.Parameters.Add("@relationCode", SqlDbType.VarChar).Value = txtRelation.Text;
                            }
                            else
                            {
                                cmd.Parameters.Add("@relationCode", SqlDbType.VarChar).Value = DBNull.Value;
                            }
                            
                            cmd.Parameters.Add("@note", SqlDbType.VarChar).Value = txtNote.Text;
                            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

                            int status = 0;

                            if(chkStatus.Checked == true)
                            {
                                status = 1;
                            }
                            
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

        private Boolean isValid()
        {
            Boolean isValidated = true;

            if (rbMilikLuar.Checked)
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
                if (String.IsNullOrEmpty(txtCode1.Text) || String.IsNullOrEmpty(txtCode2.Text))
                {
                    isValidated = false;
                    MessageBox.Show("Nomor Kontainer harus diisi!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode1.Select();
                }
            }

            return isValidated;
        }

        private void Load_Data()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 code, ownership, relationCode, note, status FROM masterContainer WHERE id = @id", con))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string[] containerCode = reader["code"].ToString().Split(' ');
                                txtCode1.Text = containerCode[0];
                                string[] containerNumber = containerCode[1].Split('-');
                                txtCode2.Text = containerNumber[0];
                                txtCode3.Text = containerNumber[1];

                                if (reader["ownership"].ToString() == "Milik Sendiri")
                                {
                                    lblRelation.Visible = false;
                                    txtRelation.Visible = false;
                                    btnRelation.Enabled = false;
                                    btnRelation.Visible = false;
                                    txtRelation.Text = "";
                                    rbMilikSendiri.Checked = true;
                                }
                                else
                                {
                                    lblRelation.Visible = true;
                                    txtRelation.Visible = true;
                                    btnRelation.Enabled = true;
                                    btnRelation.Visible = true;
                                    rbMilikLuar.Checked = true;
                                    txtRelation.Text = reader["relationCode"].ToString();
                                }

                                txtNote.Text = reader["note"].ToString();
                                if (reader["status"].ToString() == "1")
                                    chkStatus.Checked = true;
                            }
                        }

                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void btnRelationClick(string relationCode, string extension)
        {
            txtRelation.Text = relationCode;
        }

        private void rbMilikSendiri_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMilikSendiri.Checked == true)
            {
                lblRelation.Visible = false;
                txtRelation.Visible = false;
                btnRelation.Enabled = false;
                btnRelation.Visible = false;
                txtRelation.Text = "";
            }
        }

        private void rbMilikLuar_CheckedChanged(object sender, EventArgs e)
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
            Form dialogForm = new dialogRelationForm(username, "EditForm");
            dialogForm.ShowDialog(this);
        }
    }
}
