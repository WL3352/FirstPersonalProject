using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;

namespace PublishDAL
{
    public class InfotypeDal
    {
        public List<infotype> typeselect()
        {
            string strSql = "select * from infotype where state=0";
            SqlDataReader dr = DbHelPer.GetDataReader(strSql);
            List<infotype> infoList = new List<infotype>();
            infotype info=null;
            while (dr.Read())
            {
                info = new infotype();
                info.id = int.Parse(dr["id"].ToString());
                info.typeName = dr["typeName"].ToString();
                info.state = int.Parse(dr["state"].ToString());
                infoList.Add(info);
            }
            dr.Close();
            return infoList;
        }
    }
}
