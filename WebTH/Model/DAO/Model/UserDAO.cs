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

        public new long Insert(User entity)
        {
            Base.Instance.User.Add(entity);
            Base.Instance.SaveChanges();
            return entity.ID;
        }
        public List<string> GetListCredential(string userName)
        {
            var user = Base.Instance.User.Single(x=>x.UserName == userName);
            var lsCredential = new CredentialDAO().SelectAll() as List<Credential>;
            var lsUserGroup = new UserGroupDAO().SelectAll() as List<UserGroup>;
            var lsRole = new RoleDAO().SelectAll() as List<Role>;
            var data = lsCredential.Join(lsUserGroup, x => x.UserGroupID, y => y.ID, (x, y) => new
            {
                IDUG = x.UserGroupID,
                IDROLE = x.RoleID
            }).Join(lsRole, z => z.IDROLE, w => w.ID, (z, w) => new Credential
            {
                RoleID = z.IDROLE,
                UserGroupID= z.IDUG
            }).Where(u=>u.UserGroupID == user.GroupID);
            return data.Select(x=>x.RoleID).ToList();
        }
        public int Login(string userName, string passWord, bool isLoginAdmin = false)
        {
            User result = Base.Instance.User.SingleOrDefault(x => x.UserName == userName);
            if(result == null)
            {
                return 0;//tai khoan khong ton tai
            }
            else
            {
                if (isLoginAdmin)
                {
                    if((result.GroupID == CommonConstants.ADMIN_GROUP || result.GroupID == CommonConstants.MOD_GROUP))
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
                    else
                    {
                        return -3;
                    }
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
        }

        public User GetByID(string st)
        {
            var user = Base.Instance.User.Where(u => u.UserName == st).FirstOrDefault();
            return user;
        }
    }
}
