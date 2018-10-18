#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.IO;

namespace Dashboard
{
    public partial class RestoreForm : Syncfusion.Windows.Forms.MetroForm
    {
        string connString = ConfigurationManager.ConnectionStrings["stowageConnection"].ToString();
        string username = "";

        public RestoreForm(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            DeclareDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                //RestoreDB();
            }
        }

        private Boolean IsValid()
        {
            Boolean isValidated = true;


            if (String.IsNullOrEmpty(txtFileName.Text))
            {
                isValidated = false;
                MessageBox.Show("Nama File harus diisi!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFileName.Select();
            }
            else if (String.IsNullOrEmpty(txtLocation.Text))
            {
                isValidated = false;
                MessageBox.Show("Lokasi Penyimpanan harus diisi!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Select();
            }

            return isValidated;
        }

        private void DeclareDialog()
        {
            txtFileName.Text = "stowage" + DateTime.Now.ToString("yyyyMMddHHmmss");
            txtLocation.Text = folderBrowserDialog.SelectedPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\backup";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtLocation.Text = folderBrowserDialog.SelectedPath;
                Environment.SpecialFolder root = folderBrowserDialog.RootFolder;
            }
        }

        //private void RestoreDB()
        //{
        //    try
        //    {
        //        txtStatus.AppendText("Backup operation started...\n");
        //        using (var con = new SqlConnection(connString))
        //        {
        //            string destination = txtLocation.Text;
        //            var fileName = Path.Combine(destination, String.Format("{0}.bak", txtFileName.Text));
        //            if (!Directory.Exists(destination))
        //                Directory.CreateDirectory(destination);
        //            var sqlServer = new Server(new ServerConnection(con));
        //            var bkpDatabase = new Backup
        //            {
        //                Action = BackupActionType.Database,
        //                Database = "Stowage"
        //            };
        //            var bkpDevice = new BackupDeviceItem(fileName, DeviceType.File);
        //            bkpDatabase.Devices.Add(bkpDevice);
        //            bkpDatabase.Checksum = true;
        //            bkpDatabase.ContinueAfterError = true;
        //            bkpDatabase.Incremental = false;
        //            bkpDatabase.Initialize = true;
        //            bkpDatabase.CompressionOption = BackupCompressionOptions.On;
        //            bkpDatabase.SqlBackup(sqlServer);
        //            txtStatus.AppendText("Backup operation succeeded!\n");
        //            MessageBox.Show("Backup Selesai!", "Finished!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        txtStatus.AppendText("Backup operation failed :\n");
        //        txtStatus.AppendText(ex.Message + "\n\n");
        //        MessageBox.Show("Backup Gagal!", "Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    conn = new ServerConnection();
        //    conn.ServerInstance = serverName;
        //    srv = new Server(conn);

        //    try
        //    {
        //        Restore res = new Restore();

        //        res.Devices.AddDevice(filePath, DeviceType.File);

        //        RelocateFile DataFile = new RelocateFile();
        //        string MDF = res.ReadFileList(srv).Rows[0][1].ToString();
        //        DataFile.LogicalFileName = res.ReadFileList(srv).Rows[0][0].ToString();
        //        DataFile.PhysicalFileName = srv.Databases[databaseName].FileGroups[0].Files[0].FileName;

        //        RelocateFile LogFile = new RelocateFile();
        //        string LDF = res.ReadFileList(srv).Rows[1][1].ToString();
        //        LogFile.LogicalFileName = res.ReadFileList(srv).Rows[1][0].ToString();
        //        LogFile.PhysicalFileName = srv.Databases[databaseName].LogFiles[0].FileName;

        //        res.RelocateFiles.Add(DataFile);
        //        res.RelocateFiles.Add(LogFile);

        //        res.Database = databaseName;
        //        res.NoRecovery = false;
        //        res.ReplaceDatabase = true;
        //        res.SqlRestore(srv);
        //        conn.Disconnect();
        //    }
        //    catch (SmoException ex)
        //    {
        //        throw new SmoException(ex.Message, ex.InnerException);
        //    }
        //    catch (IOException ex)
        //    {
        //        throw new IOException(ex.Message, ex.InnerException);
        //    }
        //}

        //public static Server Getdatabases(string serverName)
        //{
        //    conn = new ServerConnection();
        //    conn.ServerInstance = serverName;

        //    srv = new Server(conn);
        //    conn.Disconnect();
        //    return srv;

        //}
    }
}

