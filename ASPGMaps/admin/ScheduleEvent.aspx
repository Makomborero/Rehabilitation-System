<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="True" Inherits="ITS.admin.ScheduleEvent" CodeFile="ScheduleEvent.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headplaceholder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="Server">
    <div class="col-12">
    <h1>Schedule Event</h1>
    <hr />
    </div>
    <div class="col-md-12">
        <div class="card">
            <asp:Panel runat="server">
                <div class="card-body">
                    <div class="row form-group">
                        <label class="col-md-2 col-form-label ">Event</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txt_examname" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="require_examname" runat="server" ErrorMessage="Enter exam name" ControlToValidate="txt_examname" ForeColor="red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row form-group">
                        <label class="col-md-2 col-form-label ">Event Discription</label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txt_examdis" runat="server" TextMode="MultiLine" CssClass="form-control" Height="150px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row form-group">
                        <label class="col-md-2 col-form-label ">Start Date</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txt_examdate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="require_examdate" runat="server" ErrorMessage="Enter exam date" ControlToValidate="txt_examdate" ForeColor="red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="card-footer">
                        <div class="offset-2">
                            <asp:Button ID="btn_addexam" runat="server" Text="Add Event" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" OnClick="btn_addexam_Click" />
                        </div>
                        <asp:Panel ID="panel_addexam_warning" runat="server" Visible="false">
                            <br />
                            <div class="alert alert-danger text-center">
                                <asp:Label ID="lbl_examaddwarning" runat="server" />
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>


