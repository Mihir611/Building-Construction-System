<%@ Page Title="" Language="C#" MasterPageFile="~/Project_Management.Master" AutoEventWireup="true" CodeBehind="Task_Management.aspx.cs" Inherits="WebApplication1.Task_Management" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3 class="text-center" style="color:#EEFFFF;">Task Management</h3>
        <section class="getdata p-5">
            <div class="row">
                <div class="col-sm-6">
                    <div class="card bg-transparent mb-5" style="max-width:40rem; border-radius:15px; box-shadow: rgba(63,255,0, 0.25) 0px 30px 60px -12px inset, rgba(0, 0, 0, 0.3) 0px 18px 36px -18px inset;">
                        <div class="card-header">
                            <p class="text-center">Get Project Details</p>
                        </div>
                        <div class="card-body">
                            <p>Select the Project ID from the Dropdown List to get the Phase names defined in the project.</p>
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="mydropdown mydropdown-content"></asp:DropDownList>
                        </div>
                        <div class="card-footer mx-auto">
                            <asp:Button ID="Button1" runat="server" Text="Get Data" CssClass="btn btn-outline-primary" OnClick="Button1_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="card bg-transparent mb-5" style="max-width:40rem; border-radius:15px; box-shadow: rgba(63,255,0, 0.25) 0px 30px 60px -12px inset, rgba(0, 0, 0, 0.3) 0px 18px 36px -18px inset;">
                        <div class="card-header">
                            <p class="text-center">Project Phase Details</p>
                        </div>
                        <div class="card-body">
                            <p>Select single Item from the List and click on the button to get the Task names of the corresponding phase.</p>
                            <asp:ListBox ID="ListBox1" runat="server" CssClass="tb2" SelectionMode="Single"></asp:ListBox>
                        </div>
                        <div class="card-footer mx-auto">
                            <asp:Button ID="Button4" runat="server" Text="Get Task Names" CssClass="btn btn-outline-primary" OnClick="Button4_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <hr />
        <section class="phasedet">
            <div class="card bg-transparent mb-5" style="max-width:100rem; border-radius:15px; box-shadow: rgb(63, 0, 255, 0.25) 3px 3px 6px 0px inset, rgba(63, 255, 0, 0.5) -3px -3px 6px 1px inset;">
                <div class="card-header">
                    <p class="text-center">Update Phase Details</p>
                </div>
                <div class="card-body">
                    <div class="card-header">
                        <h5 class="card-subtitle mb-2 text-center pt-3" style="color:#3f00ff">Data Corresponding to <span>
                        <asp:Label ID="LblPhaseID" runat="server" class="new2"></asp:Label></span> are : </h5>
                        <h6 style="color:#3f00ff">Select the Task name from the <i>dropdown list</i> and insert the value <i>(integer values 0 - 100 only)</i> for progress field then click on the add button to update the progress.</h6>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <p>Actual Start Date</p>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="TextStrtDt" runat="server" CssClass="tb2" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <p>Actual End Date</p>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="TextEndDt" runat="server" CssClass="tb2" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <p>Task Name :</p>
                        </div>
                        <div class="col-sm-3">
                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="mydropdown mydropdown-content"></asp:DropDownList>
                        </div>
                        <div class="col-sm-3">
                            <p>Progress %</p>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="TextProgress" runat="server" CssClass="tb2"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="card-footer mx-auto">
                    <asp:Button ID="Button2" runat="server" Text="Add Data" CssClass="btn btn-outline-primary" OnClick="Button2_Click"/>
                </div>
            </div>
        </section>
        <section class="datastore p-5">
            <asp:GridView ID="GridView1" runat="server" BackColor="Transparent" GridLines="Both" ShowHeader="true" ShowFooter="false" style="color:#3f00ff;"></asp:GridView>
        </section>
        <asp:Button ID="Button3" runat="server" Text="Save Data" CssClass="btn btn-outline-success" OnClick="Button3_Click" />
    </div>
</asp:Content>
