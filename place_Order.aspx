<%@ Page Title="" Language="C#" MasterPageFile="~/Biilling_System.Master" AutoEventWireup="true" CodeBehind="place_Order.aspx.cs" Inherits="WebApplication1.place_Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3 class="text-center" style="color:#EEFFFF;text-decoration:underline;">Place Order</h3>
        <section class="order-Det p-5">
            <h5 class="text-center pb-2" style="color:#EEFFFF;text-decoration:underline;">Order Details</h5>
            <div class="row row1">
                <div class="col-sm-3">
                    <p>Order Id :</p>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="Label3" runat="server" Text="OrderId" style="color:#EEFFFF;"></asp:Label>
                </div>
                <div class="col-sm-3">
                    <p>Date :</p>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="Label7" runat="server" Text="Date" style="color:#EEFFFF;"></asp:Label>
                </div>
            </div>
        </section>
        <section class="GetSupDet p-5">
            <h5 class="text-center pb-2" style="color:#EEFFFF; text-decoration:underline;">Supplier Details</h5>
            <div class="row row1">
                <div class="col-sm-12">
                    <div class="row">
                        <div class="col-sm-4">
                            <p class="text-center">Supplier Phone :</p>
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="TextBox1" runat="server" TextMode="Number" CssClass="tb2" style="width:100%;"></asp:TextBox>
                        </div>
                        <div class="col-sm-4">
                            <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" style="color:#101010;" Text="Get Data" OnClick="Button1_Click" />
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-sm-2">
                            <p class="text-center">Supplier Name :</p>
                        </div>
                        <div class="col-sm-2">
                            <asp:Label ID="Label1" runat="server" Text="Name" style="color:#EEFFFF;"></asp:Label>
                        </div>
                        <div class="col-sm-1">
                            <p class="text-center">Email :</p>
                        </div>
                        <div class="col-sm-3">
                            <asp:Label ID="Label2" runat="server" Text="Email" style="color:#EEFFFF;"></asp:Label>
                        </div>
                        <div class="col-sm-2">
                            <p class="text-center">GSTin Number :</p>
                        </div>
                        <div class="col-sm-2">
                            <asp:Label ID="Label6" runat="server" Text="GSTin" style="color:#EEFFFF;"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section class="p-5">
            <div class="row">
                <div class="col-sm-4">
                    <p>Narration : </p>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="tb2" style="width:100%" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
        </section>
        <section class="getMaterial_Info p-5">
            <h5 class="text-center pb-2" style="color:#EEFFFF;text-decoration:underline;">Material Info</h5>
            <div class="row row1">
                <div class="col-sm-12">
                    <div class="row">
                        <div class="col-sm-2">
                            <p class="text-center">Item Name :</p>
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="TextName" CssClass="tb2" style="width:100%" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-sm-1">
                            <p class="text-center">Qty :</p>
                        </div>
                        <div class="col-sm-2">
                            <asp:TextBox ID="TextQty" runat="server" CssClass="tb2" style="width:100%" TextMode="Number"></asp:TextBox>
                        </div>
                        <div class="col-sm-1">
                            <p class="text-center">Price :</p>
                        </div>
                        <div class="col-sm-2">
                            <asp:TextBox ID="TextPrice" runat="server" CssClass="tb2" style="width:100%" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" Text="Add Data" style="color:#101010;" OnClick="Button3_Click"/>
                    <div class="row p-3">
                        <div class="col-sm-12">
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
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <div class="row">
            <div class="col-sm-8"></div>
            <div class="col-sm-2">
                <p class="text-center">Total Items :</p>
            </div>
            <div class="col-sm-2">
                <span style="color:#EEFFFF;"> <asp:Label ID="Label4" runat="server" Text="Items" style="color:#EEFFFF;"></asp:Label> Nos</span>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-8"></div>
            <div class="col-sm-2">
                <p class="text-center">Total Amount :</p>
            </div>
            <div class="col-sm-2">
                <span style="color:#EEFFFF;">&#8377 <asp:Label ID="Label5" runat="server" Text="Amount" style="color:#EEFFFF;"></asp:Label></span>
            </div>
        </div>
        <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" style="color:#101010;" Text="Save and Send Email" OnClick="Button2_Click" />
    </div>
</asp:Content>
