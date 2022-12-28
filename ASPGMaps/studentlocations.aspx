<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" Inherits="ASPGMaps._Default" CodeFile="studentlocations.aspx.cs" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="headplaceholder">
    
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="maincontent">
    <h3>Users Locations</h3>
    <div>
        <cc1:GMap ID="GMap1" runat="server" Width="800px" Height="500px"/>
    </div>
</asp:Content>
