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

        public int Login(string userName, string passWord)
        {
            User result = Base.Instance.User.SingleOrDefault(x => x.UserName == userName);
            if(result == null)
            {
                return 0;//tai khoan khong ton tai
            }
            else
            {
                if (result.AnHien == false)
                {
                    return -1; //tai khoan bi khoa
                }
                else
                {
                    if (result.Password == passWord)
                        return 1;
                    else
                        return -2;// mat khau khong dung
                }
            }
        }

        public User GetByID(string st)
        {
            var user = Base.Instance.User.Where(u => u.UserName == st).FirstOrDefault();
            return user;
        }
    }
}
