using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using KredasInfra_v2_28May2024.Common;

namespace KredasInfra_v2_28May2024
{
    public partial class FranchiseRegistration : System.Web.UI.Page
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
                        Area_ddl.Items.Clear();
                        Area_ddl.Items.Add("Slect a Area");
                        dt1 = ds1.Tables[0];
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            Area_ddl.Items.Add(dt1.Rows[i][1].ToString());


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


        public bool IsEnteredAreaAlreadyExists(string EnteredArea)
        {
            bool Exists = false;

            SqlConnection sqlCon = new SqlConnection();

#pragma warning disable CS0168 // Variable is declared but never used
            try
            {
                sqlCon.ConnectionString = SqlCon_str;

                SqlCommand cmd = new SqlCommand(SqlCon_str, sqlCon);
                cmd.CommandText = SQlStrings.GET_AREA_DETAILS_BYNAME + "'" + (Area_txt.Text) + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, sqlCon);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();

                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        Exists = true;
                    }
                    else
                    {
                        Exists = false;

                    }
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlCon.Close();
            }
#pragma warning restore CS0168 // Variable is declared but never used

            return Exists;
        }

        public bool IsEnteredCityAlreadyExists(string EnteredCity)
        {
            bool Exists = false;

            SqlConnection sqlCon = new SqlConnection();

#pragma warning disable CS0168 // Variable is declared but never used
            try
            {
                sqlCon.ConnectionString = SqlCon_str;

                SqlCommand cmd = new SqlCommand(SqlCon_str, sqlCon);
                cmd.CommandText = SQlStrings.GET_AREA_DETAILS_BYNAME + "'" + (Area_txt.Text) + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, sqlCon);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();

                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        Exists = true;
                    }
                    else
                    {
                        Exists = false;

                    }
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlCon.Close();
            }
