using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace ITS.admin
{
    public partial class ScheduleEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        protected void btn_addexam_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                using (SqlConnection con = new SqlConnection(s))
                {
                    SqlCommand cmd = new SqlCommand("spAddEvent", con);
                    cmd.CommandType = CommandType.StoredProcedure;
             
                    cmd.Parameters.AddWithValue("@subject", txt_examname.Text);
                    cmd.Parameters.AddWithValue("@event_description", txt_examdis.Text);
                    cmd.Parameters.AddWithValue("@start_date", txt_examdate.Text);
                    try
                    {
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            Response.Redirect("~/admin/MyLearningCalendar.aspx");
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
    }
}