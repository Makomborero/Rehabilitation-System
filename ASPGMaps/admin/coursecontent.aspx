<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="coursecontent.aspx.cs" Inherits="ASPGMaps.admin.coursecontent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headplaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">

    <div class="col-md-12">
        <div class="card">
            <%--Button For select panel--%>
            <div class="btn-group">
                <asp:Button ID="btn_panelcategorylist" runat="server" Text="View Content List" CssClass="btn btn-info" OnClick="btn_panelcategorylist_Click" BorderStyle="None" CausesValidation="False" />
                <asp:Button ID="btn_paneladdcategory" runat="server" Text="Add Content" CssClass="btn d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" OnClick="btn_paneladdcategory_Click" BorderStyle="None" CausesValidation="False" />
            </div>

            <%--Add course content panel--%>
            <asp:Panel ID="panel_addcontent" runat="server">
                    <div class="row">

                        <!-- Area Chart -->
                        <div style="min-width: 100%">
                            <div class="card shadow mb-4">
                                <!-- Card Header - Dropdown -->
                                <div
                                    class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                    <h6 class="m-0 font-weight-bold text-primary">Upload Portable Document Format (pdf) files</h6>
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
                         <div class="col-md-12">
        <div class="card">
            <asp:Panel runat="server">
                <div class="card-body">
                    <div class="row form-group">
                        <label class="col-md-2 col-form-label ">Select Topic</label>
                        <div class="col-md-4">
                            
                            <asp:DropDownList ID="drp_subjectexam" runat="server" CssClass="form-control" DataTextField="subject_name" >
                            </asp:DropDownList>
                           </div>
                    </div>
                    <div class="row form-group">
                        <label class="col-md-2 col-form-label ">Name</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txt_examname" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row form-group">
                        <label class="col-md-2 col-form-label ">Description</label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txt_examdis" runat="server" TextMode="MultiLine" CssClass="form-control" Height="150px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row form-group">
                    <asp:FileUpload ID="FileUpload1" runat="server"/>  
                    </div>
                    <div class="card-footer">
                        <div class="offset-2">
                            <asp:Button ID="btn_addexam" runat="server" Text="Add File" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" onclick="btn_addexam_Click1"/>
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
                                    <h6 class="m-0 font-weight-bold text-primary">Upload Powerpoint (ppt) slides</h6>
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
                               <div class="col-md-12">
        <div class="card">
            <asp:Panel runat="server">
                <div class="card-body">
                    <div class="row form-group">
                       
                        <label class="col-md-2 col-form-label ">Select Topic</label >
                        <div class="col-md-4">
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" DataTextField="subject_name" DataValueField="subject_id" placeholder="Select Course">
                                                    <asp:ListItem selected hidden>Select Topic</asp:ListItem>
                            </asp:DropDownList>
                             </div>
                    </div>
                     <div class="row form-group">
                        <label class="col-md-2 col-form-label ">Name</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row form-group">
                        <label class="col-md-2 col-form-label ">Description</label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" CssClass="form-control" Height="150px"></asp:TextBox>
                        </div>
                    </div>
                    
                    <div class="row form-group">
                    <asp:FileUpload ID="FileUpload2" runat="server"/>  
                    </div>
                    <div class="card-footer">
                        <div class="offset-2">
                            <asp:Button ID="Button1" runat="server" Text="Add File" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" OnClick="Button1_Click" />
                        </div>
                        <asp:Panel ID="panel5" runat="server" Visible="false">
                            <br />
                            <div class="alert alert-danger text-center">
                                <asp:Label ID="Label3" runat="server" />
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>


                                
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
                                    <h6 class="m-0 font-weight-bold text-primary">Upload pictures or videos</h6>
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
                           <div class="col-md-12">
        <div class="card">
            <asp:Panel runat="server">
                <div class="card-body">
                    <div class="row form-group">
                        <label class="col-md-2 col-form-label ">Select Topic</label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" DataTextField="subject_name" DataValueField="subject_id" placeholder="Select Course">
                                                    <asp:ListItem selected hidden>Select Topic</asp:ListItem>
                            </asp:DropDownList></div>
                    </div>
                    <div class="row form-group">
                        <label class="col-md-2 col-form-label ">Name</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row form-group">
                        <label class="col-md-2 col-form-label ">Description</label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine" CssClass="form-control" Height="150px"></asp:TextBox>
                        </div>
                    </div>
                    
                    <div class="row form-group">
                    <asp:FileUpload ID="FileUpload3" runat="server" />  
                    </div>
                    <div class="card-footer">
                        <div class="offset-2">
                            <asp:Button ID="Button2" runat="server" Text="Add File" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" OnClick="Button2_Click"/>
                        </div>
                        <asp:Panel ID="panel6" runat="server" Visible="false">
                            <br />
                            <div class="alert alert-danger text-center">
                                <asp:Label ID="Label4" runat="server" />
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>

                            </div>
                        </div>
                    </div>
                </asp:Panel>

            <%--course content list panel--%>
            <asp:Panel ID="panel_contentlist" runat="server">
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
                            <asp:GridView ID="grdview_examlist" runat="server" GridLines="None" CssClass="table table-bordered" AutoGenerateColumns="False" AllowPaging="True" OnRowCommand="grdview_examlist_RowCommand" OnPageIndexChanging="grdview_examlist_PageIndexChanging" PageSize="5">
                                <Columns>
                                    <asp:BoundField DataField="name" HeaderText="File Name" />
                                    <asp:BoundField DataField="description" HeaderText="Description" />
                                    <asp:BoundField DataField="upload_date" HeaderText="Upload Date" DataFormatString="{0:d}" />
                                    <asp:TemplateField HeaderText="Option">
                                        <ItemTemplate>
                                            
                                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" CommandName="Download"  CommandArgument='<%#Eval("path") %>' oncommand="LinkButton1_Command" CausesValidation="false">
                                            <i class="fa fa-download" aria-hidden="true"></i> Download
                                            </asp:LinkButton>
                                            
                                            <asp:LinkButton ID="btn_deleteexam" runat="server" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" CommandArgument='<%# Eval("pdf_Id") %>' CommandName="deletepdf">
                                            <i class="fa fa-trash" aria-hidden="true"></i> Delete
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    There are no files added at the moment. Wait for the professional to add files
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
                            <asp:GridView ID="GridView1" runat="server" GridLines="None" CssClass="table table-bordered" AutoGenerateColumns="False" AllowPaging="True" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="grdview_examlist_PageIndexChanging1" PageSize="5">
                                <Columns>
                                    <asp:BoundField DataField="name" HeaderText="File Name" />
                                    <asp:BoundField DataField="description" HeaderText="Description" />
                                    <asp:BoundField DataField="upload_date" HeaderText="Upload Date" DataFormatString="{0:d}" />
                                    <asp:TemplateField HeaderText="Option">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" CommandName="Download"  CommandArgument='<%#Eval("path") %>' oncommand="LinkButton1_Command" CausesValidation="false">
                                            <i class="fa fa-download" aria-hidden="true"></i> Download
                                            </asp:LinkButton>
                                            
                                            <asp:LinkButton ID="btn_deleteexam" runat="server" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" CommandArgument='<%# Eval("ppt_Id") %>' CommandName="deleteppt">
                                            <i class="fa fa-trash" aria-hidden="true"></i> Delete
                                            </asp:LinkButton>
                                            
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
                                    <h6 class="m-0 font-weight-bold text-primary">Video Lectures (.mp4) files</h6>
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
                            <asp:GridView ID="GridView2" runat="server" GridLines="None" CssClass="table table-bordered" AutoGenerateColumns="False" AllowPaging="True" OnRowCommand="GridView2_RowCommand" OnPageIndexChanging="grdview_examlist_PageIndexChanging2" PageSize="5">
                                <Columns>
                                    <asp:BoundField DataField="name" HeaderText="File Name" />
                                    <asp:BoundField DataField="description" HeaderText="Description" />
                                    <asp:BoundField DataField="upload_date" HeaderText="Upload Date" DataFormatString="{0:d}" />
                                    <asp:TemplateField HeaderText="Content">
                                        <ItemTemplate>
                                            <video  height="300" width="300" controls><source src="<%#Eval("path") %>" type="video/mp4"></source></video>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Option">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" CommandName="Download"  CommandArgument='<%#Eval("path") %>' oncommand="LinkButton1_Command" CausesValidation="false">
                                            <i class="fa fa-download" aria-hidden="true"></i> Download
                                            </asp:LinkButton>
                                            
                                            <asp:LinkButton ID="btn_deleteexam" runat="server" CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White" CommandArgument='<%# Eval("vid_Id") %>' CommandName="deletevid">
                                            <i class="fa fa-trash" aria-hidden="true"></i> Delete
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    There are no files added at the moment. Wait for the professional to add files
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

            </asp:Panel>
            </div>
                    </div>
    

</asp:Content>