#pragma warning restore CS0168 // Variable is declared but never used

            return Exists;
        }

        public void InsertNewCity(string EnteredCity)
        {
            SqlConnection conn = new SqlConnection();
#pragma warning disable CS0168 // Variable is declared but never used
            try
            {

                conn.ConnectionString = SqlCon_str;
                DateTime dt = DateTime.Now;

                int StateID = GetStateIDByName(State_ddl.SelectedItem.ToString());
                int DistrictID = GetDistrictIDByName(city_ddl.SelectedItem.ToString());

                SqlCommand cmd = new SqlCommand(SqlCon_str, conn);
                cmd.CommandText = SQlStrings.CITY_INSERT_QUERY;
                conn.Open();
                int CityID = GetCityIDByName(city_ddl.SelectedValue);


                cmd.Parameters.AddWithValue("@CityName", EnteredCity);
                cmd.Parameters.AddWithValue("@StateID", StateID);

                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
#pragma warning restore CS0168 // Variable is declared but never used
        }
        public void InsertNewArea(string EnteredArea)
        {
            SqlConnection conn = new SqlConnection();
#pragma warning disable CS0168 // Variable is declared but never used
            try
            {

                conn.ConnectionString = SqlCon_str;
                DateTime dt = DateTime.Now;

                int StateID = GetStateIDByName(State_ddl.SelectedItem.ToString());
                int DistrictID = GetDistrictIDByName(city_ddl.SelectedItem.ToString());

                SqlCommand cmd = new SqlCommand(SqlCon_str, conn);
                cmd.CommandText = SQlStrings.AREA_INSERT_QUERY;
                conn.Open();
                int CityID = GetCityIDByName(city_ddl.SelectedValue);


                cmd.Parameters.AddWithValue("@AreaName", EnteredArea);
                cmd.Parameters.AddWithValue("@CityID", CityID);
                cmd.Parameters.AddWithValue("@DistrictID", 99);// 99 for Unknown district, since new city being added by user
                cmd.Parameters.AddWithValue("@StateID", StateID);

                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
#pragma warning restore CS0168 // Variable is declared but never used
        }

        public int GetAreaIDByName(string Name)
        {
            int ID = 0;

            SqlConnection conn = new SqlConnection();


#pragma warning disable CS0168 // Variable is declared but never used
            try
            {
                conn.ConnectionString = SqlCon_str;

                SqlCommand cmd = new SqlCommand(SqlCon_str, conn);
                cmd.CommandText = SQlStrings.AREA_ID_BY_NAME + "'" + (Name) + "'";
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
#pragma warning restore CS0168 // Variable is declared but never used




            return ID;
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
#pragma warning restore CS0168 // Variable is declared but never used




            return ID;
        }

        /// <summary>
        /// used to clear all the fields after successful registration
        /// </summary>
        /// <param name="name"></param>
        public void ClearFields(string name)
        {
            Name_txt.Text = string.Empty;
            mobNumber_txt.Text = string.Empty;
            email_txt.Text = string.Empty;
            AltContactNumber_txt.Text = string.Empty;
            State_ddl.SelectedIndex = 0;
            city_ddl.SelectedIndex = 0;
            Address_txt.Text = string.Empty;
            LandMark_txt.Text = string.Empty;

            result_lbl.Text = string.Empty;
        }

        public byte[] GetBytes()
        {
            String Filename = Path.GetFileName(FileUpload1.PostedFile.FileName);

            String ContentType = FileUpload1.PostedFile.ContentType;

            using (Stream fs = FileUpload1.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    return bytes;
                }
            }

        }

        protected void FranchiseType_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FranchiseType_ddl.SelectedIndex == 0)
            {
                // NONE SELECTED

            }
            else if (FranchiseType_ddl.SelectedIndex == 1)
            {
                //selected district type franchise
                DistrictRow.Visible = false;
                CityRow.Visible = false;
                AreaRow.Visible = false;
                OtherCityRow.Visible = false;
            }
            else if (FranchiseType_ddl.SelectedIndex == 2)
            {
                //selected City type franchise
                DistrictRow.Visible = true;
                CityRow.Visible = true;
                AreaRow.Visible = true;
            }            
        }

        protected void State_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SqlCon_str;

            
            int StateID = GetStateIDByName(State_ddl.SelectedItem.ToString());
            string DistrictsSelectQuery = String.Format(SQlStrings.CITY_LIST_SELECT_QUERY, StateID);



            #region Fill Districts drop down list
            SqlCommand cmd1 = new SqlCommand(SqlCon_str, conn);
            cmd1.CommandText = SQlStrings.DISTRICT_LIST_SELECT_QUERY + "'" + (StateID) + "'";
            //cmd.CommandText = DistrictsSelectQuery;
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
            SqlCommand cmd = new SqlCommand(SqlCon_str, conn);
            //cmd.CommandText = SQlStrings.CITY_LIST_SELECT_QUERY + "'" + (StateID) + "'";
            cmd.CommandText = DistrictsSelectQuery;
            SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            SqlCommand cmd2 = new SqlCommand(SqlCon_str, conn);
            //cmd.CommandText = SQlStrings.CITY_LIST_SELECT_QUERY + "'" + (StateID) + "'";
            cmd2.CommandText = DistrictsSelectQuery;
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
        }
        #endregion

        protected void city_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(city_ddl.SelectedItem.Value == "Other")
            {
                OtherCityRow.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();

            try
            {
                #region Check If Area Frachise is selected, Check and insert the entered Area name into Database if it does not exist Already
                if (FranchiseType_ddl.SelectedIndex == 4)
                {
                    if (Area_txt.Text == string.Empty)
                    {
                        result_lbl.Text = "Please Enter Area";
                    }
                    else
                    {
                        if (State_ddl.SelectedIndex == 0)
                        {
                            result_lbl.Text = "Please select State and City";

                        }
                        else if (city_ddl.SelectedIndex == 0)
                        {
                            result_lbl.Text = "Please select State and City";
                        }
                        else
                        {
                            InsertNewArea(Area_txt.Text);
                        }

                    }
                }

                if (!IsEnteredAreaAlreadyExists(Area_txt.Text))
                {

                }


                #endregion
                //SqlConnection conn = new SqlConnection();
                conn.ConnectionString = SqlCon_str;
                DateTime dt = DateTime.Now;

                int StateID = GetStateIDByName(State_ddl.SelectedItem.ToString());
                int DistrictID = GetDistrictIDByName(District_ddl.SelectedItem.ToString());

                int CityID = GetCityIDByName(OtherCity_txt.Text);

                SqlCommand cmd = new SqlCommand(SqlCon_str, conn);
                cmd.CommandText = SQlStrings.FRANCHISE_INSERT_QUERY;
                Byte[] bytes = GetBytes();
                String ContentType = FileUpload1.PostedFile.ContentType;
                string FranchiseInsertComd = String.Format(SQlStrings.FRANCHISE_INSERT_QUERY, UsrName_txt.Text, Password_txt.Text, Name_txt.Text, mobNumber_txt.Text, email_txt.Text, AltContactNumber_txt.Text, StateID, DistrictID, CityID, Address_txt.Text, LandMark_txt.Text, bytes, ContentType, 0, dt.ToString(), FranchiseType_ddl.SelectedIndex);

                //cmd.CommandText = "INSERT INTO Kredasindia.FranchiseDetails(UserName,Password,Name,MobileNumber,Email,AlternateContactNumber,StateID,DistrictID,CityID,Address,Landmark,PaymentInfo,ContentType,IsActive,RegDate,FranchiseType)values ("+"'"UsrName_txt.Text+"'"+","+Password_txt.Text+","+Name_txt.Text+","+mobNumber_txt.Text+","+email_txt.Text+","+AltContactNumber_txt+","+ StateID + ","+ DistrictID + ","+ CityID + ","+Address_txt.Text+","+Landmark_txt.Text+","+ bytes + ","+ ContentType + ","'0'","'getdate()'","'Area'")";
                cmd.CommandText = SQlStrings.FRANCHISE_INSERT_QUERY;
                conn.Open();
                
                //String ContentType = FileUpload1.PostedFile.ContentType;
                cmd.Parameters.Clear();
                //cmd.Parameters.Add(new SqlParameter("@name",SqlDbType.VarChar,50)).Value = Name_txt.Text;
                cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar, 50)).Value = UsrName_txt.Text;
                cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 50)).Value = Password_txt.Text;
                cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 50)).Value = Name_txt.Text;
                cmd.Parameters.Add(new SqlParameter("@MobileNumber", SqlDbType.VarChar, 15)).Value = mobNumber_txt.Text; // Assuming max length 15 for mobile number
                cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 100)).Value = email_txt.Text; // Assuming max length 100 for email
                cmd.Parameters.Add(new SqlParameter("@AlternateContactNumber", SqlDbType.VarChar, 15)).Value = AltContactNumber_txt.Text; // Assuming max length 15
                cmd.Parameters.Add(new SqlParameter("@StateID", SqlDbType.Int)).Value = StateID;
                cmd.Parameters.Add(new SqlParameter("@DistrictID", SqlDbType.Int)).Value = DistrictID;
                cmd.Parameters.Add(new SqlParameter("@CityID", SqlDbType.Int)).Value = CityID;
                cmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar, 250)).Value = Address_txt.Text; // Assuming max length 250 for address
                cmd.Parameters.Add(new SqlParameter("@Landmark", SqlDbType.VarChar, 100)).Value = LandMark_txt.Text; // Assuming max length 100 for landmark
                cmd.Parameters.Add(new SqlParameter("@PaymentInfo", SqlDbType.VarBinary)).Value = bytes; // Assuming binary data for payment info
                cmd.Parameters.Add(new SqlParameter("@ContentType", SqlDbType.VarChar, 50)).Value = ContentType; // Assuming max length 50 for content type
                cmd.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit)).Value = 0; // Boolean flag for IsActive
                cmd.Parameters.Add(new SqlParameter("@RegDate", SqlDbType.DateTime)).Value = DateTime.Now; // Using current date and time for registration date
                cmd.Parameters.Add(new SqlParameter("@FranchiseType", SqlDbType.Int)).Value = FranchiseType_ddl.SelectedIndex + 1;


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

        protected void GetImage_Click(object sender, EventArgs e)
        {

        }

        protected void District_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            try
            {


                conn.ConnectionString = SqlCon_str;

                int DistrictID = GetDistrictIDByName(District_ddl.SelectedValue);

                string AreaListByDistrictID_Query = String.Format(SQlStrings.AREAS_LIST_BY_DISTRICT_SELECT_QUERY, DistrictID);

                SqlCommand cmd1 = new SqlCommand(SqlCon_str, conn);
                cmd1.CommandText = AreaListByDistrictID_Query;
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1.CommandText, conn);
                DataTable dt1 = new DataTable();
                DataSet ds1 = new DataSet();
                conn.Open();
                da1.Fill(ds1, "Areas");

                if (ds1.Tables.Count > 0)
                {
                    Area_ddl.Items.Clear();
                    Area_ddl.Items.Add("Slect a Area");
                    dt1 = ds1.Tables[0];
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        Area_ddl.Items.Add(dt1.Rows[i][1].ToString());


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
        }
    }
}