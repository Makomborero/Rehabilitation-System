<%@ Page Language="C#" AutoEventWireup="true" Inherits="ITS.StudentMenu" CodeFile="StudentMenu.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BMR System</title>

    <link href="css/sb-admin-2.css" rel="stylesheet">
</head>
<body class="bg-gradient-primary">
    <section>
      <form id="form1" runat="server">
        <div class="container">
            <div >

            </div>
            <div class="row justify-content-center">

                <div class="col-xl-10 col-lg-12 col-md-9">

                    <div class="card o-hidden border-0 shadow-lg my-5">
                       <div class="card-header" style="font-size: 1.5em; text-align: center;">Better-Me Rehabilitation System</></div>
                        <div class="card-body p-0">
                            <div class="row">
                                <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
                                <div class="col-lg-6">
                                    <div class="p-5">
                                        <div class="text-center">
                                            <h1 class="h4 text-gray-900 mb-4">User Login</h1>
                                        </div>
                                        <div class="user">
                                            <div class="form-group">

                                                <asp:DropdownList runat="server" ID="ComboBox1" CssClass="form-control form-control-user" placeholder="User Category">
                                                    <asp:ListItem selected hidden>User Category</asp:ListItem>
                                                    <asp:ListItem Text="Administrator" Value="0" />
                                                    <asp:ListItem Text="Former Addict" Value="1" />
                                                    <asp:ListItem Text="Professional" Value="2" />
                                                </asp:DropdownList>
                                               
                                            </div>

                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control form-control-user" placeholder="Username" />
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control form-control-user" placeholder="Password" />
                                            </div>
                                            <asp:Button Text="Login" ID="btnLogin" CssClass="btn btn-primary btn-user btn-block" runat="server" />
                                        </div>
                                        <hr>
                                        <div class="text-center">
                                            <a class="small" href="forgot-password.html">Forgot Password?</a>
                                        </div>
                                        <div class="text-center">
                                            <a class="small" href="Register.aspx">Register New Account</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

            </div>

        </div>
    </form>
    </section>
 
</body>
</html>