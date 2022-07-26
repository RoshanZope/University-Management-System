using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace University_Management_System
{
    public class DataLayer
    {
        string constr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;

        public DataTable GetDBData(string sp)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sp, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        con.Open();
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                        con.Close();
                    }
                }
            }
            return dt;
        }

        public void InsertData(Students std)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("InsertStudent", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = std.Name;
                    cmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = std.DOB;
                    cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = std.Gender;
                    cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = std.Address;
                    cmd.Parameters.Add("@DeptId", SqlDbType.Int).Value = std.DeptId;
                    cmd.Parameters.Add("@Department", SqlDbType.VarChar).Value = std.Department;
                    cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = std.Phone;
                    cmd.Parameters.Add("@Semester", SqlDbType.VarChar).Value = std.Semester;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = std.Email;
                    cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = std.Country;
                    cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = std.State;
                    cmd.Parameters.Add("@ZIP", SqlDbType.VarChar).Value = std.ZIP;
                    cmd.Parameters.Add("@GenderText", SqlDbType.VarChar).Value = std.GenderText;
                    cmd.Parameters.Add("@CountryName", SqlDbType.VarChar).Value = std.CountryName;
                    cmd.Parameters.Add("@StateName", SqlDbType.VarChar).Value = std.StateName;
                    cmd.Parameters.Add("@SemesterName", SqlDbType.VarChar).Value = std.SemesterName;
                    
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}