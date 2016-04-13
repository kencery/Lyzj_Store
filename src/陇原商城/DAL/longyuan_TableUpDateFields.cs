using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;
using DBUtility;

namespace DAL
{
    public class longyuan_TableUpDateFields
    {
       protected int _recordcount;
       protected int _pagecount;

       public int RecordCount
       {
           get { return _recordcount; }
       }

       public int PageCount
       {
           get { return _pagecount; }
       }

        public longyuan_TableUpDateFields() { }

        public DataSet GetPageList(L_PageList pl)  //获取分页信息
        {
            SqlParameter[] para = new SqlParameter[11];
            para[0] = new SqlParameter("@TableName", pl.TableName);
            para[1] = new SqlParameter("@PKey", pl.PKey);
            para[2] = new SqlParameter("@FieldList", pl.FieldList);
            para[3] = new SqlParameter("@Condition", pl.Conditon);
            para[4] = new SqlParameter("@OrderBy", pl.OrderBy);
            para[5] = new SqlParameter("@Sql", pl.Sql);
            para[6] = new SqlParameter("@SqlGetRC", pl.SqlGetRc);
            para[7] = new SqlParameter("@CurrPage", pl.Currpage);
            para[8] = new SqlParameter("@PageSize", pl.PageSize);
            para[9] = new SqlParameter("@RecordCount", pl.RecordCount);
            para[10] = new SqlParameter("@result", SqlDbType.Int);
            para[10].Direction = ParameterDirection.Output;
            DataSet set = SqlHelper.ExecuteDateSet(CommandType.StoredProcedure, "p_PageList", para);
            _recordcount = int.Parse(set.Tables[1].Rows[0]["RecordCount"].ToString());
            _pagecount = int.Parse(set.Tables[1].Rows[0]["PageCount"].ToString());
            return set;
        }

        public DataSet getDeleteShop(string sqlStr)
        {
            return SqlHelper.ExecuteDateSet(CommandType.Text, sqlStr, null);
        }

        public int Deleteproject(string tablename, string conditions)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@TableName", tablename);
            param[1] = new SqlParameter("@Conditions", conditions);
            param[2] = new SqlParameter("@Result", SqlDbType.Int);
            param[2].Direction = ParameterDirection.Output;

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "p_DeleteProduct", param);
        }

        public int UpdateShoping(string tablename, string upDateFields, string conditions)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@TableName", tablename);
            param[1]=new SqlParameter("@UpDateFields",upDateFields);
            param[2]=new SqlParameter("@Conditions",conditions);
            param[3] = new SqlParameter("@Result", SqlDbType.Int);
            param[3].Direction = ParameterDirection.Output;

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "p_groundingShopPing", param);
        }

        public DataSet GetBindAddr(string sqlStr)
        {
            return SqlHelper.ExecuteDateSet(CommandType.Text, sqlStr, null);
        }
    }
}
