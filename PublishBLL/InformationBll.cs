using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublishDAL;
using Model;

namespace PublishBLL
{
    public class InformationBll
    {
        public List<_Information> infoSelect(int id=0,int page=0)
        {
            int max =0;
            int min=0;
            if (page!= 0)
            {
                max= page * 10;
                min= max - 9;
            }
            return new InformationDal().infoSelect(id,max,min);
        }
    }
}
