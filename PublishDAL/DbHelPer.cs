using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PublishDAL
{
    public class DbHelPer
    {
        /// <summary>
        /// 创建并初始化连接字符串和连接对象
        /// </summary>
        static string conSql = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
        static SqlConnection conn = new SqlConnection(conSql);
        /// <summary>
        /// 创建打开的方法
        /// </summary>
        public static void Open()
        {
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
        }
        /// <summary>
        /// 创建关闭的方法
        /// </summary>
        public static void Close()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
                conn.Close();
        }
        /// <summary>
        /// 数据阅读器,根据SQL语句完成数据查询
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static SqlDataReader GetDataReader(string strSql, params SqlParameter[] p)
        {
            SqlDataReader dr;
            try
            {
                Open();
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddRange(p);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                throw;
            }
            return dr;
        }
        /// <summary>
        ///  根据SQL语句,对于数据表的增，删，改操作返回影响的行数;
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int GetExecuteNonQuery(string strSql, params SqlParameter[] p)
        {
            int count;
            try
            {
                Open();
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddRange(p);
                count = cmd.ExecuteNonQuery();
            }
            catch
            {
                return -1;
            }
            return count;
        }
        /// <summary>
        /// 对于数据表查询返回首行首列值
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool ExecuteScalar(string strSql, params SqlParameter[] p)
        {
            bool b = false;
            try
            {
                Open();
                SqlCommand mad = new SqlCommand(strSql, conn);
                mad.Parameters.AddRange(p);
                //mad.CommandType = CommandType.StoredProcedure;//设置为调用存储过程
                b = ((int)mad.ExecuteScalar()) > 0;
            }
            catch (Exception)
            {
            }
            return b;
        }
        public static object ex(string strSql, params SqlParameter[] p)
        {
            object de = null;
            try
            {
                Open();
                SqlCommand mad = new SqlCommand(strSql, conn);
                mad.Parameters.AddRange(p);
                //mad.CommandType = CommandType.StoredProcedure;//设置为调用存储过程
                de = mad.ExecuteScalar();
            }
            catch (Exception)
            {
            }
            return de;
        }
        public static int Transaction(string strSql = null, List<string> Sql = null)
        {
            SqlTransaction tr = conn.BeginTransaction();
            try
            {
                SqlCommand mad = new SqlCommand(strSql, conn);
                mad.Transaction = tr;
                mad.ExecuteNonQuery();
                SqlCommand md = null;
                foreach (var item in Sql)
                {
                    md = new SqlCommand(item, conn);
                    md.Transaction = tr;
                    md.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            tr.Commit();
            Close();
            return 1;
        }
    }
}
