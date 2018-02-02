using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublishDAL;
using Model;

namespace PublishBLL
{
    public class InfotypeBll
    {
        public List<infotype> typeselect()
        {
            return new InfotypeDal().typeselect();
        }
    }
}
