<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard_User.Master" AutoEventWireup="true" CodeBehind="Create_Project.aspx.cs" Inherits="WebApplication1.Create_Project" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content products">
        <h3 class="text-center" style="color:#EEFFFF;text-decoration:underline;text-shadow: 1px 1px 2px blue; ">Quotation Details</h3>
        <section class="qdet p-4">
            <div class="row">
                <div class="col-sm-2">
                    <p>Quotation Id :</p>
                </div>
                <div class="col-sm-2">
                    <asp:DropDownList ID="DropDownList3" runat="server" style="width:100%" CssClass="mydropdown mydropdown-content"></asp:DropDownList>
                </div>
                <div class="col-sm-2">
                    <asp:Button ID="BtnGetData" CssClass="btn btn-primary" style="background:#00ff21; color:#101010; border:none;text-shadow: 1px 1px 2px black; " runat="server" Text="Get Data" OnClick="BtnGetData_Click"  />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2">
                    <p>Quotation Dated :</p>
                </div>
                <div class="col-sm-2">
                    <asp:Label ID="LblDate" runat="server" CssClass="new2"></asp:Label>
                </div>
                <div class="col-sm-3">
                    <p>Total Amount to be paid :</p>
                </div>
                <div class="col-sm-2">
                    <asp:Label ID="LblAmt" runat="server" CssClass="new2"></asp:Label> <span style="color:#EEFFFF;"> &#8377;</span>
                </div>
            </div>
            <h3 class="text-center" style="color:#EEFFFF;text-decoration:underline;text-shadow: 1px 1px 2px blue; ">Contact Details</h3>
            <section class="CustomerDet p-4">
                <div class="row">
                    <div class="col-sm-2">
                        <p>Customer Name :</p>
                    </div>
                    <div class="col-sm-2">
                        <asp:Label ID="LblCusName" runat="server" Text="Label" CssClass="new2"></asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <p>Customer Phone :</p>
                    </div>
                    <div class="col-sm-2">
                        <asp:Label ID="LblPhone" runat="server" Text="Label" CssClass="new2"></asp:Label>
                    </div>
                    <div class="col-sm-2">
                        <p>Customer Email :</p>
                    </div>
                    <div class="col-sm-2">
                        <asp:Label ID="LblMail" runat="server" Text="Label" CssClass="new2"></asp:Label>
                    </div>
                </div>
            </section>
            <section class="agreement">
                <div class="row">
                    <div class="col-sm-6">
                        <p>Agreement Accepted ? :</p>
                    </div>
                    <div class="col-sm-6">
                        <asp:Label ID="LblAgree" runat="server" CssClass="new2"></asp:Label>
                    </div>
                </div>
            </section>
        </section>
        <hr />
        <h3 class="text-center" style="color:#EEFFFF;text-decoration:underline;text-shadow: 1px 1px 2px blue; ">Project Details</h3>
        <section class="proj_Det p-4">
            <div class="row">
                <div class="col-sm-2 text-center">
                    <p>Project Id :</p>
                </div>
                <div class="col-sm-2" style="color:#EEFFFF;">
                    <asp:Label ID="LblID" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-sm-4 text-center">
                    <p>Project Name :</p>
                </div>
                <div class="col-sm-4">
                    <asp:TextBox ID="TextName" runat="server" CssClass="tb2" style="width:100%;"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2">
                    <p class="text-center">Project Type :</p>
                </div>
                <div class="col-sm-2">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="mydropdown mydropdown-content" style="width:100%;">
                        <asp:ListItem>Select Item</asp:ListItem>
                        <asp:ListItem>House</asp:ListItem>
                        <asp:ListItem>Flat</asp:ListItem>
                        <asp:ListItem>Villa</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm-4">
                    <p class="text-center">Construction Address :</p>
                </div>
                <div class="col-sm-4">
                    <asp:TextBox ID="TextAddress" runat="server" TextMode="MultiLine" CssClass="tb2" style="width:100%;"></asp:TextBox>
                </div>
            </div>
        </section>
        <hr />
        <section class="QutDet p-4">
            <div class="row">
                <div class="col-sm-6">
                    <div class="card bg-success mb-5" style="max-width: 40rem;">
                        <div class="card-header">Quotation Id : <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></div>
                        <div class="card-body">
                        <h5 class="card-title text-center" style="text-decoration:underline solid #101010;text-shadow: 1px 1px 2px black; ">Quotation Details</h5>
                            <div class="row">
                                <div class="col-sm-5">
                                    <p>Plot Size :</p>
                                </div>
                                <div class="col-sm-5">
                                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                    <span>Ft By </span>
                                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                    <span> Ft</span>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-5">
                                    <p>Enterence Direction :</p>
                                </div>
                                <div class="col-sm-3">
                                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-5">
                                    <p>Well :</p>
                                </div>
                                <div class="col-sm-4">
                                    <asp:Label ID="LblWell" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-5">
                                    <p>Garden Space :</p>
                                </div>
                                <div class="col-sm-4">
                                    <asp:Label ID="LblGarden" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-5">
                            <p>Select Project Manager :</p>
                        </div>
                        <div class="col-sm-7">
                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="mydropdown mydropdown-content" style="width:100%;"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="card bg-info mb-5" style="max-width: 30rem;">
                        <div class="card-header">Enter Date Details</div>
                        <div class="card-body">
                        <h5 class="card-title text-center" style="text-decoration:underline solid #101010;text-shadow: 1px 1px 2px black; ">Input Start and End Date</h5>
                            <div class="row">
                                <div class="col-sm-6">
                                    <p>Expected Start Date :</p>
                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="TextStartDate" runat="server" TextMode="Date" style="width:100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <p>Expected End Date :</p>
                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="TextEndDate" runat="server" TextMode="Date" style="width:100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">

                </div>
                <div class="col-sm-2">
                    <asp:Button ID="BtnAssignPM" runat="server" Text="Assign Project Manager" CssClass="btn btn-primary" style="color:#101010;text-shadow: 1px 1px 2px black; " OnClick="BtnAssignPM_Click"/>
                </div>
            </div>
        </section>
        <hr />
        <section class="predefinedtask p-4">
            <div class="row">
                <div class="col-sm-6">
                    <div class="card bg-transparent">
                        <div class="card-header" id="headingTwo">
                            <h5 class="mb-0">
                            <button class="btn btn-link collapsed" style="text-shadow: 1px 1px 2px blue;color:#EEFFFF; " type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                Task Defined By Default
                            </button>
                            </h5>
                        </div>
                        <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionExample">
                            <div class="card-body">
                                <asp:GridView ID="GridView1" runat="server" ForeColor="#EEFFFF" BackColor="#101010" ShowFooter="false" GridLines="Both"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="card bg-transparent">
                        <div class="card-header" id="headingThree">
                            <h5 class="mb-0">
                                <button class="btn btn-link collapsed" style="text-shadow: 1px 1px 2px blue;color:#EEFFFF; " type="button" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                User Defined Task
                                </button>
                            </h5>
                        </div>
                        <div id="collapseThree" class="collapse" aria-labelledby="headingThree" data-parent="#accordionExample">
                            <div class="card-body">
                                <table>
                                    <tr>
                                        <th class="mytable">Item Name</th>
                                        <th class="mytable">Type/Value</th>
                                    </tr>
                                    <tr>
                                        <td class="mydata">Roof</td>
                                        <td class="mydata">
                                            <asp:Label ID="LblRoof" runat="server" CssClass="new2"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="mydata">Walls</td>
                                        <td class="mydata">
                                            <asp:Label ID="LblW" runat="server" CssClass="new2"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="mydata">Floor</td>
                                        <td class="mydata">
                                            <asp:Label ID="LblFloor" runat="server" CssClass="new2"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="mydata">Windows</td>
                                        <td class="mydata">
                                            <asp:Label ID="LblWindow" runat="server" CssClass="new2"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="mydata">Door</td>
                                        <td class="mydata">
                                            <asp:Label ID="LblDoor" runat="server" CssClass="new2"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="mydata">Well</td>
                                        <td class="mydata">
                                            <asp:Label ID="LblWEl" runat="server" CssClass="new2"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="mydata">Garden</td>
                                        <td class="mydata">
                                            <asp:Label ID="LblGard" runat="server" CssClass="new2"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>   
                        </div>
                    </div>
                </div>
            </div>     
        </section>
        <asp:Button ID="BtnSaveData" runat="server" Text="Save Data" CssClass="btn btn-primary" style="color:#101010;text-shadow: 1px 1px 2px black; " OnClick="BtnSaveData_Click" />
        <asp:Label ID="Label5" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>
</asp:Content>
