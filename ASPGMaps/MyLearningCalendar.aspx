<%@ Page Title="" Language="C#" MasterPageFile="~/StudentMaster.master" AutoEventWireup="True" Inherits="ASPGMaps.MyLearningCalendar" CodeFile="MyLearningCalendar.aspx.cs" %>

<asp:Content ID="Content4" ContentPlaceHolderID="maincontentplaceholder" runat="Server">
    <div class="col-12">
    <h1>Activities Calendar</h1>
    <hr />
    </div>
      <div class="card text center mb-3">
         <asp:Calendar ID="Calendar2" Height="420px" Width="1092px" runat="server" OnDayRender="Calendar2_DayRender">
          </asp:Calendar>
      </div>
</asp:Content>