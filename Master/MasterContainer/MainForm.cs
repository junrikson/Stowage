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
    public partial class MainForm : Syncfusion.Windows.Forms.MetroForm
    {
        string connString = ConfigurationManager.ConnectionStrings["stowageConnection"].ToString();
        string username = "";

        public MainForm(string username)
        {
            this.username = username;
            InitializeComponent();
            GridSettings();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (CheckAuth())
            {
                Grid_Load();
                txtFilterValue.Focus();
            }
            else
            {
                MessageBox.Show("Anda tidak mempunyai Otoritas untuk mengakses menu ini!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }

        private bool CheckAuth()
        {
            bool isOk = true;

            string query = "SELECT c.[active], c.[new], c.[edit], c.[view], c.[delete], c.[print], c.[refresh] " +
                "FROM masterUser a " +
                "INNER JOIN masterRoles b ON a.rolesCode = b.code " +
                "INNER JOIN masterRolesDetail c ON b.ID = c.rolesID " +
                "INNER JOIN masterMenu d ON c.menuCode = d.code " +
                "WHERE a.code = @username AND c.menuCode = 'A0003' ";
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = this.username;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["active"].ToString() != "1")
                                    isOk = false;
                                if (reader["new"].ToString() != "1")
                                    btnNew.Enabled = false;
                                if (reader["edit"].ToString() != "1")
                                    btnEdit.Enabled = false;
                                if (reader["view"].ToString() != "1")
                                    btnView.Enabled = false;
                                if (reader["delete"].ToString() != "1")
                                    btnDelete.Enabled = false;
                                if (reader["refresh"].ToString() != "1")
                                    btnRefresh.Enabled = false;
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
            return isOk;
        }

        void Form_Closed(object sender, FormClosedEventArgs e)
        {
            Grid_Load();
        }

        #region Actions
        private void btnNew_Click(object sender, EventArgs e)
        {
            NewForm newForm = new NewForm(username);
            newForm.FormClosed += new FormClosedEventHandler(Form_Closed);
            newForm.ShowDialog();
            this.SuspendLayout();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string id = "";

            if (gridView.SelectedCells.Count != 0)
            {
                try
                {
                    DataGridViewCell cell = gridView.SelectedCells[0];
                    DataGridViewRow row = cell.OwningRow;
                    id = row.Cells[0].Value.ToString();

                    ViewForm viewForm = new ViewForm(id, username);
                    viewForm.FormClosed += new FormClosedEventHandler(Form_Closed);
                    viewForm.ShowDialog();
                    this.SuspendLayout();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = "";

            if (gridView.SelectedCells.Count != 0)
            {
                try
                {
                    DataGridViewCell cell = gridView.SelectedCells[0];
                    DataGridViewRow row = cell.OwningRow;
                    id = row.Cells[0].Value.ToString();

                    EditForm editForm = new EditForm(id, username);
                    editForm.FormClosed += new FormClosedEventHandler(Form_Closed);
                    editForm.ShowDialog();
                    this.SuspendLayout();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Grid_Load();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = "";
            string name = "";

            if (gridView.SelectedCells.Count != 0)
            {
                try
                {
                    DataGridViewCell cell = gridView.SelectedCells[0];
                    DataGridViewRow row = cell.OwningRow;
                    id = row.Cells[0].Value.ToString();
                    name = row.Cells["Nomor Kontainer"].Value.ToString();

                    DialogResult dialogResult = MessageBox.Show("Are you sure want to delete " + name + " ?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            using (SqlConnection con = new SqlConnection(connString))
                            {
                                using (SqlCommand cmd = new SqlCommand("DELETE FROM masterContainer WHERE id = @id", con))
                                {

                                    cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                                    con.Open();
                                    cmd.ExecuteNonQuery();

                                    Grid_Load();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            } 
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int status = 1;
            string code = "";
            string relationCode = "";
            string ownership = "";
            string note = "";

            if (cmbStatus.SelectedItem.ToString() == "Not Active")
            {
                status = 0;
            }

            if (cmbFilterColumn.SelectedItem.ToString() == "Kode Relasi")
            {
                relationCode = txtFilterValue.Text;
            }
            else if (cmbFilterColumn.SelectedItem.ToString() == "Nomor Kontainer")
            {
                code = txtFilterValue.Text;
            }
            else if (cmbFilterColumn.SelectedItem.ToString() == "Kepemilikan")
            {
                ownership = txtFilterValue.Text;
            }
            else if (cmbFilterColumn.SelectedItem.ToString() == "Keterangan")
            {
                note = txtFilterValue.Text;
            }

            Grid_Load(status, code, ownership, relationCode, note);
        }
        #endregion

        #region Grid

        public void Grid_Load(int status = 1, string code = "", string ownership = "", string relationCode = "", string note = "")
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Nomor Kontainer", typeof(String));
            dt.Columns.Add("Kepemilikan", typeof(String));
            dt.Columns.Add("Kode Relasi", typeof(String));
            dt.Columns.Add("Keterangan", typeof(String));
            dt.Columns.Add("Ketersediaan", typeof(String));
            dt.Columns.Add("Diubah", typeof(DateTime));
            dt.Columns.Add("Dibuat", typeof(DateTime));
            dt.Columns.Add("User", typeof(String));
            dt.Columns.Add("Status", typeof(String));

            try
            {
                String sqlString = "SELECT id, code, ownership, relationCode, note, available, status, username, updated, created FROM masterContainer WHERE " +
                    "status = (@status) " +
                    "AND (code like @code OR code IS NULL) " +
                    "AND (ownership like @ownership OR ownership IS NULL) " +
                    "AND (relationCode like @relationCode OR relationCode IS NULL) " +
                    "AND (note like @note OR note IS NULL) " +
                    "AND (1=1)";

                using (SqlDataAdapter da = new SqlDataAdapter(sqlString, connString))
                {
                    da.SelectCommand.Parameters.Add("@status", SqlDbType.Int).Value = status;
                    da.SelectCommand.Parameters.Add("@ownership", SqlDbType.VarChar).Value = ownership + '%';
                    da.SelectCommand.Parameters.Add("@code", SqlDbType.VarChar).Value = code + '%';
                    da.SelectCommand.Parameters.Add("@relationCode", SqlDbType.VarChar).Value = relationCode + '%';
                    da.SelectCommand.Parameters.Add("@note", SqlDbType.VarChar).Value = note + '%';

                    using (DataSet ds = new DataSet())
                    {
                        da.Fill(ds, "data");

                        DataTable tDT = new DataTable();
                        tDT = ds.Tables["data"];

                        for (int i = 0; i < tDT.Rows.Count; i++)
                        {
                            DataRow dr = dt.NewRow();
                            DataRow tDR = tDT.Rows[i];
                            string isActive = "Active";
                            string Available = "Tersedia";
                            
                            dr["ID"] = tDR["id"];
                            dr["Nomor Kontainer"] = tDR["code"];
                            dr["Kepemilikan"] = tDR["ownership"];
                            dr["Kode Relasi"] = tDR["relationCode"];
                            dr["Keterangan"] = tDR["note"];
                            dr["Diubah"] = tDR["updated"];
                            dr["Dibuat"] = tDR["created"];
                            dr["User"] = tDR["username"];

                            if (tDR["status"].ToString() != "1")
                            {
                                isActive = "Not Active";
                            }
                            dr["Status"] = isActive;

                            if (tDR["available"].ToString() != "1")
                            {
                                Available = "Tidak Tersedia";
                            }
                            dr["Ketersediaan"] = Available;

                            dt.Rows.Add(dr);
                        }

                        gridView.DataSource = dt;
                        gridView.Columns["ID"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void GridSettings()
        {
            cmbFilterColumn.Items.Add("Nomor Kontainer");
            cmbFilterColumn.Items.Add("Kepemilikan");
            cmbFilterColumn.Items.Add("Kode Relasi");
            cmbFilterColumn.Items.Add("Keterangan");
            cmbFilterColumn.SelectedItem = "Nomor Kontainer";

            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("Not Active");
            cmbStatus.SelectedItem = "Active";
        }
        #endregion
    }
}