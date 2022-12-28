using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;



namespace ASPGMaps.admin
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getallusers();
            }
        }

        string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        //method for get all result
        public void getallusers()
        {
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("select * from usrdata", con);
                try
                {
                    con.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter())
                    {
                        ad.SelectCommand = cmd;
                        using (DataTable tb = new DataTable())
                        {
                            ad.Fill(tb);
                            if (tb != null)
                            {
                                gridallstudents.DataSource = tb;
                                gridallstudents.DataBind();
                            }
                            else
                            {
                                panel_studentlistshow_warning.Visible = true;
                                lbl_studentlistshowwarning.Text = "There are no result right now in this application";
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    panel_studentlistshow_warning.Visible = true;
                    lbl_studentlistshowwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                }
            }
        }

        protected void grdview_examlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "deleteuser")
            {
                deleteuser(Convert.ToInt32(e.CommandArgument));
                getallusers();
            }
        }

        public void deleteuser(int id)
        {
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("delete usrdata where usrID = @userid", con);
                cmd.Parameters.AddWithValue("@userid", id);
                try
                {
                    con.Open();
                    int i = (int)cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Response.Redirect("~/admin/UserList.aspx");
                        Response.Write("Delete Succesfully");
                    }
                    else
                    {
                        panel_studentlistshow_warning.Visible = true;
                        lbl_studentlistshowwarning.Text = "Something went wrong. Can't delete now";
                    }
                }
                catch (Exception ex)
                {
                    panel_studentlistshow_warning.Visible = true;
                    lbl_studentlistshowwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                }

            }
        }


        //for paging
        protected void gridallstudents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridallstudents.PageIndex = e.NewPageIndex;
            getallusers();
        }
    }
}


   
