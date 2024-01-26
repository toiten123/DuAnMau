using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBanHang
{
    public interface DAL_IHang
    {
        List<Hang> GetAll();
        Hang Get(int maHang);
        Hang Insert(Hang hang);
        int Update(Hang hang);
        int Delete(Hang hang);
        List<Hang> Search(string key);
    }
}
