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
using System.Data;

namespace Dashboard
{
    public partial class DeleteDataForm : Syncfusion.Windows.Forms.MetroForm
    {
        string connString = ConfigurationManager.ConnectionStrings["stowageConnection"].ToString();
        string username = "";

        public DeleteDataForm(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void DeleteDataForm_Load(object sender, EventArgs e)
        {
            
        }

        private void cbLoadingPlan_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLoadingPlan.Checked == true)
            {
                cbStowage.Checked = true;
                cbStowage.Enabled = false;
            }
            else
            {
                cbStowage.Enabled = true;
            }
        }

        private void cbContainerTransaction_CheckedChanged(object sender, EventArgs e)
        {
            if (cbContainerTransaction.Checked == true)
            {
                cbStowage.Checked = true;
                cbStowage.Enabled = false;
                cbLoadingPlan.Checked = true;
                cbLoadingPlan.Enabled = false;
            }
            else
            {
                cbLoadingPlan.Enabled = true;
            }
        }

        private void cbMasterContainer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMasterContainer.Checked == true)
            {
                cbStowage.Checked = true;
                cbStowage.Enabled = false;
                cbLoadingPlan.Checked = true;
                cbLoadingPlan.Enabled = false;
                cbContainerExternalIn.Checked = true;
                cbContainerExternalIn.Enabled = false;
                cbContainerExternalOut.Checked = true;
                cbContainerExternalOut.Enabled = false;
                cbContainerInternalIn.Checked = true;
                cbContainerInternalIn.Enabled = false;
                cbContainerInternalOut.Checked = true;
                cbContainerInternalOut.Enabled = false;
                cbContainerTransaction.Checked = true;
                cbContainerTransaction.Enabled = false;
            }
            else
            {
                cbContainerExternalIn.Enabled = true;
                cbContainerExternalOut.Enabled = true;
                cbContainerInternalIn.Enabled = true;
                cbContainerInternalOut.Enabled = true;
                cbContainerTransaction.Enabled = true;
            }
        }

        private void cbMasterRelation_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMasterRelation.Checked == true)
            {
                cbStowage.Checked = true;
                cbStowage.Enabled = false;
                cbLoadingPlan.Checked = true;
                cbLoadingPlan.Enabled = false;
                cbContainerExternalIn.Checked = true;
                cbContainerExternalIn.Enabled = false;
                cbContainerExternalOut.Checked = true;
                cbContainerExternalOut.Enabled = false;
                cbContainerInternalIn.Checked = true;
                cbContainerInternalIn.Enabled = false;
                cbContainerInternalOut.Checked = true;
                cbContainerInternalOut.Enabled = false;
                cbContainerTransaction.Checked = true;
                cbContainerTransaction.Enabled = false;
                cbMasterContainer.Checked = true;
                cbMasterContainer.Enabled = false;
            }
            else
            {
                cbMasterContainer.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtStatus.AppendText("Deleting Data...\n\n");
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    SqlTransaction tran = con.BeginTransaction();
                    SqlCommand cmd;

                    if(cbStowage.Checked == true)
                    {
                        txtStatus.AppendText("Deleting Stowage...\n\n");
                        cmd = new SqlCommand("DELETE FROM stowageDetail", con, tran);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("DELETE FROM stowage", con, tran);
                        cmd.ExecuteNonQuery();
                    }

                    if (cbLoadingPlan.Checked == true)
                    {
                        txtStatus.AppendText("Deleting Loading Plan...\n\n");
                        cmd = new SqlCommand("DELETE FROM loadingPlanDetail", con, tran);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("DELETE FROM loadingPlan", con, tran);
                        cmd.ExecuteNonQuery();
                    }

                    if (cbContainerTransaction.Checked == true)
                    {
                        txtStatus.AppendText("Deleting Container Transaction...\n\n");
                        cmd = new SqlCommand("DELETE FROM containerTransaction", con, tran);
                        cmd.ExecuteNonQuery();
                    }

                    if (cbContainerExternalIn.Checked == true)
                    {
                        txtStatus.AppendText("Deleting Container External In...\n\n");
                        cmd = new SqlCommand("DELETE FROM containerExternalIn", con, tran);
                        cmd.ExecuteNonQuery();
                    }

                    if (cbContainerExternalOut.Checked == true)
                    {
                        txtStatus.AppendText("Deleting Container External Out...\n\n");
                        cmd = new SqlCommand("DELETE FROM containerExternalOut", con, tran);
                        cmd.ExecuteNonQuery();
                    }

                    if (cbContainerInternalIn.Checked == true)
                    {
                        txtStatus.AppendText("Deleting Container Internal In...\n\n");
                        cmd = new SqlCommand("DELETE FROM containerInternalIn", con, tran);
                        cmd.ExecuteNonQuery();
                    }

                    if (cbContainerInternalOut.Checked == true)
                    {
                        txtStatus.AppendText("Deleting Container Internal Out...\n\n");
                        cmd = new SqlCommand("DELETE FROM containerInternalOut", con, tran);
                        cmd.ExecuteNonQuery();
                    }

                    if (cbMasterContainer.Checked == true)
                    {
                        txtStatus.AppendText("Deleting Master Container...\n\n");
                        cmd = new SqlCommand("DELETE FROM masterContainer", con, tran);
                        cmd.ExecuteNonQuery();
                    }

                    if (cbMasterRelation.Checked == true)
                    {
                        txtStatus.AppendText("Deleting Master Relation...\n\n");
                        cmd = new SqlCommand("DELETE FROM MasterRelation", con, tran);
                        cmd.ExecuteNonQuery();
                    }

                    try
                    {
                        tran.Commit();
                        txtStatus.AppendText("All Data Deleted Succesfully...\n\n");
                        MessageBox.Show("Penghapusan Selesai!");
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
        }
    }
}

