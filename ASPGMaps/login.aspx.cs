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

public partial class login : System.Web.UI.Page
{
    public SerialPort aSerialPort = new SerialPort(); // thisport is a reference of the serial port to be used in the program
    string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString; //calling the connection string
    string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; //calling the connection string
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string str = string.Empty;
        str = Convert.ToString(Session["User_Username"]);
        checkTempandBP(str);
    }
        //for login
        protected void checkTempandBP(string user_username)
    {
        if (Page.IsValid)
        {
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("select top 1 * from TempHeart where Student_Name = @user_username order by Id desc", con);
                cmd.Parameters.AddWithValue("@user_username", user_username);
                try
                {
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    //Fuzzification
                    while (rd.Read())
                    {
                        //No temperature or blood pressure value
                        if (((rd["Temp"].ToString() == "") || (rd["Temp"].ToString() == "")) || ((rd["Bmp"].ToString() == "") || (rd["Bmp"].ToString() == "")))
                        {
                            Label1.Visible = true;
                            Label1.Text = "You temperature value is missing please connect your sensor to port and connect";
                        }
                        //Recruit is sick
                        else if (((Convert.ToDouble(rd["Temp"]) < 36.1) || (Convert.ToDouble(rd["Temp"]) > 37.2)) || ((Convert.ToDouble(rd["Bmp"]) < 60.0) || (Convert.ToDouble(rd["Bmp"]) > 100.0)))
                        {
                            Label1.Visible = true;
                            Label1.Text = "You are sick visit the doctor";
                            Label1.ForeColor = System.Drawing.Color.Red;
                        }
                        //Recruit is well and can login
                        else {
                            Response.Redirect(string.Format("~/mainmenu.aspx?name={0}", user_username));
                        }

                    }
                }
                catch (Exception ex)
                {

                    Label1.Visible = true;
                    Label1.Text = "Something went wrong.</br> Contact you developer for this problem " + ex.Message;
                }
                  
            }
        }
        else
        {
            Label1.Visible = true;
            Label1.Text = "You temperature value is missing please connect your sensor to port and connect";
        }
    }


    private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
        try
        {
            //SerialPort sData = sender as SerialPort;
            //string[] arrList = sData.ReadLine().Split('/');

            string cord_longitude, cord_latitude, datetime, temp, bmp;
            bool result = true;
            bool result1 = true;
            temp = "37";
            bmp = "100";
            cord_longitude = "-17.836021";
            cord_latitude = "31.005889";
            datetime = "124942";
            string str = string.Empty;
            str = Convert.ToString(Session["User_Username"]);
            string str2 = string.Empty;
            str2 = Convert.ToString(Session["User_Category"]);

            if (result || result1)
            {
                try
                {
                    SqlConnection con = new SqlConnection(s);
                    SqlConnection conn = new SqlConnection(cs);


                    SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[TempHeart] (Student_Name, Temp, Bmp, DateTime) values (@Student_Name, @Temp, @Bmp, @DateTime)", con);
                    cmd.Parameters.AddWithValue("@Student_Name", str);
                    cmd.Parameters.AddWithValue("@Temp", temp);
                    cmd.Parameters.AddWithValue("@bmp", bmp);
                    cmd.Parameters.AddWithValue("@DateTime", datetime);

                    SqlCommand cmd2 = new SqlCommand("spInsertStudentLocation", conn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@User_Category", str2);
                    cmd2.Parameters.AddWithValue("@User_Username", str);
                    cmd2.Parameters.AddWithValue("@LocLat", cord_latitude);
                    cmd2.Parameters.AddWithValue("@LocLong", cord_longitude);
                    cmd.Parameters.AddWithValue("@User_Username2", temp);


                    try
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }
                        int x = cmd.ExecuteNonQuery();
                        int y = cmd2.ExecuteNonQuery();

                        if (x == 1 && y == 1)
                        {
                            Label1.Visible = true;
                            Label1.Text = "Records saved";
                        }
                        else
                        {
                            Label1.Visible = true;
                            Label1.Text = "Query not executed";
                        }
                    }
                    catch (Exception ex)
                    {
                        Label1.Visible = true;
                        Label1.Text = ex.Message;
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }

                    }

                }
                catch (Exception ex)
                {
                    Label1.Visible = true;
                    Label1.Text = ex.Message;
                }
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Data Format not readable"; // checks if data format has been parsed sucessfully
            }
        }
        catch (Exception ex)
        {
            Label1.Visible = true;
            Label1.Text = "Serial Conflict" + ex.Message;
        }
    }

    void getAvailablePorts()
    {
        string[] ports = SerialPort.GetPortNames(); // gets the available port names
        for (int i = 0; i < ports.Length; i++)
        {
            DropDownList1.Items.Add(ports[i].ToString());  // populates the combobox with free ports
        }
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    aSerialPort.PortName = DropDownList1.Text; // Open the serial port from the laptop
        //}
        //catch (Exception ex)
        //{
        //    Label1.Visible = true;
        //    Label1.Text = "Portname Empty </br>" + ex.Message;
        //}
        //aSerialPort.BaudRate = 9600;  //Baudrate of the serial communication system
        //aSerialPort.DataBits = 8;
        //aSerialPort.Parity = Parity.None;
        //aSerialPort.StopBits = StopBits.One;
        //aSerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

        //try
        //{
        //    if (!aSerialPort.IsOpen)
        //    {
        //        aSerialPort.Open();
        //        Label1.Visible = true;
        //        Label1.Text = "Connection Established";
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Label1.Visible = true;
        //    Label1.Text = "Serial Port Not Available </br>" + ex.Message;
        //}

        try
        {
            //SerialPort sData = sender as SerialPort;
            //string[] arrList = sData.ReadLine().Split('/');

            string cord_longitude, cord_latitude, datetime, temp, bmp;
            bool result = true;
            bool result1 = true;
            temp = "37";
            bmp = "100";
            cord_longitude =  "31.005889";
            cord_latitude = "-17.836021";
            datetime = "124942";
            string str = string.Empty;
            str = Convert.ToString(Session["User_Username"]);
            string str2 = string.Empty;
            str2 = Convert.ToString(Session["User_Category"]);

            if (result || result1)
            {
                try
                {
                    SqlConnection con = new SqlConnection(s);
                    SqlConnection conn = new SqlConnection(cs);


                    SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[TempHeart] (Student_Name, Temp, Bmp, DateTime) values (@Student_Name, @Temp, @Bmp, @DateTime)", con);
                    cmd.Parameters.AddWithValue("@Student_Name", str);
                    cmd.Parameters.AddWithValue("@Temp", temp);
                    cmd.Parameters.AddWithValue("@bmp", bmp);
                    cmd.Parameters.AddWithValue("@DateTime", datetime);

                    SqlCommand cmd2 = new SqlCommand("spInsertStudentLocation", conn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@User_Category", str2);
                    cmd2.Parameters.AddWithValue("@User_Username", str);
                    cmd2.Parameters.AddWithValue("@LocLat", cord_latitude);
                    cmd2.Parameters.AddWithValue("@LocLong", cord_longitude);
                    cmd2.Parameters.AddWithValue("@User_Username2", str);


                    try
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }
                        int x = cmd.ExecuteNonQuery();
                        int y = cmd2.ExecuteNonQuery();

                        if (x == 1 && y == 1)
                        {
                            Label1.Visible = true;
                            Label1.Text = "Records saved";
                        }
                        else
                        {
                            Label1.Visible = true;
                            Label1.Text = "Query not executed";
                        }
                    }
                    catch (Exception ex)
                    {
                        Label1.Visible = true;
                        Label1.Text = ex.Message;
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }

                    }

                }
                catch (Exception ex)
                {
                    Label1.Visible = true;
                    Label1.Text = ex.Message;
                }
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Data Format not readable"; // checks if data format has been parsed sucessfully
            }
        }
        catch (Exception ex)
        {
            Label1.Visible = true;
            Label1.Text = "Serial Conflict" + ex.Message;
        }
    }

}


