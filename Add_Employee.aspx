<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard_User.Master" AutoEventWireup="true" CodeBehind="Add_Employee.aspx.cs" Inherits="WebApplication1.Add_Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container products">
        <h3 class="text-center" style="color:#EEFFFF;">Add employees to the company</h3>
        <section class="getdata p-5 product">
            <div class="row">
                <div class="col-sm-8">
                    <h5 class="text-center" style="color:#EEFFFF;">Input Employee Data</h5>
                    <div class="p-4"></div>
                    <div class="row">
                        <div class="col-sm-4">
                            <p>Employee Name :</p>
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="TextBox1" runat="server" placeholder="Employee Name" CssClass="tb2" style="width:100%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter the Employee Name" ControlToValidate="TextBox1" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <p>Employee Address : </p>
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" placeholder="Employee Address" CssClass="tb2" style="width:100%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter the Employee Address" ControlToValidate="TextBox2" ForeColor="#FF0000" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <p>Email Id :</p>
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="TextBox3" runat="server" TextMode="Email" placeholder="Employee Email Id" CssClass="tb2" style="width:100%"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Proper Email ID" ControlToValidate="TextBox3" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <p>Phone Number :</p>
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="TextBox4" runat="server" TextMode="Phone" placeholder="Employee Phone Number" CssClass="tb2" style="width:100%"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Proper Phone Number" ControlToValidate="TextBox4" Display="Dynamic" ForeColor="Red" ValidationExpression="^[789]\d{9}$"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <p>Date of Birth </p>
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="TextBox5" runat="server" TextMode="Date" CssClass="tb2" style="width:100%"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <p>Gender :</p>
                        </div>
                        <div class="col-sm-4"style="color:#c2eea0;">
                            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="Gender" Text="Male" CssClass="p-2" />
                            <asp:RadioButton ID="RadioButton2" runat="server" Text="Female" GroupName="Gender"/>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="p-4"></div>
                    <p class="text-center">Employee Image</p>
                    <asp:Image ID="Image1" runat="server" style="height:50%;width:75%;" /><br />
                    <asp:FileUpload ID="FileUpload1" runat="server" style="color:#c2eea0;" />
                    <asp:Label ID="Label1" runat="server" Text="Label" style="color:#FF0000;"></asp:Label>
                </div>
            </div>
        </section>
        <hr />
        <section class="otherdetails products p-5">
            <h3 class="text-center" style="color:#EEFFFF;">Other Details</h3>
            <div class="p-5">
                <div class="row">
                    <div class="col-sm-6">
                        <p>Joining Date :</p>
                    </div>
                    <div class="col-sm-6">
                        <asp:TextBox ID="TextBox6" runat="server" TextMode="Date" CssClass="tb2" style="width:100%"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        <p>Employee Designation :</p>
                    </div>
                    <div class="col-sm-6">
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="tb2" style="width:100%" BackColor="#101010">
                            <asp:ListItem>Executive</asp:ListItem>
                            <asp:ListItem Selected="True">Secondary Admin</asp:ListItem>
                            <asp:ListItem>Project Manager</asp:ListItem>
                            <asp:ListItem>Receptionist</asp:ListItem>
                            <asp:ListItem>Marketing Manager</asp:ListItem>
                            <asp:ListItem>Product Manager</asp:ListItem>
                            <asp:ListItem>Finance Manager</asp:ListItem>
                            <asp:ListItem>Human-Resource Manager</asp:ListItem>
                            <asp:ListItem>Analyst</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        <p>Basic Salary</p>
                    </div>
                    <div class="col-sm-6">
                        <asp:TextBox ID="TextBox7" runat="server" TextMode="Number" CssClass="tb2" style="width:100%"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        <p>Leaves Awarder (CL)</p>
                    </div>
                    <div class="col-sm-6">
                        <asp:TextBox ID="TextBox8" runat="server" TextMode="Number" CssClass="tb2" style="width:100%"></asp:TextBox>
                    </div>
                </div>
                <hr />
            </div>
        </section>
        <asp:Button ID="Button1" runat="server" Text="Save Data" CssClass="btn btn-success" style="color:#101010;" OnClick="Button1_Click" />
    </div>
</asp:Content>
