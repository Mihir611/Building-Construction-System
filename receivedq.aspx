<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard_User.Master" AutoEventWireup="true" CodeBehind="receivedq.aspx.cs" Inherits="WebApplication1.receivedq" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-3">
                <p>Quotation Requested by User</p>
            </div>
            <div class="col-sm-3" style="color:#c2f8ca;">
                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                <asp:Button ID="Button1" runat="server" Text="Get Data" class="btn btn-primary" OnClick="Button1_Click" style="text-shadow: 1px 1px 2px black;"/>
            </div>
        </div>
        <h3 class="text-center" style="color:#EEEFFF;">Customer Details</h3>
        <section class="p-5">
            <div class="row ">
                <div class="col-sm-3">
                    <p>Customer Name</p>
                </div>
                <div class="col-sm-5" style="color:#c2f8ca;">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <p>Phone Number</p>
                </div>
                <div class="col-sm-5">
                    <asp:Label ID="Label2" runat="server" style="color:#c2f8ca;"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <p>Email ID</p>
                </div>
                <div class="col-sm-5">
                    <asp:Label ID="Label3" runat="server" style="color:#c2f8ca;"></asp:Label>
                </div>
            </div>
        </section>
        <h3 class="text-center" style="color:#EEEFFF">Quotation Details</h3>
        <section class="quotdet p-5">
            <div class="row">
                <div class="col-sm-5">
                    <p class="text-center">Quotation Id :</p>
                </div>
                <div class="col-sm-5" style="color:#c2f8ca;">
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                </div>
                <div class="col-sm-5">
                    <p class="text-center">Plot Size :</p>
                </div>
                <div class="col-sm-5" style="color:#c2f8ca;">
                    <asp:Label ID="Label5" runat="server"></asp:Label> ft <span> By </span> <asp:Label ID="Label6" runat="server"></asp:Label> ft
                </div>
                <div class="col-sm-5">
                    <p class="text-center">Entrence Direction :</p>
                </div>
                <div class="col-sm-5" style="color:#c2f8ca;">
                    <asp:Label ID="Label15" runat="server"></asp:Label>
                </div>
                <div class="col-sm-5">
                    <p class="text-center">Approximate Budget :</p>
                </div>
                <div class="col-sm-5" style="color:#c2f8ca;">
                    <asp:Label ID="Label14" runat="server"></asp:Label>
                </div>
            </div>
        </section>
        <section class="housedet">
            <h3 class="text-center" style="color:#EEEFFF;">House Style</h3>
            <div class="row p-5">
                <div class="col-sm-5">
                    <div class="row">
                        <div class="col-sm-5">
                            <p>Roof Style :</p>
                        </div>
                        <div class="col-sm-5" style="color:#c2f8ca;">
                            <asp:Label ID="Label7" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <p>Floor Style :</p>
                        </div>
                        <div class="col-sm-5" style="color:#c2f8ca;">
                            <asp:Label ID="Label8" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <p>Wall Style :</p>
                        </div>
                        <div class="col-sm-5" style="color:#c2f8ca;">
                            <asp:Label ID="Label9" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <p>Window Style :</p>
                        </div>
                        <div class="col-sm-5" style="color:#c2f8ca;">
                            <asp:Label ID="Label10" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col-sm-5">
                    <div class="row">
                        <div class="col-sm-5">
                            <p>Door Style :</p>
                        </div>
                        <div class="col-sm-7" style="color:#c2f8ca;">
                            <asp:Label ID="Label11" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <p>Well Required ? :</p>
                        </div>
                        <div class="col-sm-5" style="color:#c2f8ca;">
                            <asp:Label ID="Label12" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <p>Garden Space Required ? :</p>
                        </div>
                        <div class="col-sm-5" style="color:#c2f8ca;">
                            <asp:Label ID="Label13" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!--<section class="refdetails p-5">
            <h3 class="text-center" style="color:#EEEFFF;">Images Refered</h3>
            <asp:DataList ID="dtlist" runat="server">
                <ItemTemplate>
                    <asp:Image ID="imgsource" ImageUrl='<%# Eval("ImageUrl") %>' runat="server" />
                </ItemTemplate>
            </asp:DataList>

        </section>-->
        <asp:Button ID="Button2" runat="server" Text="Approve and Advertize" CssClass="btn btn-primary" ToolTip="Approve and Advertize this quotation." style="text-shadow: 1px 1px 2px black;" OnClick="Button2_Click" />
    </div>
</asp:Content>
