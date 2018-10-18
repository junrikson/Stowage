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
using System.Linq;
using System.Windows.Forms;

namespace ContainerExternalOut
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
            if (IsValid())
            {
                try
                {
                    string query = "";

                    if (String.IsNullOrEmpty(txtCode.Text))
                    {
                        query = "INSERT INTO containerExternalOut" +
                            "(code, date, relationCode, containerCode, note, updated, created, username) VALUES " +
                            "(@code + (SELECT RIGHT('000' + CAST((ISNULL((SELECT TOP 1 RIGHT(code,4) " +
                            "   FROM containerExternalOut " +
                            "   WHERE LEFT(RIGHT(code,10),6) = @today " +
                            "   ORDER BY RIGHT(code,4) DESC),0) + 1) AS VARCHAR(4)),4))," +
                            "@date, @relationCode, @containerCode, @note, getdate(), getdate(), @username)";
                    }
                    else
                    {
                        query = "INSERT INTO containerExternalOut" +
                               "(code, date, relationCode, containerCode, note, updated, created, username) VALUES " +
                               "(@code, @date, @relationCode, @containerCode, @note, getdate(), getdate(), @username)";
                    }

                    using (SqlConnection con = new SqlConnection(connString))
                    {

                        con.Open();
                        SqlTransaction tran = con.BeginTransaction();
                        SqlCommand cmd;

                        cmd = new SqlCommand(query, con, tran);

                        if (String.IsNullOrEmpty(txtCode.Text))
                        {
                            cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = "EOU/" + dtpDate.Value.ToString("yyMMdd");
                            cmd.Parameters.Add("@today", SqlDbType.VarChar).Value = dtpDate.Value.ToString("yyMMdd");
                        }
                        else
                        {
                            cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = txtCode.Text;
                        }

                        cmd.Parameters.Add("@date", SqlDbType.Date).Value = dtpDate.Value;
                        cmd.Parameters.Add("@relationCode", SqlDbType.VarChar).Value = txtRelationCode.Text;
                        cmd.Parameters.Add("@containerCode", SqlDbType.VarChar).Value = txtContainerCode.Text;
                        cmd.Parameters.Add("@note", SqlDbType.VarChar).Value = txtNote.Text;
                        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;                        
                        cmd.ExecuteNonQuery();
                        
                        cmd = new SqlCommand("UPDATE masterContainer SET status = 0, available = 0 WHERE code = @containerCode", con, tran);
                        cmd.Parameters.Add("@containerCode", SqlDbType.VarChar).Value = txtContainerCode.Text;
                        cmd.ExecuteNonQuery();

                        try
                        {
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            MessageBox.Show(ex.Message.ToString());
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
            txtCode.ReadOnly = true;
            txtCode.Text = "";
            chkManual.Checked = false;
            dtpDate.Value = DateTime.Today;
            txtContainerCode.Text = "";
            txtNote.Text = "-";
            txtContainerCode.Select();
        }

        private Boolean IsValid()
        {
            Boolean isValidated = true;

            if (!(String.IsNullOrEmpty(txtCode.Text)))
            {
                if(txtCode.Text.Length < 10)
                {
                    isValidated = false;
                    MessageBox.Show("No. Transaksi harus lebih dari 10 karakter!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode.Select();
                }
                else if (!txtCode.Text.Substring(txtCode.Text.Length-10).All(char.IsDigit))
                {
                    isValidated = false;
                    MessageBox.Show("10 Karakter terakhir harus terdiri dari angka dengan format YYMMDDNNNN!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode.Select();
                }
            }

            if (isValidated == true)
            {
                if (String.IsNullOrEmpty(txtRelationCode.Text))
                {
                    isValidated = false;
                    MessageBox.Show("Relasi harus diisi!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRelationCode.Select();
                }
                else if (String.IsNullOrEmpty(txtContainerCode.Text) )
                {
                    isValidated = false;
                    MessageBox.Show("Nomor Kontainer harus diisi!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContainerCode.Select();
                }
            }

            return isValidated;
        }

        private void chkManual_CheckedChanged(object sender, EventArgs e)
        {
            if(chkManual.Checked == true)
            {
                txtCode.ReadOnly = false;   
            }
            else
            {
                txtCode.ReadOnly = true;
            }
        }

        private void btnContainer_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRelationCode.Text))
            {
                MessageBox.Show("Relasi harus diisi!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRelationCode.Select();
            }
            else
            {
                string relationCode = txtRelationCode.Text;
                Form dialogForm = new dialogContainerForm(username, relationCode, "NewForm");
                dialogForm.ShowDialog(this);
            }
        }

        public void btnContainerClick(string containerCode)
        {
            txtContainerCode.Text = containerCode;
        }

        private void btnRelation_Click(object sender, EventArgs e)
        {
            Form dialogForm = new dialogRelationForm(username, "NewForm");
            dialogForm.ShowDialog(this);
        }

        public void btnRelationClick(string relationCode)
        {
            txtRelationCode.Text = relationCode;
        }
    }
}
