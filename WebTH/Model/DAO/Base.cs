using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model
{
    public abstract class Base
    {
        private static volatile EFWebTuHocDbContext _instance;
        private static object syncRoot = new Object();
        private Base(){}
        public static EFWebTuHocDbContext Instance
        {
            get{
                if(_instance == null)
                {
                    lock (syncRoot)
                    {
                        if(_instance == null)
                        {
                            _instance = new EFWebTuHocDbContext();
                        }
                    }
                }
                return _instance;

            }
        }
    }
}
