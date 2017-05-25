using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;


namespace Model
{
    public class UserDAO: ModelController<User>
    {

        public long Insert(User entity)
        {
            Base.Instance.User.Add(entity);
            Base.Instance.SaveChanges();
            return entity.ID;
        }

        public bool Login(string userName, string passWord)
        {
            var result = Base.Instance.User.Count(x => x.UserName == userName && x.Password == passWord);
            if(result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
