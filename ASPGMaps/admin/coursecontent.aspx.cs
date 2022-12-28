using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.IO;


namespace ASPGMaps.admin
{
    public partial class coursecontent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                panel_contentlist.Visible = true;
                panel_addcontent.Visible = false;
                btn_panelcategorylist.BackColor = ColorTranslator.FromHtml("#343A40");
                btn_paneladdcategory.BackColor = ColorTranslator.FromHtml("#4e73df");
                string cid = Request.QueryString["sid"];
                getexamList();
                getpdffiles();
                getpptfiles();
                get_subjectdrp();
                get_subjectdrp1();
                get_subjectdrp2();
            }
        }

        protected void btn_addexam_Click1(object sender, EventArgs e)
        {
            string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString; //string of connection
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
                            Response.Redirect("~/admin/coursecontent.aspx");
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

                    string fileName2 = Path.GetFileName(FileUpload2.PostedFile.FileName);
                    FileUpload2.PostedFile.SaveAs(Server.MapPath("~/img/") + fileName2);

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
                            Response.Redirect("~/admin/coursecontent.aspx");
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

                    string fileName2 = Path.GetFileName(FileUpload3.PostedFile.FileName);
                    FileUpload3.PostedFile.SaveAs(Server.MapPath("~/img/") + fileName2);

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
                            Response.Redirect("~/admin/coursecontent.aspx");
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


        //This is button for the enable list of category panel 
        protected void btn_panelcategorylist_Click(object sender, EventArgs e)
        {
            panel_contentlist.Visible = true;
            panel_addcontent.Visible = false;
            btn_panelcategorylist.BackColor = ColorTranslator.FromHtml("#343A40");
            btn_paneladdcategory.BackColor = ColorTranslator.FromHtml("#4e73df");
            string cid = Request.QueryString["sid"];
            getexamList();
            getpdffiles();
            getpptfiles();

        }
        //This is button for enable the adding in category panel
        protected void btn_paneladdcategory_Click(object sender, EventArgs e)
        {
            txt_examname.Focus();
            panel_contentlist.Visible = false;
            panel_addcontent.Visible = true;
            btn_panelcategorylist.BackColor = ColorTranslator.FromHtml("#4e73df");
            btn_paneladdcategory.BackColor = ColorTranslator.FromHtml("#343A40");
        }


        string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString; //string of connection
        public void getexamList()
        {
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("select [vid_Id], [name],  [description], [upload_date], [path] from [dbo].[mp4_files]", con);
                try
                {
                    con.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;
                        using (DataTable dtatble = new DataTable())
                        {
                            ad.Fill(dtatble);
                            GridView2.DataSource = dtatble;
                            GridView2.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    panel4.Visible = true;
                    Label2.Text = "Something went wrong </br>" + ex.Message;
                }
            }
        }

        public void getpdffiles()
        {
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("select [pdf_Id], [name],  [description], [upload_date], [path] from [dbo].[pdf_files] ", con);
                try
                {
                    con.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;
                        using (DataTable dtatble = new DataTable())
                        {
                            ad.Fill(dtatble);
                            grdview_examlist.DataSource = dtatble;
                            grdview_examlist.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    panel_examlist_warning.Visible = true;
                    lbl_examlistwarning.Text = "Something went wrong </br>" + ex.Message;
                }
            }
        }

        public void getpptfiles()
        {
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("select [ppt_Id],[name],  [description], [upload_date], [path] from [dbo].[ppt_files]", con);
                try
                {
                    con.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;
                        using (DataTable dtatble = new DataTable())
                        {
                            ad.Fill(dtatble);
                            GridView1.DataSource = dtatble;
                            GridView1.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    panel2.Visible = true;
                    Label1.Text = "Something went wrong </br>" + ex.Message;
                }
            }
        }

        protected void grdview_examlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdview_examlist.PageIndex = e.NewPageIndex;
            getpdffiles();
        }



        protected void grdview_examlist_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getpptfiles();
        }

        protected void grdview_examlist_PageIndexChanging2(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            getexamList();
        }


        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            string filePath = Server.MapPath(e.CommandArgument.ToString());
            if (File.Exists(filePath))
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("content-disposition", "filename="
                    + filePath);
                Response.WriteFile(filePath);
                Response.Flush();
                Response.End();
            }
        }


    

        public void deletepdf(int id)
        {
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("delete pdf_files where pdf_Id = @pdfid", con);
                cmd.Parameters.AddWithValue("@pdfid", id);
                try
                {
                    con.Open();
                    int i = (int)cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Response.Write("Deleted Succesfully");
                    }
                    else
                    {
                        panel_addexam_warning.Visible = true;
                        lbl_examaddwarning.Text = "Something went wrong. Can't delete now";
                    }
                }
                catch (Exception ex)
                {
                    panel_addexam_warning.Visible = true;
                    lbl_examaddwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                }

            }
        }

        protected void grdview_examlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "deletepdf")
            {
                deletepdf(Convert.ToInt32(e.CommandArgument));
                getpdffiles();
            }
        }

        public void deleteppt(int id)
        {
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("delete ppt_files where ppt_Id = @pptid", con);
                cmd.Parameters.AddWithValue("@pptid", id);
                try
                {
                    con.Open();
                    int i = (int)cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Response.Write("Deleted Succesfully");
                    }
                    else
                    {
                        panel_addexam_warning.Visible = true;
                        lbl_examaddwarning.Text = "Something went wrong. Can't delete now";
                    }
                }
                catch (Exception ex)
                {
                    panel_addexam_warning.Visible = true;
                    lbl_examaddwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                }

            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "deleteppt")
            {
                deleteppt(Convert.ToInt32(e.CommandArgument));
                getpptfiles();
            }
        }

        public void deletevid(int id)
        {
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("delete mp4_files where vid_Id = @vidid", con);
                cmd.Parameters.AddWithValue("@vidid", id);
                try
                {
                    con.Open();
                    int i = (int)cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Response.Write("Deleted Succesfully");
                    }
                    else
                    {
                        panel_addexam_warning.Visible = true;
                        lbl_examaddwarning.Text = "Something went wrong. Can't delete now";
                    }
                }
                catch (Exception ex)
                {
                    panel_addexam_warning.Visible = true;
                    lbl_examaddwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                }

            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "deletevid")
            {
                deletevid(Convert.ToInt32(e.CommandArgument));
                getexamList();
            }
        }
    }
}