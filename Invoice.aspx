<%@ Page Title="" Language="C#" MasterPageFile="~/Biilling_System.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="WebApplication1.Invoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div id="mySection01" runat="server" visible="true">
            <div class="row">
                <div class="col-sm-3">
                     <p>Project Name :</p>
                </div>
                <div class="col-sm-6">
                    <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2">
                    <p>Bill Type : </p>
                </div>
                <div class="col-sm-3">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>Select Option</asp:ListItem>
                        <asp:ListItem>Sales Bill</asp:ListItem>
                        <asp:ListItem>Service Bill</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <asp:Button ID="Button5" runat="server" Text="Generate Bill" CssClass="btn btn-outline-primary btn-primary" OnClick="Button5_Click"/>
        </div>
        <div id="Generateinvoice" runat="server" visible="false">
            <div class="row row1">
                <div class="col-sm-4">
                    <div class="context">
                        <p class="text-center">Bill To</p>
                        <hr />
                        <p>Invoice Number : <span> <asp:Label ID="Label6" runat="server" Text="Bill Num"></asp:Label></span></p>
                        <p>Date : <span> <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></span></p>
                        <p>Customer Phone Number :</p>
                        <asp:Label ID="Label9" runat="server" CssClass="new2" Text="Customer Phone"></asp:Label>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="col2">
                        <p class="text-center">Get Customer Details</p>
                        <hr />
                        <p>Full Name : <span> <asp:Label ID="Label1" CssClass="lb1" runat="server" Text="Label"></asp:Label></span></p>
                        <p>User Name : <span> <asp:Label ID="Label2" CssClass="lb1" runat="server" Text="Label"></asp:Label></span></p>
                        <p>Email Id : <span> <asp:Label ID="Label5" CssClass="lb1" runat="server" Text="Label"></asp:Label></span></p>
                        <asp:Button ID="Button3" runat="server" CssClass="btn btn-success" Text="Get Data" OnClick="Button3_Click" />
                    </div>
                </div>
                <div class="col-sm-2 col1">
                    <p>Invoice Total</p>
                    <div class="total">
                        <i class="fas fa-rupee-sign"></i><span><asp:Label ID="Label3" runat="server" Text="0.00"></asp:Label></span>
                    </div>
                </div>
            </div>
            <section class="products p-5 container">
                <div class="row text-center">
                    <div class="col-sm-4">
                        <p>Contractor Name : </p>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="TextBox2" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <h2 class="p-5">Products</h2>
                <hr />
                <div class="container" id="salesBill">
                    <div class="row text-center">
                        <div class="col-sm-3">
                            <p>Product Name : <span><asp:TextBox ID="TextName" runat="server" class="tb1" style="width:100%;" ></asp:TextBox></span></p>
                        </div>
                        <div class="col-sm-3">
                            <p>Quantity : <span><asp:TextBox ID="TextQuantity" runat="server" TextMode="Number" CssClass="tb2 text-center"></asp:TextBox></span></p>
                        </div>
                        <div class="col-sm-3">
                            <p>Unite Price : <span> <asp:TextBox ID="TextPrice" runat="server" TextMode="Number" style="width:100%;" CssClass="tb2 text-center"></asp:TextBox></span></p>
                        </div>
                        <div class="col-sm-3">
                            <p>GST : <br /><span>
                                <asp:DropDownList ID="DropDownGST" runat="server">
                                    <asp:ListItem>5%</asp:ListItem>
                                    <asp:ListItem>12%</asp:ListItem>
                                    <asp:ListItem>18%</asp:ListItem>
                                    <asp:ListItem>28%</asp:ListItem>
                                </asp:DropDownList></span></p>
                        </div>
                    </div>
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Add Values" OnClick="Button1_Click" />
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
                    <br />
                    <asp:Button ID="Button2" CssClass="btn btn-success display-2" runat="server" Text="Save" OnClick="Button2_Click" />
                    <br />
                    <asp:Label ID="Label8" runat="server"></asp:Label>
                </div>
            </section>
        </div>     
    </div>
    <asp:Label ID="Label10" runat="server" ViewStateMode="Disabled" Visible="false" EnableViewState="false"></asp:Label>
</asp:Content>