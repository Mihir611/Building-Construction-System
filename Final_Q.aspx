<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Final_Q.aspx.cs" Inherits="WebApplication1.Final_Q" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <section class="getdata p-5">
            <div class="row">
                <div class="col-sm-2">
                    <p>Quotation Id :</p>
                </div>
                <div class="col-sm-4">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="tb2" style="width:100%;"></asp:DropDownList>
                </div>
                <div class="col-sm-4">
                    <asp:Button ID="Button1" runat="server" Text="Get Data" CssClass="btn btn-outline-primary btn-primary" style="box-shadow: 1px 2px 22px 0px rgba(0,0,205,0.85); color:#EEFFFF;" OnClick="Button1_Click" />
                </div>
            </div>
        </section>
        <h3 class="text-center font-weight-bold" style="color:#EEFFFF;">Quotation Details</h3>
        <section class="qdet p-5"> 
            <div class="row">
                <div class="col-sm-3">
                    <p class="text-center">Quotation Id :</p>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="LabelQid" runat="server" Cssclass="new2"></asp:Label>
                </div>
                <div class="col-sm-3">
                    <p class="text-center"> Dated :</p>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="LabelDT" runat="server" CssClass="new2"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <p class="text-center">For Quotation ID :</p>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="LabelForQID" runat="server" class="new2"></asp:Label>
                </div>
            </div>
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
        <section class="final">
            <div class="row">
                <div class="col-sm-4">
                    <asp:Label ID="LabelNote" runat="server" Cssclass="new2" style="color:#FF0000;"></asp:Label>
                </div>
                <div class="col-sm-4">
                    <p class="text-center">Total Amount To be Paid :</p>
                </div>
                <div class="col-sm-4">
                    <asp:Label ID="LabelTotal" runat="server" class="new2"></asp:Label> <span style="color:#EEFFFF;"> &#8377;</span>
                </div>
            </div>
        </section>
        <section class="button p-5">
            <asp:Button ID="Button2" runat="server" Text="Accept and Continue.." CssClass="btn btn-outline-primary btn-primary" style="box-shadow: 1px 2px 22px 0px rgba(0,0,205,0.85); color:#EEFFFF;" OnClick="Button2_Click" />
            <asp:Label ID="LabelFileName" runat="server" Visible="false"></asp:Label>
        </section>
    </div>
</asp:Content>
