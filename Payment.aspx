<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="WebApplication1.Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payments</title>
    <link rel="stylesheet" href="Scripts/Payments.css" />
    <link rel="stylesheet" href="Scripts/font.css" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="app-container">
        <div class="top-box">
            <p><span class="left-icon">&#x2190;</span>CHECKOUT<span class="right-icon">&#xb7;&#xb7;&#xb7;</span></p>
        </div>
        <div class="middle-box">
            <h1><asp:Label ID="Label1" runat="server" Text="0.00" name="amount"></asp:Label><span>&#8377</span></h1>
            <p>Pay to Syndicate Constructions India</p>
            <p><asp:Label ID="Label2" runat="server" Text="Label" name="name"></asp:Label></p>
        </div>
        <div class="card-details">
            <p>Pay using credit or debit card</p>
            <div class="card-num-field-group">
                <label>Card Number</label><br />
                <asp:TextBox ID="TextBox1" placeholder="xxxx-xxxx-xxxx-xxxx" CssClass="card-num-field" runat="server" MaxLength="16" TextMode="Number" Enabled="True"></asp:TextBox>
            </div>
            <div class="date-num-field-group">
                <label>Expiry Date</label><br />
                <asp:TextBox ID="TextBox2" placeholder="MM" CssClass="date-num-field asp" runat="server" MaxLength="2" TextMode="Number"></asp:TextBox>
                <asp:TextBox ID="TextBox3" placeholder="YY" CssClass="date-num-field asp" runat="server" MaxLength="2" TextMode="Number"></asp:TextBox>
            </div>
            <div class="cvv-num-field-group">
                <label>CVV</label><br />
                <asp:TextBox ID="TextBox4" placeholder="123" CssClass="cvv-num-field asp" runat="server" MaxLength="3" TextMode="Password">CVV</asp:TextBox>
            </div>
            <div class="name-field-group">
                <label>Name on the Card</label><br />
                <asp:TextBox ID="TextBox5" placeholder="Name on the Card" CssClass="name-field asp" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="Button1" CssClass="pay-btn" runat="server" Text="Pay Now." OnClick="Button1_Click" />
        </div>
        <hr />
        <div class="bottom-box">
            <button type="button" class="payment-options-btn">Pay with PayPal</button>
            <button type="button" class="payment-options-btn">Pay with Phonepay</button>
            <button type="button" class="payment-options-btn">Pay with Google Pay</button>
            <button type="button" class="payment-options-btn">Pay with Net-Banking</button>
        </div>
        </div>
    </form>
</body>
</html>
