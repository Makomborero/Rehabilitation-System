using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;
using System.IO;


namespace ITS
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        //for login
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                using (SqlConnection con = new SqlConnection(s))
                {
                    SqlCommand cmd = new SqlCommand("spUsrLogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usercategory", ComboBox1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@user_username",txtUsername.Text);
                    cmd.Parameters.AddWithValue("@user_password", txtPassword.Text);
                    try
                    {
                        con.Open();
                        int value = (int)cmd.ExecuteScalar();
                        if (value == 1 && ComboBox1.Text == "0")
                        {
                            
                            Session["User_Username"] = txtUsername.Text;
                            Session["User_Category"] = ComboBox1.SelectedItem.Text;
                            string username = txtUsername.Text;
                            Response.Redirect(string.Format("~/admin/Index.aspx?name={0}", username));
                        }
                        if (value == 1 && ComboBox1.Text == "1")
                        {
                         
                                Session["User_Username"] = txtUsername.Text;
                                Session["User_Category"] = ComboBox1.SelectedItem.Text;
                            
                            string username = txtUsername.Text;
                            Response.Redirect(string.Format("~/login.aspx?name={0}", username));
                        }
                        if (value == 1 && ComboBox1.Text == "2")
                        {
                     
                                Session["User_Username"] = txtUsername.Text;
                                Session["User_Category"] = ComboBox1.SelectedItem.Text;
                                
                            
                            string username = txtUsername.Text;
                            Response.Redirect(string.Format("~/admin/Index.aspx?name={0}",username));
                        }
                        else
                        {
                            Label1.Visible = true;
                            Label1.Text = "Use correct username and password</br>";
                            Label1.ForeColor = System.Drawing.Color.Red;
                        }

                    }
                    catch (Exception ex)
                    {
                        Label1.Visible = true;
                        Label1.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
                    }
                }
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Please fill all the requirements";
            }

        }

       
    }
}