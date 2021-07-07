<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Get_Quotation.aspx.cs" Inherits="WebApplication1.Get_Quotation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <p>Quotation Id : <span> <asp:Label ID="Label2" runat="server"></asp:Label> </span></p>
        <h3 class="text-center" style="color:#EEEFFF;">Input General Details</h3>
        <div class="row myrow">
            <div class="col-sm-12">
                <p class="text-center">Plot Size: <span>
                <asp:TextBox ID="TextBox1" CssClass="quotetb" runat="server" TextMode="Number" AutoPostBack="True"></asp:TextBox></span>ft /<span><asp:TextBox ID="TextBox2" CssClass="quotetb" runat="server" TextMode="Number"></asp:TextBox></span> ft </p>
                <div class="row mx-auto p-5">
                    <div class="col-sm-5 mylist">
                        <h3>Selected Options</h3>
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                            <asp:ListItem Selected="True" class="ListItem">&nbsp;Roof</asp:ListItem>
                            <asp:ListItem Selected="True" class="ListItem">&nbsp;Floor</asp:ListItem>
                            <asp:ListItem Selected="True" class="ListItem">&nbsp;Walls</asp:ListItem>
                            <asp:ListItem Selected="True" class="ListItem">&nbsp;Windows</asp:ListItem>
                            <asp:ListItem Selected="True" class="ListItem">&nbsp;Doors</asp:ListItem>
                        </asp:CheckBoxList>
                    </div>
                    <div class="col-sm-7 mybtns mylist">
                        <h3>Available Options</h3>
                        <asp:RadioButton ID="RadioButton1" runat="server" Text="Tiles" GroupName="Roofing" Checked="true" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RadioButton ID="RadioButton2" runat="server" Text="Cement" GroupName="Roofing"/>
                        <br />
                        <asp:RadioButton ID="RadioButton3" runat="server" Text="Tiles" GroupName="Flooring" Checked="true" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RadioButton ID="RadioButton4" runat="server" Text="Marbel" GroupName="Flooring"/>
                        <br />
                        <asp:RadioButton ID="RadioButton5" runat="server" Text="Tiles" GroupName="Walls" Checked="true" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RadioButton ID="RadioButton6" runat="server" Text="Cement" GroupName="Walls"/>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RadioButton ID="RadioButton7" runat="server" Text="Wooden" GroupName="Walls"/>
                        <br />
                        <asp:RadioButton ID="RadioButton8" runat="server" Text="Grills" GroupName="Windows" Checked="true"/>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RadioButton ID="RadioButton9" runat="server" Text="Alluminium" GroupName="Windows"/>
                        <br />
                        <asp:RadioButton ID="RadioButton10" runat="server" Text="Wooden" GroupName="Doors" Checked="true" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RadioButton ID="RadioButton11" runat="server" Text="Compressed Wood" GroupName="Doors"/>
                    </div>
                </div>
            </div>
        </div>
        <div class="row p-5">
            <div class="col-sm-5">
                <p>Upload House specific Designs,Blueprints</p>
            </div>
            <div class="col-sm-3 myfileupload">
                <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" BorderStyle="Groove" maxlength="5000"/>
            </div>
            <div class="col-sm-3 ml-5">
                <asp:Button CssClass="btn btn-primary mx-auto" runat="server" icon ="fas fa-upload" Text="Upload Data" OnClick="Unnamed1_Click"/>
                <asp:Label ID="Label1" runat="server" CssClass="mylavel" style="color:#ff0000;"></asp:Label>
            </div>
        </div>
        <h3 class="text-center" style="color:#EEEFFF;">Some other Requirements</h3>
        <div class="row p-5">
            <div class="col-sm-6">
                <p>Entrence Direction : <span>
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="quotetb"></asp:TextBox></span></p>
                <p>Do you want a well ? &nbsp;&nbsp;<asp:RadioButton ID="RadioButton12" runat="server" text="Yes" GroupName="well" Checked="true"/>
                    &nbsp;&nbsp;<asp:RadioButton ID="RadioButton13" runat="server" Text="No" GroupName="well" /></p>
                <p>Do you want place for gardening ? &nbsp;&nbsp;<asp:RadioButton ID="RadioButton14" runat="server" text="Yes" GroupName="garder" Checked="true"/>
                    &nbsp;&nbsp;<asp:RadioButton ID="RadioButton15" runat="server" Text="No" GroupName="gardern"/></p>
            </div>
            <div class="col-sm-4">
                <p>Approximate Budget(In &#x20B9;) <span><asp:TextBox ID="TextBox3" runat="server" CssClass="quotetb"></asp:TextBox></span></p>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-5">
                <p>Dont have an idea ??<br />
                No Worries<br />
                Just look at some of our models,<br />select which ever u feel good</p>
            </div>
            <div class="col-sm-3">
                <asp:Button CssClass="btn btn-primary" runat="server" Text="Select Models"/>
            </div>
        </div>
        <div class="submit p-5">
            <div class="row">
                <div class="col-sm-5">
                    <p>Click here to get the Quotation</p>
                    <p style="color:#ff0000; font-size:10px;">Note- The Quotation may take around 2-3 days</p>
                </div>
                <div class="col-sm-3">
                    <asp:Button Cssclass="btn btn-primary" runat="server" Text="Submit Request" OnClick="Unnamed2_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
