#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.WinForms.Controls;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class MainForm : Syncfusion.Windows.Forms.MetroForm
    {
        string connString = ConfigurationManager.ConnectionStrings["stowageConnection"].ToString();
        string username = "";

        public MainForm(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Grid_Load();
            Menu_Load();
        }

        private void Menu_Load()
        {
            string query = "SELECT d.code FROM masterUser a " +
                "INNER JOIN masterRoles b ON a.rolesCode = b.code " +
                "INNER JOIN masterRolesDetail c ON b.ID = c.rolesID " +
                "INNER JOIN masterMenu d ON c.menuCode = d.code " +
                "WHERE a.code = @username AND c.[active] = 0";
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
                                DisableMenu(reader["code"].ToString());
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
        
        private void DisableMenu(string code)
        {
            switch(code)
            {
                //A0000 Master
                case "A0000":
                    masterToolStripMenuItem.Visible = false;
                    break;
                //A0001 Master Kapal
                case "A0001":
                    masterKapalToolStripMenuItem.Visible = false;
                    btnMasterShip.Enabled = false;
                    break;
                //A0002 Master Relasi
                case "A0002":
                    masterRelasiToolStripMenuItem.Visible = false;
                    break;
                //A0003 Master Kontainer
                case "A0003":
                    masterKontainerToolStripMenuItem.Visible = false;
                    btnMasterContainer.Enabled = false;
                    break;
                //A0003 Master Kontainer
                case "A0004":
                    kategoriBeratToolStripMenuItem.Visible = false;

    
                    break;
                //B0000 Kontainer
                case "B0000":
                    kontainerToolStripMenuItem.Visible = false;
                    break;
                //B0001 Transaksi Kontainer
                case "B0001":
                    transaksiKontainerToolStripMenuItem1.Visible = false;
                    btnContainerTransaction.Enabled = false;
                    break;
                //B0010 Milik Sendiri
                case "B0010":
                    milikSendiriToolStripMenuItem.Visible = false;
                    break;
                //B0011 Penjualan Kontainer(OUT)
                case "B0011":
                    penjualanKontainerToolStripMenuItem1.Visible = false;
                    break;
                //B0012 Pembelian Kembali(IN)
                case "B0012":
                    pembelianKembaliToolStripMenuItem.Visible = false;
                    break;
                //B0020 Milik Luar
                case "B0020":
                    milikLuarToolStripMenuItem.Visible = false;
                    break;
                //B0021 Peminjaman Kontainer(IN)
                case "B0021":
                    peminjamanKontainerINToolStripMenuItem1.Visible = false;
                    break;
                //B0022 Pengembalian Kontainer(OUT)
                case "B0022":
                    pengembalianKontainerOUTToolStripMenuItem1.Visible = false;
                    break;
                //C0000 Stowage
                case "C0000":
                    stowageToolStripMenuItem.Visible = false;
                    break;
                //C0001 Rencana Muat
                case "C0001":
                    rencanaMuatToolStripMenuItem.Visible = false;
                    btnLoadingPlan.Enabled = false;
                    break;
                //C0002 Stowage
                case "C0002":
                    stowageToolStripMenuItem.Visible = false;
                    btnStowagePlan.Enabled = false;
                    break;
                //D0000 Settings
                case "D0000":
                    settingsToolStripMenuItem.Visible = false;
                    break;
                //D0001 Menu Manager
                case "D0001":
                    menuManagerToolStripMenuItem.Visible = false;
                    break;
                //D0002 Roles
                case "D0002":
                    rolesToolStripMenuItem.Visible = false;
                    break;
                //D0003 User Manager
                case "D0003":
                    userManagerToolStripMenuItem.Visible = false;
                    break;
                //E0000 Tools
                case "E0000":
                    toolsToolStripMenuItem.Visible = false;
                    break;
                //E0001 BackupDatabase
                case "E0001":
                    backupDatabaseToolStripMenuItem.Visible = false;
                    btnBackupDatabase.Enabled = false;
                    break;
                //E0002 Maintenance Database
                case "E0002":
                    maintenanceDatabaseToolStripMenuItem.Visible = false;
                    break;
                //E0003 Hapus Data
                case "E0003":
                    hapusDataToolStripMenuItem.Visible = false;
                    break;
                //E0004 Ganti Password
                case "E0004":
                    gantiPasswordToolStripMenuItem.Visible = false;
                    btnChangePassword.Enabled = false;
                    break;
                case "F0000":
                    reportsToolStripMenuItem.Visible = false;
                    break;
                case "F0001":
                    transaksiKontainerPerRelasiToolStripMenuItem.Visible = false;
                    break;
            }

        }

        private void kategoriBeratToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process exe = new Process();
                exe.StartInfo.FileName = "MasterCategory.exe";
                exe.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void sfButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Process exe = new Process();
                exe.StartInfo.FileName = "MasterContainer.exe";
                exe.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void masterKapalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process exe = new Process();
                exe.StartInfo.FileName = "MasterShip.exe";
                exe.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void sfButton4_Click(object sender, EventArgs e)
        {
            try
            {
                Process exe = new Process();
                exe.StartInfo.FileName = "MasterShip.exe";
                exe.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void transaksiKontainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process exe = new Process();
                exe.StartInfo.FileName = "ContainerTransaction.exe";
                exe.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnContainerTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                Process exe = new Process();
                exe.StartInfo.FileName = "ContainerTransaction.exe";
                exe.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void rencanaMuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process exe = new Process();
                exe.StartInfo.FileName = "LoadingPlan.exe";
                exe.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Process exe = new Process();
                exe.StartInfo.FileName = "LoadingPlan.exe";
                exe.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void stowageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Process exe = new Process();
                exe.StartInfo.FileName = "StowagePlan.exe";
                exe.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void sfButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Process exe = new Process();
                exe.StartInfo.FileName = "StowagePlan.exe";
                exe.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void menuManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process exe = new Process();
                exe.StartInfo.FileName = "MenuManager.exe";
                exe.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        
        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process exe = new Process();
                exe.StartInfo.FileName = "Roles.exe";
                exe.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void userManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process exe = new Process();
                exe.StartInfo.FileName = "UserManager.exe";
                exe.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void masterRelasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process exe = new Process();
                exe.StartInfo.FileName = "MasterRelation.exe";
                exe.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void masterKontainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process exe = new Process();
                exe.StartInfo.FileName = "MasterContainer.exe";
                exe.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void peminjamanKontainerINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process exe = new Process();
                exe.StartInfo.FileName = "ContainerExternalIn.exe";
                exe.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void pengembalianKontainerOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process exe = new Process();
                exe.StartInfo.FileName = "ContainerExternalOut.exe";
                exe.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void penjualanKontainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process exe = new Process();
                exe.StartInfo.FileName = "ContainerInternalOut.exe";
                exe.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void pembelianKembaliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process exe = new Process();
                exe.StartInfo.FileName = "ContainerInternalIn.exe";
                exe.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void gantiPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm(username);
            changePasswordForm.ShowDialog();
            this.SuspendLayout();
        }

        private void sfButton5_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm(username);
            changePasswordForm.ShowDialog();
            this.SuspendLayout();
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void aboutStowagePlanSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm(username);
            aboutForm.ShowDialog();
            this.SuspendLayout();
        }

        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackupForm backupForm = new BackupForm(username);
            backupForm.ShowDialog();
            this.SuspendLayout();
        }

        private void btnBackupDatabase_Click(object sender, EventArgs e)
        { 
            BackupForm backupForm = new BackupForm(username);
            backupForm.ShowDialog();
            this.SuspendLayout();
        }

        private void hapusDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteDataForm deleteDataForm = new DeleteDataForm(username);
            deleteDataForm.ShowDialog();
            this.SuspendLayout();
        }

        private void maintenanceDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaintenanceForm maintenanceForm = new MaintenanceForm(username);
            maintenanceForm.ShowDialog();
            this.SuspendLayout();
        }

        private void transaksiKontainerPerRelasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransaksiKontainerPerRelasiForm transaksiKontainerPerRelasiForm = new TransaksiKontainerPerRelasiForm(this.username);
            transaksiKontainerPerRelasiForm.ShowDialog();
            this.SuspendLayout();
        }


        public void Grid_Load(string code = "", string container = "", string seal = "", string sender = "", string receiver = "", string type = "", string brand = "", string note = "")
        {
            try
            {
                String sqlString = "SELECT a.id, a.code, a.date, a.containerCode, a.seal, a.sender, a.receiver, a.type, a.brand, a.weight, a.room, a.note, a.username, a.updated, a.created " +
                    "FROM containerTransaction a LEFT JOIN stowageDetail b ON a.code = b.transactionCode " +
                    "WHERE b.transactionCode IS NULL " +
                    "AND (a.date < @date) " +
                    "AND (1=1)";

                SqlDataAdapter da = new SqlDataAdapter(sqlString, connString);
                da.SelectCommand.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Today.AddDays(-7); ;

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
    }
}
