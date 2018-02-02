using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;

namespace PublishDAL
{
    public class InformationDal
    {
        public List<_Information> infoSelect(int id=0,int max=0,int min=0)
        {
            string strSql = "select * from (select *,ROW_NUMBER() over(Order by id desc) InfoID from _information where [state]=0) as d where d.InfoID between " + min + " and " + max;
            SqlParameter[] ps = null;
            SqlDataReader dr = null;
            if (id != 0)
            {
                strSql = "select * from (select *,ROW_NUMBER() over(Order by id desc) InfoID from _information where [state]=0 and typeid=@id) as d where d.InfoID between @min and @max";
                ps = new SqlParameter[]{
                    new SqlParameter("@id",id),
                    new SqlParameter("@min",min),
                    new SqlParameter("@max",max)
                };
                dr = DbHelPer.GetDataReader(strSql, ps);
            }
            else
            {
                dr = DbHelPer.GetDataReader(strSql);
            }
            List<_Information> infolist = new List<_Information>();
            _Information info = null;
            while (dr.Read())
            {
                info = new _Information();
                info.id = int.Parse(dr["id"].ToString());
                info.userid = int.Parse(dr["userid"].ToString());
                info.releaseImg = dr["releaseImg"].ToString();
                info.releaseVio = dr["releaseVio"].ToString();
                info.something = dr["something"].ToString();
                info.typeid = int.Parse(dr["typeid"].ToString());
                info.releaseTime = DateTime.Parse(dr["releaseTime"].ToString());
                info.watch = int.Parse(dr["watch"].ToString());
                info.thumbsup = int.Parse(dr["thumbsup"].ToString());
                info.comment = int.Parse(dr["comment"].ToString());
                info.report = int.Parse(dr["report"].ToString());
                info.state = int.Parse(dr["state"].ToString());
                info.relName = dr["relName"].ToString();
                info.typeName = dr["typeName"].ToString();
                infolist.Add(info);
            }
            dr.Close();

            return infolist;
        }
    }
}
