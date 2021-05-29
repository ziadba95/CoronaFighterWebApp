using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DataAccess
{
    public interface DAOS
    {
         List<T> LoadData<T>(string sql);

         List<T> LoadData<T>(string sql, T data);

         int SaveData<T>(string sql, T data);

         void DeleteData(string sql);

         bool GetData(string sql);

         string GetDataString(string sql);

         string GetUserName(string sql);
       
    }
}
