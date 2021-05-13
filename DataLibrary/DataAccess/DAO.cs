﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataLibrary.DataAccess
{
    public static class DAO
    {
        public static string GetConnectionString(string connectionName = "CoronaFighterDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }
        public static List<T> LoadData<T>(string sql)
        {

            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            { 
                return cnn.Query<T>(sql).ToList();
            }
        }
        public static List<T> LoadData<T>(string sql, T data)
        {

            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql,data).ToList();
            }

        }
        public static int SaveData<T>(string sql, T data)
        {
            try
            {
                using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
                {
                    return cnn.Execute(sql, data);
                }
            }
            catch (Exception)
            {

                return 0;
            }
            
        }
        public static void DeleteData(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                cnn.Execute(sql);
            }
        }
        public static bool GetData(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                int count = cnn.Query<int>(sql).FirstOrDefault();
                return count > 0 ? true : false;
                //return cnn.QueryFirst<int>(sql);
            }
        }
        public static string GetDataString(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.QueryFirst<string>(sql);
            }
        }
        public static string GetUserName(string sql)
        {
            try
            {
                using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
                {
                    return cnn.QueryFirst<string>(sql);
                }
            }
            catch (Exception)
            {
                return "Nothing";
            }
            
        }
    }
}
