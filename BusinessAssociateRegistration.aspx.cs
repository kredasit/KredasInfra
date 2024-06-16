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
    public partial class BusinessAssociateRegistration : System.Web.UI.Page
    {

        public string SqlCon_str = "Password=Kredas1@#;Persist Security Info=True;User ID=kredasInfra;Initial Catalog=kredaeqg_KredasInfra;Data Source=208.91.199.99";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int BAMaxNumber = GetMaxNumberOfBA();
                string CurrentBACode = GenerateCurrentBACode(BAMaxNumber);

                BACode_lbl.Text = CurrentBACode;
                BACode_lbl.Visible = false;

                #region Fill BA dropdown
                SqlConnection conn = new SqlConnection();

                conn.ConnectionString = SqlCon_str;

                SqlCommand cmd = new SqlCommand(SqlCon_str, conn);
                cmd.CommandText = SQlStrings.GET_BA_DETAILS;
                SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();

                da.Fill(ds);

                if(ds.Tables.Count>0)
                {
                    dt = ds.Tables[0];

                    if(dt.Rows.Count>0)
                    {
                        BusinessAss_ddl.Items.Clear();
                        for(int i=0;i< dt.Rows.Count;i++)
                        {
                            BusinessAss_ddl.Items.Add(dt.Rows[i][1].ToString());
                        }
                        
                    }
                }

                #endregion
                SqlConnection conn1 = new SqlConnection();
                conn1.ConnectionString = SqlCon_str;
                #region Fill States into States dropdown
                try
                {
                    

                    SqlCommand cmd1 = new SqlCommand(SqlCon_str, conn1);
                    cmd.CommandText = SQlStrings.STATE_LIST_SELECT_QUERY;
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd.CommandText, conn1);
                    DataTable dt1 = new DataTable();
                    DataSet ds1 = new DataSet();
                    conn1.Open();
                    da1.Fill(ds1, "States");

                    if (ds1.Tables.Count > 0)
                    {
                        State_ddl.Items.Clear();
                        State_ddl.Items.Add("Slect a State");
                        dt1 = ds1.Tables[0];
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            State_ddl.Items.Add(dt1.Rows[i][1].ToString());


                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn1.Close();
                }
                #endregion
            }
        }

        protected void register_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SqlCon_str;
            DateTime dt = DateTime.Now;
            try
            { 
            

            int StateID = GetStateIDByName(State_ddl.SelectedItem.ToString());

            int CityID = GetCityIDByName(city_ddl.SelectedValue);


            SqlCommand cmd = new SqlCommand(SqlCon_str, conn);
            //cmd.CommandText = SQlStrings.FRANCHISE_INSERT_QUERY;
            //Byte[] bytes = GetBytes();
            //String ContentType = FileUpload1.PostedFile.ContentType;
            //string FranchiseInsertComd = String.Format(SQlStrings.FRANCHISE_INSERT_QUERY, UsrName_txt.Text, Password_txt.Text, Name_txt.Text, mobNumber_txt.Text, email_txt.Text, AltContactNumber_txt.Text, StateID, DistrictID, CityID, Address_txt.Text, Landmark_txt.Text, bytes, ContentType, 0, dt.ToString(), FranchiseType_ddl.SelectedIndex);

            //cmd.CommandText = "INSERT INTO Kredasindia.FranchiseDetails(UserName,Password,Name,MobileNumber,Email,AlternateContactNumber,StateID,DistrictID,CityID,Address,Landmark,PaymentInfo,ContentType,IsActive,RegDate,FranchiseType)values ("+"'"UsrName_txt.Text+"'"+","+Password_txt.Text+","+Name_txt.Text+","+mobNumber_txt.Text+","+email_txt.Text+","+AltContactNumber_txt+","+ StateID + ","+ DistrictID + ","+ CityID + ","+Address_txt.Text+","+Landmark_txt.Text+","+ bytes + ","+ ContentType + ","'0'","'getdate()'","'Area'")";
            cmd.CommandText = SQlStrings.BA_INSERT_QUERY;
            conn.Open();

            //String ContentType = FileUpload1.PostedFile.ContentType;
            cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@BACode", SqlDbType.VarChar, 50)).Value = BusinessAss_ddl.SelectedValue;
                //cmd.Parameters.Add(new SqlParameter("@name",SqlDbType.VarChar,50)).Value = Name_txt.Text;
                cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar, 50)).Value = username_txt.Text;
            cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 50)).Value = password_txt.Text;
                cmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.VarChar, 50)).Value = first_name_txt.Text;
                cmd.Parameters.Add(new SqlParameter("@MiddleName", SqlDbType.VarChar, 50)).Value = middle_name_txt.Text;
                cmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.VarChar, 50)).Value = last_name_txt.Text;
            cmd.Parameters.Add(new SqlParameter("@MobileNumber", SqlDbType.VarChar, 15)).Value = mobile_number_txt.Text; // Assuming max length 15 for mobile number
            cmd.Parameters.Add(new SqlParameter("@ContactNumber", SqlDbType.VarChar, 15)).Value = ContactNumber_txt.Text; // Assuming max length 15
                cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 100)).Value = email_txt.Text; // Assuming max length 100 for email
                cmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar, 250)).Value = address_txt.Text; // Assuming max length 250 for address
                cmd.Parameters.Add(new SqlParameter("@StateID", SqlDbType.Int)).Value = StateID;            
            cmd.Parameters.Add(new SqlParameter("@CityID", SqlDbType.Int)).Value = CityID;
                cmd.Parameters.Add(new SqlParameter("@ReferedByCode", SqlDbType.NVarChar)).Value = "testID";                

                cmd.Parameters.Add(new SqlParameter("@LandMark", SqlDbType.VarChar, 100)).Value = LandMark_txt.Text; 
            cmd.Parameters.Add(new SqlParameter("@RegDate", SqlDbType.DateTime)).Value = DateTime.Now; // Using current date and time for registration date
                cmd.Parameters.Add(new SqlParameter("@AadharNumber", SqlDbType.VarChar, 100)).Value = AadharNumber_txt.Text;
                cmd.Parameters.Add(new SqlParameter("@PANNumber", SqlDbType.VarChar, 100)).Value = PANNumber_txt.Text;


                cmd.ExecuteNonQuery();
                

            result_lbl.Text = "Registration Successful";
            result_lbl.ForeColor = System.Drawing.Color.Green;
            ClearFields("test");

        }
            catch (Exception ex)
            {
                result_lbl.Text = "Registration failed, please contact support";
                result_lbl.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                conn.Close();
            }
        }

