using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Course2.Model.IDBHELP
{
    public class DBSqlserver : IDbhelp
    {

        private static SqlConnection SqlConnection;
        static DBSqlserver() 
        {
            SqlConnection = new SqlConnection();
        }

        public bool sqlDelete<T>(T t) where T : BaseModel.BaseModel
        {
            throw new NotImplementedException();
        }

        public bool sqlInsert<T>(T t) where T : BaseModel.BaseModel
        {
            throw new NotImplementedException();
        }

        public List<T> SqlSelect<T>(T t) where T : BaseModel.BaseModel
        {
            throw new NotImplementedException();
        }

        public bool sqlUpdate<T>(T t) where T : BaseModel.BaseModel
        {
            throw new NotImplementedException();
        }
    }
}
