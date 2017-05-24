using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model
{
    public class UserDAO
    {
        EFWebTuHocDbContext db = null;

        public UserDAO()
        {
            db = new EFWebTuHocDbContext();
        }

        public long Insert(User entity)
        {
            db.User.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Login(string userName, string passWord)
        {
            var result = db.User.Count(x => x.UserName == userName && x.Password == passWord);
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
