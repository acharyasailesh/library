<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteBook.aspx.cs" Inherits="Library.DeleteBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Deleting Book</h1>
    <div class="form-group">
        <br />
    </div>
    <div class="form-group">
        <asp:Label ID="delteBookName" runat="server" Text="BookName"></asp:Label>
        <asp:ListBox ID="BookList" runat="server" CssClass="form-control"></asp:ListBox>
        <br />
    </div>

    
    <div class="form-group">
        Book No to delete
    
        <br />
        <asp:TextBox ID="deletedBookNo" runat="server" CssClass="form-control"></asp:TextBox>
    </div>


    <asp:Button ID="submit" runat="server" Text="Delete" OnClick="submit_Click" />
</asp:Content>
