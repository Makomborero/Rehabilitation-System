using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace ASPGMaps
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string name = Request.QueryString["name"];
            string str = string.Empty;
            str = Convert.ToString(Session["User_Username"]);
            if (!IsPostBack)
            {
                if (name == "")
                {
                    get_editexamfill(str);
                }
                else
                {
                    get_editexamfill(str);
                }
            }
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

        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        protected void get_editexamfill(string username) {
            string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spGetUserInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_username", username);
                try
                {
                    byte[] bytes;
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        TextBox1.Text = rd["user_id_number"].ToString();
                        ComboBox1.SelectedItem.Text = rd["usercategory"].ToString();
                        DropdownList2.SelectedItem.Text = rd["user_rank"].ToString();
                        DropdownList3.SelectedItem.Text = rd["user_department"].ToString();
                        TextBox5.Text = rd["user_fname"].ToString();
                        TextBox6.Text = rd["user_lname"].ToString();
                        TextBox2.Text = rd["user_username"].ToString();
                        TextBox3.Text = Decrypt(rd["user_password"].ToString());
                        DropdownList1.SelectedItem.Text = rd["user_gender"].ToString();
                        TextBox4.Text = rd["user_dob"].ToString();
                        TextBox7.Text = rd["user_force_number"].ToString();
                        TextBox10.Text = rd["user_mobile"].ToString();
                        TextBox11.Text = rd["user_email"].ToString();
                        TextBox13.Text = rd["user_address"].ToString();
                        bytes = (byte[])rd["user_picture"];
                        string strBase64 = Convert.ToBase64String(bytes);
                        image1.ImageUrl = "data:Image/png;base64," + strBase64;
                    }


                }
                catch (Exception ex)
                {
                    Label1.Visible = true;
                    Label1.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
                }
            }
        }

        protected void btn_editexam_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                HttpPostedFile postedFile = ProfileFileUpload.PostedFile;
                string filename = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(filename);

                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".jpeg" || fileExtension.ToLower() == ".bmp" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".gif")
                {
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand("spEditUser", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@user_id_number", TextBox1.Text);
                        cmd.Parameters.AddWithValue("@user_rank", DropdownList2.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@user_department", DropdownList3.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@usercategory", ComboBox1.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@user_fname", TextBox5.Text);
                        cmd.Parameters.AddWithValue("@user_lname", TextBox6.Text);
                        cmd.Parameters.AddWithValue("@user_username", TextBox2.Text);
                        cmd.Parameters.AddWithValue("@user_password", Encrypt(TextBox3.Text));
                        cmd.Parameters.AddWithValue("@user_gender", DropdownList1.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@user_dob", TextBox4.Text);
                        cmd.Parameters.AddWithValue("@user_force_number", TextBox7.Text);
                        cmd.Parameters.AddWithValue("@user_mobile", TextBox10.Text);
                        cmd.Parameters.AddWithValue("@user_email", TextBox11.Text);
                        cmd.Parameters.AddWithValue("@user_address", TextBox13.Text);
                        cmd.Parameters.AddWithValue("@user_picture", bytes);
                        try
                        {
                            con.Open();
                            int i = (int)cmd.ExecuteNonQuery();
                            if (i > 0)
                            {
                                Response.Redirect("~/MyProfile.aspx");
                            }
                            else
                            {
                                Label1.Visible = true;
                                Label1.Text = "Something went wrong. Can't update. Please try after sometime later</br> ";
                            }
                        }
                        catch (Exception ex)
                        {
                            Label1.Visible = true;
                            Label1.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                        }
                    }
                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "Enter valid image format";
                    Label1.ForeColor = System.Drawing.Color.Red;

                }
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "You must fill all the requirements";
            }

        }

    }
}
