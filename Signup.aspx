<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="WebApplication1.Signup" %>

<!DOCTYPE html>
<html>
<head>
    <title>Sign up</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="Scripts/style.css" type="text/css"/>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Abel"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body>
    <div class="container">
        <h2>Sign Up</h2>
        <div class="form-container">
            <form runat="server">
                <div class="row">
                    <div class="col-sm-6">
                        <label><b>Full Name</b></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" ControlToValidate="TextBox3" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:TextBox class="tb1" ID="TextBox3" runat="server" ToolTip="Enter Full Name" Placeholder="Enter Full Name"></asp:TextBox>

                        <label><b>Phone Number</b></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="TextBox4" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:TextBox CssClass="tb1" ID="TextBox4" runat="server" ToolTip="Enter the Phone Number" TextMode="Number" MaxLength="10" Placeholder="Enter Phone Number"></asp:TextBox>

                        <label><b>Email ID</b></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox5" ErrorMessage="Required" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="TextBox5" ErrorMessage="Invalid Email Format" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:TextBox class="tb1" ID="TextBox5" runat="server" ToolTip="Enter Email ID" TextMode="Email" Placeholder="someone@example.com"></asp:TextBox>
                    </div>
                    <div class="col-sm-6">
                        <label><b>Username</b></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required" ControlToValidate="TextBox1" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:TextBox class="tb1" ID="TextBox1" runat="server" ToolTip="Enter User Name" Placeholder="Enter User Name"></asp:TextBox>

                        <br />
                        <label><b>Password</b></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required" ControlToValidate="psw" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:TextBox class="tb2" ID="psw" name="psw" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" TextMode="Password" ToolTip="Enter Password" runat="server"></asp:TextBox>

                        <br />
                        <label><b>Confirm Password</b></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required" ControlToValidate="TextBox6" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                        <asp:TextBox class="tb2" ID="TextBox6" runat="server" TextMode="Password" ToolTip="Enter Password"></asp:TextBox>
                    </div>
                </div>
                <br />
                <br />
                <asp:Button ID="Button1" CssClass="button" runat="server" Text="Submit" OnClick="Button1_Click" />
                <br />
                <a class="my_link" href="Login.aspx">Click here to Login</a>
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
