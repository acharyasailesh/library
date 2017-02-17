<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="Library.AddBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>Adding Book</h1>
    <div class="form-group">

    <br />
    </div>
     <div class="form-group">
    <asp:Label ID="addBookName" runat="server" Text="BookName"></asp:Label>
    <asp:TextBox ID="bookName" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
      </div>
     <div class="form-group">
    <asp:Label ID="addBookAuthor" runat="server" Text="BookAuthor"></asp:Label>
    <asp:TextBox ID="bookAuthor" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    </div>
     <div class="form-group">

    <asp:Label ID="addDate" runat="server" Text="BookPublicationDate"></asp:Label>
    

         <asp:TextBox id="TextBox1" runat="server"></asp:TextBox>
  <INPUT type="button" value="..." onclick="OnClick()"><br>



<div id="divCalendar" style="DISPLAY: none; POSITION: absolute">
  <asp:Calendar id="Calendar1" runat="server" BorderWidth="2px"
                BackColor="White" Width="200px" onselectionchanged="Calendar1_SelectionChanged"
    ForeColor="Black" Height="180px" Font-Size="8pt"
                      Font-Names="Verdana" BorderColor="#999999"
    BorderStyle="Outset" DayNameFormat="FirstLetter" CellPadding="4">
    <TodayDayStyle ForeColor="Black" BackColor="#CCCCCC">
      </TodayDayStyle>
    <SelectorStyle BackColor="#CCCCCC"></SelectorStyle>
    <NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
    <DayHeaderStyle Font-Size="7pt" Font-Bold="True"
                    BackColor="#CCCCCC"></DayHeaderStyle>
    <SelectedDayStyle Font-Bold="True" ForeColor="White"
                      BackColor="#666666"></SelectedDayStyle>
    <TitleStyle Font-Bold="True" BorderColor="Black"
                BackColor="#999999"></TitleStyle>
    <WeekendDayStyle BackColor="#FFFFCC"></WeekendDayStyle>
    <OtherMonthDayStyle ForeColor="#808080"></OtherMonthDayStyle>
  </asp:Calendar>
</div>
<script>
function OnClick()
{
  if( divCalendar.style.display == "none")
    divCalendar.style.display = "";
  else
      divCalendar.style.display = "none";
         TextBox.Text= Calendar1.SelectedDate.ToString();

}
</script>
 
    
    <br />

    </div>


     <div class="form-group">
     <asp:Label runat="server">ISBN</asp:Label>
     <asp:TextBox ID="ISBN"  CssClass="form-control" runat="server"/> 
     </div>

    <div class="form-group">
     <asp:Label runat="server">Quantity</asp:Label>
     <asp:TextBox ID="quantity"  CssClass="form-control" runat="server"/> 
     </div>

    <asp:Button ID="submit" runat="server" Text="Submit" OnClick="submit_Click" />







    
</asp:Content>
