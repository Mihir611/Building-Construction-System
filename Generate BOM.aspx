<%@ Page Title="" Language="C#" MasterPageFile="~/Service_Provider.Master" AutoEventWireup="true" CodeBehind="Generate BOM.aspx.cs" Inherits="WebApplication1.Generate_BOM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-3">
                <p>Get Quotation Details</p>
            </div>
            <div class="col-sm-3" style="color:#c2f8ca;">
                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                <asp:Button ID="Button1" runat="server" Text="Get Data" class="btn btn-primary" style="text-shadow: 1px 1px 2px black;" OnClick="Button1_Click"/>
            </div>
        </div>
        <h3 class="text-center" style="color:#EEEFFF">Quotation Details</h3>
        <section class="quotdet p-5">
            <div class="row">
                <div class="col-sm-3">
                    <p class="text-center">Quotation Id :</p>
                </div>
                <div class="col-sm-3" style="color:#c2f8ca;">
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                </div>
                <div class="col-sm-3" style="color:#c2f8ca;">
                    <p class="text-center">Date</p>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="Label1" runat="server" style="color:#EEEFFF;"></asp:Label>
                </div>
            </div>
        </section>
        <section class="BOM p-5">
            <div class="row">
                <div class="col-sm-2">
                    <p class="text-center">Item Name :</p>
                </div>
                <div class="col-sm-2">
                    <asp:TextBox ID="TextName" runat="server" CssClass="tb2" style="width:100%;"></asp:TextBox>
                </div>
                <div class="col-sm-1">
                    <p class="text-center">Qty :</p>
                </div>
                <div class="col-sm-2">
                    <asp:TextBox ID="TextQty" runat="server" CssClass="tb2" style="width:100%;"></asp:TextBox>
                </div>
                <div class="col-sm-1">
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem>Kgs</asp:ListItem>
                        <asp:ListItem>Nos</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm-2">
                    <p class="text-center">Unite Price :</p>
                </div>
                <div class="col-sm-2">
                    <asp:TextBox ID="TextPrice" runat="server" CssClass="tb2" style="width:100%;"></asp:TextBox>
                </div>
            </div>
            <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" Text="Add Values" OnClick="Button2_Click"/>
                <hr />
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" style="width:100%;border:1px solid #FFEEEE; border-radius:15px;">
                    <AlternatingRowStyle BackColor="#101010" Forecolor="#EEFFFF"/>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#101010" Font-Bold="True" ForeColor="#c2f8ca" HorizontalAlign="Center" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#101010" ForeColor="#EEFFFF" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
        </section>
        <section class="finalamtdetails p-3">
            <div class="row">
                <div class="col-sm-6"></div>
                <div class="col-sm-3">
                    <p class="text-center">Total Amount :</p>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="Label2" runat="server" style="color:#EEEFFF;"></asp:Label> <span style="color:#EEEFFF;">&#8377;</span>
                </div>
            </div>
        </section>
        <asp:Button ID="Button3" runat="server" Text="Submit BOM" class="btn btn-success" style="text-shadow: 1px 1px 2px black;" OnClick="Button3_Click" />
        <asp:Label ID="Label3" runat="server" Text="Label" Width="48px" Visible="false"></asp:Label>
        <asp:Label ID="Label5" runat="server" Text="Label" Width="48px" Visible="false"></asp:Label>
    </div>
    
</asp:Content>
