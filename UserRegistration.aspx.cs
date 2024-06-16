using KredasInfra_v2_28May2024.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KredasInfra_v2_28May2024
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        public string SqlCon_str = "Password=Kredas1@#;Persist Security Info=True;User ID=kredasInfra;Initial Catalog=kredaeqg_KredasInfra;Data Source=208.91.199.99";
        protected void Page_Load(object sender, EventArgs e)
        {
            result_lbl.Text = string.Empty;
            if (!IsPostBack == true)
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SqlCon_str;

                SqlCommand cmd = new SqlCommand(SqlCon_str, conn);
                cmd.CommandText = SQlStrings.STATE_LIST_SELECT_QUERY;
                SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();

                #region Fill States into States dropdown
                try
                {

                    conn.Open();
                    da.Fill(ds, "States");

                    if (ds.Tables.Count > 0)
                    {
                        State_ddl.Items.Clear();
                        State_ddl.Items.Add("Slect a State");
                        dt = ds.Tables[0];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            State_ddl.Items.Add(dt.Rows[i][1].ToString());


                        }

                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    conn.Close();
                }
                #endregion

                #region Fill the districts list into districts drop down control
                try
                {


                    conn.ConnectionString = SqlCon_str;

                    SqlCommand cmd1 = new SqlCommand(SqlCon_str, conn);
                    cmd1.CommandText = SQlStrings.DISTRICTS_LIST_SELECT_QUERY;
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1.CommandText, conn);
                    DataTable dt1 = new DataTable();
                    DataSet ds1 = new DataSet();
                    conn.Open();
                    da1.Fill(ds1, "Districts");

                    if (ds1.Tables.Count > 0)
                    {
                        District_ddl.Items.Clear();
                        District_ddl.Items.Add("Slect a District");
                        dt1 = ds1.Tables[0];
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            District_ddl.Items.Add(dt1.Rows[i][1].ToString());


                        }

                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    conn.Close();
                }
                #endregion

                #region Fill the Areas list into Areas drop down control
                try
                {


                    conn.ConnectionString = SqlCon_str;

                    SqlCommand cmd1 = new SqlCommand(SqlCon_str, conn);
                    cmd1.CommandText = SQlStrings.AREAS_LIST_BY_DISTRICT_SELECT_QUERY;
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1.CommandText, conn);
                    DataTable dt1 = new DataTable();
                    DataSet ds1 = new DataSet();
                    conn.Open();
                    da1.Fill(ds1, "Areas");

                    if (ds1.Tables.Count > 0)
                    {
                        //Area_ddl.Items.Clear();
                        //Area_ddl.Items.Add("Slect a Area");
                        dt1 = ds1.Tables[0];
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            //Area_ddl.Items.Add(dt1.Rows[i][1].ToString());


                        }

                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    conn.Close();
                }
                #endregion

            }
        }

        public int GetStateIDByName(string name)
        {

            int ID = 0;

            SqlConnection conn = new SqlConnection();

            try
            {
                conn.ConnectionString = SqlCon_str;

                SqlCommand cmd = new SqlCommand(SqlCon_str, conn);
                cmd.CommandText = SQlStrings.STATE_ID_BY_NAME + "'" + (State_ddl.SelectedValue) + "'";
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
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }



            return ID;
        }


        public int GetDistrictIDByName(string name)
        {
            int ID = 0;

            SqlConnection conn = new SqlConnection();


#pragma warning disable CS0168 // Variable is declared but never used
            try
            {
                conn.ConnectionString = SqlCon_str;

                SqlCommand cmd = new SqlCommand(SqlCon_str, conn);
                cmd.CommandText = SQlStrings.DISTRICT_ID_BY_NAME + "'" + (city_ddl.SelectedValue) + "'";
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
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }





            return ID;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}