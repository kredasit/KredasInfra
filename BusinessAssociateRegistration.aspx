<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusinessAssociateRegistration.aspx.cs" Inherits="KredasInfra_v2_28May2024.BusinessAssociateRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

                                   <table>
              <tr>
    <td colspan="2" style="height:30px; background-color:#69598f; color:white;">
        &nbsp;BUSINESS EXECUTIVE REGISTRATION
    </td>
</tr>
               <tr>
                   <td class="auto-style1">
                       <asp:Label ID="label1" runat="server" Text="Username:"></asp:Label>
                   </td>
                   <td class="auto-style1">
                       <asp:TextBox ID="username_txt" runat="server"></asp:TextBox>
                   </td>
                   <td class="auto-style1">
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="username_txt"></asp:RequiredFieldValidator>
                   </td>
               </tr>
              
               <tr>
                   
                   <td>
                       <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
                       </td>
                       <td>
                           <asp:TextBox ID="password_txt" runat="server" TextMode="Password"></asp:TextBox>
                       </td>
                   <td>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="password_txt"></asp:RequiredFieldValidator>
                   </td>
                  
               </tr>
              
               <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Confirm Password:"></asp:Label>
                    </td>
              <td>
                   <asp:TextBox ID="confirm_password" runat="server" TextMode="Password"></asp:TextBox>
                   </td>
                   <td>
                       <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password and confirm password are  different" ControlToCompare="confirm_password" ControlToValidate="password_txt"></asp:CompareValidator>
                   </td>
                   <td>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="confirm_password"></asp:RequiredFieldValidator>
                   </td>
               </tr>

               <tr>
                   <td>
                       <asp:Label ID="Label4" runat="server" Text="First Name:"></asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="first_name_txt" runat="server"></asp:TextBox>
                   </td>
                   <td>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="first_name_txt"></asp:RequiredFieldValidator>
                   </td>
               </tr>
               
                <tr>
    <td>
        <asp:Label ID="Label5" runat="server" Text="Middle Name:"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="middle_name_txt" runat="server"></asp:TextBox>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="middle_name_txt"></asp:RequiredFieldValidator>
    </td>
</tr>
               
               <tr>
                   <td class="auto-style1">
                       <asp:Label ID="Label6" runat="server" Text="Last Name"></asp:Label>
                   </td>
                   <td class="auto-style1">
                       <asp:TextBox ID="last_name_txt" runat="server"></asp:TextBox>
                   </td>
                   <td class="auto-style1">
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="last_name_txt"></asp:RequiredFieldValidator>
                   </td>
               </tr>
               
               <tr>
                   <td>
                       <asp:Label ID="Label7" runat="server" Text="Mobile Number:"></asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="mobile_number_txt" runat="server"></asp:TextBox>
                   </td>
                   <td>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="mobile_number_txt"></asp:RequiredFieldValidator>
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label ID="Label12" runat="server" Text="Alternate Number:"></asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="ContactNumber_txt" runat="server"></asp:TextBox>
                   </td>
               </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label8" runat="server" Text="Email:"></asp:Label>
                  </td>
                  <td>
                      <asp:TextBox ID="email_txt" runat="server"></asp:TextBox>
                  </td>
                  <td>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="email_txt"></asp:RequiredFieldValidator>
                  </td>
              </tr>
                                       <tr>
                                           <td>Aadhar Number</td>
                                           <td>
                                               <asp:TextBox ID="AadharNumber_txt" runat="server"></asp:TextBox>

                                           </td>
                                           <td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="AadharNumber_txt"></asp:RequiredFieldValidator>
</td>
                                       </tr>
                                       <tr>
                                           <td>PAN Number</td>
                                           <td>
                                               <asp:TextBox ID="PANNumber_txt" runat="server"></asp:TextBox>

                                           </td>
                                           <td>
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="PANNumber_txt"></asp:RequiredFieldValidator>
    
</td>
                                       </tr>
               <tr>
                   <td>
                       <asp:Label ID="Label9" runat="server" Text="Address:"></asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="address_txt" runat="server" TextMode="MultiLine"></asp:TextBox>
                   </td>
                   <td>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="address_txt"></asp:RequiredFieldValidator>
                   </td>
               </tr>
<tr>
    <td>
        <asp:Label ID="Label14" runat="server" Text="Landmark:"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="LandMark_txt" runat="server" TextMode="MultiLine"></asp:TextBox>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="LandMark_txt"></asp:RequiredFieldValidator>
    </td>
</tr>
               <tr>
                   <td class="auto-style1">
                       <asp:Label ID="Label10" runat="server" Text="State:"></asp:Label>
                   </td>
                   
                   <td class="auto-style1">
                   <asp:DropDownList ID="State_ddl" runat="server" OnSelectedIndexChanged="State_ddl_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>    
                   </td>
                   <td class="auto-style1">
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="State_ddl"></asp:RequiredFieldValidator>
                   </td>
               </tr>
                                       <tr>
    <td>
        <asp:Label ID="Label15" runat="server" Text="District:"></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="District_ddl" runat="server"></asp:DropDownList>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="city_ddl"></asp:RequiredFieldValidator>
    </td>
</tr>
               <tr>
                   <td>
                       <asp:Label ID="Label11" runat="server" Text="City:"></asp:Label>
                   </td>
                   <td>
                       <asp:DropDownList ID="city_ddl" runat="server"></asp:DropDownList>
                   </td>
                   <td>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="city_ddl"></asp:RequiredFieldValidator>
                   </td>
               </tr>
                           <tr>
                               <td>
                                   <asp:Label ID="Label13" runat="server" Text="Refered by BA"></asp:Label>
                               </td>
                               <td>
                                   <asp:DropDownList ID="BusinessAss_ddl" runat="server"></asp:DropDownList>
                               </td>
                           </tr>
               <tr>
                   <td>
                       <asp:Button ID="register" runat="server" Text="Register" OnClick="register_Click" />
                   </td>
                   <td>
                       <asp:Label ID="result_lbl" runat="server" Text=""></asp:Label>
                       <asp:Label ID="BACode_lbl" runat="server" Text="Label"></asp:Label>
                   </td>
               </tr>
           </table>
        </div>
    </form>
</body>
</html>
