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
using MindFusion.Scheduling;

namespace ITS
{
    
    public partial class MyLearningCalendar : System.Web.UI.Page
    {
        string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        Dictionary<string, string> holidays = new Dictionary<string, string>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            DateTime HDays;
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spGetEvent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    con.Open();
                    SqlDataReader _Rd;
                    _Rd = cmd.ExecuteReader();
                    while (_Rd.Read())
                    {
                        HDays = (DateTime)_Rd["start_date"];
                        if (HDays == e.Day.Date)
                        {
                            e.Cell.Controls.Add(new LiteralControl("<p>" + _Rd["subject"] + "<p>"));
                            e.Cell.BackColor = System.Drawing.Color.RoyalBlue;
                            e.Cell.ForeColor = System.Drawing.Color.WhiteSmoke;
                            e.Cell.Font.Bold = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('There was an error: " + ex.Message + "');</script>");
                }
            }
        }
    }
}