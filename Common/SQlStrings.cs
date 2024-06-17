using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KredasInfra_v2_28May2024.Common
{
    public class SQlStrings
    {
        public const String STATE_LIST_SELECT_QUERY = "select * from Kredasindia.States";
        public const String DISTRICTS_LIST_SELECT_QUERY = "select * from Kredasindia.Districts";
        public const String AREAS_LIST_SELECT_QUERY = "select * from kredasInfra.Area_latest";
        public const String AREAS_LIST_BY_DISTRICT_SELECT_QUERY = "select * from kredasInfra.Area_latest where DistrictID={0}";
        public const String CITIES_LIST_SELECT_QUERY = "select * from Cities WHERE stateid={0}";
        public const String BA_LIST_SELECT_QUERY = "select FirstName,* from Kredasindia.BussinessAssociatesDetails";
        public const String GET_PAYMENT_IMAGE = "select PaymentInfo,ContentType from Kredasindia.FranchiseDetails where ID=2";

        public const String SELECT_BADETAILS_COUNT = "select * from Kredasindia.BussinessAssociatesDetails order by ID desc";

        public const String CITY_LIST_SELECT_QUERY = "select * from Cities C where C.StateID={0}";

        public const String DISTRICT_LIST_SELECT_QUERY = "select * from Kredasindia.Districts D where D.StateID={0}";

        public const String FETCH_BUSUNESSREPRESENTATIVE_DETAILS_QUERY = "select * from BussinessAssociatesDetails where UserName=";

        public const String FETCH_FRANCHISE_DETAILS_QUERY = "select * from Kredasindia.FranchiseDetails where UserName=";

        public const String FETCH_COORDINATOR_DETAILS_QUERY = "select * from CoordinatorDetails where UserName=";

        //public const String FRANCHISE_INSERT_QUERY = "INSERT INTO Kredasindia.FranchiseDetails(UserName,Password,Name,MobileNumber,Email,AlternateContactNumber,StateID,DistrictID,CityID,Address,Landmark,PaymentInfo,ContentType,IsActive,RegDate,FranchiseType)values (@UserName,@Password,@Name,@MobileNumber,@Email,@AlternateContactNumber,@StateID,@DistrictID,@CityID,@Address,@Landmark,@PaymentInfo,@ContentType,@IsActive,@RegDate,@FranchiseType)";

        //public const String FRANCHISE_INSERT_QUERY = "INSERT INTO Kredasindia.FranchiseDetails(UserName,Password,Name,MobileNumber,Email,AlternateContactNumber,StateID,DistrictID,CityID,Address,Landmark,PaymentInfo,ContentType,IsActive,RegDate,FranchiseType)values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','[12}','{13}','{14}','{15}')";

        public const String FRANCHISE_INSERT_QUERY = "INSERT INTO Kredasindia.FranchiseDetails(UserName,Password,Name,MobileNumber,Email,AlternateContactNumber,StateID,DistrictID,CityID,Address,Landmark,PaymentInfo,ContentType,IsActive,RegDate,FranchiseType)values (@UserName,@Password,@Name,@MobileNumber,@Email,@AlternateContactNumber,@StateID,@DistrictID,@CityID,@Address,@Landmark,@PaymentInfo,@ContentType,@IsActive,@RegDate,@FranchiseType)";

        public const String COORDINATOR_INSERT_QUERY = "INSERT INTO kredasindia.CoordinatorDetails(UserName, Name,FirstName, MiddleName,LastName,MobileNumber,Email,ContactNumber,StateID,DistrictID,CityID,AreaCode,Address,LandMark,RegDate) VALUES(@UserName, @Name,@FirstName, @MiddleName,@LastName,@MobileNumber,@Email,@ContactNumber,@StateID,@DistrictID,@CityID,@AreaCode,@Address,@LandMark,@RegDate)";

        public const string BA_INSERT_QUERY = "INSERT INTO Kredasindia.BussinessAssociatesDetails(BACode,UserName,Password,FirstName,MiddleName,LastName,MobileNumber,ContactNumber,Email,Address,StateID,CityID,LandMark,ReferedByCode,AadharNumber,PANNumber)values (@BACode,@UserName,@Password, @FirstName, @MiddleName, @LastName, @MobileNumber, @ContactNumber, @Email, @Address, @StateID, @CityID,@LandMark,@ReferedByCode,@AadharNumber,@PANNumber)";


        public const String BUSINESS_ASSOCIATES_INSERT_QUERY = "insert into BussinessAssociatesDetails(UserName,Password, FirstName, MiddleName, LastName, MobileNumber, ContactNumber, Email, Address, StateID, CityID, Landmark, FranchiseType) Values (@UserName, @Password, @FirstName, @MiddleName, @LastName, @MobileNumber, @ContactNumber, @Email, @Address, @StateID, @CityID, @landmark,@FranchiseType)";

        public const String STATE_ID_BY_NAME = "select ID from Kredasindia.States where Name=";

        public const String AREA_ID_BY_NAME = "select ID from Kredasindia.Areas where AreaName=";

        public const String GET_AREA_DETAILS_BYNAME = "select * from kredasindia.Areas where AreaName=";

        public const String AREA_INSERT_QUERY = "insert into kredasindia.Areas(AreaName,CityID,DistrictID,StateID) values (@AreaName,@CityID,@DistrictID,@StateID)";

        public const String CITY_INSERT_QUERY = "insert into Cities(CityName,StateID) values (@CityName,@StateID)";

        public const String CITY_ID_BY_NAME = "select ID from kredasindia.Cities where CityName=";

        public const String DISTRICT_ID_BY_NAME = "select ID from kredasindia.Districts where Name=";

        public const String GET_BA_DETAILS = "select * from Kredasindia.BussinessAssociatesDetails order by ID desc";

        public const String GET_CURRENT_MAX_BAID = "SELECT ISNULL(MAX(ID), 0) AS MaxID FROM BussinessAssociatesDetails";
    }
}