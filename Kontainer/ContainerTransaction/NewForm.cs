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

namespace ContainerTransaction
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
                    string query = "";

                    if (String.IsNullOrEmpty(txtCode.Text))
                    {
                        query = "INSERT INTO containerTransaction" +
                            "(code, date, containerCode, seal, sender, receiver, type, brand, weight, note, updated, created, username) VALUES " +
                            "(@code + (SELECT RIGHT('000' + CAST((ISNULL((SELECT TOP 1 RIGHT(code,4) " +
                            "   FROM containerTransaction " +
                            "   WHERE LEFT(RIGHT(code,10),6) = @today " +
                            "   ORDER BY RIGHT(code,4) DESC),0) + 1) AS VARCHAR(4)),4))," +
                            "@date, @containerCode, @seal, @sender, @receiver, @type, @brand, @weight, @note, getdate(), getdate(), @username)";
                    }
                    else
                    {
                        query = "INSERT INTO containerTransaction" +
                               "(code, date, containerCode, seal, sender, receiver, type, brand, weight, note, updated, created, username) VALUES " +
                               "(@code, @date, @containerCode, @seal, @sender, @receiver, @type, @brand, @weight, @note, getdate(), getdate(), @username)";
                    }

                    using (SqlConnection con = new SqlConnection(connString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {

                            if (String.IsNullOrEmpty(txtCode.Text))
                            {
                                cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = "TRX/" + dtpDate.Value.ToString("yyMMdd");
                                cmd.Parameters.Add("@today", SqlDbType.VarChar).Value = dtpDate.Value.ToString("yyMMdd");
                            }
                            else
                            {
                                cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = txtCode.Text;
                            }

                            cmd.Parameters.Add("@date", SqlDbType.Date).Value = dtpDate.Value;
                            cmd.Parameters.Add("@containerCode", SqlDbType.VarChar).Value = txtContainerCode.Text;
                            cmd.Parameters.Add("@seal", SqlDbType.VarChar).Value = txtSeal1.Text.Replace("-", string.Empty) + "-" + txtSeal2.Text.Replace("-", string.Empty);
                            cmd.Parameters.Add("@sender", SqlDbType.VarChar).Value = txtSender.Text;
                            cmd.Parameters.Add("@receiver", SqlDbType.VarChar).Value = txtReceiver.Text;
                            cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = txtType.Text;
                            cmd.Parameters.Add("@brand", SqlDbType.VarChar).Value = txtBrand.Text;
                            cmd.Parameters.Add("@weight", SqlDbType.Decimal).Value = txtWeight.Value;
                            cmd.Parameters.Add("@note", SqlDbType.VarChar).Value = txtNote.Text;
                            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                            
                            con.Open();
                            cmd.ExecuteNonQuery();

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
            txtSeal1.Text = "";
            txtSeal2.Text = "";
            txtSender.Text = "";
            txtReceiver.Text = "";
            txtType.Text = "";
            txtBrand.Text = "";
            txtWeight.Value = 0;
            txtNote.Text = "-";
            txtContainerCode.Select();
        }

        private Boolean isValid()
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
                if (String.IsNullOrEmpty(txtContainerCode.Text) )
                {
                    isValidated = false;
                    MessageBox.Show("Nomor Kontainer harus diisi!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContainerCode.Select();
                }
                else if (String.IsNullOrEmpty(txtSeal1.Text) || String.IsNullOrEmpty(txtSeal2.Text))
                {
                    isValidated = false;
                    MessageBox.Show("Nomor Seal harus diisi!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSeal1.Select();
                }
                else if (String.IsNullOrEmpty(txtSender.Text))
                {
                    isValidated = false;
                    MessageBox.Show("Pengirim harus diisi!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSender.Select();
                }
                else if (String.IsNullOrEmpty(txtReceiver.Text))
                {
                    isValidated = false;
                    MessageBox.Show("Penerima harus diisi!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtReceiver.Select();
                }
                else if (String.IsNullOrEmpty(txtType.Text))
                {
                    isValidated = false;
                    MessageBox.Show("Jenis Barang harus diisi!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtType.Select();
                }
                else if (!(txtWeight.Value >= 0))
                {
                    isValidated = false;
                    MessageBox.Show("Berat harus lebih besar daripada Nol!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            Form dialogForm = new dialogContainerForm(username, "NewForm");
            dialogForm.ShowDialog(this);
        }

        public void btnContainerClick(string containerCode)
        {
            txtContainerCode.Text = containerCode;
        }
    }
}
