using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using PublishDAL;

namespace PublishBLL
{
    public class UserBll
    {
        public static relUser getUser(string name)
        {
            return UserDal.getUser(name);
        }
        public static int insertUser(relUser user)
        {
            return UserDal.insertUser(user);
        }
    }
}
