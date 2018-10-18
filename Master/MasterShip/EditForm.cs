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

namespace MasterShip
{
    public partial class EditForm : Syncfusion.Windows.Forms.MetroForm 
    {
        string connString = ConfigurationManager.ConnectionStrings["stowageConnection"].ToString();
        string username = "";
        string id = "";
        string code = "";

        public EditForm(string id, string username)
        {
            this.id = id;
            this.username = username;
            InitializeComponent();
        }

        private void NewForm_Load(object sender, EventArgs e)
        {
            Load_Data();
            Grid_Load();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                try
                {
                    string query = "UPDATE masterShip SET " +
                               "code = @code, " +
                               "name = @name, " +
                               "note = @note, " +
                               "status = @status, " +
                               "updated = getdate(), " +
                               "created = getdate(), " +
                               "username = @username " +
                               "WHERE id = @id";
                    
                    using (SqlConnection con = new SqlConnection(connString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = txtCode.Text;
                            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = txtName.Text;
                            cmd.Parameters.Add("@note", SqlDbType.VarChar).Value = txtNote.Text;
                            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

                            int status = 0;

                            if (chkStatus.Checked == true)
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

        private Boolean isValid()
        {
            Boolean isValidated = true;

            if (String.IsNullOrEmpty(txtCode.Text))
            {
                isValidated = false;
                MessageBox.Show("Kode Kapal harus diisi!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Select();
            }
            else if (String.IsNullOrEmpty(txtName.Text))
            {
                isValidated = false;
                MessageBox.Show("Nama Kapal harus diisi!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Select();
            }

            return isValidated;
        }

        private void Load_Data()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 code, name, note,status FROM masterShip WHERE id = @id", con))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                txtCode.Text = code = reader["code"].ToString();
                                txtName.Text = reader["name"].ToString();
                                txtNote.Text = reader["note"].ToString();
                                if (reader["status"].ToString() == "0")
                                    chkStatus.Checked = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void Grid_Load()
        {
            try
            {
                String sqlString = "SELECT room FROM masterShipDetail " +
                    "WHERE shipID = @shipID " +
                    "AND (1=1) " +
                    "ORDER BY room";

                using (SqlDataAdapter da = new SqlDataAdapter(sqlString, connString))
                {
                    da.SelectCommand.Parameters.Add("@shipID", SqlDbType.VarChar).Value = id;

                    using (DataSet ds = new DataSet())
                    {
                        da.Fill(ds, "data");

                        DataTable dt = new DataTable();
                        dt = ds.Tables["data"];

                        gridView.DataSource = dt;
                        gridView.Columns[0].HeaderText = "Room";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void gridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string room = gridView.Rows[e.RowIndex].Cells[0].Value.ToString();

            try
            {
                string query = "INSERT INTO masterShipDetail (shipID, room) " +
                            "VALUES(@shipID, @room)";
                
                using (SqlConnection con = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add("@shipID", SqlDbType.VarChar).Value = id;
                        cmd.Parameters.Add("@room", SqlDbType.VarChar).Value = room;

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
            Grid_Load();
        }

        private void gridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string code = e.FormattedValue.ToString();
            string headerText = gridView.Columns[e.ColumnIndex].HeaderText;

            if (!headerText.Equals("Room")) return;
            
            if (string.IsNullOrEmpty(code))
            {
                MessageBox.Show("No. Transaksi tidak boleh kosong!");
                e.Cancel = true;
            }
        }
        
        private void gridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            string code = e.Row.Cells[0].Value.ToString();

            DialogResult dialogResult = MessageBox.Show("Are you sure want to delete " + code + " ?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM masterShipDetail WHERE shipID = @id AND room = @code", con))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                        cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = code;
                        con.Open();
                        cmd.ExecuteNonQuery();

                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
