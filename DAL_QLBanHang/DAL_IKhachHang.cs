using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBanHang
{
    public interface DAL_IKhachHang
    {
        List<Khach> GetAll();
        Khach Get(string dienThoai);
        int Insert(Khach khach);
        int Update(Khach khach);
        int Delete(Khach khach);
        List<Khach> Search(string key);
    }
}
