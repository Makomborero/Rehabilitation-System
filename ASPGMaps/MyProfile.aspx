<%@ Page Title="" Language="C#" MasterPageFile="~/StudentMaster.master" AutoEventWireup="True" Inherits="ASPGMaps.MyProfile" CodeFile="MyProfile.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="heardcontentplaceholder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontentplaceholder" Runat="Server">
    <script type="text/javascript" language="javascript">
        function displayImage(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=image1.ClientID%>').prop('src', e.target.result)
                        .width(250)
                        .height(250);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
    <div class="card-header">
        <h2>My Profile</h2>
    </div>
    <div class="container">
        <div class="card o-hidden border-0 shadow-lg my-50">
            <div class="card-body p-0">
                <div class="rowregister">
                    <div class="col-lg-70">
                        <div class="p-5">
                            <div class="user">
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <div class="form-group">                                        <div class="text-center">
                                            <h1 class="h4 text-gray-90 mb-4" style="font-size: 1rem;font-weight: 400;line-height: 1.5;color: #6e707e;background-color: #fff;background-clip: padding-box;border-radius: 0.35rem;transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;">Profile Picture</h1>
                                        </div>
                                            </div>
                                        <div class="form-group" style="display: block; margin-left: auto; margin-right: auto; width: 250px;">
                                         <asp:Image ID="image1" runat="server" CssClass="img-thumbnail" ImageUrl="~/img/default_user.jpg" Width="250px" Height="250px" ImageAlign="Middle" />
                                            </div>  
                                  
                                            <div style="position: relative; display: inline-block; width: 250px; height: calc(1.5em + 0.75rem + 2px); margin-bottom: 0; display: block; margin-left: auto; margin-right: auto; width: 250px;">  
                                                <asp:FileUpload ID="ProfileFileUpload" runat="server" CssClass="custom-file-input" onchange="displayImage(this)"/>  
                                                <label class="custom-file-label"></label>  
                                          
                                </div>
                                    </div>

                                    <div class="col-sm-6">
                                        <div class="form-group">
                                             <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                                        </div>

                                        <div class="form-group row">
                                            <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <h4 class="form-control-user" style="display: block;width: 100%;height: calc(1.5em + 0.75rem + 2px);padding: 0.375rem 0.75rem;font-size: 1rem;font-weight: 400;line-height: 1.5;color: #6e707e;background-color: #fff;background-clip: padding-box;border-radius: 0.35rem;transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;">User Category</h4>
                                            </div>
                                            <div class="col-sm-6">
                                        <asp:DropdownList runat="server" ID="ComboBox1" CssClass="form-control form-control-user" placeholder="User Category">
                                                    <asp:ListItem selected="True" hidden="True">User Category</asp:ListItem>
                                                    <asp:ListItem Text="Former Addict" Value="0" />
                                                </asp:DropdownList>
                                        </div>
                                            </div>

                                        <div class="form-group row">
                                            <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <h4 class="form-control-user" style="display: block;width: 100%;height: calc(1.5em + 0.75rem + 2px);padding: 0.375rem 0.75rem;font-size: 1rem;font-weight: 400;line-height: 1.5;color: #6e707e;background-color: #fff;background-clip: padding-box;border-radius: 0.35rem;transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;">Force Number</h4>
                                            </div>
                                            <div class="col-sm-6">
                                              <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control form-control-user" placeholder="ID Number" />
                                        </div>
                                            </div>

                                        

                                        <div class="form-group row">
                                            <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <h4 class="form-control-user" style="display: block;width: 100%;height: calc(1.5em + 0.75rem + 2px);padding: 0.375rem 0.75rem;font-size: 1rem;font-weight: 400;line-height: 1.5;color: #6e707e;background-color: #fff;background-clip: padding-box;border-radius: 0.35rem;transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;">Rank</h4>
                                            </div>
                                            <div class="col-sm-6">
                                        <asp:DropdownList runat="server" ID="DropdownList2" CssClass="form-control form-control-user" placeholder="Rank">
                                                   <asp:ListItem selected="True" hidden="True">Drug Categories</asp:ListItem>
                                                    <asp:ListItem Text="Marijuana/ Cannabis" Value="0" />
                                                    <asp:ListItem Text="Cocaine" Value="1" />
                                                    <asp:ListItem Text="Guka" Value="2" />
                                                    <asp:ListItem Text="Alcohol" Value="3" />
                                                    <asp:ListItem Text="heroin" Value="4" />
                                                    <asp:ListItem Text="Glue" Value="5" />
                                                    <asp:ListItem Text="Histalix" Value="6" />
                                                    <asp:ListItem Text="Bronclear" Value="7" />
                                                    <asp:ListItem Text="Stimulants" Value="8" />
                                                    <asp:ListItem Text="Tobacco" Value="9" />
                                                    <asp:ListItem Text="FLT" Value="10" />
                                                    <asp:ListItem Text="LT" Value="11" />
                                                    <asp:ListItem Text="Benzos" Value="12" />
                                                    <asp:ListItem Text="Hallucinogen Drugs" Value="13" />
                                                    <asp:ListItem Text="Methamphetamine" Value="14" />
                                                    <asp:ListItem Text="CAPT" Value="15" />
                                                    <asp:ListItem Text="AVM" Value="16" />
                                                    <asp:ListItem Text="Prescription Drugs" Value="17" />
                                                </asp:DropdownList>
                                        </div>
                                            </div>

                                         <div class="form-group row">
                                            <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <h4 class="form-control-user" style="display: block;width: 100%;height: calc(1.5em + 0.75rem + 2px);padding: 0.375rem 0.75rem;font-size: 1rem;font-weight: 400;line-height: 1.5;color: #6e707e;background-color: #fff;background-clip: padding-box;border-radius: 0.35rem;transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;">Name</h4>
                                            </div>
                                            <div class="col-sm-6">
                                               <asp:TextBox runat="server" ID="TextBox5" CssClass="form-control form-control-user" placeholder="Name" />
                                            </div>
                                        </div>  

                                        <div class="form-group row">
                                            <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <h4 class="form-control-user" style="display: block;width: 100%;height: calc(1.5em + 0.75rem + 2px);padding: 0.375rem 0.75rem;font-size: 1rem;font-weight: 400;line-height: 1.5;color: #6e707e;background-color: #fff;background-clip: padding-box;border-radius: 0.35rem;transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;">Surname</h4>
                                            </div>
                                            <div class="col-sm-6">
                                               <asp:TextBox runat="server" ID="TextBox6" CssClass="form-control form-control-user" placeholder="Surname" />
                                            </div>
                                        </div>  

                                        <div class="form-group row">
                                            <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <h4 class="form-control-user" style="display: block;width: 100%;height: calc(1.5em + 0.75rem + 2px);padding: 0.375rem 0.75rem;font-size: 1rem;font-weight: 400;line-height: 1.5;color: #6e707e;background-color: #fff;background-clip: padding-box;border-radius: 0.35rem;transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;">Department</h4>
                                            </div>
                                            <div class="col-sm-6">
                                        <asp:DropdownList runat="server" ID="DropdownList3" CssClass="form-control form-control-user" placeholder="Department">
                                                    <asp:ListItem selected="True" hidden="True">Department</asp:ListItem>
                                                    <asp:ListItem Text="Engineering" Value="0" />
                                                    <asp:ListItem Text="Administration" Value="1" />
                                                    <asp:ListItem Text="Regiment" Value="2" />
                                                    <asp:ListItem Text="Equipment" Value="2" />
                                                    <asp:ListItem Text="Flying" Value="2" />
                                        </asp:DropdownList>
                                        </div>
                                            </div>

                                        <div class="form-group row">
                                            <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <h4 class="form-control-user" style="display: block;width: 100%;height: calc(1.5em + 0.75rem + 2px);padding: 0.375rem 0.75rem;font-size: 1rem;font-weight: 400;line-height: 1.5;color: #6e707e;background-color: #fff;background-clip: padding-box;border-radius: 0.35rem;transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;">Username</h4>
                                            </div>
                                            <div class="col-sm-6">
                                               <asp:TextBox runat="server" ID="TextBox2" CssClass="form-control form-control-user" placeholder="Username" />
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <h4 class="form-control-user" style="display: block;width: 100%;height: calc(1.5em + 0.75rem + 2px);padding: 0.375rem 0.75rem;font-size: 1rem;font-weight: 400;line-height: 1.5;color: #6e707e;background-color: #fff;background-clip: padding-box;border-radius: 0.35rem;transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;">Password</h4>
                                            </div>
                                            <div class="col-sm-6">
                                               <asp:TextBox runat="server" ID="TextBox3" CssClass="form-control form-control-user" placeholder="Password" />
                                            </div>
                                        </div>  

                                        <div class="form-group row">
                                            <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <h4 class="form-control-user" style="display: block;width: 100%;height: calc(1.5em + 0.75rem + 2px);padding: 0.375rem 0.75rem;font-size: 1rem;font-weight: 400;line-height: 1.5;color: #6e707e;background-color: #fff;background-clip: padding-box;border-radius: 0.35rem;transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;">Date of Birth</h4>
                                            </div>
                                            <div class="col-sm-6">
                                               <asp:TextBox runat="server" ID="TextBox4" CssClass="form-control form-control-user"/>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <h4 class="form-control-user" style="display: block;width: 100%;height: calc(1.5em + 0.75rem + 2px);padding: 0.375rem 0.75rem;font-size: 1rem;font-weight: 400;line-height: 1.5;color: #6e707e;background-color: #fff;background-clip: padding-box;border-radius: 0.35rem;transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;">ID Number</h4>
                                            </div>
                                            <div class="col-sm-6">
                                              <asp:TextBox runat="server" ID="TextBox7" CssClass="form-control form-control-user" placeholder="ID Number" />
                                        </div>
                                        </div>

                                        
                                        <div class="form-group row">
                                            <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <h4 class="form-control-user" style="display: block;width: 100%;height: calc(1.5em + 0.75rem + 2px);padding: 0.375rem 0.75rem;font-size: 1rem;font-weight: 400;line-height: 1.5;color: #6e707e;background-color: #fff;background-clip: padding-box;border-radius: 0.35rem;transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;">Gender</h4>
                                            </div>
                                            <div class="col-sm-6">
                                        <asp:DropdownList runat="server" ID="DropdownList1" CssClass="form-control form-control-user" placeholder="Gender">
                                                    <asp:ListItem selected="True" hidden="True">Gender</asp:ListItem>
                                                    <asp:ListItem Text="Male" Value="0" />
                                                    <asp:ListItem Text="Female" Value="1" />
                                                </asp:DropdownList>
                                        </div>
                                        </div>

                                        <div class="form-group row">
                                            <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <h4 class="form-control-user" style="display: block;width: 100%;height: calc(1.5em + 0.75rem + 2px);padding: 0.375rem 0.75rem;font-size: 1rem;font-weight: 400;line-height: 1.5;color: #6e707e;background-color: #fff;background-clip: padding-box;border-radius: 0.35rem;transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;">Address</h4>
                                            </div>
                                            <div class="col-sm-6">
                                              <asp:TextBox runat="server" ID="TextBox10" CssClass="form-control form-control-user" placeholder="Mobile Number" />
                                        </div>
                                            </div>

                                        <div class="form-group row">
                                            <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <h4 class="form-control-user" style="display: block;width: 100%;height: calc(1.5em + 0.75rem + 2px);padding: 0.375rem 0.75rem;font-size: 1rem;font-weight: 400;line-height: 1.5;color: #6e707e;background-color: #fff;background-clip: padding-box;border-radius: 0.35rem;transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;">Email Address</h4>
                                            </div>
                                            <div class="col-sm-6">
                                              <asp:TextBox runat="server" ID="TextBox11" CssClass="form-control form-control-user" placeholder="Email Address" />
                                        </div>
                                            </div>
                                        <div class="form-group row">
                                            <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <h4 class="form-control-user" style="display: block;width: 100%;height: calc(1.5em + 0.75rem + 2px);padding: 0.375rem 0.75rem;font-size: 1rem;font-weight: 400;line-height: 1.5;color: #6e707e;background-color: #fff;background-clip: padding-box;border-radius: 0.35rem;transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;">Address</h4>
                                            </div>
                                            <div class="col-sm-6">
                                              <asp:TextBox runat="server" ID="TextBox13" CssClass="form-control form-control-user" placeholder="Address" />
                                        </div>
                                            </div>
                            </div>
                        </div>

                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">


                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group row">
                                            <div class="col-sm-6 mb-3 mb-sm-0">
                                                    <asp:Button Text="Update" ID="button2" CssClass="btn btn-primary btn-user btn-block" runat="server" OnClick="btn_editexam_Click"/>
                                            </div>
                                            <div class="col-sm-6">
                                               <asp:Button Text="Back" ID="button1" CssClass="btn btn-primary btn-user btn-block" runat="server"/>
                                            </div>
                                        </div>
                                    </div>
                        </div>
                    </div>
                    </div>
                </div>
            </div>
                </div>
        </div>

    </div>
</asp:Content>


    

