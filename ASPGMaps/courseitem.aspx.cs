using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ITS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cid = "Theory";
            subjectlistmethod(cid);
        }


        string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        //method for subjectlist
        public void subjectlistmethod(string id)
        {

            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("select * from subject where category_name = @category_name", con);
                cmd.Parameters.AddWithValue("@category_name", id);
                try
                {
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        gridview_categoryitem.DataSource = rd;
                        gridview_categoryitem.DataBind();
                    }
                    else
                    {
                        panel_subjectshow_warning.Visible = true;
                        lbl_subjectshowwarning.Text = "Sorry! There are no courses in this assessment";
                    }
                }
                catch (Exception ex)
                {
                    panel_subjectshow_warning.Visible = true;
                    lbl_subjectshowwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                }
            }
        }
    }
}