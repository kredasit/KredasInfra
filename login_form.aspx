<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login_form.aspx.cs" Inherits="login_form.login_form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form</title>
    <style>
        .login-form {
            width: 300px;
            margin: 150px auto;
            padding: 30px;
            background-color:#ffffff;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
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

        .login-form input[type="text"],
        .login-form input[type="password"] {
            width: 90%;
            padding: 10px;
            margin: 10px 0;
            border: 1px solid #ccc;
            border-radius: 5px;
            background-color:#f8f7f7;
        }

        .login-form input[type="checkbox"] {
            margin-right: 10px;
        }

        .login-form button {
            width: 100%;
            padding: 10px;
            background-color: #69598f;
            border: none;
            border-radius: 5px;
            color: white;
            font-size: 16px;
            cursor: pointer;
        }

        .login-form button:hover {
            background-color: #ffffff;
            color:#69598f;
            font-weight:900;
        }

        .login-form label {
            margin: 10px 0;
            display: block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-form">
            <h2>Login</h2>
            <label for="username">Username</label>
            <input type="text" id="username" runat="server" placeholder="Enter your username" />
            <label for="password">Password</label>
            <input type="password" id="password" runat="server" placeholder="Enter your password" />
            
            <asp:RadioButtonList ID="LoginType_rbn" runat="server">
                <asp:ListItem>Business Executive</asp:ListItem>
                <asp:ListItem>Coordinator</asp:ListItem>
                <asp:ListItem>Franchise</asp:ListItem>
                <asp:ListItem>Portal User</asp:ListItem>
            </asp:RadioButtonList>
                  
            <button type="submit">Login</button>
            <asp:Label ID="error_lbl" runat="server" Text="Label"></asp:Label>
            

        </div>
    </form>
</body>
</html>
