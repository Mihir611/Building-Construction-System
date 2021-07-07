<%@ Page Title="" Language="C#" MasterPageFile="~/Biilling_System.Master" AutoEventWireup="true" CodeBehind="Supplier_Master.aspx.cs" Inherits="WebApplication1.Supplier_Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3 class="text-center" style="color:#EEFFFF;">Enter supplier Details</h3>
            <section class="basic_Details p-5">
                <h5 class="text-center" style="color:#EEFFFF;text-decoration:underline">Company Info</h5>
                <div class="row row1">
                    <div class="col-sm-12">
                        <div class="row p-1">
                            <div class="col-sm-5 text-center">
                                <p>Supplier Name</p>
                            </div>
                            <div class="col-sm-5">
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="tb1"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row p-1">
                            <div class="col-sm-5 text-center">
                                <p class="mx-auto">Address</p>
                            </div>
                            <div class="col-sm-5">
                                <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" CssClass="tb1"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="row p-1">
                            <div class="col-sm-5 text-center">
                                <p>GSTIN/UIN</p>
                            </div>
                            <div class="col-sm-5">
                                <asp:TextBox ID="TextBox3" runat="server" MaxLength="16" CssClass="tb1"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        <hr />
        <section class="contact-Details p-3">
            <h5 class="text-center" style="color:#EEFFFF;text-decoration:underline;">Contact Details</h5>
            <div class="row row1">
                <div class="col-sm-12">
                    <div class="row">
                        <div class="col-sm-5 text-center">
                            <p>Contact Person</p>
                        </div> 
                        <div class="col-sm-5">
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="tb1"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5 text-center">
                            <p>Phone Number (Company)</p>
                        </div>
                        <div class="col-sm-5">
                            <asp:TextBox ID="TextBox5" runat="server" TextMode="Number" MaxLength="10" CssClass="tb1"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Proper Phone Number" ControlToValidate="TextBox5" ForeColor="Red" ValidationExpression="^[7-9][0-9]{9}$"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5 text-center">
                            <p>Email ID (Company)</p>
                        </div>
                        <div class="col-sm-5">
                            <asp:TextBox ID="TextBox6" runat="server" TextMode="Email" CssClass="tb1"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter proper email id" ForeColor="Red" ControlToValidate="TextBox6" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5 text-center">
                            <p>FAX</p>
                        </div>
                        <div class="col-sm-5">
                            <asp:TextBox ID="TextBox7" runat="server" CssClass="tb1"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <asp:Button ID="Button1" runat="server" Text="Save Data" class="btn btn-success" style="border-radius:10px;color:#101010;" OnClick="Button1_Click"/>
    </div>
</asp:Content>
