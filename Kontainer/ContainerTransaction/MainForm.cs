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
                "WHERE a.code = @username AND c.menuCode = 'B0001' ";
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
            string code = "";

            if (gridView.SelectedCells.Count != 0)
            {
                try
                {
                    DataGridViewCell cell = gridView.SelectedCells[0];
                    DataGridViewRow row = cell.OwningRow;
                    id = row.Cells[0].Value.ToString();
                    code = row.Cells["code"].Value.ToString();

                    DialogResult dialogResult = MessageBox.Show("Are you sure want to delete " + code + " ?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        using (SqlConnection con = new SqlConnection(connString))
                        {
                            using (SqlCommand cmd = new SqlCommand("DELETE FROM containerTransaction WHERE id = @id", con))
                            {

                                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                                con.Open();
                                cmd.ExecuteNonQuery();

                                if (con.State == System.Data.ConnectionState.Open)
                                {
                                    con.Close();
                                }
                                Grid_Load();
                            }
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
            string code = "";
            string container = "";
            string seal = "";
            string sender2 = "";
            string receiver = "";
            string type = "";
            string brand = "";
            string note = "";
            
            if (cmbFilterColumn.SelectedItem.ToString() == "No. Transaksi")
            {
                code = txtFilterValue.Text;
            }
            else if (cmbFilterColumn.SelectedItem.ToString() == "No. Kontainer")
            {
                container = txtFilterValue.Text;
            }
            else if (cmbFilterColumn.SelectedItem.ToString() == "No. Seal")
            {
                seal = txtFilterValue.Text;
            }
            else if (cmbFilterColumn.SelectedItem.ToString() == "Pengirim")
            {
                sender2 = txtFilterValue.Text;
            }
            else if (cmbFilterColumn.SelectedItem.ToString() == "Penerima")
            {
                receiver = txtFilterValue.Text;
            }
            else if (cmbFilterColumn.SelectedItem.ToString() == "Jenis Barang")
            {
                type = txtFilterValue.Text;
            }
            else if (cmbFilterColumn.SelectedItem.ToString() == "Merek")
            {
                brand = txtFilterValue.Text;
            }
            else if (cmbFilterColumn.SelectedItem.ToString() == "Keterangan")
            {
                note = txtFilterValue.Text;
            }

            Grid_Load(code, container, seal, sender2, receiver, type, brand, note);
        }
        #endregion

        #region Grid

        public void Grid_Load(string code = "", string container = "", string seal = "", string sender = "", string receiver = "", string type = "", string brand = "", string note = "")
        {
            try
            {
                String sqlString = "SELECT a.id, a.code, a.date, a.containerCode, a.seal, a.sender, a.receiver, a.type, a.brand, a.weight, a.room, a.note, a.username, a.updated, a.created " +
                    "FROM containerTransaction a LEFT JOIN stowageDetail b ON a.code = b.transactionCode " +
                    "WHERE b.transactionCode IS NULL " +
                    "AND (a.code like @code OR a.code IS NULL) " +
                    "AND (a.containerCode like @containerCode OR a.containerCode IS NULL) " +
                    "AND (a.seal like @seal OR a.seal IS NULL) " +
                    "AND (a.sender like @sender OR a.sender IS NULL) " +
                    "AND (a.receiver like @receiver OR a.receiver IS NULL) " +
                    "AND (a.type like @type OR a.type IS NULL) " +
                    "AND (a.brand like @brand OR a.brand IS NULL) " +
                    "AND (a.note like @note OR a.note IS NULL) " +
                    "AND (a.weight between @weightBegin AND @weightEnd) " +
                    "AND (a.date between @dateBegin AND @dateEnd) " +
                    "AND (1=1)";

                SqlDataAdapter da = new SqlDataAdapter(sqlString, connString);
                da.SelectCommand.Parameters.Add("@code", SqlDbType.VarChar).Value = code + '%';
                da.SelectCommand.Parameters.Add("@containerCode", SqlDbType.VarChar).Value = container + '%';
                da.SelectCommand.Parameters.Add("@seal", SqlDbType.VarChar).Value = seal + '%';
                da.SelectCommand.Parameters.Add("@sender", SqlDbType.VarChar).Value = sender + '%';
                da.SelectCommand.Parameters.Add("@receiver", SqlDbType.VarChar).Value = receiver + '%';
                da.SelectCommand.Parameters.Add("@type", SqlDbType.VarChar).Value = type + '%';
                da.SelectCommand.Parameters.Add("@brand", SqlDbType.VarChar).Value = brand + '%';
                da.SelectCommand.Parameters.Add("@note", SqlDbType.VarChar).Value = note + '%';
                da.SelectCommand.Parameters.Add("@dateBegin", SqlDbType.Date).Value = dtpDateBegin.Value;
                da.SelectCommand.Parameters.Add("@dateEnd", SqlDbType.Date).Value = dtpDateEnd.Value;
                da.SelectCommand.Parameters.Add("@weightBegin", SqlDbType.Decimal).Value = txtWeightBegin.Value;
                da.SelectCommand.Parameters.Add("@weightEnd", SqlDbType.Decimal).Value = txtWeightEnd.Value;

                DataSet ds = new DataSet();
                da.Fill(ds, "data");

                DataTable dt = new DataTable();
                dt = ds.Tables["data"];

                gridView.DataSource = dt;
                gridView.Columns["id"].HeaderText = "ID";
                gridView.Columns["id"].Visible = false;
                gridView.Columns["code"].HeaderText = "No. Transaksi";
                gridView.Columns["date"].HeaderText = "Tanggal";
                gridView.Columns["containerCode"].HeaderText = "No. Kontainer";
                gridView.Columns["seal"].HeaderText = "No. Seal";
                gridView.Columns["sender"].HeaderText = "Pengirim";
                gridView.Columns["receiver"].HeaderText = "Penerima";
                gridView.Columns["type"].HeaderText = "Jenis Barang";
                gridView.Columns["brand"].HeaderText = "Merek";
                gridView.Columns["weight"].HeaderText = "Berat (TON)";
                gridView.Columns["room"].HeaderText = "Room";
                gridView.Columns["note"].HeaderText = "Keterangan";
                gridView.Columns["updated"].HeaderText = "Diubah";
                gridView.Columns["created"].HeaderText = "Dibuat";
                gridView.Columns["username"].HeaderText = "User";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void GridSettings()
        {   
            cmbFilterColumn.Items.Add("No. Transaksi");
            cmbFilterColumn.Items.Add("No. Kontainer");
            cmbFilterColumn.Items.Add("No. Seal");
            cmbFilterColumn.Items.Add("Pengirim");
            cmbFilterColumn.Items.Add("Penerima");
            cmbFilterColumn.Items.Add("Jenis Barang");
            cmbFilterColumn.Items.Add("Merek");
            cmbFilterColumn.Items.Add("Keterangan");
            cmbFilterColumn.SelectedItem = "No. Transaksi";

            dtpDateBegin.Value = DateTime.Today;
            dtpDateEnd.Value = DateTime.Today;

            txtWeightBegin.Value = 0;
            txtWeightEnd.Value = 100000;
        }
        #endregion        
    }
}
