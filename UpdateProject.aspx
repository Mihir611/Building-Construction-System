<%@ Page Title="" Language="C#" MasterPageFile="~/Project_Management.Master" AutoEventWireup="true" CodeBehind="UpdateProject.aspx.cs" Inherits="WebApplication1.UpdateProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2 class="text-center" style="color:#EEFFFF;">Update Project and Other Related Data</h2>
        <section class="relateddata p-5">
            <div class="row">
                <div class="col-sm-6">
                    <div class="card bg-success mb-5" style="max-width:40rem; border-radius:15px;">
                        <div class="card-header">
                            <h6 class="card-subtitle mb-2 text-center pt-3" style="color:#101010">Get Project Data</h6>
                        </div>
                        <div class="card-body p-3">
                            <p style="color:#101010">First select the below project name from the dropdown list and click on Get data to get the project specific data</p>
                            <div class="row">
                                <div class="col-sm-6">
                                    <p style="color:#101010">Project Name :</p>
                                </div>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="mydropdown mydropdown-content"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="card-footer">
                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Get Data" OnClick="Button1_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="card bg-primary mb-5" style="max-width:30rem; border-radius:15px;">
                        <div class="card-header">
                            <h6 class="card-subtitle mb-2 text-center pt-3" style="color:#101010">Completion Status</h6>
                        </div>
                        <div class="card-body p-3">
                            <div class="row">
                                <div class="col-sm-6">
                                    <p style="color:#101010"> Total % Completed</p>
                                </div>
                                <div class="col-sm-6">
                                    <asp:Label ID="LblTotalPerc" runat="server" CssClass="new2"></asp:Label> <span style="color:#101010">%</span>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <p style="color:#101010">Phase 1 % Completed</p>
                                </div>
                                <div class="col-sm-6">
                                    <asp:Label ID="LblPhase1Perc" runat="server" CssClass="new2"></asp:Label> <span style="color:#101010">%</span>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <p style="color:#101010">Phase 2 % Completed</p>
                                </div>
                                <div class="col-sm-6">
                                    <asp:Label ID="LblPhase2Perc" runat="server" CssClass="new2"></asp:Label> <span style="color:#101010">%</span>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <p style="color:#101010">Phase 3 % Completed</p>
                                </div>
                                <div class="col-sm-6">
                                    <asp:Label ID="LblPhase3Perc" runat="server" CssClass="new2"></asp:Label> <span style="color:#101010">%</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <hr/>
        <h3 class="text-center" style="color:#EEFFFF;">Update Project Details</h3>
        <section class="updatedet p-5">
            <div class="card bg-transparent mb-5" style="max-width:100rem; border-radius:15px; box-shadow: rgba(57,255,20, 0.25) 0px 14px 28px, rgba(57,255,20, 0.22) 0px 10px 10px;">
                <div class="card-header">
                    <p class="text-center pt-3">Date Details</p>
                </div>
                <div class="card-body p-2">
                    <div class="row">
                    <div class="col-sm-3">
                        <p>Current Start Date :</p>
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="LblStrtDt" runat="server" CssClass="new2"></asp:Label>
                    </div>
                    <div class="col-sm-3">
                        <p>Current End Date :</p>
                    </div>
                    <div class="col-sm-3">
                        <asp:Label ID="LblEndDt" runat="server" CssClass="new2"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3">
                        <p>Actual Start Date :</p>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="TextStrtDt" runat="server" TextMode="Date" CssClass="tb2" style="width:100%;"></asp:TextBox>
                    </div>
                    <div class="col-sm-3">
                        <p>Actual End Date</p>
                    </div>
                    <div class="col-sm-3">
                        <asp:TextBox ID="TextEndDt" runat="server" TextMode="Date" CssClass="tb2"></asp:TextBox>
                    </div>
                    </div>
                </div>
            </div>
            <div class="card bg-transparent mb-5" style="max-width:100rem; border-radius:15px; box-shadow: rgba(57,255,20, 0.25) 0px 14px 28px, rgba(57,255,20, 0.22) 0px 10px 10px;">
                <div class="card-header">
                    <p class="text-center pt-3">Budget Details</p>
                </div>
                <div class="card-body p-2">
                    <div class="row">
                        <div class="col-sm-3">
                            <p>Current Budget Value :</p>
                        </div>
                        <div class="col-sm-3">
                            <asp:Label ID="LblBudget" runat="server" CssClass="new2"></asp:Label> <span style="color:#EEFFFF;">&#8377;</span>
                        </div>
                        <div class="col-sm-3">
                            <p>Update Budget :</p>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="TextBudget" runat="server" CssClass="tb2" Text="0"></asp:TextBox>  
                        </div>
                    </div>
                </div>
            </div>
            <div class="card bg-transparent mb-5" style="max-width:100rem; border-radius:15px; box-shadow: rgba(57,255,20, 0.25) 0px 14px 28px, rgba(57,255,20, 0.22) 0px 10px 10px;">
                <div class="card-header">
                    <p class="text-center pt-3">Project Status</p>
                </div>
                <div class="card-body p-2">
                    <div class="row">
                        <div class="col-sm-3">
                            <p>Current Value:</p>
                        </div>
                        <div class="col-sm-3">
                            <asp:Label ID="LblStatus" runat="server" CssClass="new2"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <p>Project Status :</p>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="TextStatus" runat="server" CssClass="tb2" Text="status"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div> 
        </section>
        <hr />
        <h3 class="text-center" style="color:#EEFFFF;">Update Project Phase Details</h3>
        <section class="updatephases pt-5">
            <div class="row">
                <div class="col-sm-4">
                    <div class="card bg-transparent mb-5" style="max-width:40rem; border-radius:15px; box-shadow: rgba(57,255,20, 0.25) 0px 14px 28px, rgba(57,255,20, 0.22) 0px 10px 10px;">
                        <div class="card-header">
                            <h6 class="card-subtitle mb-2 text-center pt-3" style="color:#EEFFFF;">Phase 1 Details</h6>
                        </div>
                        <div class="card-body p-2">
                            <div class="row">
                                <div class="col-sm-6">
                                    <p>Phase 1 Start Date :</p>
                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="TextP1StrtDt" runat="server" TextMode="Date" CssClass="tb2"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <p>Phase 1 End Date</p>
                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="TextP1EndDt" runat="server" TextMode="Date" CssClass="tb2"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="card bg-transparent mb-5" style="max-width:40rem; border-radius:15px; box-shadow: rgba(57,255,20, 0.25) 0px 14px 28px, rgba(57,255,20, 0.22) 0px 10px 10px;">
                        <div class="card-header">
                            <h6 class="card-subtitle mb-2 text-center pt-3" style="color:#EEFFFF;">Phase 2 Details</h6>
                        </div>
                        <div class="card-body p-2">
                            <div class="row">
                                <div class="col-sm-6">
                                    <p>Phase 2 Start Date :</p>
                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="TextP2StrtDt" runat="server" TextMode="Date" CssClass="tb2"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <p>Phase 2 End Date</p>
                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="TextP2EndDt" runat="server" TextMode="Date" CssClass="tb2"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="card bg-transparent mb-5" style="max-width:40rem; border-radius:15px; box-shadow: rgba(57,255,20, 0.25) 0px 14px 28px, rgba(57,255,20, 0.22) 0px 10px 10px;">
                        <div class="card-header">
                            <h6 class="card-subtitle mb-2 text-center pt-3" style="color:#EEFFFF;">Phase 3 Details</h6>
                        </div>
                        <div class="card-body p-2">
                            <div class="row">
                                <div class="col-sm-6">
                                    <p>Phase 3 Start Date :</p>
                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="TextP3StrtDt" runat="server" TextMode="Date" CssClass="tb2"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <p>Phase 3 End Date</p>
                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="TextP3EndDt" runat="server" TextMode="Date" CssClass="tb2"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <asp:Button ID="Button2" runat="server" Text="Save Data" CssClass="btn btn-primary" OnClick="Button2_Click" />
    </div>
</asp:Content>
