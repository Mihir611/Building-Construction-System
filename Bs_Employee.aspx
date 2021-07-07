<%@ Page Title="Billing System" Language="C#" MasterPageFile="~/Employee_Home.Master" AutoEventWireup="true" CodeBehind="Bs_Employee.aspx.cs" Inherits="WebApplication1.Bs_Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-3">
            <p>Number of Projects Completed</p>
        </div>
        <div class="col-sm-3">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="col-sm-3">
            <p>Number of Projects in Hand</p>
        </div>
        <div class="col-sm-3">
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Content>
