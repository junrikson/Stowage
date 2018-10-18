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

namespace ContainerTransaction
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connString))
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE containerTransaction " +
                            "SET date = @date, " +
                            "containerCode = @containerCode, " +
                            "seal = @seal, " +
                            "sender = @sender, " +
                            "receiver = @receiver, " +
                            "type = @type, " +
                            "brand = @brand, " +
                            "weight = @weight, " +
                            "note = @note, " +
                            "updated = getdate(), " +
                            "username = @username " +
                            "WHERE id = @id", con))
                        {

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
                            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                            
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

        private Boolean IsValid()
        {
            Boolean isValidated = true;

            if (String.IsNullOrEmpty(txtContainerCode.Text))
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

            return isValidated;
        }

        private void Load_Data()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 code, date, containerCode, seal, sender, receiver, type, brand, weight, note FROM containerTransaction WHERE id = @id", con))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                txtCode.Text = reader["code"].ToString();
                                dtpDate.Value = DateTime.Parse(reader["date"].ToString());

                                txtContainerCode.Text = reader["containerCode"].ToString();                                

                                string[] seal = reader["seal"].ToString().Split('-');
                                txtSeal1.Text = seal[0];
                                txtSeal2.Text = seal[1];

                                txtSender.Text = reader["sender"].ToString();
                                txtReceiver.Text = reader["receiver"].ToString();
                                txtType.Text = reader["type"].ToString();
                                txtBrand.Text = reader["brand"].ToString();
                                txtWeight.Value = Decimal.Parse(reader["weight"].ToString());
                                txtNote.Text = reader["note"].ToString();
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

        public void btnContainerClick(string containerCode)
        {
            txtContainerCode.Text = containerCode;
        }

        private void btnContainer_Click(object sender, EventArgs e)
        {
            Form dialogForm = new dialogContainerForm(username, "EditForm");
            dialogForm.ShowDialog(this);
        }
    }
}
