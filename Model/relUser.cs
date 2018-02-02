using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //用户信息实体
    public class relUser
    {
        public  int id { get; set; }
        public  string userName { get; set; }//登录名
        public  string userPwd { get; set; }//密码
        public  string Email { get; set; }//邮箱
        public  string relName { get; set; }//昵称
        public  string Name { get; set; }//真实姓名
        public  string userCity { get; set; }
        public  string QQnumber { get; set; }
        public  string MobilePhone { get; set; }
        public  DateTime userTime { get; set; }
        public  int state { get; set; }
    }
}
