<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" Inherits="ASPGMaps.admin.studentlocations" CodeFile="studentlocations.aspx.cs" %>
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headplaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <meta http-equiv="refresh" content="20">
    <div class="col-12">
    <h3>Addicts Locations</h3>
    <hr />
    </div>
      <div class="card text center mb-3">
         <cc1:GMap ID="GMap1" runat="server" Height="500px" Width="1092px"/>
      </div>
</asp:Content>
