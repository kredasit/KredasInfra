using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KredasInfra_v2_28May2024.Common;

namespace KredasInfra_v2_28May2024
{
    public partial class CoordinatorRegistration : System.Web.UI.Page
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
                        //State_ddl.Items.Clear();
                        //State_ddl.Items.Add("Slect a State");
                        dt = ds.Tables[0];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //State_ddl.Items.Add(dt.Rows[i][1].ToString());


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
                        //District_ddl.Items.Clear();
                        //District_ddl.Items.Add("Slect a District");
                        dt1 = ds1.Tables[0];
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            //District_ddl.Items.Add(dt1.Rows[i][1].ToString());


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


                #region Fill the Cities list into Cities drop down control
                try
                {


                    conn.ConnectionString = SqlCon_str;

                    SqlCommand cmd1 = new SqlCommand(SqlCon_str, conn);

                    //string StateID = GetStateIDByName(State_ddl.Text);
                    string CitiesByStateIDQuery = String.Format(SQlStrings.CITIES_LIST_SELECT_QUERY, "1");
                    cmd1.CommandText = CitiesByStateIDQuery;
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1.CommandText, conn);
                    DataTable dt1 = new DataTable();
                    DataSet ds1 = new DataSet();
                    conn.Open();
                    da1.Fill(ds1, "Cities");

