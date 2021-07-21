<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WebApplication1.Dashboard1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <section id="selproj" runat="server" visible="true" >
            <div class="row">
                <div class="col-sm-4">
                    <p>Select The Project</p>
                </div>
                <div class="col-sm-4">
                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                </div>
                <div class="col-sm-4">
                    <asp:Button ID="Button1" runat="server" Text="Get Details" OnClick="Button1_Click" />
                </div>
            </div>
        </section>
        <section id="main" runat="server" visible="false">
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
            <%--<section class="p-5">
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
            </section>--%>
            <div class="container">
                <h1 class="h3 mb-0 text-center-800" style="color:#EEFFFF;">Sample Gallery</h1>
                <br />
                <div class="row">
                    <div class="col-sm-6">
                        <div>
                            <div class="sketchfab-embed-wrapper"> <iframe title="Modern House 1" frameborder="0" allowfullscreen mozallowfullscreen="true" webkitallowfullscreen="true" allow="fullscreen; autoplay; vr" xr-spatial-tracking execution-while-out-of-viewport execution-while-not-rendered web-share src="https://sketchfab.com/models/982af28527364104b53e4f52a43f49af/embed?autospin=1&preload=1&ui_theme=dark"> </iframe> <p style="font-size: 13px; font-weight: normal; margin: 5px; color: #4A4A4A;"> <a href="https://sketchfab.com/3d-models/modern-house-1-982af28527364104b53e4f52a43f49af?utm_medium=embed&utm_campaign=share-popup&utm_content=982af28527364104b53e4f52a43f49af" target="_blank" style="font-weight: bold; color: #1CAAD9;"> Modern House 1 </a> by <a href="https://sketchfab.com/danchristie25?utm_medium=embed&utm_campaign=share-popup&utm_content=982af28527364104b53e4f52a43f49af" target="_blank" style="font-weight: bold; color: #1CAAD9;"> danchristie25 </a> on <a href="https://sketchfab.com?utm_medium=embed&utm_campaign=share-popup&utm_content=982af28527364104b53e4f52a43f49af" target="_blank" style="font-weight: bold; color: #1CAAD9;">Sketchfab</a></p></div>
                        </div>
                    </div>
                    <div class="col sm-6">
                        <div class="sketchfab-embed-wrapper"> <iframe title="Corkellis House" frameborder="0" allowfullscreen mozallowfullscreen="true" webkitallowfullscreen="true" allow="fullscreen; autoplay; vr" xr-spatial-tracking execution-while-out-of-viewport execution-while-not-rendered web-share src="https://sketchfab.com/models/367c66c7272248f3b56f33b56df55dea/embed?autospin=1&preload=1&ui_theme=dark"> </iframe> <p style="font-size: 13px; font-weight: normal; margin: 5px; color: #4A4A4A;"> <a href="https://sketchfab.com/3d-models/corkellis-house-367c66c7272248f3b56f33b56df55dea?utm_medium=embed&utm_campaign=share-popup&utm_content=367c66c7272248f3b56f33b56df55dea" target="_blank" style="font-weight: bold; color: #1CAAD9;"> Corkellis House </a> by <a href="https://sketchfab.com/danchristie25?utm_medium=embed&utm_campaign=share-popup&utm_content=367c66c7272248f3b56f33b56df55dea" target="_blank" style="font-weight: bold; color: #1CAAD9;"> danchristie25 </a> on <a href="https://sketchfab.com?utm_medium=embed&utm_campaign=share-popup&utm_content=367c66c7272248f3b56f33b56df55dea" target="_blank" style="font-weight: bold; color: #1CAAD9;">Sketchfab</a></p></div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        <div class="sketchfab-embed-wrapper"> <iframe title="Modern House 3" frameborder="0" allowfullscreen mozallowfullscreen="true" webkitallowfullscreen="true" allow="fullscreen; autoplay; vr" xr-spatial-tracking execution-while-out-of-viewport execution-while-not-rendered web-share src="https://sketchfab.com/models/32b184f9b96242aebd6374e4768f9e59/embed?ui_theme=dark"> </iframe> <p style="font-size: 13px; font-weight: normal; margin: 5px; color: #4A4A4A;"> <a href="https://sketchfab.com/3d-models/modern-house-3-32b184f9b96242aebd6374e4768f9e59?utm_medium=embed&utm_campaign=share-popup&utm_content=32b184f9b96242aebd6374e4768f9e59" target="_blank" style="font-weight: bold; color: #1CAAD9;"> Modern House 3 </a> by <a href="https://sketchfab.com/danchristie25?utm_medium=embed&utm_campaign=share-popup&utm_content=32b184f9b96242aebd6374e4768f9e59" target="_blank" style="font-weight: bold; color: #1CAAD9;"> danchristie25 </a> on <a href="https://sketchfab.com?utm_medium=embed&utm_campaign=share-popup&utm_content=32b184f9b96242aebd6374e4768f9e59" target="_blank" style="font-weight: bold; color: #1CAAD9;">Sketchfab</a></p></div>
                    </div>
                    <div class="col-sm-6">
                        <div class="sketchfab-embed-wrapper"> <iframe title="modern house" frameborder="0" allowfullscreen mozallowfullscreen="true" webkitallowfullscreen="true" allow="fullscreen; autoplay; vr" xr-spatial-tracking execution-while-out-of-viewport execution-while-not-rendered web-share src="https://sketchfab.com/models/5dd761507e3548b19f186207cde65fbb/embed?ui_theme=dark"> </iframe> <p style="font-size: 13px; font-weight: normal; margin: 5px; color: #4A4A4A;"> <a href="https://sketchfab.com/3d-models/modern-house-5dd761507e3548b19f186207cde65fbb?utm_medium=embed&utm_campaign=share-popup&utm_content=5dd761507e3548b19f186207cde65fbb" target="_blank" style="font-weight: bold; color: #1CAAD9;"> modern house </a> by <a href="https://sketchfab.com/qurbanova.irade?utm_medium=embed&utm_campaign=share-popup&utm_content=5dd761507e3548b19f186207cde65fbb" target="_blank" style="font-weight: bold; color: #1CAAD9;"> qurbanova.irade </a> on <a href="https://sketchfab.com?utm_medium=embed&utm_campaign=share-popup&utm_content=5dd761507e3548b19f186207cde65fbb" target="_blank" style="font-weight: bold; color: #1CAAD9;">Sketchfab</a></p></div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        <div class="sketchfab-embed-wrapper"> <iframe title="Modern House 4" frameborder="0" allowfullscreen mozallowfullscreen="true" webkitallowfullscreen="true" allow="fullscreen; autoplay; vr" xr-spatial-tracking execution-while-out-of-viewport execution-while-not-rendered web-share src="https://sketchfab.com/models/390c5bd5cd57459fb8d32953f230f444/embed?ui_theme=dark"> </iframe> <p style="font-size: 13px; font-weight: normal; margin: 5px; color: #4A4A4A;"> <a href="https://sketchfab.com/3d-models/modern-house-4-390c5bd5cd57459fb8d32953f230f444?utm_medium=embed&utm_campaign=share-popup&utm_content=390c5bd5cd57459fb8d32953f230f444" target="_blank" style="font-weight: bold; color: #1CAAD9;"> Modern House 4 </a> by <a href="https://sketchfab.com/danchristie25?utm_medium=embed&utm_campaign=share-popup&utm_content=390c5bd5cd57459fb8d32953f230f444" target="_blank" style="font-weight: bold; color: #1CAAD9;"> danchristie25 </a> on <a href="https://sketchfab.com?utm_medium=embed&utm_campaign=share-popup&utm_content=390c5bd5cd57459fb8d32953f230f444" target="_blank" style="font-weight: bold; color: #1CAAD9;">Sketchfab</a></p></div>
                    </div>
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
                    <div class="col-sm-4">
                        <div class="card bg-transparent mb-5" style="max-width:40rem; border-radius:15px;">
                            <div class="card-heading text-center">
                                <asp:Label ID="Label6" CssClass="new2" runat="server" Text="Label"></asp:Label>
                                <div class="card-body">
                                    <button class="btn btn-link collapsed" style="text-shadow: 1px 1px 2px blue;color:#EEFFFF; " type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                        <i class="fas fa-chevron-circle-down"></i> <span> <b>Tasks</b></span>
                                    </button>
                                    <div id="collapseTwo">
                                    <div class="progress-bar progress-bar-animated bg-success progress" runat="server" id="div1" >
                                        <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                                    </div>
                                    <asp:GridView ID="GridView2" runat="server"></asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="card bg-transparent mb-5" style="max-width:40rem; border-radius:15px;">
                            <div class="card-heading text-center">
                                <asp:Label ID="Label8" CssClass="new2" runat="server" Text="Label"></asp:Label>
                                <div class="card-body">
                                    <button class="btn btn-link collapsed" style="text-shadow: 1px 1px 2px blue;color:#EEFFFF; " type="button" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                        <i class="fas fa-chevron-circle-down"></i> <span> <b>Tasks</b></span>
                                    </button>
                                    <div id="collapseThree">
                                        <div class="progress-bar progress-bar-animated bg-success progress" runat="server" id="div2" >
                                            <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                                        </div>
                                        <asp:GridView ID="GridView3" runat="server"></asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="card bg-transparent mb-5" style="max-width:40rem; border-radius:15px;">
                            <div class="card-heading text-center">
                                <asp:Label ID="Label9" CssClass="new2" runat="server" Text="Label"></asp:Label>
                                <div class="card-body">
                                    <button class="btn btn-link collapsed" style="text-shadow: 1px 1px 2px blue;color:#EEFFFF; " type="button" data-toggle="collapse" data-target="#collapse4" aria-expanded="false" aria-controls="collapse4">
                                        <i class="fas fa-chevron-circle-down"></i> <span> <b>Tasks</b></span>
                                    </button>
                                    <div id="collapse4">
                                        <div class="progress-bar progress-bar-animated bg-success progress" runat="server" id="div3" >
                                            <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                                        </div>
                                        <asp:GridView ID="GridView4" runat="server"></asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </section>
    </div>
</asp:Content>
