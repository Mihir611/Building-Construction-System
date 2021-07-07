<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard_User.Master" AutoEventWireup="true" CodeBehind="View_Payments.aspx.cs" Inherits="WebApplication1.View_Payments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3 class="font-weght-bold text-center" style="color:#EEFFFF;">Payments Done</h3>
        <section class="DET p-5">
            <div class="row">
                <div class="col-sm-3">
                    <p class="text-center">Select username :</p>
                </div>
                <div class="col-sm-3">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="tb2" style="color:#EEFFFF;width:100%;"></asp:DropDownList>
                </div>
                <div class="col-sm-2">
                    <asp:Button ID="Button1" runat="server" Text="Get Data" CssClass="btn btn-primary" />
                </div>
                <div class="col-sm-2">
                    <p class="text-center"> User Type :</p>
                </div>
                <div class="col-sm-2">
                    <asp:Label ID="Label1" runat="server" Text="Label" CssClass="new2"></asp:Label>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
