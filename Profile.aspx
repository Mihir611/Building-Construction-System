<%@ Page Title="" Language="C#" MasterPageFile="~/Employee_Home.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebApplication1.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3 class="text-center" style="color:#EEFFFF;">Not Editable Region</h3>
        <section class="notEditable p-5">
            <div class="row1 p-3">
                <div class="row">
                    <div class="col-sm-2">
                        <p>User Name :</p>
                    </div>
                    <div class="col-sm-2">
                        <asp:Label ID="Label1" runat="server" Text="Label" style="color:#EEFFFF;font-size:1.1em;line-height:1.7em;"></asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <p>Date of Birth :</p>
                    </div>
                    <div class="col-sm-2">
                        <asp:Label ID="Label2" runat="server" Text="Label" style="color:#EEFFFF;font-size:1.1em;line-height:1.7em;"></asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <p>Gender :</p>
                    </div>
                    <div class="col-sm-2">
                        <asp:Label ID="Label3" runat="server" Text="Label" style="color:#EEFFFF;font-size:1.1em;line-height:1.7em;"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3">
                        <p>Your Salary :</p>
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="Label4" runat="server" Text="Label" style="color:#EEFFFF;font-size:1.1em;line-height:1.7em;"></asp:Label>
                    </div>
                    <div class="col-sm-3">
                        <p>Your Designation :</p>
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="Label5" runat="server" Text="Label" style="color:#EEFFFF;font-size:1.1em;line-height:1.7em;"></asp:Label>
                    </div>
                </div>
            </div>
        </section>
        <h3 class="text-center" style="color:#EEFFFF;">Editable Region</h3>
        <section class="editable p-5">
            <div class="row1 p-3">
                <div class="row">
                    <div class="col-sm-3">
                        <p class="text-center">Email ID :</p>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="TextBox1" runat="server" TextMode="Email" style="width:100%" CssClass="tb2"></asp:TextBox>
                    </div>
                    <div class="col-sm-3">
                        <p class="text-center">Phone Number :</p>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Number" style="width:100%" CssClass="tb2"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3">
                        <p class="text-center">Address</p>
                    </div>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" style="width:100%" CssClass="tb2"></asp:TextBox>
                    </div>
                </div>
                <div class="row pt-3">
                    <div class="col-sm-12 text-center">
                        <asp:Button ID="Button1" runat="server" Text="Update Data" CssClass="btn btn-primary" style="text-shadow: 1px 1px 2px black;" OnClick="Button1_Click"/>
                    </div>
                </div>
                <div class="passwords p-3">
                    <div class="row">
                        <div class="col-sm-3">
                            <p>Current Password :</p>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" style="width:100%" CssClass="tb2"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <p>New Password :</p>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="TextBox5" runat="server" TextMode="Password" style="width:100%" CssClass="tb2"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <p>Confirm Password :</p>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="TextBox6" runat="server" TextMode="Password" style="width:100%" CssClass="tb2"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <asp:Button ID="Button2" runat="server" Text="Update Password" CssClass="btn btn-primary" style="text-shadow: 1px 1px 2px black;" OnClick="Button2_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
