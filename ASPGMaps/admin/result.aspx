<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="True" Inherits="admin_result" CodeFile="result.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headplaceholder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="Server">

    <div class="col-md-12">
        <div class="card">
            <%--Button For select panel--%>
            <div class="btn-group">
                <asp:Button ID="btn_panelresult" runat="server" Text="All Results" CssClass="btn btn-info" BorderStyle="None" CausesValidation="False" BackColor="#4e73df" />
            </div>
            <div class="card text-center mb-3">
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="gridviewspecific" runat="server" GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered" PageSize="8" Visible="false" OnPageIndexChanging="gridviewspecific_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="user_email" HeaderText="Username" />
                                <asp:BoundField DataField="exam_name" HeaderText="Assessment Name" NullDisplayText="no exam name" />
                                <asp:BoundField DataField="exam_date" DataFormatString="{0:M/d/yy}" HeaderText="Exam Date" NullDisplayText="No date" />
                                <asp:BoundField DataField="totalquestion" HeaderText="Total Questions" />
                                <asp:BoundField DataField="result_status" HeaderText="Result" />
                                <asp:BoundField DataField="exam_marks" HeaderText="Total Marks" />
                                <asp:BoundField DataField="result_score" HeaderText="Score" />
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="gridresult" runat="server" GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered" PageSize="8" OnPageIndexChanging="gridresult_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="user_email" HeaderText="Username" />
                                <asp:BoundField DataField="exam_name" HeaderText="Assessment Name" NullDisplayText="no exam name" />
                                <asp:BoundField DataField="exam_date" DataFormatString="{0:M/d/yy}" HeaderText="Exam Date" NullDisplayText="No date" />
                                <asp:BoundField DataField="totalquestion" HeaderText="Total Questions" />
                                <asp:BoundField DataField="result_status" HeaderText="Result" />
                                <asp:BoundField DataField="exam_marks" HeaderText="Total Marks" />
                                <asp:BoundField DataField="result_score" HeaderText="Score" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <asp:Panel ID="panel_resultshow_warning" runat="server" Visible="false">
                    <div class="card-footer">
                        <br />
                        <div class="alert alert-danger text-center">
                            <asp:Label ID="lbl_resultshowwarning" runat="server" />
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

