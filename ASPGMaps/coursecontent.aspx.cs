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


namespace ITS
{
    public partial class coursecontent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cid = Request.QueryString["sid"];
            getexamList(cid);
            getpdffiles(cid);
            getpptfiles(cid);
        }
                string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString; //string of connection
        public void getexamList(string id)
        {
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("select [name],  [description], [upload_date], [path] from [dbo].[mp4_files] where course_fid = @categoryid", con);
                cmd.Parameters.AddWithValue("@categoryid", id);
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

        public void getpdffiles(string id)
        {
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("select [name],  [description], [upload_date], [path] from [dbo].[pdf_files] where course_fid = @course_id", con);
                cmd.Parameters.AddWithValue("@course_id", id);
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

        public void getpptfiles(string id)
        {
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("select [name],  [description], [upload_date], [path] from [dbo].[ppt_files] where course_fid = @course_id", con);
                cmd.Parameters.AddWithValue("@course_id", id);
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
            string cid = Request.QueryString["cid"];
            if (cid == null)
            {
                Response.Redirect("courseitem.aspx");
            }
            getexamList(cid);
        }

        protected void grdview_examlist_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            string cid = Request.QueryString["cid"];
            if (cid == null)
            {
                Response.Redirect("courseitem.aspx");
            }
            getpptfiles(cid);
        }

        protected void grdview_examlist_PageIndexChanging2(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            string cid = Request.QueryString["cid"];
            if (cid == null)
            {
                Response.Redirect("courseitem.aspx");
            }
            getexamList(cid);
        }
    }
}