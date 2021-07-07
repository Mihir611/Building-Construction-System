<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>
<html>
<head>
    <title>Sign up</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="Scripts/style.css" type="text/css"/>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Abel"/>
</head>
<body>
    <div class="container">
        <h2>Login</h2>
        <div class="form-container">
            <form runat="server">
                <label><b>Username</b></label>
                <asp:TextBox class="tb1" ID="TextBox1" runat="server" ToolTip="Enter User Name" Placeholder="Enter the User Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" SetFocusOnError="True">User Name Required</asp:RequiredFieldValidator>
                <br />
                <label><b>Password</b></label>
                <asp:TextBox class="tb2" ID="TextBox2" runat="server" TextMode="Password" ToolTip="Enter Password">Enter Password</asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="RequiredFieldValidator" ForeColor="Red" SetFocusOnError="True">Password Required</asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Button ID="Button1" CssClass="button" runat="server" Text="Login" OnClick="Button1_Click"/>
            </form>
            <a class="my_link" href="ForgotPw.aspx">Forgot Password ??</a>
            <a class="my_link" href="Signup.aspx">Dont have an Account ?</a>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"> </script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/js/bootstrap.min.js"> </script>
</body>
</html>