                    if (ds1.Tables.Count > 0)
                    {
                        //city_ddl.Items.Clear();
                        //city_ddl.Items.Add("Slect a City");
                        dt1 = ds1.Tables[0];
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            //city_ddl.Items.Add(dt1.Rows[i][1].ToString());


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

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SqlCon_str;
            DateTime dt = DateTime.Now;
            try
            {
                
                //int StateID = GetStateIDByName(State_ddl.SelectedItem.ToString());

                //int CityID = GetCityIDByName(city_ddl.SelectedValue);
                //int DistrictID = GetDistrictIDByName(District_ddl.SelectedValue);




                SqlCommand cmd = new SqlCommand(SqlCon_str, conn);
                cmd.CommandText = SQlStrings.COORDINATOR_INSERT_QUERY;
                //Byte[] bytes = GetBytes();
                //String ContentType = FileUpload1.PostedFile.ContentType;
                //string FranchiseInsertComd = String.Format(SQlStrings.FRANCHISE_INSERT_QUERY, UsrName_txt.Text, Password_txt.Text, Name_txt.Text, mobNumber_txt.Text, email_txt.Text, AltContactNumber_txt.Text, StateID, DistrictID, CityID, Address_txt.Text, Landmark_txt.Text, bytes, ContentType, 0, dt.ToString(), FranchiseType_ddl.SelectedIndex);

                //cmd.CommandText = "INSERT INTO Kredasindia.FranchiseDetails(UserName,Password,Name,MobileNumber,Email,AlternateContactNumber,StateID,DistrictID,CityID,Address,Landmark,PaymentInfo,ContentType,IsActive,RegDate,FranchiseType)values ("+"'"UsrName_txt.Text+"'"+","+Password_txt.Text+","+Name_txt.Text+","+mobNumber_txt.Text+","+email_txt.Text+","+AltContactNumber_txt+","+ StateID + ","+ DistrictID + ","+ CityID + ","+Address_txt.Text+","+Landmark_txt.Text+","+ bytes + ","+ ContentType + ","'0'","'getdate()'","'Area'")";
                cmd.CommandText = SQlStrings.COORDINATOR_INSERT_QUERY;
                conn.Open();
                string CoordinatorName = first_name_txt.Text + " " + middle_name_txt.Text + "" + last_name_txt.Text;
                //String ContentType = FileUpload1.PostedFile.ContentType;
                cmd.Parameters.Clear();
                //cmd.Parameters.Add(new SqlParameter("@BACode", SqlDbType.VarChar, 50)).Value = BusinessAss_ddl.SelectedValue;
                cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 50)).Value = CoordinatorName;
                cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar, 50)).Value = UsrName_txt.Text;
                cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 50)).Value = Password_txt.Text;
                cmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.VarChar, 50)).Value = first_name_txt.Text;
                cmd.Parameters.Add(new SqlParameter("@MiddleName", SqlDbType.VarChar, 50)).Value = middle_name_txt.Text;
                cmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.VarChar, 50)).Value = last_name_txt.Text;
                cmd.Parameters.Add(new SqlParameter("@MobileNumber", SqlDbType.VarChar, 15)).Value = mobile_number_txt.Text; // Assuming max length 15 for mobile number
                cmd.Parameters.Add(new SqlParameter("@ContactNumber", SqlDbType.VarChar, 15)).Value = AltContactNumber_txt.Text;// Assuming max length 15
                cmd.Parameters.Add(new SqlParameter("@AadharNumber", SqlDbType.VarChar, 15)).Value = AadharNumber_txt.Text;
                cmd.Parameters.Add(new SqlParameter("@PanNumber", SqlDbType.VarChar, 15)).Value = PanNumber_txt.Text;
                cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 100)).Value = email_txt.Text; // Assuming max length 100 for email
                cmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar, 250)).Value = address_txt.Text; // Assuming max length 250 for address
                //cmd.Parameters.Add(new SqlParameter("@StateID", SqlDbType.Int)).Value = StateID;
                //cmd.Parameters.Add(new SqlParameter("@DistrictID", SqlDbType.Int)).Value = DistrictID;
                //cmd.Parameters.Add(new SqlParameter("@CityID", SqlDbType.Int)).Value = CityID;
                cmd.Parameters.Add(new SqlParameter("@AreaCode", SqlDbType.NVarChar)).Value = Area_txt.Text;
                //cmd.Parameters.Add(new SqlParameter("@ReferedByCode", SqlDbType.NVarChar)).Value = "testID";
                
                cmd.Parameters.Add(new SqlParameter("@LandMark", SqlDbType.VarChar, 100)).Value = LandMark_txt.Text;
                cmd.Parameters.Add(new SqlParameter("@RegDate", SqlDbType.DateTime)).Value = DateTime.Now; // Using current date and time for registration date
                //cmd.Parameters.Add(new SqlParameter("@AadharNumber", SqlDbType.VarChar, 100)).Value = AadharNumber_txt.Text;
                //cmd.Parameters.Add(new SqlParameter("@PANNumber", SqlDbType.VarChar, 100)).Value = PANNumber_txt.Text;


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

        public void ClearFields(string name)
        {
            UsrName_txt.Text = string.Empty;
            mobile_number_txt.Text = string.Empty;
            email_txt.Text = string.Empty;
            AltContactNumber_txt.Text = string.Empty;
            //State_ddl.SelectedIndex = 0;
            //city_ddl.SelectedIndex = 0;
            address_txt.Text = string.Empty;
            LandMark_txt.Text = string.Empty;

            result_lbl.Text = string.Empty;
        }

        public int GetStateIDByName(string name)
        {

            int ID = 0;

            SqlConnection conn = new SqlConnection();



            try
            {
                conn.ConnectionString = SqlCon_str;

                SqlCommand cmd = new SqlCommand(SqlCon_str, conn);
                //cmd.CommandText = SQlStrings.STATE_ID_BY_NAME + "'" + (State_ddl.SelectedValue) + "'";
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
                //cmd.CommandText = SQlStrings.CITY_ID_BY_NAME + "'" + (city_ddl.SelectedValue) + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();

                conn.Open();
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
                conn.Close();
            }





            return ID;
        }

        public int GetDistrictIDByName(string Name)
        {
            int DistID = 0;

            SqlConnection conn = new SqlConnection();


            try
            {
                conn.ConnectionString = SqlCon_str;

                SqlCommand cmd = new SqlCommand(SqlCon_str, conn);
                //cmd.CommandText = SQlStrings.CITY_ID_BY_NAME + "'" + (city_ddl.SelectedValue) + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, conn);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();

                conn.Open();
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        DistID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                    }
                }

                return DistID;
            }
            catch (Exception ex)
            {
                return DistID = 0;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void State_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}