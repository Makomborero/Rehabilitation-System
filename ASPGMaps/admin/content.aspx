<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" Inherits="ITS.admin.content" CodeFile="content.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headplaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
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
                        <label class="col-md-2 col-form-label ">Select Course</label>
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
                       
                        <label class="col-md-2 col-form-label ">Select Topic</label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" DataTextField="subject_name" DataValueField="subject_id" placeholder="Select Course">
                                                    <asp:ListItem selected hidden>Select Course</asp:ListItem>
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
                        <asp:Panel ID="panel1" runat="server" Visible="false">
                            <br />
                            <div class="alert alert-danger text-center">
                                <asp:Label ID="Label1" runat="server" />
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
                        <asp:Panel ID="panel2" runat="server" Visible="false">
                            <br />
                            <div class="alert alert-danger text-center">
                                <asp:Label ID="Label2" runat="server" />
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
</asp:Content>
