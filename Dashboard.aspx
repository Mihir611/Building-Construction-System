<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WebApplication1.Dashboard1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-6">
                <p class="text-center font-weight-bold">Project Name :<asp:Label ID="Label1" runat="server" Text="Project name" CssClass="new2 font-weight-bold"></asp:Label></p>
            </div>
            <div class=col-sm-6>
                <p class="text-center">
                    <asp:Label ID="Label2" runat="server" CssClass="new2"></asp:Label> <span class="new2">% COMPLETED</span>
                </p>
            </div>
        </div>
        <hr />
        <section class="card mainprogress" style="background-color:transparent;box-shadow: rgba(0, 0, 255, 0.56) 0px 22px 30px 4px;">
            <h3 class="text-center font-weight-bold" style="color:#EEFFFF;">Project Progress</h3>
            <div class="row p-5">
                <div class="col-sm-12 mycol">
                    <div class="row">
                        <div class="col-sm-6">
                            <div id="progress-bar">
                                 <div class="progress">
                                    <div class="progress-bar progress-bar-animated bg-success" runat="server" id="divprogress1" >
                                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                        <span style="color:#101010;">PROGRESS</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-6">
                                    <p class="text-uppercase">Start Date </p>
                                </div>
                                <div class="col-sm-6">
                                    <p class="text-uppercase">End Date</p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <asp:Label ID="StartDt" runat="server" Text="Label" CssClass="new2"></asp:Label>
                                </div>
                                <div class="col-sm-6">
                                    <asp:Label ID="EndDt" runat="server" Text="Label" CssClass="new2"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                      <div class="col-sm-4">
                          <asp:Label ID="Label4" runat="server" CssClass="new2"></asp:Label> <span class="new2">/</span> <asp:Label ID="Label5" runat="server" CssClass =" new2"></asp:Label>
                          <p>Phases Complted</p>
                        </div>
                        <div class="col-sm-4">

                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section class="p-5">
            <div class="row">
                <div class="col-sm-6 mycol card" style="background-color:transparent;box-shadow: rgba(0, 0, 255, 0.56) 0px 22px 30px 4px;">
                    <h2 class="text-center" style="color:#EEFFFF;">Payment Info</h2>
                    <div class="row">
                        <div class="col">
                            <p>Q1</p>
                        </div>
                        <div class="col">
                            <asp:RadioButton ID="RadioButton1" runat="server" Text="Made" Enabled="false" style="color:#EEFFFF;"/>
                            <asp:RadioButton ID="RadioButton2" runat="server" Text="Not Made" Enabled="false" style="color:#EEFFFF;"/>
                            <asp:RadioButton ID="RadioButton3" runat="server" Text ="NA" Checked="true" Enabled="false" style="color:#EEFFFF;"/>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <p>Q2</p>
                        </div>
                        <div class="col">
                            <asp:RadioButton ID="RadioButton4" runat="server" Text="Made" Enabled="false" style="color:#EEFFFF;"/>
                            <asp:RadioButton ID="RadioButton5" runat="server" Text="Not Made" Enabled="false" style="color:#EEFFFF;"/>
                            <asp:RadioButton ID="RadioButton6" runat="server" Text ="NA" Checked="true" Enabled="false" style="color:#EEFFFF;"/>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <p>Q3</p>
                        </div>
                        <div class="col">
                            <asp:RadioButton ID="RadioButton7" runat="server" Text="Made" Enabled="false" style="color:#EEFFFF;"/>
                            <asp:RadioButton ID="RadioButton8" runat="server" Text="Not Made" Enabled="false" style="color:#EEFFFF;"/>
                            <asp:RadioButton ID="RadioButton9" runat="server" Text ="NA" Checked="true" Enabled="false" style="color:#EEFFFF;"/>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <p>Q4</p>
                        </div>
                        <div class="col">
                            <asp:RadioButton ID="RadioButton10" runat="server" Text="Made" Enabled="false" style="color:#EEFFFF;"/>
                            <asp:RadioButton ID="RadioButton11" runat="server" Text="Not Made" Enabled="false" style="color:#EEFFFF;"/>
                            <asp:RadioButton ID="RadioButton12" runat="server" Text ="NA" Checked="true" Enabled="false" style="color:#EEFFFF;"/>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <div class="container">
            <h1 class="h3 mb-0 text-center-800" style="color:#EEFFFF;">Sample Gallery</h1>
            <br />
            <div class="row">
                <div class="col-sm-6">
                    <div>
                        <iframe id="2bf4ce6d-0160-4135-bd38-c3315b28605f" src="https://www.vectary.com/viewer/v1/?model=2bf4ce6d-0160-4135-bd38-c3315b28605f&env=studio3&turntable=3" frameborder="0" width="100%" height="480"></iframe>
                    </div>
                </div>
                <div class="col sm-6">
                        <iframe title="Corkellis House" src="https://sketchfab.com/models/367c66c7272248f3b56f33b56df55dea/embed?preload=1&ui_theme=1">
                        </iframe>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <p>Wanna View More Models ?</p>
                </div>
                <div class="col-sm-3">
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary" OnClick="LinkButton1_Click">Click here</asp:LinkButton>
                </div>
            </div>
        </div>
        <hr />
        <section class="phasedet p-5">
            <h2 style="color:#EEFFFF;">Phases</h2>
            <div class="row">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-6">
                            <div class="card bg-transparent mb-5" style="max-width:40rem; border-radius:15px;">
                                <div class="card-heading">
                                    <asp:Label ID="LblPhaseID" runat="server" CssClass="new2" Text='<%#Eval("Phase_ID") %>'></asp:Label>
                                </div>
                                <div class="card-body">
                                    <div id="progress-bar2">
                                        <div class="progress">
                                            <div class="progress-bar progress-bar-striped progress-bar-animated bg-primary" runat="server" id="div1" >
                                                <asp:Label ID="LblProg" runat="server" Text='<%#Eval("Overall_Progress") %>'></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="card-footer" id="headingTwo">
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <h5 class="mb-0">
                                            <button class="btn btn-link collapsed" style="text-shadow: 1px 1px 2px blue;color:#EEFFFF; " type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                                <i class="fas fa-chevron-circle-down"></i> <span> <p><b>Tasks</b></p></span>
                                            </button>
                                            </h5>
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:Label ID="LblProg1" runat="server" Text='<%#Eval("Overall_Progress") %>'></asp:Label>
                                        </div>
                                    </div>
                                    <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionExample">
                                        <div class="card-body">
                                            <asp:GridView ID="GridView1" runat="server" BackColor="#101010" ForeColor="#EEFFFF" GridLines="Both" ShowFooter="false"></asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </section>
        <asp:Label ID="LblPhaseID3" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="LblPhaseID4" runat="server" Text="Label"></asp:Label>
    </div>
    </asp:Content>
