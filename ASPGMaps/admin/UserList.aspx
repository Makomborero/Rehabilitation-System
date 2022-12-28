<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="ASPGMaps.admin.UserList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headplaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div class="col-md-12">
        <div class="card">
            <%--Button For select panel--%>
            <div class="btn-group">
                <asp:Button ID="btn_panelresult" runat="server" Text="All Users" CssClass="btn btn-info" BorderStyle="None" CausesValidation="False" BackColor="#4e73df" />
            </div>
            <div class="card text-center mb-3">
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="gridallstudents" runat="server" GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered" PageSize="8" OnRowCommand="grdview_examlist_RowCommand" OnPageIndexChanging="gridallstudents_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="user_fname" HeaderText="First name" />
                                <asp:BoundField DataField="user_lname" HeaderText="Last name" />
                                <asp:BoundField DataField="user_rank" HeaderText="Drug Category" />
                                <asp:BoundField DataField="usercategory" HeaderText="Category" />
                                <asp:BoundField DataField="user_gender" HeaderText="Gender" />
                                <asp:BoundField DataField="user_dob" HeaderText="DOB" />
                                <asp:BoundField DataField="user_force_number" HeaderText="ID Number" />
                                <asp:BoundField DataField="user_mobile" HeaderText="Phone Number" />
                                <asp:TemplateField HeaderText="Options">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="btn_detailsexam" runat="server" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" NavigateUrl='<%# "~/admin/UserDetails.aspx?eid=" + Eval("usrID") %>'>
                                            <i class="fa fa-info-circle" aria-hidden="true"></i> Details
                                            </asp:HyperLink>
                                            <asp:HyperLink ID="btn_editexam" runat="server" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" NavigateUrl='<%# "~/admin/EditUser.aspx?name=" + Eval("user_username") %>'>
                                            <i class="fa fa-pencil-square-o" aria-hidden="true" onclick=></i> Edit
                                            </asp:HyperLink>
                                            <asp:LinkButton ID="btn_deleteexam" runat="server" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" CommandArgument='<%# Eval("usrID") %>' CommandName="deleteuser">
                                            <i class="fa fa-trash" aria-hidden="true"></i> Delete
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <asp:Panel ID="panel_studentlistshow_warning" runat="server" Visible="false">
                    <div class="card-footer">
                        <br />
                        <div class="alert alert-danger text-center">
                            <asp:Label ID="lbl_studentlistshowwarning" runat="server" />
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
