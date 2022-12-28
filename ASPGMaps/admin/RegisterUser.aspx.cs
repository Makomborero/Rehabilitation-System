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
    public partial class RegisterUser : System.Web.UI.Page
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


        protected void button2_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                HttpPostedFile postedFile = ProfileFileUpload.PostedFile;
                string filename = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(filename);

                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".bmp" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".jpeg")
                {
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    using (SqlConnection con = new SqlConnection(s))
                    {
                        SqlCommand cmd = new SqlCommand("spInsertNewUser", con);
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
                            int value = (int)cmd.ExecuteScalar(); // as procedure return number
                            if (value == 1)
                            {
                                Response.Redirect("/admin/RegisterUser.aspx?registration=successful");
                                Label1.Visible = true;
                                Label1.Text = "Registration Successful";
                                Label1.ForeColor = System.Drawing.Color.Blue;
                            }
                            else
                            {
                                Label1.Visible = true;
                                Label1.Text = "Username is already in use";
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
                else {
                    Label1.Visible = true;
                    Label1.Text = "Enter valid image format";
                    Label1.ForeColor = System.Drawing.Color.Red;

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