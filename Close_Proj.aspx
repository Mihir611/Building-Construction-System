<%@ Page Title="" Language="C#" MasterPageFile="~/Project_Management.Master" AutoEventWireup="true" CodeBehind="Close_Proj.aspx.cs" Inherits="WebApplication1.Close_Proj" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3 class="text-center" style="color:#EEFFFF; text-decoration:underline"> Close Project </h3>
        <section class="getdata p-5">
            <h5 class="text-center" style="color:#EEFFFF;">Project Details</h5>
            <div class="card bg-transparent mb-5" style="box-shadow: rgba(57,255,20, 0.25) 0px 50px 100px -20px, rgba(57,255,20, 0.3) 0px 30px 60px -30px, rgba(57,255,20, 0.35) 0px -2px 6px 0px inset; max-width:100rem; border-radius:15px;">
                <div class="card-header">
                    <p>Get Project Details</p>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-sm-6">
                            <p>Project Id :</p>
                        </div>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="mydropdown mydropdown-content">
                                <asp:ListItem Selected="True">SELECT ITEM</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="card-footer mx-auto">
                    <asp:Button ID="Button1" runat="server" Text="Get Data" CssClass="btn btn-outline-primary waves-effect" OnClick="Button1_Click" />
                </div>
            </div>
        </section>
        <h4 class="text-center" style="color:#EEFFFF;">Project Details</h4>
        <section class="projdet p-5">
            <div class="card bg-transparent mb-5" style="box-shadow: rgba(57,255,20, 0.25) 0px 50px 100px -20px, rgba(57,255,20, 0.3) 0px 30px 60px -30px, rgba(57,255,20, 0.35) 0px -2px 6px 0px inset; max-width:100rem; border-radius:15px;">
                <div class="card-header">
                    <p>Important Project Data</p>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-sm-4">
                            <p>Project Id :</p>
                        </div>
                        <div class="col-sm-4">
                            <asp:Label ID="LblId" runat="server" CssClass="new2"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <p>Project Name :</p>
                        </div>
                        <div class="col-sm-4">
                            <asp:Label ID="LblProjName" runat="server" CssClass="new2"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <p>Owner Name :</p>
                        </div>
                        <div class="col-sm-4">
                            <asp:Label ID="LblOwName" runat="server" CssClass="new2"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <p>Construction Address :</p>
                        </div>
                        <div class="col-sm-4">
                            <asp:Label ID="LblAddress" runat="server" CssClass="new2"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <p>Current Progress</p>
                        </div>
                        <div class="col-sm-4">
                            <asp:Label ID="LblProg" runat="server" CssClass="new2"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <p>Current Project Status</p>
                        </div>
                        <div class="col-sm-4">
                            <asp:Label ID="LblStatus" runat="server" CssClass="new2"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card-footer mx-auto">
                    <asp:Button ID="Button2" runat="server" Text="Close Project" CssClass="btn btn-outline-primary waves-effect" OnClick="Button2_Click" />
                </div>
            </div>
        </section>
    </div>
</asp:Content>
