using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
public partial class StudentMaster : System.Web.UI.MasterPage
{
    string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString; //calling the connection string
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Request.QueryString["name"];
        string str = string.Empty;
        str = Convert.ToString(Session["User_Username"]);
        if (!this.IsPostBack)
        {
            this.BindGrid(str);
        }
        if (name == "")
        {
            get_editexamfill(str);
            get_tempPulseLocation(str);
        }
        else
        {
            get_editexamfill(str);
            get_tempPulseLocation(str);
        }
    }

    private void BindGrid(string username)
    {
        string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlCommand cmd = new SqlCommand("SELECT top 1 [LocLat],[LocLong] FROM HotelMaster where HotelName = @user_username order by HotelId desc");
        cmd.Parameters.AddWithValue("@user_username", username);
        using (SqlConnection con = new SqlConnection(conString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;

                sda.SelectCommand = cmd;
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
    }


    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string url = "https://maps.google.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false&key=AIzaSyC4RxKLQzKnyAQ0qKy8M-ZFG1Fxp0wdj_4";
            url = string.Format(url, e.Row.Cells[0].Text, e.Row.Cells[1].Text);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.UserAgent = "[any words that is more than 5 characters]";

            using (WebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    DataSet dsResult = new DataSet();
                    dsResult.ReadXml(reader);
                    (e.Row.FindControl("lblAddress") as Label).Text = dsResult.Tables[0].ToString();
                    Label8.Visible = true;
                    Label8.Text = dsResult.Tables["result"].Rows[0]["formatted_address"].ToString();
                }
            }
        }
    }

    string ConvertDatasetToString(DataSet Ds)
    {
        string OUT = "";
        for (int t = 0; t < Ds.Tables.Count; t++)
        {
            for (int r = 0; r < Ds.Tables[t].Rows.Count; r++)
            {
                for (int c = 0; c < Ds.Tables[t].Columns.Count; c++)
                {
                    string s = Ds.Tables[t].Rows[r][c].ToString();
                    OUT += s;
                }
            }
        }
        return OUT;
    }


    protected void get_tempPulseLocation(string username)
    {
        string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        using (SqlConnection con = new SqlConnection(s))
        {
            SqlCommand com = new SqlCommand("select top 1 * from TempHeart where Student_Name = @user_username order by Id desc", con);
            com.Parameters.AddWithValue("@user_username", username);
            try
            {
                con.Open();
                SqlDataReader rd = com.ExecuteReader();
                while (rd.Read())
                {
                    Label3.Visible = true;
                    Label3.ForeColor = System.Drawing.Color.RoyalBlue;
                    Label3.Text = "Temperature: ";
                    Label4.Visible = true;
                    Label4.Text = rd["Temp"].ToString() + " °C.";

                    Label5.Visible = true;
                    Label5.ForeColor = System.Drawing.Color.RoyalBlue;
                    Label5.Text = "Pulse Rate: ";
                    Label6.Visible = true;
                    Label6.Text = rd["Bmp"].ToString() + " bmps.";
                }


            }
            catch (Exception ex)
            {
                Label1.Visible = true;
                Label1.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
            }
        }

        using (SqlConnection con2 = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("select top 1 * from HotelMaster where HotelName = @user_username order by HotelId desc", con2);
            cmd.Parameters.AddWithValue("@user_username", username);
            try
            {
                con2.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Label7.Visible = true;
                    Label7.ForeColor = System.Drawing.Color.RoyalBlue;
                    Label7.Text = "Location: ";
                }
            }
            catch (Exception ex)
            {
                Label1.Visible = true;
                Label1.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
            }
        }
    }


    protected void get_editexamfill(string username)
    {
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
                    Label2.Text = rd["user_fname"].ToString() + " " + rd["user_lname"].ToString();
                    bytes = (byte[])rd["user_picture"];
                    string strBase64 = Convert.ToBase64String(bytes);
                    image2.ImageUrl = "data:Image/png;base64," + strBase64;
                }


            }
            catch (Exception ex)
            {
                Label1.Visible = true;
                Label1.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
            }
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string name = Request.QueryString["name"];
        Response.Redirect(string.Format("~/MyProfile.aspx?name={0}", name));
    }

    protected void btnLogin2_Click(object sender, EventArgs e)
    {
        Response.Redirect(string.Format("~/Default.aspx"));
    }

}
