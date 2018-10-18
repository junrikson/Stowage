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
    public partial class ViewForm : Syncfusion.Windows.Forms.MetroForm 
    {
        string connString = ConfigurationManager.ConnectionStrings["stowageConnection"].ToString();
        string id = "";
        string username = "";

        public ViewForm(string id, string username)
        {
            InitializeComponent();
            this.id = id;
            this.username = username;
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void Load_Data()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 code, ownership, relationCode, note, status FROM masterContainer WHERE id = @id", con))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string[] container = reader["code"].ToString().Split(' ');
                                txtCode1.Text = container[0];
                                txtCode2.Text = container[1];

                                if (reader["ownership"].ToString() == "Milik Sendiri")
                                {
                                    lblRelation.Visible = false;
                                    txtRelation.Visible = false;
                                    txtRelation.Text = "";
                                    rbMilikSendiri.Checked = true;
                                }
                                else
                                {
                                    lblRelation.Visible = true;
                                    txtRelation.Visible = true;
                                    rbMilikLuar.Checked = true;
                                    txtRelation.Text = reader["relationCode"].ToString();
                                }

                                txtNote.Text = reader["note"].ToString();
                                if (reader["status"].ToString() == "1")
                                    chkStatus.Checked = true;
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

        private void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 id, code, ownership, relationCode, note, status FROM masterContainer WHERE id < @id ORDER BY id DESC", con))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.id = reader["id"].ToString();
                                string[] container = reader["code"].ToString().Split(' ');
                                txtCode1.Text = container[0];
                                txtCode2.Text = container[1];

                                if (reader["ownership"].ToString() == "Milik Sendiri")
                                {
                                    lblRelation.Visible = false;
                                    txtRelation.Visible = false;
                                    txtRelation.Text = "";
                                    rbMilikSendiri.Checked = true;
                                }
                                else
                                {
                                    lblRelation.Visible = true;
                                    txtRelation.Visible = true;
                                    rbMilikLuar.Checked = true;
                                    txtRelation.Text = reader["relationCode"].ToString();
                                }

                                txtNote.Text = reader["note"].ToString();
                                if (reader["status"].ToString() == "1")
                                    chkStatus.Checked = true;
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 id, code, ownership, relationCode, note, status FROM masterContainer WHERE id > @id ORDER BY id ASC", con))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.id = reader["id"].ToString();
                                string[] container = reader["code"].ToString().Split(' ');
                                txtCode1.Text = container[0];
                                txtCode2.Text = container[1];

                                if (reader["ownership"].ToString() == "Milik Sendiri")
                                {
                                    lblRelation.Visible = false;
                                    txtRelation.Visible = false;
                                    txtRelation.Text = "";
                                    rbMilikSendiri.Checked = true;
                                }
                                else
                                {
                                    lblRelation.Visible = true;
                                    txtRelation.Visible = true;
                                    rbMilikLuar.Checked = true;
                                    txtRelation.Text = reader["relationCode"].ToString();
                                }

                                txtNote.Text = reader["note"].ToString();
                                if (reader["status"].ToString() == "1")
                                    chkStatus.Checked = true;
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
    }
}
