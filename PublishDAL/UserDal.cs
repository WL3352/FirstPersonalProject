using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model;

namespace PublishDAL
{
    public class UserDal
    {
        public static relUser getUser(string name)
        {
            string strSql = "select * from relUser where state=0 and userName=@name";
            SqlParameter[] pr ={
                                new SqlParameter("@name",name)
                            };
            SqlDataReader dr = DbHelPer.GetDataReader(strSql,pr);
            //List<relUser> listUser = new List<relUser>();
            relUser user = null;
            while (dr.Read())
            {
                user = new relUser();
                user.id = int.Parse(dr["id"].ToString());
                user.userName = dr["userName"].ToString();
                user.userPwd = dr["userPwd"].ToString();
                user.Email = dr["Email"].ToString();
                user.relName = dr["relName"].ToString();
                user.Name = dr["Name"].ToString();
                user.userCity = dr["userCity"].ToString();
                user.QQnumber = dr["QQnumber"].ToString();
                user.MobilePhone = dr["MobilePhone"].ToString();
                user.userTime = DateTime.Parse(dr["userTime"].ToString());
                user.state =int.Parse(dr["state"].ToString());
                //listUser.Add(user);
            }
            dr.Close();
            return user;
        }
        public static int insertUser(relUser user)
        {
            string strSql = "insert into relUser(userName,userPwd,Email,relName) values(@userName,@userPwd,@Email,@relName)";
            SqlParameter[] pr ={
                                  new SqlParameter("@userName",user.userName),
                                  new SqlParameter("@userPwd",user.userPwd),
                                  new SqlParameter("@Email",user.Email),
                                  new SqlParameter("@relName",user.userName),
                              };
            return DbHelPer.GetExecuteNonQuery(strSql,pr);
        }
    }
}
