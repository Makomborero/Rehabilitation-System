<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="assessment.aspx.cs" Inherits="ASPGMaps.admin.assessment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headplaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
        <div class="col-md-12">
        <div class="card">
            <asp:Panel ID="panel_examlist" runat="server">
                <div class="card text-center mb-3">
                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:GridView ID="gridallstudents" runat="server" GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered" PageSize="8" OnPageIndexChanging="gridallstudents_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="user_fname" HeaderText="First name"/>
                                <asp:BoundField DataField="user_lname" HeaderText="Last name"/>
                                <asp:BoundField DataField="user_email" HeaderText="Email"/>
                                <asp:TemplateField HeaderText="Option">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="btn_viewquestion" runat="server" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" NavigateUrl='<%# "~/admin/physicalassessments.aspx?uid=" + Eval("user_username") %>'>
                                            <i class="fa fa-info-circle" aria-hidden="true"></i> View Assessment
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

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
            </asp:Panel>

        </div>
        </div>
</asp:Content>
