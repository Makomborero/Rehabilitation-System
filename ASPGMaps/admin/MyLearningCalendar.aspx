<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="True" Inherits="ITS.MyLearningCalendar" CodeFile="MyLearningCalendar.aspx.cs" %>

<asp:Content ID="Content4" ContentPlaceHolderID="maincontent" runat="Server">
    <div class="col-12">
    <h1>Schedule Calendar</h1>
    <hr />
    </div>
      <div class="card text center mb-3">
         <asp:Calendar ID="Calendar2" Height="420px" Width="1092px" runat="server" OnDayRender="Calendar2_DayRender">
          </asp:Calendar>
      </div>
</asp:Content>