<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enter_OTP.aspx.cs" Inherits="WebApplication1.enter_OTP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Enter OTP</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <style>
        .img{
            padding:10px;
            height:80%;
        }
        .img1{
            height:50%;
            top:0;
        }
        .myp{
            text-align:center;
        }
        .mytextbox{
            border:none;
            border-bottom:1px solid black;
        }
        .myp1{
            color:#070ff9;
            font-size:30px;
        }
    </style>
    <script>
    $(document).ready(function(){
        $("#myModal").modal('show');
    });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-sm-6">
                    <img src="Images/Untitled.png" />
                    <p style="padding-left:50px;">Secure Gate Way</p>
                </div>
                <div class="col-sm-6">
                    <img class="img" src="Images/banklogo.png" />
                </div>
            </div>
            <hr />
            <div class="section">
                <p>Please enter the One Time Password(OTP), Which is sent to your registered mobile number</p>
                <p class="myp1">Authenticate Payment</p>
                <div class="row">
                    <div class="col-md-8">
                        <p>OTP has been sent to your mobile number ending with</p>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label4" runat="server" Text="Mobile number"></asp:Label>
                    </div>
                </div>
            <hr />
            </div>
            <p class="myp" style="font-size:20px;">Transaction Details</p>
            <div class="row">
                <div class="col-md-8">
                    <p class="myp">Merchant Name</p>
                </div>
                <div class="col-md-4">
                    <p>Syndicate Constructions India</p>
                </div>
            </div>
            <div class="row">
                <div class="col-md-8">
                    <p class="myp">Date</p>                        
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label1" runat="server" Text="Date"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-8">
                    <p class="myp">Card Number</p>                  
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label2" runat="server" Text="Card Number"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-8">
                    <p class="myp">Transaction Amount</p>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label3" runat="server" Text="Amount"></asp:Label><span>&#8377</span>
                </div>
            </div>
            <div class="row">
                <div class="col-md-8">
                    <p class="myp">Enter the Generated OTP</p>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="TextBox1" CssClass="mytextbox" runat="server"></asp:TextBox>
                </div>  
            </div>
            <div class="row">
                <div class="col-md-8">
                    <div class="text-center">
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="Button1_Click" />
                    </div>
                </div>
                <div class="col-md-4">
                    <asp:Button ID="Button2" runat="server" class="btn btn-danger" Text="Cancel" />
                </div>
            </div>
        </div>
    </form>
    <div id="myModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Subscribe our Newsletter</h5>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col">
                            <p class="myp">The Generated OTP is</p>
                        </div>
                        <div class="col">
                            <asp:Label ID="Label5" runat="server" Text="OTP"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
