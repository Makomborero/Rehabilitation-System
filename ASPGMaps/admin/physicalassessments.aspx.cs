using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace ASPGMaps.admin
{
    public partial class physicalassessments : System.Web.UI.Page
    {
        private SqlConnection con;
        private SqlCommand com;
        private string constr, query;

        private void connection()
        {
            constr = ConfigurationManager.ConnectionStrings["dbcs"].ToString();
            con = new SqlConnection(constr);
            con.Open();

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            string uemail = Request.QueryString["uid"];
            if (!IsPostBack)
            {
                if (uemail != null)
                {
                    Bindchart(uemail);
                }
                else
                {
                    Bindchart(uemail);
                }

            }
            if (!IsPostBack)
            {
                

            }
        }

        private void Bindchart(string user_username)
        {
            connection();
            SqlCommand com = new SqlCommand("select top 10 * from TempHeart where Student_Name = @user_username order by Id desc", con);
            com.Parameters.AddWithValue("@user_username", user_username);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = com;
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable ChartData = ds.Tables[0];

            //storing total rows count to loop on each Record
            string[] XPointMember = new string[ChartData.Rows.Count];
            double[] YPointMember = new double[ChartData.Rows.Count];
            double[] Y2PointMember = new double[ChartData.Rows.Count];

            for (int count = ChartData.Rows.Count-1; count >= 0; count--)
            {
                //storing Values for X axis
                XPointMember[(ChartData.Rows.Count - 1)-count] = ChartData.Rows[count]["DateTime"].ToString();
                //storing values for Y Axis
                YPointMember[(ChartData.Rows.Count - 1) - count] = Convert.ToDouble(ChartData.Rows[count]["Temp"]);
                Y2PointMember[(ChartData.Rows.Count - 1) - count] = Convert.ToDouble(ChartData.Rows[count]["Bmp"]);
            }
            //binding chart control
            Chart1.Series[0].Points.DataBindXY(XPointMember, YPointMember);

            //Setting width of line
            Chart1.Series[0].BorderWidth = 1;
            //setting Chart type 
              Chart1.Series[0].ChartType = SeriesChartType.Line ;
             Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
             Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            Chart1.ChartAreas["ChartArea1"].AxisX.Title = "Timestamp";
            Chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Sans Serif", 10, FontStyle.Bold);
            Chart1.ChartAreas["ChartArea1"].AxisY.Title = "Temperature (°C)";
            Chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Sans Serif", 10, FontStyle.Bold);
            Chart1.ChartAreas["ChartArea1"].AxisY.Minimum = 32;
            Chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 41;
            Chart1.ChartAreas["ChartArea1"].AxisY.Interval = 5;

            Chart1.Series[0].ChartType = SeriesChartType.Spline;
            Chart1.Titles.Add(new Title("Temperature vs Time Graph",Docking.Top, new Font("Apple Color Emoji", 12f, FontStyle.Bold),Color.Gray));
            //Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;


            Chart1.ChartAreas["ChartArea1"].AxisY.StripLines.Add(new StripLine() { StripWidth = 0.0001, BorderDashStyle = ChartDashStyle.Dot, BorderWidth = 3, Text = "36.1°C - Minimum Normal Temperature", IntervalOffset = 36.1, BorderColor = Color.Red, BackColor = Color.Red });
            Chart1.ChartAreas["ChartArea1"].AxisY.StripLines.Add(new StripLine() { StripWidth = 0.0001, BorderDashStyle = ChartDashStyle.Dot, BorderWidth = 3, Text = "37.2°C - Maximum Normal Temperature", IntervalOffset = 37.2, BorderColor = Color.Red, BackColor = Color.Red });


            //binding chart control
            Chart2.Series[0].Points.DataBindXY(XPointMember, Y2PointMember);

            //Setting width of line
            Chart2.Series[0].BorderWidth = 1;
            //setting Chart type 
            Chart2.Series[0].ChartType = SeriesChartType.Line;
            Chart2.ChartAreas["ChartArea2"].AxisX.MajorGrid.Enabled = false;
            Chart2.ChartAreas["ChartArea2"].AxisY.MajorGrid.Enabled = false;
            Chart2.ChartAreas["ChartArea2"].AxisX.Title = "Timestamp";
            Chart2.ChartAreas["ChartArea2"].AxisX.TitleFont = new Font("Sans Serif", 10, FontStyle.Bold);
            Chart2.ChartAreas["ChartArea2"].AxisY.Title = "Pulse Rate (bmp)";
            Chart2.ChartAreas["ChartArea2"].AxisY.TitleFont = new Font("Sans Serif", 10, FontStyle.Bold);

            
            Chart2.Series[0].ChartType = SeriesChartType.Spline;
            Chart2.Titles.Add(new Title("Pulse Rate vs Time Graph", Docking.Top, new Font("Apple Color Emoji", 12f, FontStyle.Bold), Color.Gray));
            //Chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

            Chart2.ChartAreas["ChartArea2"].AxisY.StripLines.Add(new StripLine() { StripWidth = 0.0001, BorderDashStyle = ChartDashStyle.Dot, BorderWidth = 3, Text = "60bpm - Minimum Normal Pulse Rate", IntervalOffset = 60, BorderColor = Color.Red, BackColor = Color.Red });
            Chart2.ChartAreas["ChartArea2"].AxisY.StripLines.Add(new StripLine() { StripWidth = 0.0001, BorderDashStyle = ChartDashStyle.Dot, BorderWidth = 3, Text = "100bpm - Maximum Normal Pulse Rate", IntervalOffset = 100, BorderColor = Color.Red, BackColor = Color.Red });


            con.Close();

        }
    }
}