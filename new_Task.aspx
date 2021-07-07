<%@ Page Title="" Language="C#" MasterPageFile="~/Project_Management.Master" AutoEventWireup="true" CodeBehind="new_Task.aspx.cs" Inherits="WebApplication1.new_Task" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3 class="text-center" style="color:#EEFFFF;">Add New Task</h3>
        <section class="det p-5">
            <div class="row">
                <div class="col-sm-6">
                    <div class="card bg-transparent mb-5" style="max-width:40rem; border-radius:15px; box-shadow: rgba(89, 203, 232, 0.56) 0px 22px 70px 4px;">
                        <div class="card-header">
                            <h5 class="text-center" style="color:#EEFFFF;">Get Project ID</h5>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-6">
                                    <p>Project ID :</p>
                                </div>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="mydropdown mydropdown-content">
                                        <asp:ListItem style="color:#EEFFFF;">Select Item</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="card-footer mx-auto">
                            <asp:Button ID="Button1" runat="server" Text="Get Data" CssClass="btn btn-primary" OnClick="Button1_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="card bg-transparent mb-5" style="max-width:40rem; border-radius:15px; box-shadow: rgba(89, 203, 232, 0.56) 0px 22px 70px 4px;">
                        <div class="card-header">
                            <h5 class="text-center" style="color:#EEFFFF;">Select Phase ID</h5>
                        </div>
                        <div class="card-body">
                            <asp:Label ID="Label2" runat="server" Text="Please select the Phase ID from the below given list box to insert data to that perticular phase ID" CssClass="new2"></asp:Label>
                            <asp:ListBox ID="ListBox1" runat="server" CssClass="tb2"></asp:ListBox>
                            <div class="row">
                                <div class="col-sm-6">
                                    <asp:Label ID="Label1" runat="server" Text="Enter the Phase Id" CssClass="new2" Visible="false"></asp:Label>
                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="TextPhaseID" runat="server" CssClass="tb2" Visible="false"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="card-footer mx-auto">
                            <asp:Button ID="Button3" runat="server" Text="Create Phase ID" ToolTip="Click here to create new Phase ID" CssClass="btn btn-primary" OnClick="Button3_Click" />
                        </div>
                    </div> 
                </div>
            </div>       
        </section>
        <section class="getphasedetails p-5">
            <div class="card bg-transparent mb-5" style="max-width:100rem; border-radius:15px; box-shadow: rgba(51, 147, 255, 0.56) 0px 22px 70px 4px;">
                <div class="card-header">
                    <h5 class="text-center" style="color:#EEFFFF;">Input Phase Details</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-sm-4">
                            <p>Phase Name :</p>
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="TextPhaseName" runat="server" CssClass="tb2"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <p>Start Date :</p>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="TextStrtDt" runat="server" TextMode="Date" CssClass="tb2"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <p>End Date :</p>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="TextEndDt" runat="server" TextMode="Date" CssClass="tb2"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="card-footer mx-auto">
                    <asp:Button ID="Button2" runat="server" Text="Add Data" CssClass="btn btn-primary" OnClick="Button2_Click" />
                </div>
            </div>
        </section>
        <section class="datagrid p-5">
            <asp:GridView ID="GridView1" runat="server" BackColor="#101010" ForeColor="#EEFFFF" GridLines="Both" ShowFooter="false" ShowHeader="true"></asp:GridView>
        </section>
        <asp:Button ID="Button4" runat="server" Text="Save Data" CssClass="btn btn-primary" OnClick="Button4_Click" />
    </div>
</asp:Content>
