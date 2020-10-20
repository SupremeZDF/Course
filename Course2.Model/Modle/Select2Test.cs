using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Course2.Model.Modle
{
    public class Select2Test
    {
        public static SelectData GetSelectData(int pageIndex, int pageSize)  
        {
            var selectCount = " SELECT COUNT(1) FROM t_CarStyle";
            SelectData selectData = new SelectData();
            //获取页数总数

            DataTable dataTableOne = Data.GetDate(selectCount);
            var Count = (int)dataTableOne.Rows[0][0];

           // var a = Math.Floor((double)Count / pageSize);
            var b = (double)(Count+1) / pageSize;
            var cc = Math.Floor(b);

            int pageCount = 0;
            if (Count % pageSize == 0)
            {
                pageCount = (int)Math.Floor((double)Count / pageSize);
            }
            else 
            {
                pageCount = (int)Math.Floor((double)Count / pageSize) + 1;
            }
            selectData.total_Count = pageCount;

            //获取分页数据
            DataTable selectPageData = Data.GetDate($"SELECT * FROM ( SELECT ROW_NUMBER() OVER(ORDER BY FID) AS RUM,FID,FName  FROM t_CarStyle) AS C WHERE C.RUM BETWEEN  {(pageIndex - 1) * pageSize + 1} AND {pageSize * pageIndex}");
            List<SelectReslut> resluts = new List<SelectReslut>();
            resluts = (from i in selectPageData.AsEnumerable()  select 
                      new SelectReslut() 
                      {
                          id = i.Field<int>("FID"),
                          text=i.Field<string>("FName")
                      }).ToList();
            selectData.results = resluts;
            selectData.pagination = new mores() { more = true };
            return selectData;
        }
    }
}
