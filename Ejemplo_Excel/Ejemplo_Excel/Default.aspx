<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ejemplo_Excel._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">

</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Import / Export Database data to/from EXCEL file.</h3>
    <div>
        <table>
            <tr>
                <td>Select File: </td>
                <td>
                    <asp:FileUpload ID="FileUpload" runat="server" />
                </td>
                <td>
                    <asp:Button ID="btnImport" runat="server" Text="Upload" OnClick="btnImport_Click1"/>
                </td>
            </tr>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </table>
        <div>
            <br />
            <asp:Label ID="lblMessage" runat="server" Font-Bold="true"/>
            <br />
            <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="false">
                <EmptyDataTemplate>
                    <div style="padding:10px">
                        Data not found!
                    </div>
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField HeaderText="Employee ID" DataField="EmployeeID" />
                    <asp:BoundField HeaderText="Company Nmae" DataField="companyName" />
                    <asp:BoundField HeaderText="Contact Name" DataField="ContactName" />
                    <asp:BoundField HeaderText="Contact Title" DataField="ContactTitle" />
                    <asp:BoundField HeaderText="Adress" DataField="EmployeeAddress" />
                    <asp:BoundField HeaderText="Postal Code" DataField="PostalCode" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    
</asp:Content>
