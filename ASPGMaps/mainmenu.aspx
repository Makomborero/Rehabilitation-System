<%@ Page Title="" Language="C#" MasterPageFile="~/StudentMaster.master" AutoEventWireup="True" Inherits="mainmenu" CodeFile="mainmenu.aspx.cs" %>

<asp:Content ID="Content4" ContentPlaceHolderID="maincontentplaceholder" runat="Server">
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>

    <div class="col-12">
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h3>Dashboard</h3>     
    </div>
    
    <hr />
    </div>
    <div class="row">
    <div class="col-xl-4 col-sm-6 mb-4">
        <div class="card text-white bg-primary o-hidden h-100">
            <div class="card-body">
                <div class="card-body-icon">
                    <i class="fa fa-fw fa-comments"></i>
                </div>
                <div class="mr-5">Assessments</div>
            </div>
            <a class="card-footer text-black clearfix small z-1" href="index.aspx">
                <span class="float-left">View Details</span>
                <span class="float-right">
                    <i class="fa fa-angle-right"></i>
                </span>
            </a>
        </div>
    </div>
    <div class="col-xl-4 col-sm-6 mb-4">
        <div class="card text-white bg-warning o-hidden h-100">
            <div class="card-body">
                <div class="card-body-icon">
                    <i class="fa fa-fw fa-comments"></i>
                </div>
                <div class="mr-5">Results</div>
            </div>
            <a class="card-footer text-black clearfix small z-1" href="myresult.aspx">
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
                <div class="mr-5">About</div>
            </div>
            <a class="card-footer text-black clearfix small z-1" href="about.aspx">
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
                            <br />
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
        </div>
</asp:Content>


