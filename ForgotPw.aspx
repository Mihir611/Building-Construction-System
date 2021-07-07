<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPw.aspx.cs" Inherits="WebApplication1.ForgotPw" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <link rel="stylesheet" href="Scripts/font.css" />
    <link rel="stylesheet" href="Scripts/ForgotPw_Style.css" />
    <link href="https://fonts.googleapis.com/css2?family=Caveat&family=Oswald&display=swap" rel="stylesheet"/>
    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body>
    <div class="container">
        <h2>Forgot Password ?</h2>
        <div class="form-container">
            <form id="form1" runat="server">
                <div id="pass" runat="server">
                    <label><b>Username</b></label>
                    <asp:TextBox ID="TextBox1" CssClass="tb1" runat="server" Placeholder="User Name"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" CssClass="new2" style="color:#ff0000;"></asp:Label>
                    <hr />
                </div>
                <div id="nousr" runat="server" visible="false">
                    <label><b>Email ID</b></label>
                    <asp:TextBox ID="TextBox2" CssClass="tb1" runat="server"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" CssClass="new2" style="color:#ff0000;"></asp:Label>
                    <hr />
                </div>
                <div id="pass1" runat="server" visible="false">
                    <label><b>New Password</b></label>
                    <asp:TextBox ID="psw" name="psw" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" TextMode="Password" ToolTip="Enter Password" CssClass="tb1" runat="server"></asp:TextBox>
                    <label><b>Confirm Password</b></label>
                    <asp:TextBox ID="TextBox3" CssClass="tb1" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <asp:Button ID="Button1" runat="server" Text="Continue" CssClass="button" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" CssClass="button" OnClick="Button2_Click" Visible="false"  />
                <div id="btns" runat="server">
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="my_link" OnClick="LinkButton1_Click">Forgot UserName ?</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="my_link">Cancel</asp:LinkButton>
                </div>
            </form>
        </div>
        <div id="message">
            <h3>Password must contain the following:</h3>
            <p id="letter" class="invalid">A <b>lowercase</b> letter</p>
            <p id="capital" class="invalid">A <b>capital (uppercase)</b> letter</p>
            <p id="number" class="invalid">A <b>number</b></p>
            <p id="length" class="invalid">Minimum <b>8 characters</b></p>
        </div>
    </div>
    <script src="Scripts/Validation.js"></script>
</body>
</html>
