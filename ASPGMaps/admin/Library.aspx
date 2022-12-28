<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" Inherits="ITS.Library" CodeFile="Library.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">
    <div class="card-header">
    <h2>Data Store</h2>
    </div>
               <!-- Content Row -->
                    <div class="row">
                        <!-- Earnings (Monthly) Card Example -->
                        <div class="col-md-6 mb-4">
                            <!-- Topbar Search -->
                    <div class="input-group">
                            <input type="text" class="form-control small" placeholder="Search for..."
                                aria-label="Search" aria-describedby="basic-addon2">
                            <div class="input-group-append">
                                <button class="btn btn-primary" type="button">
                                    <i class="fas fa-search fa-sm"></i>
                                </button>
                            </div>
                        </div>
                        </div>

                        <!-- Earnings (Monthly) Card Example -->
                        <div class="col-md-6 mb-4">
                            <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                            <asp:FileUpload ID="FileUpload1" runat="server" />   
                                    </div>
                                    <div class="col-sm-6">
                                      <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-primary btn-user btn-block" OnClick="UploadFile" />
                                    </div>
                                </div>
                        </div>

                    </div>

                    <!-- Content Row -->

                    <div class="row">

                        <!-- Area Chart -->
                        <div style="min-width: 100%">
                            <div class="card shadow mb-4">
                                <!-- Card Header - Dropdown -->
                                <div
                                    class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                    <h6 class="m-0 font-weight-bold text-primary">File Directory</h6>
                                    <div class="dropdown no-arrow">
                                        <a class="dropdown-toggle" href="#" role="button" id="dropdownMenuLink"
                                            data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                            <i class="fas fa-ellipsis-v fa-sm fa-fw text-gray-400"></i>
                                        </a>
                                        <div class="dropdown-menu dropdown-menu-right shadow animated--fade-in"
                                            aria-labelledby="dropdownMenuLink">
                                            <div class="dropdown-header">Dropdown Header:</div>
                                            <a class="dropdown-item" href="#">Action</a>
                                            <a class="dropdown-item" href="#">Another action</a>
                                            <div class="dropdown-divider"></div>
                                            <a class="dropdown-item" href="#">Something else here</a>
                                        </div>
                                    </div>
                                </div>

                                

                                <!-- Card Body -->
                                 <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" GridLines="None" CssClass="table table-bordered" AutoGenerateColumns="False">

                                 <Columns>
                                        <asp:BoundField DataField="Text" HeaderText="File Name" />
                                        <asp:TemplateField HeaderText="Options">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDownload"  CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "DownloadFile" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" >
                                            <i class="fa fa-download" aria-hidden="true"></i>Download
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="LinkDelete"  CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "DeleteFile" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" >
                                            <i class="fa fa-trash" aria-hidden="true"></i>Delete
                                            </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                            </asp:GridView>

                        </div>


                                
                            </div>
                        </div>
                    </div>
</asp:Content>

