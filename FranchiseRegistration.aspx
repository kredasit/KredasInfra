<%@ Page  CodeBehind="FranchiseRegistration.aspx.cs" Inherits="KredasInfra_v2_28May2024.FranchiseRegistration" %>

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
                        &nbsp;FRANCHISE REGISTRATION
                    </td>
                </tr>
                                <tr>
    <td>
        Franchise Type: 
    </td>
    <td>
        <asp:DropDownList ID="FranchiseType_ddl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="FranchiseType_ddl_SelectedIndexChanged">
            <asp:ListItem>Select Franchise Type</asp:ListItem>            
            <asp:ListItem>State</asp:ListItem>
            <asp:ListItem>District</asp:ListItem>
            <asp:ListItem>Area</asp:ListItem>
        </asp:DropDownList>

        
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
                        <asp:TextBox ID="Name_txt" runat="server"></asp:TextBox>

                        
                    </td>
                </tr>
                            <tr>
    <td>
        Name: 
    </td>
    <td>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

        
    </td>
</tr>
                <tr>
                    <td>
                        Mobile Number:
                    </td>
                    <td>
                        <asp:TextBox ID="mobNumber_txt" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="mobNumber_txt" ErrorMessage="Mobile Number is Mandatory"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
    <td>
        Email: 
    </td>
    <td>
        <asp:TextBox ID="email_txt" runat="server"></asp:TextBox>

        
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
                                <tr>
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
        <asp:DropDownList ID="District_ddl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="District_ddl_SelectedIndexChanged"></asp:DropDownList>
    </td>
</tr>
                <tr id="CityRow" runat="server">
    <td>
        City:
    </td>
    <td>
        <asp:DropDownList ID="city_ddl" runat="server" OnSelectedIndexChanged="city_ddl_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
    </td>
</tr>
                <tr id="OtherCityRow" runat="server">
    <td>Please enter City Name</td>
    <td>
        <asp:TextBox ID="OtherCity_txt" runat="server"></asp:TextBox></td>
</tr>
                <tr id="AreaRow" runat="server">
                    <td>Area: </td>
                    <td>
                        <asp:DropDownList ID="Area_ddl" runat="server"></asp:DropDownList><br />
                        <asp:TextBox ID="Area_txt" runat="server"></asp:TextBox></td>
                </tr>
                
                                <tr>
    <td>
        Address:
    </td>
    <td>
        <asp:TextBox ID="Address_txt" runat="server" TextMode="MultiLine"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Address_txt" ErrorMessage="Address is Mandatory"></asp:RequiredFieldValidator>
    </td>
</tr>
                                    <tr>
    <td>
        Landmark:
    </td>
    <td>
        <asp:TextBox ID="LandMark_txt" runat="server" TextMode="MultiLine"></asp:TextBox>
    </td>
</tr>
                <tr>
<td colspan="2" style="background-color:blue; color:white;">
    PAYMENT INFORMATION
</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Upload Screenshot"></asp:Label>
                    </td>
                    <td>
                        
                        <asp:FileUpload ID="FileUpload1" runat="server"  accept=".png,.jpg,.jpeg,.gif,.pdf" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        Please upload the screenshot of your Payment receipt/screenshot here. Accepted formats are pdf,jpeg,png,jpg,etc
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="align-items:center;">
                        <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />

                        <asp:Label ID="result_lbl" ForeColor="Green" runat="server" Text=""></asp:Label>
                        <asp:Button ID="GetImage" runat="server" Text="Display Image" OnClick="GetImage_Click" />
                        <asp:Image ID="Image1" runat="server" />

                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
