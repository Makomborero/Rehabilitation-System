<%@ Page Title="" Language="C#" MasterPageFile="~/StudentMaster.master" AutoEventWireup="true" Inherits="ITS.WebForm1" CodeFile="courseitem.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="heardcontentplaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontentplaceholder" runat="server">
    <h2 class="m-4">
            All drug addicts<asp:Label ID="lbl_categorysubject" runat="server"></asp:Label> Assessment Courses</h2>
        <hr />
                
        <div class="row">
        <div style="position: relative;width: 100%;min-height: 1px;padding-right: 15px;padding-left: 15px;">
            <div class="card-header">
                <asp:Repeater ID="gridview_categoryitem" runat="server">
            <ItemTemplate>
                <div class="col-lg-3 mb-3">
                    <div class="card h-100 text-center">
                        <h4 class="card-header"><%# Eval("subject_name") %></h4>
                        <div class="card-footer">
                            <asp:HyperLink ID="btn_category" runat="server" CssClass="btn btn-primary" ForeColor="White" NavigateUrl='<%# "~/coursecontent.aspx?sid=" +  Eval("subject_name") %>'>View Course Content</asp:HyperLink>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
                    <asp:Panel ID="panel_subjectshow_warning" runat="server" Visible="false">
                        <br />
                        <div class="alert alert-danger text-center">
                            <asp:Label ID="lbl_subjectshowwarning" runat="server" />
                        </div>
                    </asp:Panel>
                </div>
            </div>
         </div>
</asp:Content>
