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
public partial class admin : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Request.QueryString["name"];
        string str = string.Empty;
        str = Convert.ToString(Session["User_Username"]);
        if (name == "")
        {
            get_editexamfill(str);
        }
        else {
            get_editexamfill(str);
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
                    Label2.Text = rd["user_fname"].ToString() +" "+ rd["user_lname"].ToString();
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

    protected void link_loginout_Click(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string name = Request.QueryString["name"];
        Response.Redirect(string.Format("~/admin/MyProfile.aspx?name={0}", name));
    }

    protected void btnLogin_Click2(object sender, EventArgs e)
    {
        string name = Request.QueryString["name"];
        Response.Redirect(string.Format("~/admin/RegisterUser.aspx?name={0}", name));
    }
    protected void btnLogin2_Click(object sender, EventArgs e)
    {
        Response.Redirect(string.Format("~/Default.aspx"));
    }

    protected void btnLogin_Click3(object sender, EventArgs e)
    {
        string name = Request.QueryString["name"];
        Response.Redirect(string.Format("~/studentlocations.aspx"));
    }
}
