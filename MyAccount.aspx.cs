using KredasInfra_v2_28May2024.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using KredasInfra_v2_28May2024.Common;

namespace KredasInfra_v2_28May2024
{
    
    public partial class MyAccount : System.Web.UI.Page
    {
     public string SqlCon_str = "Password=Kredas1@#;Persist Security Info=True;User ID=kredasInfra;Initial Catalog=kredaeqg_KredasInfra;Data Source=208.91.199.99";
        public int UserType = 0;
        public string UserName = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            string UserType = Request.QueryString["UserType"];
            string UserName = Request.QueryString["UserName"];

            if(! IsPostBack )
            {
                string sqlQuery = string.Empty;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SqlCon_str;
                #region   Fill All UserDetails

                if (UserType == "Coordinator")
                {
                    sqlQuery = SQlStrings.FETCH_COORDINATOR_DETAILS_QUERY;
                }
                else if (UserType == "Business Executive")
                {
                    sqlQuery = SQlStrings.FETCH_BUSUNESSREPRESENTATIVE_DETAILS_QUERY;
                }
                else if (UserType == "Franchise Register")
                {
                    sqlQuery = SQlStrings.FETCH_FRANCHISE_DETAILS_QUERY +"'" + UserName +"'";
                }
                
                SqlCommand cmd = new SqlCommand(SqlCon_str, conn);
                cmd.CommandText = sqlQuery;
                SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();

                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        //string Name = dt.Rows[0]["FirstName"].ToString();
                        //Name = Name + " " + dt.Rows[0]["MiddleName"].ToString();
                        //Name = Name + " " + dt.Rows[0]["LastName"].ToString();                        

                        FirstName_lbl.Text = dt.Rows[0]["Name"].ToString();
                        //middleName_lbl.Text = dt.Rows[0]["MiddleName"].ToString();
                        //lastName_lbl.Text = dt.Rows[0]["LastName"].ToString();
                        mobileNumber_lbl.Text = dt.Rows[0]["MobileNumber"].ToString();
                        email_lbl.Text = dt.Rows[0]["Email"].ToString();
                        Address_lbl.Text = dt.Rows[0]["Address"].ToString();
                        landmark_lbl.Text = dt.Rows[0]["Landmark"].ToString();
                        //Aadhar_lbl.Text = dt.Rows[0]["AadharNumber"].ToString();
                        //PanNumber_lbl.Text = dt.Rows[0]["PANNumber"].ToString();
                    }
                }

                #endregion
            }

        }

        public String GetStateNameByID(int ID )
        {

            string StateName = string.Empty;

            SqlConnection conn = new SqlConnection();



            try
            {
                conn.ConnectionString = SqlCon_str;

                SqlCommand cmd = new SqlCommand(SqlCon_str, conn);
                cmd.CommandText = SQlStrings.STATE_ID_BY_NAME + "'" + (ID) + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();

                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        ID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                    }
                }

                return StateName;
            }

            catch (Exception ex)
            {

            }
            finally
            {

            }



            return StateName;
        }

        public string GetCityNameByID(int ID)
        {

            string Name = string.Empty;

            SqlConnection conn = new SqlConnection();


            try
            {
                conn.ConnectionString = SqlCon_str;

                SqlCommand cmd = new SqlCommand(SqlCon_str, conn);
                cmd.CommandText = SQlStrings.CITY_ID_BY_NAME + "'" + ID + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();

                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        Name = dt.Rows[0]["ID"].ToString();
                    }
                    return Name;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }





            return Name;
        }


        public string GetDistrictNameByID(int ID)
        {
            string Name = string.Empty;

            SqlConnection conn = new SqlConnection();


#pragma warning disable CS0168 // Variable is declared but never used
            try
            {
                conn.ConnectionString = SqlCon_str;

                SqlCommand cmd = new SqlCommand(SqlCon_str, conn);
                cmd.CommandText = SQlStrings.DISTRICT_ID_BY_NAME + "'" + ID + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();

                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        Name = dt.Rows[0]["ID"].ToString();
                    }
                }
                return Name;
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

            return Name;
        }
    }


    
}