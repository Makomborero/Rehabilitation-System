using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;

namespace ITS.admin
{
    public partial class content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                get_subjectdrp();
                get_subjectdrp1();
                get_subjectdrp2();
            }
        }

        string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString; //string of connection

        protected void btn_addexam_Click1(object sender, EventArgs e)
        {
            if (IsValid)
            {
                using (SqlConnection con = new SqlConnection(s))
                {
                    string filename = Path.GetFileName(FileUpload1.FileName);
                    FileUpload1.SaveAs(Server.MapPath("/pdf_files/" + filename));

                    string fileName2 = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/img/") + fileName2);

                    SqlCommand cmd = new SqlCommand("spAddpdf", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@course_fid", drp_subjectexam.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@name", txt_examname.Text);
                    cmd.Parameters.AddWithValue("@description", txt_examdis.Text);
                    DateTime today = DateTime.Today;
                    cmd.Parameters.AddWithValue("@upload_date", today);
                    cmd.Parameters.AddWithValue("@path", "/pdf_files/" + filename);
                    try
                    {
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            Response.Redirect("~/admin/content.aspx");
                        }
                        else
                        {
                            txt_examname.Focus();
                            panel_addexam_warning.Visible = true;
                            lbl_examaddwarning.Text = "Try again. Subject is not added";
                        }
                    }
                    catch (Exception ex)
                    {
                        txt_examname.Focus();
                        panel_addexam_warning.Visible = true;
                        lbl_examaddwarning.Text = "Something went wrong. Subject is not added </br>" + ex.Message;
                    }
                } //end of using
            }
            else
            {
                txt_examname.Focus();
                panel_addexam_warning.Visible = true;
                lbl_examaddwarning.Text = "You must fill all the requirements";
            }
        }

       

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                using (SqlConnection con = new SqlConnection(s))
                {
                    string filename = Path.GetFileName(FileUpload2.FileName);
                    FileUpload2.SaveAs(Server.MapPath("/ppt_files/" + filename));

                    string fileName2 = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/img/") + fileName2);

                    SqlCommand cmd = new SqlCommand("spAddppt", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@course_fid", DropDownList1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@name", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@description", TextBox2.Text);
                    DateTime today = DateTime.Today;
                    cmd.Parameters.AddWithValue("@upload_date", today);
                    cmd.Parameters.AddWithValue("@path", "/ppt_files/" + filename);
                    try
                    {
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            Response.Redirect("~/admin/content.aspx");
                        }
                        else
                        {
                            txt_examname.Focus();
                            panel_addexam_warning.Visible = true;
                            lbl_examaddwarning.Text = "Try again. Subject is not added";
                        }
                    }
                    catch (Exception ex)
                    {
                        txt_examname.Focus();
                        panel_addexam_warning.Visible = true;
                        lbl_examaddwarning.Text = "Something went wrong. Subject is not added </br>" + ex.Message;
                    }
                } //end of using
            }
            else
            {
                txt_examname.Focus();
                panel_addexam_warning.Visible = true;
                lbl_examaddwarning.Text = "You must fill all the requirements";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                using (SqlConnection con = new SqlConnection(s))
                {
                    string filename = Path.GetFileName(FileUpload3.FileName);
                    FileUpload3.SaveAs(Server.MapPath("/Video_Lectures/" + filename));

                    string fileName2 = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/img/") + fileName2);

                    SqlCommand cmd = new SqlCommand("spAddmp4", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@course_fid", DropDownList2.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@name", TextBox4.Text);
                    cmd.Parameters.AddWithValue("@description", TextBox5.Text);
                    DateTime today = DateTime.Today;
                    cmd.Parameters.AddWithValue("@upload_date", today);
                    cmd.Parameters.AddWithValue("@path", "/Video_Lectures/" + filename);
                    try
                    {
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            Response.Redirect("~/admin/content.aspx");
                        }
                        else
                        {
                            txt_examname.Focus();
                            panel_addexam_warning.Visible = true;
                            lbl_examaddwarning.Text = "Try again. Subject is not added";
                        }
                    }
                    catch (Exception ex)
                    {
                        txt_examname.Focus();
                        panel_addexam_warning.Visible = true;
                        lbl_examaddwarning.Text = "Something went wrong. Subject is not added </br>" + ex.Message;
                    }
                } //end of using
            }
            else
            {
                txt_examname.Focus();
                panel_addexam_warning.Visible = true;
                lbl_examaddwarning.Text = "You must fill all the requirements";
            }
        }

        public void get_subjectdrp()
        {
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("select subject_id, subject_name from subject", con);
                try
                {
                    con.Open();
                    drp_subjectexam.DataSource = cmd.ExecuteReader();
                    drp_subjectexam.DataBind();
                    ListItem li = new ListItem("Select category", "-1");
                    drp_subjectexam.Items.Insert(0, li);
                }
                catch (Exception ex)
                {
                    txt_examname.Focus();
                    panel_addexam_warning.Visible = true;
                    lbl_examaddwarning.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }

        public void get_subjectdrp1()
        {
            string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString; //string of connection
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("select subject_id, subject_name from subject", con);
                try
                {
                    con.Open();
                    DropDownList1.DataSource = cmd.ExecuteReader();
                    DropDownList1.DataBind();
                    ListItem li = new ListItem("Select category", "-1");
                    DropDownList1.Items.Insert(0, li);
                }
                catch (Exception ex)
                {
                    txt_examname.Focus();
                    panel_addexam_warning.Visible = true;
                    lbl_examaddwarning.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }

        public void get_subjectdrp2()
        {
            string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString; //string of connection
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("select subject_id, subject_name from subject", con);
                try
                {
                    con.Open();
                    DropDownList2.DataSource = cmd.ExecuteReader();
                    DropDownList2.DataBind();
                    ListItem li = new ListItem("Select category", "-1");
                    DropDownList2.Items.Insert(0, li);
                }
                catch (Exception ex)
                {
                    txt_examname.Focus();
                    panel_addexam_warning.Visible = true;
                    lbl_examaddwarning.Text = "Something went wrong. Try again </br>" + ex.Message;
                }
            }
        }
    }
}