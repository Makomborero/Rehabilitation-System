<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="userdetails.aspx.cs" Inherits="ASPGMaps.admin.userdetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headplaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div class="col-md-12">
        <div class="card">
            <%--Button For edit--%>
            <div class="btn-group bg-danger">
                <asp:Button ID="btn_detailsexam" runat="server" Text="User Details" CssClass="btn btn-info" BorderStyle="None" CausesValidation="False" BackColor="#343A40" />
            </div>
            <div class="card mb-3">
                <div class="card-body">
                    <%-- For showing the details --%>
                    <div class="table table-responsive">
                        <asp:DetailsView ID="exam_details" runat="server" Height="50px" GridLines="None" CssClass="table table-bordered" AutoGenerateRows="False">
                            <Fields>
                                <asp:BoundField DataField="UsrID" HeaderText="User ID" >
                                    <HeaderStyle Font-Bold="true" CssClass="col-md-2" />
                                </asp:BoundField>
                                <asp:BoundField DataField="user_rank" HeaderText="User Rank" >
                                    <HeaderStyle Font-Bold="true" CssClass="col-md-2" />
                                </asp:BoundField>
                                <asp:BoundField DataField="user_department" HeaderText="Department" >
                                    <HeaderStyle Font-Bold="true" CssClass="col-md-2" />
                                </asp:BoundField>
                                <asp:BoundField DataField="usercategory" HeaderText="User Category">
                                    <HeaderStyle Font-Bold="true" CssClass="col-md-2" />
                                </asp:BoundField>
                                <asp:BoundField DataField="user_fname" HeaderText="First Name" >
                                    <HeaderStyle Font-Bold="true" CssClass="col-md-2" />
                                </asp:BoundField>
                                <asp:BoundField DataField="user_lname" HeaderText="Last Name"  >
                                    <HeaderStyle Font-Bold="true" CssClass="col-md-2" />
                                </asp:BoundField>
                                <asp:BoundField DataField="user_username" HeaderText="Username">
                                    <HeaderStyle Font-Bold="true" CssClass="col-md-2" />
                                </asp:BoundField>
                                <asp:BoundField DataField="user_password" HeaderText="Password">
                                    <HeaderStyle Font-Bold="true" CssClass="col-md-2" />
                                </asp:BoundField>
                                <asp:BoundField DataField="user_gender" HeaderText="Gender" >
                                    <HeaderStyle Font-Bold="true" CssClass="col-md-2" />
                                </asp:BoundField>
                                    <asp:BoundField DataField="user_dob" HeaderText="DOB" >
                                    <HeaderStyle Font-Bold="true" CssClass="col-md-2" />
                                </asp:BoundField>
                                    <asp:BoundField DataField="user_force_number" HeaderText="ID Number" >
                                    <HeaderStyle Font-Bold="true" CssClass="col-md-2" />
                                </asp:BoundField>
                                    <asp:BoundField DataField="user_mobile" HeaderText="Mobile Number">
                                    <HeaderStyle Font-Bold="true" CssClass="col-md-2" />
                                </asp:BoundField>
                                    <asp:BoundField DataField="user_email" HeaderText="Email Address" >
                                    <HeaderStyle Font-Bold="true" CssClass="col-md-2" />
                                </asp:BoundField>
                                    <asp:BoundField DataField="user_address" HeaderText="Physical Address">
                                    <HeaderStyle Font-Bold="true" CssClass="col-md-2" />
                                </asp:BoundField>

                            </Fields>
                            <FooterTemplate>
                            <asp:Button ID="btn_backexam" runat="server" Text="Back To User List" CssClass="btn btn-info" BackColor="#343A40" BorderStyle="None" ForeColor="White" PostBackUrl="~/admin/UserList.aspx"/>
                            </FooterTemplate>
                            <HeaderStyle CssClass="text-center" />
                        </asp:DetailsView>
                        <asp:Panel ID="panel_examdetails_warning" runat="server" Visible="false">
                            <div class="card-footer">
                                <br />
                                <div class="alert alert-danger text-center">
                                    <asp:Label ID="lbl_examdetailswarning" runat="server" />
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
