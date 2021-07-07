<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard_User.Master" AutoEventWireup="true" CodeBehind="Review_Q.aspx.cs" Inherits="WebApplication1.Review_Q" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <section class="getdata p-5">
            <div class="row">
                <div class="col-sm-3">
                    <p>Quotation ID :</p>
                </div>
                <div class="col-sm-3">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="tb2" style="width:100%;color:#101010;" DataSourceID="SqlDataSource1" DataTextField="Quotation_Id" DataValueField="Quotation_Id"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Building_Construction_SystemConnectionString %>" SelectCommand="SELECT [Quotation_Id] FROM [BOM_Main] WHERE ([Status] = @Status) ORDER BY [Date]">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Under Review" Name="Status" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="col-sm-3">
                    <asp:Button ID="Button1" runat="server" Text="Get Data" CssClass="btn btn-outline-primary btn-primary" style=" box-shadow: 1px 2px 22px 0px rgba(0,0,205,0.85); color:#EEFFFF;" OnClick="Button1_Click"/>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <p>Service Provider Name :</p>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="Label1" runat="server" CssClass="new2"></asp:Label>
                </div>
                <div class="col-sm-3">
                    <p>Quotation Dated :</p>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="Label4" runat="server" CssClass="new2"></asp:Label>
                </div>
            </div>
            <div class="row p-2">
                <div class="col-sm-4">
                    <p>Quotation for Request Number :</p>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="Label2" runat="server" CssClass="new2"></asp:Label>
                </div>
                <div class="col-sm-2">
                    <p>Requested By :</p>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="Label3" runat="server" CssClass="new2"></asp:Label>
                </div>
            </div>
        </section>
        <section class="inputdet p-5">
            <div class="row">
                <div class="col-sm-1">
                    <p class="text-center">Item :</p>
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
                    <p>Unite :</p>
                </div>
                <div class="col-sm-1">
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem>Kgs</asp:ListItem>
                        <asp:ListItem>Nos</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm-2">
                    <p>Unite Price :</p>
                </div>
                <div class="col-sm-2">
                    <asp:TextBox ID="TextPrice" runat="server" CssClass="tb2" style="width:100%;"></asp:TextBox>
                </div>
            </div>
            <asp:Button ID="Button3" runat="server" Text="Add" CssClass="btn btn-outline-primary btn-primary" style=" box-shadow: 1px 2px 22px 0px rgba(0,0,205,0.85); color:#EEFFFF;" OnClick="Button3_Click"/>
        </section>
        <h3 class="text-center font-weight-bold" style="color:#EEFFFF;"> BOM Details </h3>
        <section class="BOMDet">
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
        <section class="last p-5">
            <div class="row">
                <div class="col-sm-3">
                    <p> Total Amount To be Paid is :</p>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="Label5" runat="server" CssClass="new2"></asp:Label><span style="color:#EEFFFF;">&#8377;</span>
                </div>
                <div class="col-sm-4">
                    <asp:Button ID="Button2" runat="server" Text="Save and foreward it to Client." CssClass="btn btn-outline-success btn-primary" style="color:#EEFFFF;box-shadow: 1px 2px 22px 0px rgba(57,255,20,0.85);" OnClick="Button2_Click" />
                </div>
            </div>
        </section>
        <asp:Label ID="Label6" runat="server" CssClass="new2" style="color:#FF0000;"></asp:Label>
        <asp:Label ID="Label7" runat="server" Text="Label" Visible="false"></asp:Label>
        <asp:Label ID="Label8" runat="server" Text="Label" Visible="true" CssClass="new2"></asp:Label>
    </div>
</asp:Content>
