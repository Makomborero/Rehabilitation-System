<%@ Page Title="" Language="C#" MasterPageFile="~/StudentMaster.master" AutoEventWireup="true" Inherits="ITS.coursecontent" CodeFile="coursecontent.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="heardcontentplaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontentplaceholder" runat="server">
    <div class="row">

                        <!-- Area Chart -->
                        <div style="min-width: 100%">
                            <div class="card shadow mb-4">
                                <!-- Card Header - Dropdown -->
                                <div
                                    class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                    <h6 class="m-0 font-weight-bold text-primary">Portable Document Format (pdf) files</h6>
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
                         <asp:Panel ID="panel_examlist" runat="server">
                <div class="card text-center mb-3">
                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:GridView ID="grdview_examlist" runat="server" GridLines="None" CssClass="table table-bordered" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grdview_examlist_PageIndexChanging" PageSize="5">
                                <Columns>
                                    <asp:BoundField DataField="name" HeaderText="File Name" />
                                    <asp:BoundField DataField="description" HeaderText="Description" />
                                    <asp:BoundField DataField="upload_date" HeaderText="Upload Date" DataFormatString="{0:d}" />
                                    <asp:TemplateField HeaderText="Option">
                                        <ItemTemplate>
                                            <p><a href="<%#Eval("path") %>" download>Download</a></p>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    There are no files added at the moment. Wait for the instructor to add files
                                </EmptyDataTemplate>
                                <PagerStyle CssClass="card-footer" HorizontalAlign="Right" />
                            </asp:GridView>
                        </div>
                        <asp:Panel ID="panel_examlist_warning" runat="server" Visible="false">
                            <div class="card-footer">
                                <br />
                                <div class="alert alert-danger text-center">
                                    <asp:Label ID="lbl_examlistwarning" runat="server" />
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </asp:Panel>


                                
                            </div>
                        </div>
                    </div>

    <div class="row">

                        <!-- Area Chart -->
                        <div style="min-width: 100%">
                            <div class="card shadow mb-4">
                                <!-- Card Header - Dropdown -->
                                <div
                                    class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                    <h6 class="m-0 font-weight-bold text-primary">Powerpoint (ppt) slides</h6>
                                    <div class="dropdown no-arrow">
                                        <a class="dropdown-toggle" href="#" role="button" id="dropdownMenuLinkkk"
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
                                <asp:Panel ID="panel1" runat="server">
                <div class="card text-center mb-3">
                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" GridLines="None" CssClass="table table-bordered" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grdview_examlist_PageIndexChanging1" PageSize="5">
                                <Columns>
                                    <asp:BoundField DataField="name" HeaderText="File Name" />
                                    <asp:BoundField DataField="description" HeaderText="Description" />
                                    <asp:BoundField DataField="upload_date" HeaderText="Upload Date" DataFormatString="{0:d}" />
                                    <asp:TemplateField HeaderText="Option">
                                        <ItemTemplate>
                                            <p><a href="<%#Eval("path") %>" download>Download</a></p>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    There are no files added at the moment. Wait for the professional to add files
                                </EmptyDataTemplate>
                                <PagerStyle CssClass="card-footer" HorizontalAlign="Right" />
                            </asp:GridView>
                        </div>
                        <asp:Panel ID="panel2" runat="server" Visible="false">
                            <div class="card-footer">
                                <br />
                                <div class="alert alert-danger text-center">
                                    <asp:Label ID="Label1" runat="server" />
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </asp:Panel>


                                
                            </div>
                        </div>
                    </div>

    <div class="row">

                        <!-- Area Chart -->
                        <div style="min-width: 100%">
                            <div class="card shadow mb-4">
                                <!-- Card Header - Dropdown -->
                                <div
                                    class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                    <h6 class="m-0 font-weight-bold text-primary">Pictures</h6>
                                    <div class="dropdown no-arrow">
                                        <a class="dropdown-toggle" href="#" role="button" id="dropdownMenuLinkk"
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
                          <asp:Panel ID="panel3" runat="server">
                <div class="card text-center mb-3">
                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView2" runat="server" GridLines="None" CssClass="table table-bordered" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grdview_examlist_PageIndexChanging2" PageSize="5">
                                <Columns>
                                    <asp:BoundField DataField="name" HeaderText="File Name" />
                                    <asp:BoundField DataField="description" HeaderText="Description" />
                                    <asp:BoundField DataField="upload_date" HeaderText="Upload Date" DataFormatString="{0:d}" />
                                    <asp:TemplateField HeaderText="Video">
                                        <ItemTemplate>
                                            <video height="300" width="300" controls><source src="<%#Eval("path") %>" type="video/mp4"></source></video>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Option">
                                        <ItemTemplate>
                                            <p><a href="<%#Eval("path") %>" download>Download</a></p>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    There are no files added at the moment. Wait for the instructor to add files
                                </EmptyDataTemplate>
                                <PagerStyle CssClass="card-footer" HorizontalAlign="Right" />
                            </asp:GridView>
                        </div>
                        <asp:Panel ID="panel4" runat="server" Visible="false">
                            <div class="card-footer">
                                <br />
                                <div class="alert alert-danger text-center">
                                    <asp:Label ID="Label2" runat="server" />
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </asp:Panel>


                                
                            </div>
                        </div>
                    </div>
</asp:Content>
