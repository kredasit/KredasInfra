<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="KredasInfra_v2_28May2024.MyAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
          body {
    margin: 0;
    padding: 0;
    font-family: Arial, sans-serif;
    background-image: url("images/KredasInfra-Login-bg.jpg");
    background-size: cover; /* This ensures the image covers the entire screen */
    background-position: center;
    background-repeat: no-repeat;
    height: 100vh; /* Ensures the body takes up the full height of the viewport */
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table style="background-color:white; font:medium;font-family:Arial, Helvetica, sans-serif;color:black;">
                <tr>
                    <td colspan="3" style="background-color:#69598f; font:medium;font-family:Arial, Helvetica, sans-serif;color:white;">
                        MY ACCOUNT
                    </td>
                </tr>
                <tr>
                    <td>First Name:   </td>
                    <td>  <asp:Label ID="FirstName_lbl" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
    <td>Middle Name:   </td>
    <td>  <asp:Label ID="middleName_lbl" runat="server" Text=""></asp:Label></td>
</tr>
                                <tr>
    <td>Last Name:   </td>
    <td>  <asp:Label ID="lastName_lbl" runat="server" Text=""></asp:Label></td>
</tr>
                                                <tr>
    <td>Mobile Number:   </td>
    <td>  <asp:Label ID="mobileNumber_lbl" runat="server" Text=""></asp:Label></td>
</tr>
                                                                <tr>
    <td>Email:   </td>
    <td>  <asp:Label ID="email_lbl" runat="server" Text=""></asp:Label></td>
</tr>
    <tr>
    <td>Address:   </td>
    <td>  <asp:Label ID="Address_lbl" runat="server" Text=""></asp:Label></td>
</tr>
    <tr>
    <td>Landmark:   </td>
    <td>  <asp:Label ID="landmark_lbl" runat="server" Text=""></asp:Label></td>
</tr>
    <tr>
    <td>AadharNumber:   </td>
    <td>  <asp:Label ID="Aadhar_lbl" runat="server" Text=""></asp:Label></td>
</tr>
    <tr>
    <td>PAN Number:   </td>
    <td>  <asp:Label ID="PanNumber_lbl" runat="server" Text=""></asp:Label></td>
</tr>
    <tr>
    <td>Reffered By:   </td>
    <td>  <asp:Label ID="ReferedBy_lbl" runat="server" Text=""></asp:Label></td>
</tr>
            </table>
        </div>
    </form>
</body>
</html>
