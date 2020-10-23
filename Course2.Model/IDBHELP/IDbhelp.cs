using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Course2.Model.BaseModel;

namespace Course2.Model.IDBHELP
{
    public  interface IDbhelp
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlConnection"></param>
        /// <param name=""></param>
        /// <returns></returns>
        List<T> SqlSelect<T>( T t) where T : BaseModel.BaseModel;

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlConnection"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        bool sqlDelete<T>(T t) where T : BaseModel.BaseModel;

        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlConnection"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        bool sqlInsert<T>(T t) where T : BaseModel.BaseModel;

        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlConnection"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        bool sqlUpdate<T>(T t) where T : BaseModel.BaseModel;
    }
}
