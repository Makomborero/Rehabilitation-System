<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="True" Inherits="admin_Index" CodeFile="index.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headplaceholder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="Server">
    <div class="col-12">
    <h1>Dashboard</h1>
    <hr />
    </div>
    <div class="row">
    <div class="col-xl-4 col-sm-6 mb-4">
        <div class="card text-white bg-warning o-hidden h-100">
            <div class="card-body">
                <div class="card-body-icon">
                    <i class="fa fa-fw fa-comments"></i>
                </div>
                <div class="mr-5">We have a list of <asp:Label ID="lbltotalquestion" runat="server"></asp:Label> assessments</div>
            </div>
            <a class="card-footer text-black clearfix small z-1" href="category.aspx">
                <span class="float-left">View Details</span>
                <span class="float-right">
                    <i class="fa fa-angle-right"></i>
                </span>
            </a>
        </div>
    </div>
        <div class="col-xl-4 col-sm-6 mb-4">
        <div class="card text-white bg-info o-hidden h-100">
            <div class="card-body">
                <div class="card-body-icon">
                    <i class="fa fa-fw fa-comments"></i>
                </div>
                <div class="mr-5">We have a total of <asp:Label ID="Label1" runat="server"></asp:Label> advises</div>
            </div>
            <a class="card-footer text-black clearfix small z-1" href="subject.aspx">
                <span class="float-left">View Details</span>
                <span class="float-right">
                    <i class="fa fa-angle-right"></i>
                </span>
            </a>
        </div>
    </div>
    <div class="col-xl-4 col-sm-6 mb-4">
        <div class="card text-white bg-primary o-hidden h-100">
            <div class="card-body">
                <div class="card-body-icon">
                    <i class="fa fa-fw fa-comments"></i>
                </div>
                <div class="mr-5">I have a total of <asp:Label ID="lbltotalexam" runat="server"></asp:Label> converstaions</div>
            </div>
            <a class="card-footer text-black clearfix small z-1" href="exam.aspx">
                <span class="float-left">View Details</span>
                <span class="float-right">
                    <i class="fa fa-angle-right"></i>
                </span>
            </a>
        </div>
    </div>
    
    <div class="col-xl-4 col-sm-6 mb-4">
        <div class="card text-white bg-success o-hidden h-100">
            <div class="card-body">
                <div class="card-body-icon">
                    <i class="fa fa-fw fa-comments"></i>
                </div>
                <div class="mr-5">We have a total of <asp:Label ID="lbltotalstudents" runat="server"></asp:Label> addicts registered</div>
            </div>
            <a class="card-footer text-black clearfix small z-1" href="studentList.aspx">
                <span class="float-left">View Details</span>
                <span class="float-right">
                    <i class="fa fa-angle-right"></i>
                </span>
            </a>
        </div>
    </div>
    <div class="col-md-12">
        <div class="card">
            <div class="card-header">
                <asp:Panel ID="panel_index_warning" runat="server" Visible="false">
                    <div class="card-footer">
                        <br />
                        <div class="alert alert-danger text-center">
                            <asp:Label ID="lbl_indexwarning" runat="server" />
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
        </div>
</asp:Content>

