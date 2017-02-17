<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="Library.Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>Adding Employee and Viewing total Employee</h1>
    <div class="form-group">

    <br />
    </div>
     <div class="form-group">
    <asp:Label ID="addEmployeeName" runat="server" Text="EmployeeName"></asp:Label>
    <asp:TextBox ID="employeeName" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
      </div>
     <div class="form-group">
    <asp:Label ID="addEmployeeAddress" runat="server" Text="EmployeeAddress"></asp:Label>
    <asp:TextBox ID="employeeAddress" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    </div>

     <div class="form-group">
    <asp:Label ID="addPhoneNo" runat="server" Text="EmployeePhone"></asp:Label>
    <asp:TextBox ID="employeePhoneNo" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
      </div>
     <div class="form-group">
    <asp:Label ID="addEmployeeSex" runat="server" Text="Sex"></asp:Label>
    <asp:TextBox ID="employeeSex" runat="server" CssClass="form-control"></asp:TextBox>
    <br />
    </div>

    <asp:Button ID="submit" runat="server" Text="Submit" OnClick="submit_Click" />


    <h2>Employee Taking List of Book</h2>
    <asp:GridView ID="grid1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="grid1_RowCancelingEdit" OnRowEditing="grid1_RowEditing" OnRowUpdating="grid1_RowUpdating" OnRowDeleting="grid1_RowDeleting">  
     <AlternatingRowStyle BackColor="White" />  
     <columns>  
          <asp:TemplateField>  
                    <ItemTemplate>  
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Delete" runat="server" Text="ReturnBook" CommandName="delete"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  

                    </EditItemTemplate>  
                </asp:TemplateField>  
         <asp:TemplateField HeaderText="EmployeeID">  
             <ItemTemplate>  
                 <asp:Label ID="EmployeeId" runat="server" Text='<%#Bind("Id") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Name">  
             <ItemTemplate>  
                 <asp:Label ID="EmployeeName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>  
             </ItemTemplate>

            <EditItemTemplate>  
                        <asp:TextBox ID="txt_EmployeeName" runat="server" Text='<%#Bind("Name") %>'></asp:TextBox>  
                    </EditItemTemplate>

               
         </asp:TemplateField>  

         <asp:TemplateField HeaderText="Address">  
             <ItemTemplate>  
                 <asp:Label ID="EmployeeAddress" runat="server" Text='<%#Bind("Address") %>'></asp:Label>  
             </ItemTemplate>  
             <EditItemTemplate>  
                        <asp:TextBox ID="txt_EmployeeAddress" runat="server" Text='<%#Bind("Address") %>'></asp:TextBox>  
                    </EditItemTemplate>

         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Phone">  
             <ItemTemplate>  
                 <asp:Label ID="EmployeePhone" runat="server" Text='<%#Bind("PhoneNo") %>'></asp:Label>  
             </ItemTemplate>  
             <EditItemTemplate>  
                        <asp:TextBox ID="txt_EmployeePhone" runat="server" Text='<%#Bind("PhoneNo") %>'></asp:TextBox>  
                    </EditItemTemplate>

         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Sex">  
             <ItemTemplate>  
                 <asp:Label ID="EmployeeSex" runat="server" Text='<%#Bind("Sex") %>'></asp:Label>  
             </ItemTemplate>  
             <EditItemTemplate>  
                        <asp:TextBox ID="txt_EmployeeSex" runat="server" Text='<%#Bind("Sex") %>'></asp:TextBox>  
                    </EditItemTemplate>

         </asp:TemplateField>  
         <asp:TemplateField HeaderText="EmployeeBook">  
             <ItemTemplate>  
                 <asp:Label ID="EmployeeBook" runat="server" Text='<%#Bind("Names") %>'></asp:Label>  
             </ItemTemplate>  
             <EditItemTemplate>  
                        <asp:Label ID="txt_EmployeeBook" runat="server" Text='<%#Bind("Names") %>'></asp:Label>  
                    </EditItemTemplate>

         </asp:TemplateField>
         
         

     </columns>  

     <EditRowStyle BackColor="#2461BF" />  
     <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />  
     <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />  
     <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />  
     <RowStyle BackColor="#EFF3FB" />  
     <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />  
     <SortedAscendingCellStyle BackColor="#F5F7FB" />  
     <SortedAscendingHeaderStyle BackColor="#6D95E1" />  
     <SortedDescendingCellStyle BackColor="#E9EBEF" />  
     <SortedDescendingHeaderStyle BackColor="#4870BE" />  
 </asp:GridView>  
    <div class="form-group">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="id">

    <Columns>
        <asp:BoundField DataField="id" HeaderText="S.No." />
        <asp:BoundField DataField="name" HeaderText="Name" />
        <asp:BoundField DataField="address" HeaderText="address" />
        <asp:BoundField DataField="country" HeaderText="Country" />
        <asp:CommandField ShowEditButton="true" />
        <asp:CommandField ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
 </div>
    

<asp:Label ID="lblresult" runat="server"></asp:Label>

    
</asp:Content>
