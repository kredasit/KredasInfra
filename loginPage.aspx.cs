using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KredasInfra_v2_28May2024
{
    public partial class loginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the login button was clicked
            if (IsPostBack)
            {
                ;
                // Get the username and password from the form
                string username = this.username.Value;
                string password = this.password.Value;

                // Check which checkboxes are checked
                string userType = "";
                if (LoginType_rbn.SelectedIndex == 0)
                {
                    userType = "Business Executive";
                }
                else if (LoginType_rbn.SelectedIndex == 1)
                {
                    userType = "Coordinator";
                }
                else if (LoginType_rbn.SelectedIndex == 2)
                {
                    userType = "Franchise Register";
                }

                // Query the database to check if the username, password, and user type match
                string connectionString = "Password=Kredas1@#;Persist Security Info=True;User ID=kredasInfra;Initial Catalog=kredaeqg_KredasInfra;Data Source=208.91.199.99";
                string query = "";

                // Determine the query based on the selected user type
                if (userType == "Coordinator")
                {
                    query = "SELECT * FROM kredasindia.CoordinatorDetails WHERE Username = @Username AND Password = @Password";
                }
                else if (userType == "Business Executive")
                {
                    query = "SELECT * FROM kredasindia.BussinessAssociatesDetails WHERE Username = @Username AND Password = @Password";
                }
                else if (userType == "Franchise Register")
                {
                    query = "SELECT * FROM kredasindia.FranchiseDetails WHERE Username = @Username AND Password = @Password";
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Login successful
                        string redirectUrl = "MyAccount.aspx?UserType=" + userType + "&Username=" + username;
                        Response.Redirect(redirectUrl);
                    }
                    else
                    {
                        // Login failed
                        // You can handle this by displaying an error message to the user
                        errorMessage.InnerText = "Invalid username or password. Please try again.";
                    }

                    reader.Close();
                }
            }
        }
    }
}