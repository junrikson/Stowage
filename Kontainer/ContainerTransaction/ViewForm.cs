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

        private void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 id, code, date, containerCode, seal, sender, receiver, type, brand, weight, note FROM containerTransaction WHERE id < @id ORDER BY id DESC", con))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                id = reader["id"].ToString();
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 id, code, date, containerCode, seal, sender, receiver, type, brand, weight, note FROM containerTransaction WHERE id > @id ORDER BY id ASC", con))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                id = reader["id"].ToString();
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
    }
}
