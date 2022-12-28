using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class exam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Username"] != null)
        {
            getstringuser.Text =  Session["User_Username"].ToString();
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (!IsPostBack)
        {
            string eid = Request.QueryString["eid"];
            if (eid == null)
            {
                Response.Redirect("Default.aspx");
            }
            questionistmethod(Convert.ToInt32(eid));
        }
        if (!SM1.IsInAsyncPostBack)
        {
            string eid = Request.QueryString["eid"];
            string time = getExamDuration(Convert.ToInt32(eid));
            Session["timeout"] = DateTime.Now.AddMinutes(Convert.ToInt32(time)).ToString();
        }        
    }

    string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

    protected void timer1_tick(object sender, EventArgs e)
    {
        if (0 > DateTime.Compare(DateTime.Now, DateTime.Parse(Session["timeout"].ToString())))
        {
            var x = ((Int32)DateTime.Parse(Session["timeout"].ToString()).Subtract(DateTime.Now).TotalHours);
            var y = 60;
            lblTimer.Text = string.Format("Time Left: {0}:{1}:{2}", x, ((Int32)DateTime.Parse(Session["timeout"].ToString()).Subtract(DateTime.Now).TotalMinutes- (x * y)).ToString(), ((Int32)DateTime.Parse(Session["timeout"].ToString()).Subtract(DateTime.Now).Seconds).ToString());
        }
        else
        {
            timer1.Enabled = true;
            foreach (GridViewRow row in gridview_examquestion.Rows)
            {
                Label li = row.FindControl("lblid") as Label;
                RadioButton r1 = row.FindControl("option_one") as RadioButton;
                RadioButton r2 = row.FindControl("option_two") as RadioButton;
                RadioButton r3 = row.FindControl("option_three") as RadioButton;
                RadioButton r4 = row.FindControl("option_four") as RadioButton;

                if (r1.Checked == true)
                {
                    select_number = 1;
                }
                else if (r2.Checked == true)
                {
                    select_number = 2;
                }
                else if (r3.Checked == true)
                {
                    select_number = 3;
                }
                else if (r4.Checked == true)
                {
                    select_number = 4;
                }

                checkanwer(li.Text);
                panel_questshow_warning.Visible = false;
            }
            saveinresult(passfail(), correct_number, gridview_examquestion.Rows.Count);

        }
    }


    public string getExamDuration(int id)
    {
        using (SqlConnection con = new SqlConnection(s))
        {
            SqlCommand cmd = new SqlCommand("select exam_duration from exam where exam_id = @exam_id", con);
            cmd.Parameters.AddWithValue("@exam_id", id);
            try
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    return rd["exam_duration"].ToString();
                }
                return rd["exam_duration"].ToString();
            }
            catch (Exception ex)
            {
                
                panel_questshow_warning.Visible = true;
                lbl_questshowwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem " + ex.Message;
                return "";
            }

        }
    }


    //method for getting question
    public void questionistmethod(int id)
    {
        using (SqlConnection con = new SqlConnection(s))
        {
            SqlCommand cmd = new SqlCommand("spQuestionserachexam", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@examid", id);
            try
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    gridview_examquestion.DataSource = rd;
                    gridview_examquestion.DataBind();
                }
                else
                {
                    panel_questshow_warning.Visible = true;
                    lbl_questshowwarning.Text = "Sorry! There is no question in this exam";
                }
            }
            catch (Exception ex)
            {
                panel_questshow_warning.Visible = true;
                lbl_questshowwarning.Text = "Something went wrong. Please try after sometime later jdjdj</br> Contact you developer for this problem" + ex.Message;
            }
        }
    }

    //decalring some varibles to exam marking 
    string result = string.Empty;
    int select_number = 0;
    int correct_number = 0;
    int wrong_number = 0;
    int count = 0;
    protected void btn_submit_Click(object sender, EventArgs e)
    {


        foreach (GridViewRow row in gridview_examquestion.Rows)
        {
            Label li = row.FindControl("lblid") as Label;
            RadioButton r1 = row.FindControl("option_one") as RadioButton;
            RadioButton r2 = row.FindControl("option_two") as RadioButton;
            RadioButton r3 = row.FindControl("option_three") as RadioButton;
            RadioButton r4 = row.FindControl("option_four") as RadioButton;

            if (r1.Checked == true)
            {
                select_number = 1;
            }
            else if (r2.Checked == true)
            {
                select_number = 2;
            }
            else if (r3.Checked == true)
            {
                select_number = 3;
            }
            else if (r4.Checked == true)
            {
                select_number = 4;
            }

            checkanwer(li.Text);
            panel_questshow_warning.Visible = false;
        }
        saveinresult(passfail(), correct_number, gridview_examquestion.Rows.Count);

    }

    //method for checking answer wheter it is right or wrong 
    public void checkanwer(string qid)
    {
        using (SqlConnection con = new SqlConnection(s))
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "select * from question where question_id = @questionid" + count;
            cmd.Parameters.AddWithValue("@questionid" + count, qid);
            cmd.Connection = con;

            try
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    if (select_number == Convert.ToInt32(rd["question_answer"]))
                    {

                        correct_number = correct_number + 1;
                        break;
                    }
                    else
                    {
                        wrong_number = wrong_number + 1;
                        break;
                    }
                }
                count++;

            }
            catch (Exception ex)
            {
                panel_questshow_warning.Visible = true;
                lbl_questshowwarning.Text = "Something went wrong. Please try after sometime later  jsjsjs</br> Contact you developer for this problem" + ex.Message;
            }
        }
    }

    //method for cheking if examinee pass or fail from the exam pass mark in database
    public string passfail()
    {
        string eid = Request.QueryString["eid"];
        using (SqlConnection con = new SqlConnection(s))
        {
            SqlCommand cmd = new SqlCommand("Select exampass_marks from exam where exam_id = @examid", con);
            cmd.Parameters.AddWithValue("@examid", eid);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (correct_number >= Convert.ToInt32(rd["exampass_marks"]))
                {

                    result = result + "Pass";
                    break;
                }
                else
                {
                    result = result + "Fail";
                    break;
                }
            }
        }
        return result;
    }

    // method for  saving the result info in databse
    public void saveinresult(string status, int score, int tquestion)
    {
        string eid = Request.QueryString["eid"];
        using (SqlConnection con = new SqlConnection(s))
        {
            SqlCommand cmd = new SqlCommand("spResultinsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@examfid", eid);
            cmd.Parameters.AddWithValue("@resultstatus", status);
            cmd.Parameters.AddWithValue("@resultscore", score);
            cmd.Parameters.AddWithValue("@totalquestion", tquestion);
            cmd.Parameters.AddWithValue("@username", getstringuser.Text);
            cmd.Parameters.AddWithValue("@examdate", DateTime.Now);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Response.Redirect("~/myresult.aspx");
            }
            catch (Exception ex)
            {
                panel_questshow_warning.Visible = true;
                lbl_questshowwarning.Text = "Something went wrong. Please try after sometime later Contact you developer for this problem</br> Contact you developer for this problem" + ex.Message;
            }
        }
    }
}