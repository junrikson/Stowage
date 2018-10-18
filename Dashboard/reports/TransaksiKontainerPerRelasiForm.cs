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

namespace Dashboard
{
    public partial class TransaksiKontainerPerRelasiForm : Syncfusion.Windows.Forms.MetroForm
    {
        string connString = ConfigurationManager.ConnectionStrings["stowageConnection"].ToString();
        string username = "";

        public TransaksiKontainerPerRelasiForm(string username)
        {
            this.username = username;
            InitializeComponent();
            GridSettings();
        }

        private void TransaksiKontainerPerRelasiForm_Load(object sender, EventArgs e)
        {
            Grid_Load();
            txtFilterValue.Focus();
        }

        void Form_Closed(object sender, FormClosedEventArgs e)
        {
            Grid_Load();
        }

        #region Actions
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Grid_Load();
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string code = "";
            string relationCode = "";
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
            else if (cmbFilterColumn.SelectedItem.ToString() == "Kode Relasi")
            {
                relationCode = txtFilterValue.Text;
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

            Grid_Load(relationCode, code, container, seal, sender2, receiver, type, brand, note);
        }
        #endregion

        #region Grid

        public void Grid_Load(string relationCode = "", string code = "", string container = "", string seal = "", string sender = "", string receiver = "", string type = "", string brand = "", string note = "")
        {
            try
            {
                String sqlString = "SELECT a.id, a.code as transactionCode, a.date as transactionDate, a.containerCode, e.code as relationCode, e.name as relationName, a.seal, a.sender, a.receiver, a.type, a.brand, a.weight, a.room, a.note, c.code as stowageCode, c.date as stowageDate " +
                    "FROM containerTransaction a INNER JOIN masterContainer d ON a.containerCode = d.code " +
                    "LEFT JOIN masterRelation e ON d. relationCode = e.code " +
                    "LEFT JOIN stowageDetail b ON a.code = b.transactionCode " +
                    "LEFT JOIN stowage c ON b.stowageID = c.ID ";

                if (relationCode == "")
                {
                    sqlString = sqlString + "WHERE (e.code like @relationCode OR e.code IS NULL) ";
                }
                else
                {
                    sqlString = sqlString + "WHERE (e.code like @relationCode) ";
                }

                sqlString = sqlString + "AND (a.code like @code OR a.code IS NULL) " +
                    "AND (a.containerCode like @containerCode OR a.containerCode IS NULL) " +
                    "AND (a.seal like @seal OR a.seal IS NULL) " +
                    "AND (a.sender like @sender OR a.sender IS NULL) " +
                    "AND (a.receiver like @receiver OR a.receiver IS NULL) " +
                    "AND (a.type like @type OR a.type IS NULL) " +
                    "AND (a.brand like @brand OR a.brand IS NULL) " +
                    "AND (a.note like @note OR a.note IS NULL) " +
                    "AND (a.date between @dateBegin AND @dateEnd) " +
                    "AND ((c.date between @stowageBegin AND @stowageEnd) OR c.date IS NULL) " +
                    "AND (1=1)";

                SqlDataAdapter da = new SqlDataAdapter(sqlString, connString);
                da.SelectCommand.Parameters.Add("@relationCode", SqlDbType.VarChar).Value = relationCode + '%';
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
                da.SelectCommand.Parameters.Add("@stowageBegin", SqlDbType.Date).Value = dtpStowageBegin.Value;
                da.SelectCommand.Parameters.Add("@stowageEnd", SqlDbType.Date).Value = dtpStowageEnd.Value;

                DataSet ds = new DataSet();
                da.Fill(ds, "data");

                DataTable dt = new DataTable();
                dt = ds.Tables["data"];

                gridView.DataSource = dt;
                gridView.Columns["id"].HeaderText = "ID";
                gridView.Columns["id"].Visible = false;
                gridView.Columns["transactionCode"].HeaderText = "No. Transaksi";
                gridView.Columns["transactionDate"].HeaderText = "Tanggal Transaksi";
                gridView.Columns["containerCode"].HeaderText = "No. Kontainer";
                gridView.Columns["relationCode"].HeaderText = "Kode Relasi";
                gridView.Columns["relationName"].HeaderText = "Nama Relasi";
                gridView.Columns["seal"].HeaderText = "No. Seal";
                gridView.Columns["sender"].HeaderText = "Pengirim";
                gridView.Columns["receiver"].HeaderText = "Penerima";
                gridView.Columns["type"].HeaderText = "Jenis Barang";
                gridView.Columns["brand"].HeaderText = "Merek";
                gridView.Columns["weight"].HeaderText = "Berat (TON)";
                gridView.Columns["room"].HeaderText = "Room";
                gridView.Columns["note"].HeaderText = "Keterangan";
                gridView.Columns["stowageCode"].HeaderText = "Nomor Stowage";
                gridView.Columns["stowageDate"].HeaderText = "Tanggal Stowage";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void GridSettings()
        {   
            cmbFilterColumn.Items.Add("No. Transaksi");
            cmbFilterColumn.Items.Add("Kode Relasi");
            cmbFilterColumn.Items.Add("No. Kontainer");
            cmbFilterColumn.Items.Add("No. Seal");
            cmbFilterColumn.Items.Add("Pengirim");
            cmbFilterColumn.Items.Add("Penerima");
            cmbFilterColumn.Items.Add("Jenis Barang");
            cmbFilterColumn.Items.Add("Merek");
            cmbFilterColumn.Items.Add("Keterangan");
            cmbFilterColumn.SelectedItem = "Kode Relasi";

            dtpDateBegin.Value = DateTime.Today;
            dtpDateEnd.Value = DateTime.Today;
            dtpStowageEnd.Value = DateTime.Today;
        }
        #endregion        
    }
}
