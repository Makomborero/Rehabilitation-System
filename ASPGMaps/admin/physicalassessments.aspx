<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="physicalassessments.aspx.cs" Inherits="ASPGMaps.admin.physicalassessments" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headplaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <meta http-equiv="refresh" content="20"> 
    <div class="col-12">
    <h3>Chats</h3>
    <hr />
    </div>
      <div class="card text center mb-3">
         <asp:Chart ID="Chart1" runat="server" Height="500px" Width="1092px">
          
        <Series>
            <asp:Series Name="Series1">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1" >
            </asp:ChartArea>
        </ChartAreas>
        <BorderSkin BackColor="" PageColor="192, 64, 0" />
    </asp:Chart>
      </div>
    
    <div class="card text center mb-3">
         <asp:Chart ID="Chart2" runat="server" Height="500px" Width="1092px">
          
        <Series>
            <asp:Series Name="Series2">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea2" >
            </asp:ChartArea>
        </ChartAreas>
        <BorderSkin BackColor="" PageColor="192, 64, 0" />
    </asp:Chart>
      </div>
</asp:Content>
