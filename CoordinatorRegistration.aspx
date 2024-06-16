<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoordinatorRegistration.aspx.cs" Inherits="KredasInfra_v2_28May2024.CoordinatorRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

                                    <table class="required">
                <tr>
                    <td colspan="2" style="height:30px; background-color:#69598f; color:white;">
                        &nbsp;COORDINATOR REGISTRATION
                    </td>
                </tr>
                                
                <tr>
    <td>
        User Name: 
    </td>
    <td>
        <asp:TextBox ID="UsrName_txt" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="UserName_RFVal" runat="server" ErrorMessage="User Name is Mandatory" ControlToValidate="UsrName_txt"></asp:RequiredFieldValidator>
        
    </td>
</tr>
                                <tr>
    <td>
        Password: 
    </td>
    <td>
        <asp:TextBox ID="Password_txt" runat="server" TextMode="Password"></asp:TextBox>

        
        <asp:RequiredFieldValidator ID="PwdRFVal" runat="server" ControlToValidate="Password_txt" ErrorMessage="Password is mandatory"></asp:RequiredFieldValidator>

        
    </td>
</tr>
                                                <tr>
    <td>
        Confirm Password: 
    </td>
    <td>
        <asp:TextBox ID="ConPassword_txt" runat="server" TextMode="Password"></asp:TextBox>

        
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="ConPassword_txt" ControlToValidate="Password_txt" ErrorMessage="Password mismatch"></asp:CompareValidator>

        
    </td>
</tr>
                <tr>
                    <td>
                        First Name: 
                    </td>
                    <td>
                        <asp:TextBox ID="first_name_txt" runat="server"></asp:TextBox>

                        
                    </td>
                </tr>
                                        <tr>
    <td>
        Middle Name: 
    </td>
    <td>
        <asp:TextBox ID="middle_name_txt" runat="server"></asp:TextBox>

        
    </td>
</tr>
                                                                                <tr>
    <td>
        Last Name: 
    </td>
    <td>
        <asp:TextBox ID="last_name_txt" runat="server"></asp:TextBox>

        
    </td>
</tr>
                <tr>
                    <td>
                        Mobile Number:
                    </td>
                    <td>
                        <asp:TextBox ID="mobile_number_txt" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="mobile_number_txt" ErrorMessage="Mobile Number is Mandatory"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
    <td>
        Email: 
    </td>
    <td>
        <asp:TextBox ID="email_txt" runat="server"></asp:TextBox>

        
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="email_txt" ErrorMessage="Email field is Mandatory"></asp:RequiredFieldValidator>

        
    </td>
</tr>
<tr>
    <td>
        Alternate Contact Number:
    </td>
    <td>
        <asp:TextBox ID="AltContactNumber_txt" runat="server"></asp:TextBox>
    </td>
</tr>
                                <%--<tr>
    <td>
        State:
    </td>
    <td>
        <asp:DropDownList ID="State_ddl" runat="server" OnSelectedIndexChanged="State_ddl_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
    </td>
</tr>
                                <tr id="DistrictRow" runat="server">
    <td>
        District:
    </td>
    <td>
        <asp:DropDownList ID="District_ddl" runat="server"></asp:DropDownList>
    </td>
</tr>
                <tr id="CityRow" runat="server">
    <td>
        City:
    </td>
    <td>
        <asp:DropDownList ID="city_ddl" runat="server"></asp:DropDownList>
    </td>
</tr>--%>
                
                <tr id="AadharRow" runat="server">
                    <td>Aadhar Number</td>
                    <td>
                        <asp:TextBox ID="AadharNumber_txt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
                <tr >
                    <td>Upload Adhar Copy</td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                </tr>
                
                <tr id="PANRow" runat="server">
                    <td>PAN Number</td>
                    <td>
                        <asp:TextBox ID="PanNumber_txt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>Upload PAN Copy</td>
                    <td>
                        <asp:FileUpload ID="PAN_FilControl" runat="server" />
                    </td>
                </tr>
                
                <tr id="AreaRow" runat="server">
                    <td>Area: </td>
                    <td>
                        <asp:TextBox ID="Area_txt" runat="server"></asp:TextBox></td>
                </tr>
                
                                <tr>
    <td>
        Address:
    </td>
    <td>
        <asp:TextBox ID="address_txt" runat="server" TextMode="MultiLine"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="address_txt" ErrorMessage="Address is Mandatory"></asp:RequiredFieldValidator>
    </td>
</tr>
                                    <tr>
    <td>
        Landmark:
    </td>
    <td>
        <asp:TextBox ID="LandMark_txt" runat="server" TextMode="MultiLine"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Landmark is Mandatory" ControlToValidate="LandMark_txt"></asp:RequiredFieldValidator>
    </td>
</tr>           
                
                <tr>
                    <td colspan="2" style="align-items:center;">
                        <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
                        <asp:Label ID="result_lbl" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