public void ClearFields(string name)
{
            username_txt.Text = string.Empty;
            mobile_number_txt.Text = string.Empty;
    email_txt.Text = string.Empty;
            ContactNumber_txt.Text = string.Empty;
    State_ddl.SelectedIndex = 0;
    city_ddl.SelectedIndex = 0;
            address_txt.Text = string.Empty;
            LandMark_txt.Text = string.Empty;

    result_lbl.Text = string.Empty;
}

public int GetMaxNumberOfBA()
        {
            int maxNum = 0;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SqlCon_str;

            SqlCommand cmd = new SqlCommand(SqlCon_str, conn);
            cmd.CommandText = SQlStrings.SELECT_BADETAILS_COUNT;
            SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            conn.Open();
            int ID = 0;
            da.Fill(ds,"BADetails");

            if(ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                if(dt.Rows.Count > 0)
                {
                    ID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                    maxNum = ID + 1;
                }
                else
                { maxNum = maxNum + 1; 
                }
            }
            else
            {
                maxNum = ID +1;
            }

            return maxNum;
        }

        public string GenerateCurrentBACode(int ID)
        {
            string BACode = string.Empty;

            int MaxBANumber = GetMaxNumberOfBA();
            string BACodePrefix = "KREDA-";
            //string EmpCode = 
            string NumberToPad = MaxBANumber.ToString();
            string NumericPart = NumberToPad.PadLeft(4, '0');

            string CurrentBACode = BACodePrefix + NumericPart;


            return CurrentBACode;
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

        public int GetCityIDByName(string name)
        {

            int ID = 0;

            SqlConnection conn = new SqlConnection();


            try
            {
                conn.ConnectionString = SqlCon_str;

                SqlCommand cmd = new SqlCommand(SqlCon_str, conn);
                cmd.CommandText = SQlStrings.CITY_ID_BY_NAME + "'" + (city_ddl.SelectedValue) + "'";
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

        protected void State_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SqlCon_str;



            int StateID = GetStateIDByName(State_ddl.SelectedItem.ToString());
            string DistrictsSelectQuery = String.Format(SQlStrings.DISTRICT_LIST_SELECT_QUERY, StateID);

            #region Fill Districts drop down list
            SqlCommand cmd1 = new SqlCommand(SqlCon_str, conn);
            SqlCommand cmd = new SqlCommand(SqlCon_str, conn);
            cmd1.CommandText = DistrictsSelectQuery;
            cmd1.CommandText = DistrictsSelectQuery;
            cmd.CommandText = DistrictsSelectQuery;
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1.CommandText, conn);
            DataTable dt1 = new DataTable();
            DataSet ds1 = new DataSet();


            try
            {

                conn.Open();
                da1.Fill(ds1, "Districts");

                if (ds1.Tables.Count > 0)
                {
                    District_ddl.Items.Clear();
                    District_ddl.Items.Add("Slect a District");
                    dt1 = ds1.Tables[0];
                    for (int i = 0; i <= dt1.Rows.Count; i++)
                    {
                        District_ddl.Items.Add(dt1.Rows[i][1].ToString());
                    }
                    District_ddl.Items.Add("Other");
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

            #region Fillup City drop down list
            SqlCommand cmd3 = new SqlCommand(SqlCon_str, conn);
            string CitySelectQuery = String.Format(SQlStrings.CITY_LIST_SELECT_QUERY, StateID);
            cmd3.CommandText = CitySelectQuery;
            //cmd.CommandText = CitySelectQuery;
            SqlDataAdapter da = new SqlDataAdapter(cmd3.CommandText, conn);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            SqlCommand cmd2 = new SqlCommand(SqlCon_str, conn);
            cmd2.CommandText = CitySelectQuery;
            //cmd.CommandText = DistrictsSelectQuery;
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2.CommandText, conn);
            DataTable dt2 = new DataTable();
            DataSet ds2 = new DataSet();

            try
            {

                conn.Open();
                da.Fill(ds2, "City");

                if (ds2.Tables.Count > 0)
                {
                    city_ddl.Items.Clear();
                    city_ddl.Items.Add("Slect a City");
                    dt2 = ds2.Tables[0];
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        city_ddl.Items.Add(dt2.Rows[i][1].ToString());
                    }
                    city_ddl.Items.Add("Other");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            #endregion
        }
    }
}