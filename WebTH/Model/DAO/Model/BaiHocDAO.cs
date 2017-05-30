using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Model.EF;

namespace Model
{
    public class BaiHocDAO:ModelController<Model.EF.BaiHoc>
    {
        public IEnumerable<Model.EF.BaiHoc> GetListPage(int page, int pageSize)
        {
            //int nSkip = (page - 1) * pageSize;
            return Base.Instance.BaiHoc.OrderByDescending(x=>x.ID).ToPagedList(page, pageSize);
        }

        public IEnumerable<Model.EF.BaiHoc> GetListPageLession(int page, int pageSize,int id)
        {
            //int nSkip = (page - 1) * pageSize;
            List<LoaiBaiHoc> lsLBH = new LoaiBaiHocDAO().SelectAll();
            List<BaiHoc> lsBH = new BaiHocDAO().SelectAll();

            var list = lsBH.Join(lsLBH, x => x.IDLoaiBaiHoc, y => y.ID, (x, y) => new {lsbh =x,lslbh=y }).Where(a=>a.lslbh.IDCha == id).Select(c=>c.lsbh).ToList();
            return list.OrderByDescending(x => x.ID).ToPagedList(page,pageSize);
        }

        public IEnumerable<Model.EF.BaiHoc> GetListPageLessionType(int page, int pageSize,int id)
        {
            //int nSkip = (page - 1) * pageSize;
            List<LoaiBaiHoc> lsLBH = new LoaiBaiHocDAO().SelectAll();
            List<BaiHoc> lsBH = new BaiHocDAO().SelectAll();
            var list = lsBH.Where(x => x.IDLoaiBaiHoc == id).ToList();
            return list.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
    }
}
