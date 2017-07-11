using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBMS_VIS.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace DBMS_VIS.ViewModel.VehicleData
{
    public class VehicleDataViewModel
    {
        public List<AppData> GetAllData()
        {
            List<AppData> appData = new List<AppData>();
            string connString = ConfigurationManager.ConnectionStrings["ap"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("VehicleInfo_VehicleTypeJoinWithVehicleOwnerAndVehicleInformation", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        AppData ad = new AppData();
                        ad.InfoID = Convert.ToInt32(reader["InfoID"]);
                        ad.OwnerID = Convert.ToInt32(reader["OwnerID"]);
                        ad.OwnerName = reader["OwnerName"].ToString();
                        ad.Gender = reader["Gender"].ToString();
                        ad.RegistrationNumber = reader["RegistrationNumber"].ToString();
                        ad.VType = reader["VType"].ToString();
                        ad.RegistrationDate = reader["RegistrationDate"].ToString();
                        ad.Model = Convert.ToInt32(reader["Model"]);
                        ad.ManufacturedBy = reader["ManufacturedBy"].ToString();
                        ad.Color = reader["Color"].ToString();
                        ad.ChassisNumber = reader["ChassisNumber"].ToString();
                        ad.EngineNumber = reader["EngineNumber"].ToString();
                        ad.VehicleName = reader["VehicleName"].ToString();

                        appData.Add(ad);
                    }
                }
            }

                return appData;
        }

        public void DeleteVehicleDetails(int id)
        {
            string connString = ConfigurationManager.ConnectionStrings["ap"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using(SqlCommand cmd = new SqlCommand("usp_DeleteVehicleRecord", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    cmd.Parameters.AddWithValue("@InfoID", id);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void UpdateVehicleDetails(AppData appdata)
        {
            string connString = ConfigurationManager.ConnectionStrings["ap"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_UpdateVehicleRecord", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();

                    cmd.Parameters.AddWithValue("@OwnerID", appdata.OwnerID);
                    cmd.Parameters.AddWithValue("@InfoID", appdata.InfoID);
                    cmd.Parameters.AddWithValue("@OwnerName", appdata.OwnerName);
                    cmd.Parameters.AddWithValue("@Gender", appdata.Gender);
                    cmd.Parameters.AddWithValue("@VType", appdata.VType);
                    cmd.Parameters.AddWithValue("@Color", appdata.Color);
                    cmd.Parameters.AddWithValue("@RegistrationNumber", appdata.RegistrationNumber);
                    cmd.Parameters.AddWithValue("@ChassisNumber", appdata.ChassisNumber);
                    cmd.Parameters.AddWithValue("@EngineNumber", appdata.EngineNumber);
                    cmd.Parameters.AddWithValue("@RegistrationDate", appdata.RegistrationDate);
                    cmd.Parameters.AddWithValue("@Model", appdata.Model);
                    cmd.Parameters.AddWithValue("@ManufacturedBy", appdata.ManufacturedBy);
                    cmd.Parameters.AddWithValue("@VehicleName", appdata.VehicleName);

                    cmd.ExecuteNonQuery();

                }

            }
        }

        public AppData UpdateVehicleDetailById(int id)
        {

            AppData ad = new AppData();

            string connString = ConfigurationManager.ConnectionStrings["ap"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("VehicleOwner_GetCurrentVehicleDataByInfoId", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    conn.Open();

                    cmd.Parameters.AddWithValue("@InfoID", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    ad.InfoID = Convert.ToInt32(reader["InfoID"]);
                    ad.OwnerID = Convert.ToInt32(reader["OwnerID"]);
                    ad.OwnerName = reader["OwnerName"].ToString();
                    ad.Gender = reader["Gender"].ToString();
                    ad.RegistrationNumber = reader["RegistrationNumber"].ToString();
                    ad.VType = reader["VType"].ToString();
                    ad.RegistrationDate = reader["RegistrationDate"].ToString();
                    ad.Model = Convert.ToInt32(reader["Model"]);
                    ad.ManufacturedBy = reader["ManufacturedBy"].ToString();
                    ad.Color = reader["Color"].ToString();
                    ad.ChassisNumber = reader["ChassisNumber"].ToString();
                    ad.EngineNumber = reader["EngineNumber"].ToString();
                    ad.VehicleName = reader["VehicleName"].ToString();
                }
            }

            return ad;
        }

        public AppData GetVehicleDetailById(int id)
        {
            AppData ad = new AppData();

            string connString = ConfigurationManager.ConnectionStrings["ap"].ConnectionString;
            using(SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("VehicleOwner_GetCurrentVehicleDataByInfoId", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    conn.Open();

                    cmd.Parameters.AddWithValue("@InfoID", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    ad.InfoID = Convert.ToInt32(reader["InfoID"]);
                    ad.OwnerID = Convert.ToInt32(reader["OwnerID"]);
                    ad.OwnerName = reader["OwnerName"].ToString();
                    ad.Gender = reader["Gender"].ToString();
                    ad.RegistrationNumber = reader["RegistrationNumber"].ToString();
                    ad.VType = reader["VType"].ToString();
                    ad.RegistrationDate = reader["RegistrationDate"].ToString();
                    ad.Model = Convert.ToInt32(reader["Model"]);
                    ad.ManufacturedBy = reader["ManufacturedBy"].ToString();
                    ad.Color = reader["Color"].ToString();
                    ad.ChassisNumber = reader["ChassisNumber"].ToString();
                    ad.EngineNumber = reader["EngineNumber"].ToString();
                    ad.VehicleName = reader["VehicleName"].ToString();


                }
            }

            return ad;
        }

        public void AddNewRecord(AppData appdata)
        {
            string connString = ConfigurationManager.ConnectionStrings["ap"].ConnectionString;
            using (SqlConnection conn =  new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_AddNewVehicleRecord", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();

                    cmd.Parameters.AddWithValue("@OwnerID", appdata.OwnerID);
                    cmd.Parameters.AddWithValue("@InfoID", appdata.InfoID);
                    cmd.Parameters.AddWithValue("@OwnerName", appdata.OwnerName);
                    cmd.Parameters.AddWithValue("@Gender", appdata.Gender);
                    cmd.Parameters.AddWithValue("@VType", appdata.VType);
                    cmd.Parameters.AddWithValue("@Color", appdata.Color);
                    cmd.Parameters.AddWithValue("@RegistrationNumber", appdata.RegistrationNumber);
                    cmd.Parameters.AddWithValue("@ChassisNumber", appdata.ChassisNumber);
                    cmd.Parameters.AddWithValue("@EngineNumber", appdata.EngineNumber);
                    cmd.Parameters.AddWithValue("@RegistrationDate", appdata.RegistrationDate);
                    cmd.Parameters.AddWithValue("@Model", appdata.Model);
                    cmd.Parameters.AddWithValue("@ManufacturedBy", appdata.ManufacturedBy);
                    cmd.Parameters.AddWithValue("@VehicleName", appdata.VehicleName);
                      
                    cmd.ExecuteNonQuery();
                }
            }

        }
    }
}