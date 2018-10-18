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

namespace ContainerExternalIn
{
    public partial class dialogContainerForm : Syncfusion.Windows.Forms.MetroForm
    {
        string connString = ConfigurationManager.ConnectionStrings["stowageConnection"].ToString();
        string username = "";
        string typeForm = "";
        string id = "";
        string relationCode = "";

        public dialogContainerForm(string username, string relationCode, string typeForm, string id = "")
        {
            this.typeForm = typeForm;
            this.username = username;
            this.relationCode = relationCode;
            this.id = id;
            InitializeComponent();
            GridSettings();
            Grid_Load();
        }

        private void dialogContainerForm_Load(object sender, EventArgs e)
        {
            txtFilterValue.Select();
        }

        #region Actions     

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int status = 1;
            string code = "";
            string ownership = "";
            string note = "";

            if (cmbFilterColumn.SelectedItem.ToString() == "Kepemilikan")
            {
                ownership = txtFilterValue.Text;
            }
            else if (cmbFilterColumn.SelectedItem.ToString() == "Nomor Kontainer")
            {
                code = txtFilterValue.Text;
            }
            else if (cmbFilterColumn.SelectedItem.ToString() == "Keterangan")
            {
                note = txtFilterValue.Text;
            }

            Grid_Load(status, code, ownership, note);
        }
        #endregion

        #region Grid

        public void Grid_Load(int status = 1, string code = "", string ownership = "", string note = "")
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
                String sqlString = "SELECT TOP 100 id, code, ownership, relationCode, note, available, status, username, updated, created FROM masterContainer WHERE " +
                    "available = 0 AND ownership = 'Milik Luar' " +
                    "AND (code like @code OR code IS NULL) " +
                    "AND (ownership like @ownership OR ownership IS NULL) " +
                    "AND (relationCode = @relationCode) " +
                    "AND (note like @note OR note IS NULL) " +
                    "AND (1=1)";

                using (SqlDataAdapter da = new SqlDataAdapter(sqlString, connString))
                {
                    da.SelectCommand.Parameters.Add("@ownership", SqlDbType.VarChar).Value = ownership + '%';
                    da.SelectCommand.Parameters.Add("@code", SqlDbType.VarChar).Value = '%' + code + '%';
                    da.SelectCommand.Parameters.Add("@relationCode", SqlDbType.VarChar).Value = this.relationCode;
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
            cmbFilterColumn.Items.Add("Keterangan");
            cmbFilterColumn.SelectedItem = "Nomor Kontainer";
        }
        #endregion

        private void gridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridView.SelectedRows.Count > 0)
            {
                if (typeForm == "NewForm")
                {
                    string code = gridView.SelectedRows[0].Cells[1].Value.ToString();
                    NewForm parentForm = new NewForm(username);
                    ((NewForm)this.Owner).btnContainerClick(code);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Pilih transaksi yang akan ditambahkan!");
            }
        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
            if (gridView.SelectedRows.Count > 0)
            {
                if (typeForm == "NewForm")
                {
                    string code = gridView.SelectedRows[0].Cells[1].Value.ToString();
                    NewForm parentForm = new NewForm(username);
                    ((NewForm)this.Owner).btnContainerClick(code);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Pilih transaksi yang akan ditambahkan!");
            }
        }
    }
}
