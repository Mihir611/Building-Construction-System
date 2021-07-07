<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard_User.Master" AutoEventWireup="true" CodeBehind="View_Receipt.aspx.cs" Inherits="WebApplication1.View_Receipt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3 class="text-center font-weight-bold" style="color:#EEFFFF;">Payments Received</h3>
        <section class="receipt p-5">
            <div class="row">
                <div class="col-sm-4">
                    <p class="text-center"> Select User Name :</p>
                </div>
                <div class="col-sm-4">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="tb2" style="width:100%; color:#101010;" DataSourceID="SqlDataSource1" DataTextField="User_Name" DataValueField="User_Name"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Building_Construction_SystemConnectionString %>" SelectCommand="SELECT DISTINCT[User_Name] FROM [Receipts]"></asp:SqlDataSource>
                </div>
                <div class="col-sm-4">
                    <asp:Button ID="Button1" runat="server" Text="Get Data" CssClass="btn btn-primary" style="color:#101010;text-shadow: 2px 2px 5px red;" OnClick="Button1_Click" />
                </div>
            </div>
        </section>
        <h3 class="text-center font-weight-bold" style="color:#EEFFFF;">Payment Details</h3>
        <section class="det p-5">
            <asp:GridView ID="grid1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" >  
                <AlternatingRowStyle BackColor="White" />  
                <columns>  
                    <asp:TemplateField HeaderText="Name">  
                        <ItemTemplate>  
                            <asp:Label ID="Name" runat="server" Text='<%#Bind("User_Name") %>'></asp:Label>  
                        </ItemTemplate>  
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="Payment Date">  
                        <ItemTemplate>  
                            <asp:Label ID="PaymentDate" runat="server" Text='<%#Bind("Date") %>'></asp:Label>  
                        </ItemTemplate>  
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="Amount">  
                        <ItemTemplate>  
                            <asp:Label ID="Amount" runat="server" Text='<%#Bind("Amount") %>'></asp:Label>  
                        </ItemTemplate>  
                    </asp:TemplateField>  
                </columns>  
                <EditRowStyle BackColor="#2461BF" />  
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />  
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />  
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />  
                <RowStyle BackColor="#EFF3FB" />  
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />  
                <SortedAscendingCellStyle BackColor="#F5F7FB" />  
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />  
                <SortedDescendingCellStyle BackColor="#E9EBEF" />  
                <SortedDescendingHeaderStyle BackColor="#4870BE" />  
            </asp:GridView>  
        </section>
        <section class="tot">
            <div class="row">
                <div class="col-sm-7">

                </div>
                <div class="col-sm-3">
                    <p>Total Amount Paid :</p>
                </div>
                <div class="col-sm-2">
                    <asp:Label ID="Label1" runat="server" CssClass="new2"></asp:Label> <span style="color:#EEFFFF;"> &#8377;</span>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
