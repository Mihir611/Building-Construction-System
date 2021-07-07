<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Sign_Contract.aspx.cs" Inherits="WebApplication1.Sign_Contract" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3 class="text-center" style="color:#EEFFFF;">Please Fill out the Land Information</h3>
        <section class="det p-5">
            <div class="row">
                <div class="col-sm-4">
                    <p>Owner of the land :</p>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="tb2" style="width:100%;"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4">
                    <p>Land Address :</p>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" CssClass="tb2" style="width:100%;"></asp:TextBox>
                </div>
            </div>
        </section>
        <h3 class="text-center" style="color:#EEFFFF;">Other Info</h3>
        <section class="otherdet p-5">
            <div class="row">
                <div class="col-sm-4">
                    <p>Land Area :</p>
                </div>
                <div class="col-sm-8">
                    <asp:Label ID="Label1" runat="server" class="new2"></asp:Label> <span style="color:#EEFFFF;"> By </span> <asp:Label ID="Label2" runat="server" class="new2"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4">
                    <p></p>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
