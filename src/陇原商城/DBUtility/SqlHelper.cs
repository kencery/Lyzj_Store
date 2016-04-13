using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DBUtility
{
    public class SqlHelper
    {
        /// <summary>
        /// 这两句话是声明字符串
        /// </summary>
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["longyuanConnectionString"].ConnectionString;
        public static string StrConnectionString = ConnectionString;
        private SqlConnection conn;
        public SqlHelper()
        {

        }

        private void Open()
        {
            if (conn == null)
            {
                conn = new SqlConnection(StrConnectionString);
            }
            if (conn.State.Equals(ConnectionState.Closed))
            {
                conn.Open();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="cmdtype"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParms"></param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdtype, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)  //验证数据库是否打开状态
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = 100;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = cmdtype;
            if (cmdParms != null)
            {
                foreach (SqlParameter paramter in cmdParms)
                {
                    if (paramter.Value == null)
                    {
                        paramter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(paramter);
                }
            }
        }

        public static int ExecuteNonQuery(CommandType cmdtype, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand comm = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(StrConnectionString))
            {
                PrepareCommand(comm, conn, null, cmdtype, cmdText, commandParameters);
                int num = comm.ExecuteNonQuery();
                comm.Parameters.Clear();
                conn.Close();
                conn.Dispose();
                return num;
            }
        }

        public static DataSet ExecuteDateSet(CommandType cmdtype, string cmdtext, params SqlParameter[] commandParameters)
        {
            SqlCommand comm = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(StrConnectionString))
            {
                PrepareCommand(comm, conn, null, cmdtype, cmdtext, commandParameters);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = comm;
                DataSet ds = new DataSet();
                da.Fill(ds);
                comm.Parameters.Clear();
                conn.Close();
                conn.Dispose();

                return ds;
            }
        }

        private SqlCommand CreateCommand(string p_strProcName, SqlParameter[] p_lstrParam)
        {
            this.Open();
            SqlCommand comm = new SqlCommand(p_strProcName, conn);
            comm.CommandType = CommandType.StoredProcedure;
            if (p_lstrParam != null)
            {
                foreach (SqlParameter param in p_lstrParam)
                {
                    comm.Parameters.Add(param);//Paramhe和p_lstParam各自有什么意义
                }
            }
            return comm;
        }

        public void RunProc(string p_strProcName, SqlParameter[] p_lstparam, out SqlDataReader dr)
        {
            dr = this.CreateCommand(p_strProcName, p_lstparam).ExecuteReader(CommandBehavior.CloseConnection);
        }

    }
}
