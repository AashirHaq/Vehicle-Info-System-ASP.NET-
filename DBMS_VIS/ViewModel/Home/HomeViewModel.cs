using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBMS_VIS.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DBMS_VIS.ViewModel.Home
{
    public class HomeViewModel
    {
        public List<AppData> GetRecordByRegistrationNumber(string s)
        {
            List<AppData> appData = new List<AppData>();
            string connString = ConfigurationManager.ConnectionStrings["ap"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetRecordByRegistrationNumber", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    cmd.Parameters.AddWithValue("@RegistrationNumber", s);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    try
                    {
                        AppData ad = new AppData();
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
                    catch
                    {
                        return appData;
                    }


                }
            }
            return appData;

        }

        public List<AppData> GetRecordByOwnerName(string s)
        {
            List<AppData> appData = new List<AppData>();
            string connString = ConfigurationManager.ConnectionStrings["ap"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetRecordByOwnerName", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    cmd.Parameters.AddWithValue("@OwnerName", s);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        try
                        {
                            AppData ad = new AppData();
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
                        catch
                        {
                            return appData;
                        }
                    }
                }
            }

            return appData;
        }
    }
}