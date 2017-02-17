<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AssignBook.aspx.cs" Inherits="Library.AssignBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="form-group">
        <asp:Label ID="assignBookName" runat="server" Text="BookName"></asp:Label>
        <asp:ListBox ID="AssignBookList" runat="server" CssClass="form-control" OnSelectedIndexChanged="AssignBookList_SelectedIndexChanged"></asp:ListBox>

        <br />
    </div>

    <div class="form-group">
        <asp:Label ID="assignEmployee" runat="server" Text="EmployeeName"></asp:Label>
        <asp:ListBox ID="AssignEmployeeList" runat="server" CssClass="form-control"></asp:ListBox>

        <br />

        <br />
      </div>

    <div class="form-group">
        <asp:Label ID="BookIssued" runat="server" Text="Book Issued"></asp:Label>
        <asp:TextBox ID="bookIssuedDate" runat="server" CssClass="form-control"></asp:TextBox>

        <br />

    </div>


             <br>

    
    <div class="form-group">

        <asp:Button ID="submit" Text="submit"  runat="server" CssClass="form-control" OnClick="submit_Click"/>


    </div>
    

    
</asp:Content>
