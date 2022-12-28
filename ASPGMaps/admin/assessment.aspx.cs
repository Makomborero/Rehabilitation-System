using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPGMaps.admin
{
    public partial class assessment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getallstudents();
            }
        }
        string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public void getallstudents()
        {
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spGetStudentList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usercategory", "Recruit");
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
                                lbl_studentlistshowwarning.Text = "There are no results right now in this application";
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

        //for paging
        protected void gridallstudents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridallstudents.PageIndex = e.NewPageIndex;
            getallstudents();
        }
    }
}