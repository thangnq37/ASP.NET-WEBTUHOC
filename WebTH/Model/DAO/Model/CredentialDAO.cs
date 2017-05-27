using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CredentialDAO:ModelController<Credential>
    {
        public bool LoadID(string idG,string idR)
        {
            var result = Base.Instance.Credential.Where(x => x.RoleID == idR && x.UserGroupID == idR).Count();
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
