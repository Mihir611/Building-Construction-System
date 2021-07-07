<%@ Page Title="" Language="C#" MasterPageFile="~/Biilling_System.Master" AutoEventWireup="true" CodeBehind="Supply_Inward.aspx.cs" Inherits="WebApplication1.Supply_Inward" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <h3 class="text-center" style="color:#EEFFEE;">Billed From</h3>
        <section class="headerdetails products p-3">
            <div class="row">
                <div class="col-sm-8">
                    <div class="row">
                        <div class="col-sm-4">
                            <p>Invoice Number :</p>
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="tb2" style="width:100%;"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <p>Order Number :</p>
                        </div>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="tb2" style="width:100%;"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <p>Supplier Phone :</p>
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="tb2" style="width:100%;" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <p>Bill Date :</p>
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="TextBox3" runat="server" textmode="Date" CssClass="tb2" style="width:100%;"></asp:TextBox>
                        </div>
                    </div>
                    <asp:Button ID="Button4" runat="server" CssClass="btn btn-primary" Text="Get Supplier Data" OnClick="Button4_Click" />
                </div>
                <div class="col-sm-4 text-light">
                    <p>Supplier Name : </p>
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    <p>GST Number : </p>
                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                    <p>Email ID : </p>
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                    <p>Total Sales given till date :</p>
                    <span> &#8377;<asp:Label ID="Label2" runat="server" Text="0.00"></asp:Label></span>
                </div>
            </div>
            <hr />
        </section>
        <section class="itemDetails products p-3">
            <h3 class="text-center" style="color:#EEFFFF;">Item Details</h3>
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
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Add Values" OnClick="Button1_Click"  />
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
        </section>
        <section class="amountdetails products p-3">
            <hr />
            <div class="row">
                <div class="col-sm-6">
                    <p>Amount : </p>
                </div>
                <div class="col-sm-6 text-center" style="color:#EEFFFF;">
                    <span> &#8377;<asp:Label ID="Label1" runat="server" Text="0.00"></asp:Label></span>
                </div>
            </div>
        </section>
        <section class="discamt products text-center p-3">
            <hr />
            <div class="row">
                <div class="col-sm-3">
                    <p>Discount</p>
                </div>
                <div class="col-sm-2">
                    <p>Type <span>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>Rs</asp:ListItem>
                            <asp:ListItem>%</asp:ListItem>
                        </asp:DropDownList></span></p>
                </div>
                <div class="col-sm-2">
                    <asp:TextBox ID="TextBox5" runat="server" TextMode="Number" style="width:100%;" Text="0.00"></asp:TextBox>
                </div>
                <div class="col-sm-3">
                    <p>Discount Amount : <span> &#8377;<asp:Label ID="Label4" runat="server" Text="0.00"></asp:Label></span></p>
                </div>
                <div class="col-sm-2">
                    <asp:Button ID="Button3" runat="server" Text="Get Discount" class="btn btn-primary" OnClick="Button3_Click" />
                </div>
                <hr />
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <p>Update The Supply Status</p>
                    <hr />
                    <div class="row">
                        <div class="col-sm-6">
                            <asp:LinkButton ID="LinkButton1" runat="server" style="color:#EEFFFF;" OnClick="LinkButton1_Click">Delivered</asp:LinkButton>
                        </div>
                        <div class="col-sm-6">
                            <asp:LinkButton ID="LinkButton2" runat="server" style="color:#EEFFFF;" OnClick="LinkButton2_Click">Partially Delivered</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section class="finalamt p-3" style="color:#EEFFFF;">
            <div class="row">
                <div class="col-sm-6">
                    <p class="text-center">Final Amount to be Paid is :</p>
                </div>
                <div class="col-sm-6">
                    <span> &#8377;<asp:Label ID="Label5" runat="server" Text="0.00"></asp:Label></span>
                </div>
            </div>
        </section>
        <asp:Button ID="Button2" CssClass="btn btn-success display-2" runat="server" Text="Save Bill" OnClick="Button2_Click"  />
    </div>
</asp:Content>
